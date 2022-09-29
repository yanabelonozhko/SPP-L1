namespace lab1 {
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Отслеживание времени выполнения методов:");
            long MainTime = 0;

            MyMethods myMethods = new MyMethods();
            Tracer myTracer = new Tracer();

            //Подписались на события
            myMethods.TracingStart += myTracer.StartTrace;
            myMethods.TracingStoped += myTracer.StopTrace;

            // Сюда писать методы новые >:C 
            Console.WriteLine("start");
            myMethods.Method(4000000);
            myMethods.Method2(10);
           
          

            foreach (var e in myTracer.ListOfResults) {
                Console.WriteLine(e.Time.ToString() +" - "+ e.Name.ToString() + " - " + e.Class.ToString());
                MainTime = MainTime + Convert.ToInt64(e.Time);
            }
            Console.WriteLine(MainTime);
        }
    }
}