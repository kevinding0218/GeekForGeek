using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    public static class FindAllSubset
    {
        private static void AllSubsets(int[] given_array)
        {
            int[] subset = new int[given_array.Length];
            Helper(given_array, subset, 0);
        }

        private static void Helper(int[] given_array, int[] subset, int i)
        {
            if (i == given_array.Length)
                Console.Write(string.Join(",", subset));
            else
            {
                subset[i] = 0;
                Helper(given_array, subset, i + 1);
                subset[i] = given_array[i];
                Helper(given_array, subset, i + 1);
            }
        }

        /// <summary>
        /// The total number of subsets of any given set is equal to 2^ (no. of elements in the set). 
        /// If we carefully notice it is nothing but binary numbers from 0 to 15 which can be shown as below:
        /// 0000    {}
        /// 0001    {a}
        /// 0010    {b}
        /// 0011    {a, b}
        /// 0100    {c}
        /// 0101    {a, c}
        /// 0110    {b, c}
        /// 0111    {a, b, c}
        /// 1000    {d}
        /// 1001    {a, d}
        /// 1010    {b, d}
        /// 1011    {a, b, d}
        /// 1100    {c, d}
        /// 1101    {a, c, d}
        /// 1110    {b, c, d}
        /// 1111    {a, b, c, d}
        /// Starting from right, 1 at ith position shows that the ith element of the set is present as 0 shows 
        /// that the element is absent.
        /// Therefore, what we have to do is just generate the binary numbers from 0 to 2^n – 1, 
        /// where n is the length of the set or the numbers of elements in the set.
        /// </summary>
        /// <param name="set"></param>
        private static void PrintSubsets(char[] set)
        {
            int n = set.Length;

            // Run a loop for printing all 2^n
            // subsets one by obe   
            // '<<' left shift
            for (int i = 0; i < (1 << n); i++)
            {
                Console.Write("{ ");

                // Print current subset
                for (int j = 0; j < n; j++)

                    // (1<<j) is a number with jth bit 1
                    // so when we 'and' them with the
                    // subset number we get which numbers
                    // are present in the subset and which
                    // are not
                    if ((i & (1 << j)) > 0)
                        Console.Write(set[j] + " ");

                Console.Write("}");
            }
        }

        public static void Test()
        {
            //AllSubsets(new int[3] { 1, 2, 3 });
            PrintSubsets(new char[3] { 'a', 'b', 'c' });
        }
    }
}
