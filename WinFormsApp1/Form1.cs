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
            if (CBMeth1.Checked) {
                Methods.Method1();
            }
            if (CBMeth2.Checked) { 
                Methods.Method2();
            }
            if (CBMeth3.Checked) {
                Methods.Method3();
            }
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
    }
}