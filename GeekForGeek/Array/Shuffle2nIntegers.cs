using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Given an array of 2n elements in the following format { a1, a2, a3, a4, ….., an, b1, b2, b3, b4, …., bn }. 
    /// The task is shuffle the array to {a1, b1, a2, b2, a3, b3, ……, an, bn } without using extra space.
    /// Examples:
    /// Input : arr[] = { 1, 2, 9, 15 }
    /// Output : 1 9 2 15
    /// Input :  arr[] = { 1, 2, 3, 4, 5, 6 }
    /// Output : 1 4 2 5 3 6
    /// https://www.geeksforgeeks.org/shuffle-2n-integers-format-a1-b1-a2-b2-a3-b3-bn-without-using-extra-space/
    /// </summary>
    public static class Shuffle2nIntegers
    {
        /// <summary>
        /// Time Complexity: O(n2)
        /// Method: (Divide and Conquer)
        /// The idea is to use Divide and Conquer Technique.Divide the given array into half (say arr1[] and arr2[]) 
        /// and swap second half element of arr1[] with first half element of arr2[]. Recursively do this for arr1 and arr2.
        /// Let us explain with the help of an example.
        /// Let the array be a1, a2, a3, a4, b1, b2, b3, b4
        /// Split the array into two halves: a1, a2, (a3, a4 : b1, b2), b3, b4
        /// Exchange element around the center: exchange (a3, a4) with (b1, b2) correspondingly.
        /// you get: a1, a2, (b1, b2, a3, a4), b3, b4
        /// Recursively spilt a1, a2, b1, b2 into a1, (a2 : b1), b2
        /// then split a3, a4, b3, b4 into a3, (a4 : b3), b4.
        /// Exchange elements around the center for each subarray we get:
        /// a1, b1, a2, b2 and a3, b3, a4, b4.
        /// Note: This solution only handles the case when n = 2i where i = 0, 1, 2, …etc.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="f"></param>
        /// <param name="l"></param>
        static void ShuffleArray(int[] a, int f, int l)
        {
            // If only 2 element, return
            if (l - f == 1)
                return;

            // finding mid to divide the array
            int mid = (f + l) / 2;

            // using temp for swapping first half of second array
            int temp = mid + 1;

            // mmid is use for swapping second half for first array
            int mmid = (f + mid) / 2;

            // Swapping the element
            for (int i = mmid + 1; i <= mid; i++)
            {
                // swap a[i], a[temp++]
                int temp1 = a[i];
                a[i] = a[temp];
                a[temp++] = temp1;
            }

            // Recursively doing for first half and second half
            ShuffleArray(a, f, mid);
            ShuffleArray(a, mid + 1, l);
        }

        public static void Test()
        {
            int[] a = { 1, 3, 5, 7, 2, 4, 6, 8 };

            ShuffleArray(a, 0, a.Length - 1);

            foreach (var obj in a)
                Console.Write(obj + " ");
        }
    }
}
