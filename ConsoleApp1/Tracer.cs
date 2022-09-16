using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ConsoleApp1
{
    public class Tracer: ITracer
    {
        public void StartTrace() {
        }
        public void StopTrace() { }

        public TraceResult GetTraceResult() {
            stopwatch.ElapsedMilliseconds;
            TraceResult result = new TraceResult();
            return result;
        }


    }
}
