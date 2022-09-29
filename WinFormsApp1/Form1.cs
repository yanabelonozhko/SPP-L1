namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int MainTime = 0;
            List<TraceResult> ListOfResults = new List<TraceResult>();

            MyMethods myMethods = new MyMethods();
            Tracer myTracer = new Tracer();

            //Подписались на события
            myMethods.TracingStart += myTracer.StartTrace;
            myMethods.TracingStoped += myTracer.StopTrace;
            myMethods.TracingTime += myTracer.GetTraceResult;

           





            //result = tracer.GetTraceResult();
            //ListOfResults.Add(result);

            //   foreach (var p in Methods.ListOfResults)
            //  {
            //      MainTime =+ p.MethodTime;
            //   }
            //   label3.Text = MainTime.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        
    }
}