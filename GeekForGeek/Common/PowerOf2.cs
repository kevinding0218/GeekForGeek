using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class PowerOf2
    {
        // Function to check if 
        // x is power of 2
        private static bool IsPowerOfTwo(int number)
        {
            if (number == 0)
                return false;

            while (number != 1)
            {
                if (number % 2 != 0)
                    return false;

                number = number / 2;
            }
            return true;
        }

        private static bool CheckIfPowerOf2(int number)
        {
            if (number <= 0)
                return false;
            else
                return (number & (number - 1)) == 0;
        }

        public static void Test()
        {
            if (CheckIfPowerOf2(3))
                Console.Write("is Power of 2");
            Console.Write("not Power of 2");
        }
    }
}
