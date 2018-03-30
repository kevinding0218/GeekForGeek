using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    /// <summary>
    /// Reverse digits of an integer. For example: x = 123, return 321.
    /// </summary>
    public static class ReverseInteger
    {
        private static int Reverse(int x)
        {
            int ret = 0;
            while (x != 0)
            {
                // handle overflow/underflow
                if (Math.Abs(ret) > 214748364)
                {
                    return 0;
                }
                ret = ret * 10 + x % 10;
                x /= 10;
            }
            return ret;
        }

        /// <summary>
        /// It turns out that comparing from the two ends is easier. First, compare the first and last
        /// digit.If they are not the same, it must not be a palindrome.If they are the same, chop off
        /// one digit from both ends and continue until you have no digits left, which you conclude
        /// that it must be a palindrome.
        /// Now, getting and chopping the last digit is easy.However, getting and chopping the first
        /// digit in a generic way requires some thought.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int div = 1;
            while (x / div >= 10)
            {
                div *= 10;
            }
            while (x != 0)
            {
                // get first digit
                int l = x / div;
                // get last digit
                int r = x % 10;
                if (l != r) return false;

                // x decrease first and last
                x = (x % div) / 10;
                // div decrease two digit
                div /= 100;
            }
            return true;
        }

        public static void Test()
        {
            int num = 5445;
            //Console.Write("Revert of Num: " + num + " is " + Reverse(5412));
            if (IsPalindrome(num))
                Console.Write(num + " is Palindrome.");
            else
                Console.Write(num + " is not Palindrome.");

        }
    }
}
