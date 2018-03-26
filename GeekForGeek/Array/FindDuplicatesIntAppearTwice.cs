using System;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Given an array of n elements which contains elements from 0 to n-1, with any of these numbers appearing any number of times. 
    /// Find these repeating numbers in O(n) and using only constant memory space.
    /// For example, let n be 7 and array be {1, 2, 3, 1, 3, 6, 6}, the answer should be 1, 3 and 6.
    /// </summary>
    public static class FindDuplicatesIntAppearTwice
    {
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
            Console.Write("The repeating elements are : ");

            for (i = 0; i < size; i++)
            {
                if (arr[Math.Abs(arr[i])] > 0)
                    arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
                else
                    Console.Write(Math.Abs(arr[i]) + " ");
            }
        }
    }
}
