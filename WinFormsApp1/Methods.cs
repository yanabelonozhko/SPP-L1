using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class Methods
    {
        static int j;
        static int TestVar1 = 10;
        static int TestVar2 = 1000;
        static int TestVar3 = 1000000;
        public static List<TraceResult> ListOfResults = new List<TraceResult>();
        

        public static void Method1()
        {
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            j = 0;
            for (int i = 0; i < TestVar1; i++)
            {
                j++;
            }
            tracer.StopTrace();
            TraceResult result = new TraceResult();
            result = tracer.GetTraceResult();
            ListOfResults.Add(result);
        }
        public static void Method2()
        {
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            j = 0;
            for (int i = 0; i < TestVar2; i++)
            {
                j++;
            }
            tracer.StopTrace();
            TraceResult result = new TraceResult();
            result = tracer.GetTraceResult();
            ListOfResults.Add(result);
        }
        public static void Method3()
        {
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            j = 0;
            for (int i = 0; i < TestVar3; i++)
            {
                j++;
            }
            tracer.StopTrace();
            TraceResult result = new TraceResult();
            result = tracer.GetTraceResult();
            ListOfResults.Add(result);
        }
    }
}
