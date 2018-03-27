using System;

namespace GeekForGeek.Common
{
    /// <summary>
    /// Fibonacci: f(0) = 0, f(1) = 1, f(n) = f(n - 1) + f(n - 2)
    /// 0   1   1   2   3   5   8   13  21...
    /// </summary>
    public static class Fibonacci
    {
        /// <summary>
        /// Why Stack Overflow error occurs in recursion?
        /// If base case is not reached or not defined, then stack overflow problem may arise.
        /// Whenever you call a function, including recursively, 
        /// the return address and often the arguments are pushed onto the call stack. 
        /// The stack is finite, so if the recursion is too deep you'll eventually run out of stack space.
        /// int fact(int n)
        /// {
        ///     // wrong base case (it may cause
        ///     // stack overflow).
        ///     if (n == 100) 
        ///         return 1;
        ///     else
        ///         return n* fact(n-1);
        /// }         
        /// If fact(10) is called, it will call fact(9), fact(8), fact(7) and so on but number will never reach 100. 
        /// So, the base case is not reached. If the memory is exhausted by these functions on stack, it will cause stack overflow error.         
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GenerateFibNumberInRecursive(int n)
        {
            if (n == 0)
            {
                // f(0) = 0
                return 0;
            }
            else if (n == 1)
            {
                // f(1) = 1
                return 1;
            }
            else if (n > 1)
            {
                return GenerateFibNumberInRecursive(n - 1) + GenerateFibNumberInRecursive(n - 2); // f(n) = f(n—1) + f(n-2)
            }
            else
            {
                // Error condition
                return -1;
            }
        }

        public static int GenerateFibNumberNonRecursive(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            int a = 1, b = 1;
            for (int i = 3; i <= n; i++)
            {
                int c = a + b;
                Console.Write("n: " + n + "\ti: " + i);
                Console.Write("\nbefore a: " + a + "\tb: " + b + "\tc: " + c);
                Console.Write("\nswitch b: " + b + " && c: " + c);
                a = b;
                b = c;
                Console.Write("\nafter a: " + a + "\tb: " + b + "\tc: " + c);
            }
            return b;
        }
    }
}
