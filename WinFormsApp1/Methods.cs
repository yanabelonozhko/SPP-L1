using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class MyMethods
    {
        public delegate void MethodContainer();
        public event MethodContainer TracingStart;

        public delegate void MethodContainer2();
        public event MethodContainer TracingStoped;

        static int j;
        
        public void Method(int TestVar)
        {
            TracingStart();
            j = 0;
            for (int i = 0; i < TestVar; i++)
            {
                j++;
            }
            TracingStoped();
        }
    }
}
