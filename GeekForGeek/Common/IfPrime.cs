using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class IfPrime
    {
        // O(sqrt(n))   --> O(n^1.5)
        private static bool CheckIfPrime(int num)
        {
            if (num == 0 || num == 1)
                return false;

            if (num % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(num); i = i +2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Test()
        {
            CheckIfPrime(23);
        }
    }
}
