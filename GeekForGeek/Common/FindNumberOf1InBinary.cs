using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class FindNumberOf1InBinary
    {
        private static int NumberOfOneInBinary(int number)
        {
            int count = 0;

            while (number > 0)
            {
                count++;
                number = number & (number - 1);
            }

            return count;
        }

        public static void Test()
        {
            Console.Write("Number of 1 in " + 34 + " of binary representation is " + NumberOfOneInBinary(34));
        }
    }
}
