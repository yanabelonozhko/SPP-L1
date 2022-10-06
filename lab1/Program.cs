using System.Text.Json;

namespace lab1 {
    class Program
    {
        static void Main()
        {
            Tracer myTracer = new Tracer();
            Foo foo = new Foo(myTracer);
            Bar bar = new Bar(myTracer);

            Thread thread1 = new Thread(TestFoo);
            Thread thread2 = new Thread(bar.InnerMethod);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
  
            var myTraceResult = new TraceResult();
            myTraceResult =  myTracer.GetTraceResult();

            SerializationJson sj = new SerializationJson(myTraceResult);
            SerializationXML sx = new SerializationXML(myTraceResult);

            using (FileStream fileStream = new FileStream("result-json.json", FileMode.OpenOrCreate))
            {
                sj.ShowResult(fileStream);
            }

            var consoleStream = Console.OpenStandardOutput();
            
            
            sj.ShowResult(consoleStream);
           
            using (FileStream fileStream = new FileStream("result-xml.xml", FileMode.OpenOrCreate))
            {
                sx.ShowResult(fileStream);
            }
            Console.WriteLine("awdwad");
            sx.ShowResult(consoleStream);

            void TestFoo()
            {
                foo.MyMethod();
                foo.MyMethod();
                bar.InnerMethod();
            }
        }
    }
}