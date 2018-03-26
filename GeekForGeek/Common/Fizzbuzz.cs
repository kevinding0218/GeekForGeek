using System;

namespace GeekForGeek.Common
{
    public static class Fizzbuzz
    {
        public static void FizzbuzzOne()
        {
            for (int i = 1; i <= 100; i++)
            {
                bool fizz = i % 3 == 0, buzz = i % 5 == 0;
                if (fizz && buzz)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (fizz)
                {
                    Console.WriteLine("Fizz");
                }
                else if (buzz)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void FizzbuzzTwo()
        {
            for (int i = 1; i <= 100; i++)
            {
                string str = "";
                bool fizz = i % 3 == 0, buzz = i % 5 == 0;
                if (fizz)
                {
                    str += "Fizz";
                }
                if (buzz)
                {
                    str += "Buzz";
                }
                if (str.Length == 0)
                {
                    str = i.ToString();
                }
                Console.WriteLine(str);
            }
        }
    }
}
