using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public class TraceResult
{
    public string MethodName;
    public string ClassName;
    public int MethodTime;
}

// Интерфейс, который будет реализовывать класс
public interface ITracer
{
    void StartTrace();
    void StopTrace();
    TraceResult GetTraceResult();
}

namespace lab1
{
    public class Tracer : ITracer
    {
        public List<TraceResult> ListOfResults = new List<TraceResult>();
        Stopwatch stopwatch = new Stopwatch();
        string MethodName;
        string ClassName;
        public void StartTrace()
        {
            MethodName = new StackTrace(1).GetFrame(0).GetMethod().Name;
            ClassName = new StackTrace(1).GetFrame(0).GetMethod().DeclaringType.Name;
            stopwatch.Restart();
            stopwatch.Start();
        }
        public void StopTrace()
        {
            stopwatch.Stop();
            ListOfResults.Add(GetTraceResult());
        }
        public TraceResult GetTraceResult()
        {
            TraceResult result = new TraceResult();
            // Тут ещё имя метода и имя класса но это потом
            result.MethodTime = Convert.ToInt32(stopwatch.ElapsedTicks);
            result.MethodName = MethodName;
            result.ClassName = ClassName;
            return result;
        }
    }
}
