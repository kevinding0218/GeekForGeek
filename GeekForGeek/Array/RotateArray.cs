using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Write a function rotate(ar[], d, n) that rotates arr[] of size n by d elements.
    /// e.g input array:
    /// 1 2 3 4 5 6 7
    /// rotate the above array by 2 will be:
    /// 3 4 5 6 7 1 2
    /// https://www.geeksforgeeks.org/array-rotation/
    /// </summary>
    public static class RotateArray
    {
        /// <summary>
        /// Instead of moving one by one, divide the array in different sets
        /// where number of sets is equal to GCD of n and d and move the elements within sets.
        /// If GCD is 1 as is for the above example array(n = 7 and d = 2), then elements will be moved within one set only, 
        /// we just start with temp = arr[0] and keep moving arr[I + d] to arr[I] and finally store temp at the right place.
        /// Here is an example for n = 12 and d = 3.GCD is 3 and
        /// Let arr[] be {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
        /// Elements are first moved in first set – (See below diagram for this movement)
        /// (1, 2, 3), (4, 5, 6), (7, 8, 9), (10, 11, 12)
        /// a) arr[] after this step --> {'4' 2 3 '7' 5 6 '10' 8 9 '1' 11 12}
        /// b) Then in second set.
        /// arr[] after this step --> {4 '5' 3 7 '8' 6 10 '11' 9 1 '2' 12}
        /// c) Finally in third set.
        /// arr[] after this step --> { 4 5 '6' 7 8 '9' 10 11 '12' 1 2 '3'}
        /// Time complexity: O(n), Space: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="rotateBy"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int[] LeftRotate(int[] arr, int rotateBy, int length)
        {
            int i, j, k, temp;
            for (i = 0; i < gcd(rotateBy, length); i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (true)
                {
                    k = j + rotateBy;
                    if (k >= length)
                        k = k - length;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
            return arr;
        }

        private static int gcd(int rotateBy, int length)
        {
            if (length == 0)
                return rotateBy;
            else
                return gcd(length, rotateBy % length);
        }

        public static void Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int[] afterRotate = LeftRotate(arr, 2, 7);
            foreach (var item in afterRotate)
                Console.Write(item + " ");
        }
    }
}
