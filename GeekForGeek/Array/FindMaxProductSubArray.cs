using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Given an array that contains both positive and negative integers, 
    /// find the product of the maximum product subarray. 
    /// Expected Time complexity is O(n) and only O(1) extra space can be used.
    /// Input: arr[] = {6, -3, -10, 0, 2}
    /// Output:   180  // The subarray is {6, -3, -10}
    /// Input: arr[] = {-1, -3, -10, 0, 60}
    /// Output:   60  // The subarray is {60}
    /// Input: arr[] = {-2, -3, 0, -2, -40}
    /// Output:   80  // The subarray is {-2, -40}
    /// https://www.geeksforgeeks.org/maximum-product-subarray/
    /// </summary>
    public static class FindMaxProductSubArray
    {
        // Utility functions to get minimum of two integers
        static int min(int x, int y) { return x < y ? x : y; }

        // Utility functions to get maximum of two integers
        static int max(int x, int y) { return x > y ? x : y; }

        /* Returns the product of max product subarray.
        Assumes that the given array always has a subarray
        with product more than 1 */
        static int maxSubarrayProduct(int[] arr)
        {
            int n = arr.Length;
            // max positive product ending at the current 
            // position
            int max_ending_here = 1;

            // min negative product ending at the current
            // position
            int min_ending_here = 1;

            // Initialize overall max product
            int max_so_far = 1;
            int min_so_far = 1;
            int max_start = 0, max_end = 0, max_pointerIndex = 0;
            int min_start = 0, min_end = 0, min_pointerIndex = 0;

            /* Traverse through the array. Following
            values are maintained after the ith iteration:
            max_ending_here is always 1 or some positive
            product ending with arr[i] min_ending_here is
            always 1 or some negative product ending 
            with arr[i] */
            for (int i = 0; i < n; i++)
            {
                /* If this element is positive, update 
                max_ending_here. Update min_ending_here 
                only if min_ending_here is negative */
                if (arr[i] > 0)
                {
                    max_ending_here = max_ending_here * arr[i];
                    min_ending_here = min(min_ending_here * arr[i], 1);
                }

                /* If this element is 0, then the maximum 
                product cannot end here, make both 
                max_ending_here and min_ending_here 0
                Assumption: Output is alway greater than or
                equal to 1. */
                else if (arr[i] == 0)
                {
                    max_ending_here = 1;
                    min_ending_here = 1;

                    max_pointerIndex = i + 1;
                    min_pointerIndex = i + 1;
                }

                /* If element is negative. This is tricky
                max_ending_here can either be 1 or positive.
                min_ending_here can either be 1 or negative.
                next min_ending_here will always be prev max_ending_here * arr[i]
                next max_ending_here will be 1 if prev min_ending_here is 1, 
                otherwise, next max_ending_here will be prev min_ending_here * arr[i] */
                else
                {
                    int temp = max_ending_here;
                    max_ending_here = max(min_ending_here * arr[i], 1);
                    min_ending_here = temp * arr[i];
                }
                Console.Write("\ni: " + i + "\tarr[i]: " + arr[i] + "\tmax_ending_here: " + max_ending_here + "\tmin_ending_here: " + min_ending_here + "\n");
                // update max_so_far, if needed
                if (max_so_far < max_ending_here)
                {
                    max_start = max_pointerIndex;
                    max_end = i;
                    max_so_far = max_ending_here;
                }

                if (min_so_far > min_ending_here)
                {
                    min_start = min_pointerIndex;
                    min_end = i;
                    min_so_far = min_ending_here;
                }


                Console.Write("max_so_far: " + max_so_far + "\tmax_start: " + max_start + "\tmax_end: " + max_end + "\n");
                Console.Write("min_so_far: " + min_so_far + "\tmin_start: " + min_start + "\tmin_end: " + min_end + "\n");

            }

            return max_so_far;
        }

        public static void Test()
        {
            int[] arr = { 1, -2, -3, 0, 7, -8, -2 };
            foreach (var num in arr)
            {
                Console.Write(num.ToString() + " ");
            }

            Console.WriteLine("\nMaximum Sub array product is " +
                                maxSubarrayProduct(arr));
        }
    }
}
