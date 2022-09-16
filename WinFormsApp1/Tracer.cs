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

public interface ITracer
{
    // Вызвается в начале замеряемого метода 
    void StartTrace();

    // Вызывается в конце замеряемого метода 
    void StopTrace();

    TraceResult GetTraceResult();
}


namespace WinFormsApp1
{

    public class Tracer : ITracer
    {
        Stopwatch stopwatch = new Stopwatch();
        public void StartTrace() {
            stopwatch.Start();
        }
        public void StopTrace() {
            stopwatch.Stop();
        }

        public TraceResult GetTraceResult()
        {
            TraceResult result = new TraceResult();
            result.MethodTime = Convert.ToInt32(stopwatch.ElapsedTicks);
            return result;
        }



    }
}
