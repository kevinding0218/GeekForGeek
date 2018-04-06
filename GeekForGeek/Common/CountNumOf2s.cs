using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    /// <summary>
    /// http://www.cnblogs.com/hello--the-world/archive/2012/05/31/2528084.html
    /// </summary>
    public static class CountNumOf2s
    {
        /* A Simple Brute force solution is to iterate through all numbers from 0 to n. 
         * For every number being visited, count the number of 2’s in it. Finally return total count.
         * Counts the number of '2' digits in a
        single number */
        static int number0f2s(int n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 10 == 2)
                    count++;

                n = n / 10;
            }
            return count;
        }

        /* Counts the number of '2' digits between
            0 and n */
        static int numberOf2sinRange(int n)
        {

            // Initialize result
            int count = 0;

            // Count 2's in every number 
            // from 2 to n
            for (int i = 2; i <= n; i++)
                count += number0f2s(i);

            return count;
        }

        /// <summary>
        /// Let’s find a pattern:
        /// 0-10 (10^1) has 1 2s.
        /// 0-100 (10^2) has 20 2s.
        /// 0-1000 (10^3) has 300 2s
        /// Given a digit x, 1 out of every 10 numbers will have a 2 in digit x.Therefore, between 1 and
        /// 1000, you will see 100 2’s in digit 0, 100 2’s in digit 1, and 100 2’s in digit 2. So, 300 2’s total. To
        /// generalize this into a rule: between 0 and 10^n, there are n*(10^n-1) 2s.
        /// Let’s call this function f(n) = n* (10^(n-1)).
        /// 1000 -> 300
        /// 2000 -> 300*2
        /// 3000 -> 300*3 + 1000
        /// If we want to know the number of 2’s between 1 and x * 10^n, then the solution is:
        /// if x > 2 —> x* f(n) + 10^(n-1)
        /// if x = 2 —> x* f(n) + 1
        /// if x < 2 —> f(n-1)
        /// Now, let’s take a number like 2145
        /// 2’s between 1 and 1999: 2*300 (300 2’s between 1 and 999, and 300 between 1000 and 1999)
        /// 2’s between 2000 and 2099: 1*20 + 100(20 2’s between 2001 and 2099 (just like between 1 and 99), Plus, each number starts with a 2)
        /// 2’s between 2100 and 2139: 4*1 + 10 + 40(4 2’s in form 21?2 Plus 10 in form 212?)
        /// 2’s between 2140 and 2145: 1 + 6
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int Count2sEfficiently(int num)
        {
            int i = 0, countof2s = 0, digit = 0;
            int j = num, seendigits = 0, position = 0;
            while (j > 0)
            {
                digit = j % 10;
                /* Digit < 2 implies there are no 2s contributed by this
                * digit */
                if (digit < 2)
                {
                    countof2s = countof2s + digit * Numof2s(position - 1);
                }
                /* Digit == 2 implies there are 2*numof2s contributed by the
                * previous position + num of 2s contributed by the
                * presence of this 2 */
                else if (digit == 2)
                {
                    countof2s = countof2s + (digit * Numof2s(position - 1)) + seendigits + 1;
                }
                /* Digit > 2 implies there are digit * num of 2s by the prev.
                * position + 10^position */
                else if (digit > 2)
                {
                    countof2s = countof2s + (digit) * Numof2s(position - 1) + Convert.ToInt32(Math.Pow(10, position));
                }
                seendigits = seendigits + Convert.ToInt32(Math.Pow(10, position)) * digit;
                position++;
                j = j / 10;
            }
            return (countof2s);
        }
        // Returns the number of 2s between 0 and 10^n.
        static int Numof2s(int exponent)
        {
            int i = 0;
            int power = 1;
            // 10 ^ exponent e.g, 10 ^ 3 = 1000
            for (i = 0; i < exponent; i++)
            {
                power = power * 10;
            }

            // power = (n + 1) * 10^n
            power = (exponent + 1) * power;

            if (exponent >= 0)
            {
                return (power);
            }
            return (0);
        }

        public static void Test()
        {
            Console.Write("Number of 2s in 2145 is " + Count2sEfficiently(2145));
        }
    }
}
