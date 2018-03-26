using System;

namespace GeekForGeek.Array
{
    /// <summary>
    /// You are given an array of n+2 elements. 
    /// All elements of the array are in range 1 to n. 
    /// And all elements occur once except two numbers which occur twice. Find the two repeating numbers.
    /// For example, array = { 4, 2, 4, 5, 2, 3, 1 } and n = 5
    /// The above array has n + 2 = 7 elements with all elements occurring once except 2 and 4 which occur twice.So the output should be 4 2.
    /// https://www.geeksforgeeks.org/?p=7953
    /// </summary>
    public class FindTwoDuplicatesIntAppearTwice
    {
        /// <summary>
        /// We know the sum of integers from 1 to n is n(n+1)/2 and product is n!. We calculate the sum of input array, when this sum is subtracted from n(n+1)/2, we get X + Y because X and Y are the two numbers missing from set [1..n]. Similarly calculate product of input array, when this product is divided from n!, we get X*Y. Given sum and product of X and Y, we can find easily out X and Y.
        /// Let summation of all numbers in array be S and product be P
        /// X + Y = S – n(n+1)/2
        /// XY = P/n!
        /// Using above two equations, we can find out X and Y.For array = 4 2 4 5 2 3 1, we get S = 21 and P as 960.
        /// X + Y = 21 – 15 = 6
        /// XY = 960/5! = 8X – Y = sqrt((X+Y)^2 – 4*XY) = sqrt(4) = 2
        /// Using below two equations, we easily get X = (6 + 2)/2 and Y = (6 - 2) / 2
        /// X + Y = 6
        /// X – Y = 2
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        public static void MakeTwoEquations(int[] arr, int size)
        {
            /* S is for sum of elements in arr[] */
            int S = 0;

            /* P is for product of elements in arr[] */
            int P = 1;

            /* x and y are two repeating elements */
            int x, y;

            /* D is for difference of x and y, i.e., x-y*/
            int D;

            int n = size - 2, i;

            /* Calculate Sum and Product 
             of all elements in arr[] */
            for (i = 0; i < size; i++)
            {
                S = S + arr[i];
                P = P * arr[i];
            }

            /* S is x + y now */
            S = S - n * (n + 1) / 2;

            /* P is x*y now */
            P = P / fact(n);

            /* D is x - y now */
            D = (int)Math.Sqrt(S * S - 4 * P);


            x = (D + S) / 2;
            y = (S - D) / 2;

            Console.WriteLine("The two" +
                    " repeating elements are :");
            Console.Write(x + " " + y);
        }

        static int fact(int n)
        {
            return (n == 0) ? 1 : n * fact(n - 1);
        }

        /// <summary>
        /// traverse the list for i= 0 to n-1 elements
        /// {
        ///     check for sign of A[abs(A[i])] ;
        ///     if positive then
        ///         make it negative by   A[abs(A[i])]=-A[abs(A[i])];
        ///     else  // i.e., A[abs(A[i])] is negative
        ///         this   element(ith element of list) is a repetition
        ///         }
        /// Example: A[] =  {1, 1, 2, 3, 2}
        /// i=0; 
        /// Check sign of A[abs(A[0])] which is A[1].  A[1] is positive, so make it negative.
        /// Array now becomes { 1, -1, 2, 3, 2}
        /// i=1; 
        /// Check sign of A[abs(A[1])] which is A[1].  A[1] is negative, so A[1] is a repetition.
        /// i=2;
        /// Check sign of A[abs(A[2])] which is A[2].  A[2] is  positive, so make it negative. '
        /// Array now becomes { 1, -1, -2, 3, 2}
        /// i=3; 
        /// Check sign of A[abs(A[3])] which is A[3].  A[3] is  positive, so make it negative.
        /// Array now becomes { 1, -1, -2, -3, 2}
        /// i=4;
        /// Check sign of A[abs(A[4])] which is A[2].  A[2] is negative, so A[4] is a repetition.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        public static void WithEncodeArray(int[] arr, int size)
        {
            int i;
            //Console.Write("The repeating elements are : ");

            for (i = 0; i < size; i++)
            {
                Console.Write("i:" + i + "\tarr[i]:" + arr[i] + "\tMath.Abs(arr[i]):" + Math.Abs(arr[i]) + "\tarr[Math.Abs(arr[i])]:" + arr[Math.Abs(arr[i])]);
                if (arr[Math.Abs(arr[i])] > 0)
                {
                    Console.WriteLine("\nflip arr[Math.Abs(arr[i])] from " + arr[Math.Abs(arr[i])] + " to " + -arr[Math.Abs(arr[i])]);
                    arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
                }
                else
                    Console.Write("\nFound repeating elements:" + Math.Abs(arr[i]) + " \n");

                Console.Write("i:" + i + "\t");
                for (int j = 0; j < size; j++)
                {
                    //Console.WriteLine();
                    Console.Write(arr[j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
