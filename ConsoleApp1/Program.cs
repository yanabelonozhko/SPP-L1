using System.Text.Json;

namespace lab1 {
    class Program
    {
        static void Main()
        {
            long MainTime = 0;

            Tracer myTracer = new Tracer();
            Foo foo = new Foo(myTracer);
            Bar bar = new Bar(myTracer);

            //Подписались на события
            // myMethods.TracingStart += myTracer.StartTrace;
            // myMethods.TracingStoped += myTracer.StopTrace;
            Thread thread1 = new Thread(TestFoo);
           // Thread thread2 = new Thread(bar.InnerMethod);
            thread1.Start();
            //thread2.Start();
            thread1.Join();
//            thread2.Join();
  
            var myTraceResult = new TraceResult();
            myTraceResult =  myTracer.GetTraceResult();

            SerializationJson sj = new SerializationJson(myTraceResult);

            using (FileStream fileStream = new FileStream("result-json.json", FileMode.OpenOrCreate))
            {
                sj.ShowResult(fileStream);
            }

            var consoleStream = Console.OpenStandardOutput();
           // sj.ShowResult(consoleStream);

            SerializationXML sx = new SerializationXML(myTraceResult);
            using (FileStream fileStream = new FileStream("result-xml.xml", FileMode.OpenOrCreate))
            {
                sx.ShowResult(fileStream);
            }
            // sx.ShowResult(consoleStream);

            void TestFoo()
            {
                foo.MyMethod();
                foo.MyMethod();
                bar.InnerMethod();
            }
        }
    }
}