using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace lab1
{
    [Serializable]
    public class TraceResult
    {
        public ThreadResult[] Threads { get; set; }
    }

    [Serializable]
    public class ThreadResult
    {
       
        private readonly Stopwatch stopwatch;

        public int Id { get; set; }

        public int Time { get; set; }

        public List<MethodResult> Methods { get; } = new List<MethodResult>();


        // Стек для контроля включённых методов
       
        [XmlIgnore][Newtonsoft.Json.JsonIgnore]
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

    [Serializable]

    public class MethodResult
    {
        public MethodResult()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private readonly Stopwatch stopwatch;

        public string Name { get; set; }

        public string Class { get; set; }

        public int Time { get; set; }

        // Если в методе есть ещё какие-либо методы, то есть выполняющиеся в методе, 
        // то нужно хранить эту информацию. 
        // для этого я использую лист при чём этого же класса результатов работы метода
        public List<MethodResult> MethodsInclude { get; set; } = new List<MethodResult>();

        // Этот метод будет вызываться из глобального метода StopTrace. Это нужно затем, чтобы если 
        // в методе есть ещё методы, они постепенно обрабатывались, доставаясь из стека
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
        // Данный словарь нужен для отслеживания, существует ли уже такой поток в учёте 
        // или его только нужно добавить
        public ConcurrentDictionary<int, ThreadResult> AllThreads = new ConcurrentDictionary<int, ThreadResult>();

        public void StartTrace()
        {
            // Нужно получить информацию о выполняемом методе. 
            StackTrace stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();

            // Класс, хранящий в себе информацию о методе
            MethodResult methodResult = new MethodResult
            {
                Name = method.Name,
                Class = method.DeclaringType.Name,
            };

            // Больше мы получить никакой информации о текущем методе не можем, 
            // Так как включённые методы сами будут выполняться через StartTrace 
            // Проверка, является ли текущий метод включённым можно осуществить через стек 
            // И существует ли уже метод в этом потоке. 
            var currentThread = Thread.CurrentThread;

            // Пробуем получить значение из словаря всех существующих тредов 
            // Если такой метод существует, то 
            if (AllThreads.TryGetValue(currentThread.ManagedThreadId, out var existingThreadResult))
            {
                existingThreadResult.MethodsCallsStack.Push(methodResult);
                return;
            }

            // Если же этот поток ещё не был добавлен в словарь, то во-первых надо его добавить
            var threadResult = new ThreadResult
            {
                Id = currentThread.ManagedThreadId,
            };

            // ИНИЦИАЛИЗАЦИЯ THREAD --------------------------------
            // В массив методов в структуре потока добавляем текущий метод
            // threadResult.Methods.Add(methodResult);

            // Теперь надо запушить текущий метод, чтобы после проконтролировать, какой из 
            // них будет включённым
            threadResult.MethodsCallsStack.Push(methodResult);
            // -----------------------------------------------------

            // Теперь добавляем в словарь
            AllThreads.TryAdd(threadResult.Id, threadResult);
        }

        public void StopTrace()
        {
            // получаем поток и по его айди находим его структуру в словаре
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;
            var currentThreadResult = AllThreads[currentThreadId];

            // Достаём метод из стека, который содержит объект класса потока
            // И вызываем для него метод StopTrace чтобы получить в структуру 
            // время выполнения метода
            var currentMethod = currentThreadResult.MethodsCallsStack.Pop();
            currentMethod.StopTrace();

            // теперь рассматриваем стек текущего потока. Если он не пустой, то 
            // мы значит, что у метода были какие-то включённые методы. 
            if (currentThreadResult.MethodsCallsStack.Count != 0)
            {
                // Добавляем в струтуру текущего метода метод, который в него входит
                var prevResult = currentThreadResult.MethodsCallsStack.Peek();
                prevResult.MethodsInclude.Add(currentMethod);
            }
            if(currentThreadResult.MethodsCallsStack.Count == 0)
            {
                currentThreadResult.Methods.Add(currentMethod);
            }
        }

        //  AllThreads - взять все ThreadResults отткуда
        public TraceResult GetTraceResult()
        {
            List<ThreadResult> SomeThreadResulst = new List<ThreadResult>();
            foreach (var result in AllThreads)
            {
                ThreadResult someThread = result.Value;
                someThread.StopTrace();
                SomeThreadResulst.Add(someThread);
            }

            var awdawdawd = new TraceResult {
                Threads = SomeThreadResulst.ToArray()
            };

            return awdawdawd;
        }
    }
}
