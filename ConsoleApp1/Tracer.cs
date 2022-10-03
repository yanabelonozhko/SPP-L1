using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace lab1
{
    public class TraceResult
    {
        public ThreadResult[] Threads { get; set; }
    }

    public class ThreadResult
    {
        private readonly Stopwatch stopwatch;

        public int Id { get; set; }

        public int Time { get; set; }

        public List<MethodResult> Methods { get; } = new List<MethodResult>();

        public Stack<MethodResult> MethodsCallsStack { get; } = new Stack<MethodResult>();

        public ThreadResult()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void StopTrace()
        {
            stopwatch.Stop();
            Time = (int)stopwatch.ElapsedMilliseconds;
        }
    }

    public class MethodResult
    {
        private readonly Stopwatch stopwatch;

        public string Name { get; set; }

        public string Class { get; set; }

        public int Time { get; set; }

        public List<MethodResult> Methods { get; set; } = new List<MethodResult>();

        public MethodResult()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void StopTrace()
        {
            stopwatch.Stop();
            Time = (int)stopwatch.ElapsedMilliseconds;
        }
    }
    // Интерфейс, который будет реализовывать класс
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        TraceResult GetTraceResult();
    }

    public class Tracer : ITracer
    {
        public ConcurrentDictionary<int, ThreadResult> AllMyThreads = new ConcurrentDictionary<int, ThreadResult>();

        public void StartTrace()
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            var methodResult = new MethodResult
            {
                Name = method.Name,
                Class = method.DeclaringType.Name,
            };

            var currentThread = Thread.CurrentThread;
            if (AllMyThreads.TryGetValue(currentThread.ManagedThreadId, out var existingThreadResult))
            {
                existingThreadResult.Methods.Add(methodResult);
                existingThreadResult.MethodsCallsStack.Push(methodResult);
                return;
            }

            var threadResult = new ThreadResult
            {
                Id = currentThread.ManagedThreadId,
            };

            threadResult.Methods.Add(methodResult);
            threadResult.MethodsCallsStack.Push(methodResult);
            AllMyThreads.TryAdd(threadResult.Id, threadResult);
        }

        public void StopTrace()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            var currentThreadResult = AllMyThreads[currentThreadId];
            var currentMethod = currentThreadResult.MethodsCallsStack.Pop();
            currentMethod.StopTrace();

            if (currentThreadResult.MethodsCallsStack.Count != 0)
            {
                var prevResult = currentThreadResult.MethodsCallsStack.Peek();
                prevResult.Methods.Add(currentMethod);
            }
        }

        public TraceResult GetTraceResult()
        {
            var threadResults = new List<ThreadResult>();
            foreach (var result in threadResults)
            {
                result.StopTrace();
                threadResults.Add(result);
            }

            return new TraceResult { Threads = threadResults.ToArray() };
        }
    }
}
