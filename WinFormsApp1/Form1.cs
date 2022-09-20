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
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            // גûחמג לועמהמג 
            tracer.StopTrace();

            Methods.Method();
            tracer.StopTrace();

            //result = tracer.GetTraceResult();
            //ListOfResults.Add(result);

            foreach (var p in Methods.ListOfResults)
            {
                MainTime =+ p.MethodTime;
            }
            label3.Text = MainTime.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            panel.RowCount = panel.RowCount + 1;
            panel.Controls.Add(new Label() { Text = MethNameEditBox.Text }, 0, panel.RowCount - 1);
            panel.Controls.Add(new Label() { Text = CountMethEditBox.Text }, 1, panel.RowCount - 1);
            panel.Controls.Add(new CheckBox() { Text = "xxxxxxx@gmail.com" }, 2, panel.RowCount - 1);
        }
    }
}