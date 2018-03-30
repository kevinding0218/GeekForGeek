using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    public static class FindItemInNRotatedSortedArray
    {
        /// <summary>
        /// A is the array. l and u are lower and upper indexes of the array. 
        /// x is the key that we want to search.
        /// We can do this with a modification of binary search.
        /// You may observe that the above function doesn’t 
        /// give you an efficient result in case of duplicate elements.However, if your array
        /// has duplicate entries then we can’t do better than O(n) which is as good as linear search.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="l"></param>
        /// <param name="u"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int FindItemInRotatedSortedArray(int[] a, int l, int u, int x)
        {
            while (l <= u)
            {
                int m = (l + u) / 2;
                if (x == a[m])
                {
                    return m;
                }
                else if (a[l] <= a[m])
                {
                    if (x > a[m])
                    {
                        l = m + 1;
                    }
                    else if (x >= a[l])
                    {
                        u = m - 1;
                    }
                    else
                    {
                        l = m + 1;
                    }
                }
                else if (x < a[m]) u = m - 1;
                else if (x <= a[u]) l = m + 1;
                else u = m - 1;
            }
            return -1;
        }

        public static void Test()
        {
            int[] a = new int[] { 5, 6, 7, 8, 1, 2, 3, 4 };
            Console.Write("Item 3 is " + FindItemInRotatedSortedArray(a, 0, 7, 3));
        }
    }
}
