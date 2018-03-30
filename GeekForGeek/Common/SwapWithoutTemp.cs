using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class SwapWithoutTemp
    {
        private static void SwapWithSumSub(int a, int b)
        {
            Console.Write("a: " + a + "\tb: " + b);
            if (a != b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            Console.Write("a: " + a + "\tb: " + b);
        }

        private static void SwapWithXOR(int a, int b)
        {
            Console.Write("a: " + a + "\tb: " + b);
            if (a != b)
            {
                a = a ^ b;
                b = a ^ b;
                a = a ^ b;
            }
            Console.Write("a: " + a + "\tb: " + b);
        }

        public static void Test()
        {
            SwapWithSumSub(3, 5);
        }
    }
}
