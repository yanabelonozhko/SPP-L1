using System.Text.Json;

namespace lab1 {
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Отслеживание времени выполнения методов:");
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
            TraceResult myTraceResult = new TraceResult();
            myTraceResult =  myTracer.GetTraceResult();
            using (FileStream fs = new FileStream("result-json.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<TraceResult>(fs, myTraceResult);
                Console.WriteLine("Data has been saved to file");
            }
        }
    }
}