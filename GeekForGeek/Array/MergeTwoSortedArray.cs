using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    /// <summary>
    /// You are given two sorted arrays, A and B, and A has a large enough buffer at the end to
    /// hold B.Write a method to merge B into A in sorted order.
    /// </summary>
    public static class MergeTwoSortedArray
    {
        private static void MergeSortedArrays(int[] a, int[] b, int sizeA, int sizeB)
        {
            int k = sizeB + sizeA - 1; // Index of last location of array b
            int i = sizeA - 1; // Index of last element in array b
            int j = sizeB - 1; // Index of last element in array a
                               // Start comparing from the last element and merge a and b
            while (i >= 0 && j >= 0)
            {
                if (a[i] > b[j])
                {
                    //a[k--] = a[i--];
                    a[k] = a[i];
                    k = k - 1;
                    i = i - 1;
                }
                else
                {
                    //a[k--] = b[j--];
                    a[k] = b[j];
                    k = k - 1;
                    j = j - 1;
                }
            }

            while (j >= 0)
            {
                //a[k--] = b[j--];
                a[k] = b[j];
                k = k - 1;
                j = j - 1;
            }

            Console.Write(string.Join(" ", a));
        }

        public static void Test()
        {
            MergeSortedArrays(new int[8] { 2, 4, 6, 8, 0, 0, 0, 0 }, new int[] { 1, 3, 5, 7 }, 4, 4);
        }
    }
}
