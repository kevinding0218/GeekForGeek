using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    public static class FindMinInRotatedSortedArray
    {
        /// <summary>
        /// As we are discarding half of the elements at each step, the runtime complexity is O(logn).
        /// To understand the correct terminating condition, we look at two elements.Let us choose
        /// the lower median as M = (L + R) / 2.Therefore, if there are two elements, it will choose
        /// AL as the first element.
        /// There are two cases for two elements:
        /// A = [1, 2]
        /// B = [2, 1]
        /// For A, 1 < 2 => AM<AR, and therefore it will set R = M => R = 0.
        /// For B, 2 > 1 => AM > AR, and therefore it will set L = M + 1 => L = 1.
        /// Therefore, it is clear that when L == R, we have found the minimum element.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        private static int FindMinWithoutDuplicate(int[] A)
        {
            int L = 0, R = A.Length - 1;
            while (L < R && A[L] >= A[R])
            {
                int M = (L + R) / 2;
                if (A[M] > A[R])
                {
                    L = M + 1;
                }
                else
                {
                    R = M;
                }
            }
            return A[L];
        }

        /// <summary>
        /// For case where AL == AM == AR, the minimum could be on AM’s left or right side (eg,
        /// [1, 1, 1, 0, 1] or[1, 0, 1, 1, 1]). In this case, we could not discard either subarrays and
        /// therefore such worst case degenerates to the order of O(n).
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        private static int FindMinWithDuplicate(int[] A)
        {
            int L = 0, R = A.Length - 1;
            while (L < R && A[L] >= A[R])
            {
                int M = (L + R) / 2;
                if (A[M] > A[R])
                {
                    L = M + 1;
                }
                else if (A[M] < A[L])
                {
                    R = M;
                }
                else
                { // A[L] == A[M] == A[R]
                    L = L + 1;
                }
            }
            return A[L];
        }

        public static void Test()
        {
            int[] arr_noDup = new int[] { 7, 8, 1, 2, 3, 4, 5, 6 };
            Console.Write("Min Item is : " + FindMinWithoutDuplicate(arr_noDup));

            int[] arr_Dup = new int[] { 1, 1, 0, 1, 1, 1 };
            Console.Write("Min Item is : " + FindMinWithoutDuplicate(arr_Dup));
        }
    }
}
