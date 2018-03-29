using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Given an array of integers, and a number ‘sum’, 
    /// find the number of pairs of integers in the array whose sum is equal to ‘sum’.
    /// Examples:
    /// Input  :  arr[] = {1, 5, 7, -1}, 
    /// sum = 6
    /// Output :  2
    /// Pairs with sum 6 are(1, 5) and(7, -1)
    /// 
    /// Input  :  arr[] = {1, 5, 7, -1, 5}, 
    /// sum = 6
    /// Output :  3
    /// Pairs with sum 6 are(1, 5), (7, -1) & (1, 5)   
    /// </summary>
    public static class FindPairOfSum
    {
        /// <summary>
        /// Definition of Complement: If we’re trying to find a pair of numbers that sums to z, the complement
        /// of x will be z - x(that is, the number that can be added to x to make z). 
        /// For example,if we’re trying to find a pair of numbers that sum to 12, the complement of –5 would be 17.
        /// The Algorithm: Imagine we have the following sorted array: {-2 -1 0 3 5 6 7 9 13 14 }. Let first
        /// point to the head of the array and last point to the end of the array.To find the complement
        /// of first, we just move last backwards until we find it.If first + last sum, then there is no complement
        /// for first.We can therefore move first forward.We stop when first is greater than last.
        /// Why must this find all complements for first? Because the array is sorted and we’re trying progressively
        /// smaller numbers.When the sum of first and last is less than the sum, we know that
        /// trying even smaller numbers (as last) won’t help us find a complement.
        /// Why must this find all complements for last? Because all pairs must be made up of a first and
        /// a last. We’ve found all complements for first, therefore we’ve found all complements of last.
        /// O(NLogN)
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="num"></param>
        /// <param name="sum"></param>
        private static void PrintPairs(int[] ptr, int num, int sum)
        {
            System.Array.Sort(ptr);
            int first = 0;
            int last = num - 1;
            while (first < last)
            {
                int s = ptr[first] + ptr[last];
                if (s == sum)
                {
                    Console.Write(ptr[first] + " " + ptr[last] + "\n");
                    ++first;
                    --last;
                }
                else
                {
                    if (s < sum)
                    {
                        ++first;
                    }
                    else
                    {
                        --last;
                    }
                }
            }
        }

        // Returns number of pairs in arr[0..n-1] with sum equal
        // to 'sum'
        private static int getPairsCount(int[] arr, int n, int sum)
        {
            Dictionary<int, int> hm = new Dictionary<int, int>();

            // Store counts of all elements in map hm
            for (int i = 0; i < n; i++)
            {
                // initializing value to 0, if key not found
                if (!hm.ContainsKey(arr[i]))
                    hm.Add(arr[i], 0);

                hm[arr[i]] = hm.GetValueOrDefault(arr[i]) + 1;
            }
            int twice_count = 0;

            // iterate through each element and increment the
            // count (Notice that every pair is counted twice)
            for (int i = 0; i < n; i++)
            {
                int rest = 0;
                if (hm.TryGetValue(sum - arr[i], out rest))
                    twice_count += hm.GetValueOrDefault(sum - arr[i]);

                // if (arr[i], arr[i]) pair satisfies the condition,
                // then we need to ensure that the count is
                // decreased by one such that the (arr[i], arr[i])
                // pair is not considered
                if (sum - arr[i] == arr[i])
                    twice_count--;
            }

            // return the half of twice_count
            return twice_count / 2;
        }

        public static void Test()
        {
            int[] arr = new int[] { 1, 5, 7, -1, 5 };
            int sum = 6;
            Console.Write("Count of pairs is " + getPairsCount(arr, arr.Length, sum));
        }
    }
}
