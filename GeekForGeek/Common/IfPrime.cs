﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class IfPrime
    {
        private static void CheckIfPrime(int num)
        {
            int k;
            k = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    k++;
                }
            }
            if (k == 2)
            {
                Console.WriteLine("Entered Number is a Prime Number and the Largest Factor is {0}", num);
            }
            else
            {
                Console.WriteLine("Not a Prime Number");
            }
        }

        public static void Test()
        {
            CheckIfPrime(23);
        }
    }
}