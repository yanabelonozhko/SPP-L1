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
            Thread thread1 = new Thread(foo.MyMethod);
            Thread thread2 = new Thread(bar.InnerMethod);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            
            var myTraceResult = new TraceResult();
            myTraceResult =  myTracer.GetTraceResult();

            FileStream fileStream = new FileStream("result-json.json", FileMode.OpenOrCreate);
            SerializationJson sj = new SerializationJson(myTraceResult);
            sj.ShowResult(fileStream);

            // var consoleStream = Console.OpenStandardOutput();

            // Логично, что если я передаю объект сериализатору, я зарее могу не знать 
            // как я хочу выводить его в консоль или в файл 
            //  SerializationXML sx = new SerializationXML(myTraceResult);


            //  sx.ShowResult(consoleStream);

        }
    }
}