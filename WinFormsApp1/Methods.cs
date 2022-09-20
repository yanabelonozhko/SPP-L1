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
        static int TestVar;
        public static List<TraceResult> ListOfResults = new List<TraceResult>();

        public static void Method()
        {
            j = 0;
            for (int i = 0; i < TestVar; i++)
            {
                j++;
            }
        }
    }
}
