using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Methods
    {
        static int j;
        static int TestVar1 = 10;
        static int TestVar2 = 1000;
        static int TestVar3 = 1000000;
        public static void Method1() 
        {
            j = 0;
            for (int i = 0; i < TestVar1; i++)
            {
                j++;
            }
        }
        public static void Method2()
        {
            j = 0;
            for (int i = 0; i < TestVar2; i++)
            {
                j++;
            }
        }
        public static void Method3()
        {
            j = 0;
            for (int i = 0; i < TestVar3; i++)
            {
                j++;
            }
        }
    }
}
