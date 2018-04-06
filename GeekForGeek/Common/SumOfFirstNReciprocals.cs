using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    /// <summary>
    /// create a function sum that will return the sum of the first "n" reciprocals
    /// e.g sum(5) = 1 + 1/2 + 1/3 + 1/4 + 1/5
    /// </summary>
    public static class SumOfFirstNReciprocals
    {
        /// <summary>
        /// sum(5) = 1 + 1/2 + 1/3 + 1/4 + 1/5
        /// as
        /// sum(5) = 1/5 + sum(4)
        /// sum(4) = 1/4 + sum(3)
        /// sum(3) = 1/3 + sum(2)
        /// sum(2) = 1/2 + sum(1)
        /// sum(1) = 1
        /// so sum(n) = 1/n + sum(n - 1)
        /// </summary>
        /// <param name="n"></param>
        public static string SumUsingRecursion(int n)
        {
            string result = string.Empty;
            if (n == 1)
                result = "1";
            else
                result = "1 / " + n + " + " + SumUsingRecursion(n - 1);

            return result;
            //Console.Write("SumOfFirstNReciprocals of n:" + result);
        }

        public static void Test()
        {
            string output = SumUsingRecursion(5);
            Console.Write("SumOfFirstNReciprocals of 5: \t" + output);
        }
    }
}
