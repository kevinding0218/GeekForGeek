using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class ComputeNumberOfZeroInNFactorial
    {
        /// <summary>
        /// Trailing zeros are contributed by pairs of 5 and 2, because 5*2 = 10. To count the number of
        /// pairs, we just have to count the number of multiple of 5’s.Note that while 5 contributes to
        /// one multiple of 10, 25 contributes two(because 25 = 5*5).
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int NumberOfTrialingZeros(int num)
        {
            int count = 0;
            if (num < 0)
            {
                Console.Write("Factorial is not defined for negative numbers\n");
                return 0;
            }
            for (int i = 5; num / i > 0; i *= 5)
            {
                count += num / i;
            }
            return count;
        }
    }
}
