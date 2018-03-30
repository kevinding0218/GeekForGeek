using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given a sorted array of strings which is interspersed with empty strings, write a method to find the start location of a given string.
    /// Example: find “bcd” in [“a”, “”, “”, “”, “”, “b”, “c”, “”, “”, “”, “d”, “”]
    /// https://www.geeksforgeeks.org/search-in-an-array-of-strings-where-non-empty-strings-are-sorted/
    /// </summary>
    public static class FindLocationInEmptyArray
    {
        /// <summary>
        ///  modified Binary Search. Like normal binary search, we compare given str with middle string. 
        ///  If middle string is empty, we find the closest non-empty string x (by linearly searching on both sides). 
        ///  Once we find x, we do standard binary search, 
        ///  i.e., we compare given str with x. 
        ///  If str is same as x, we return index of x. 
        ///  if str is greater, we recur for right half, 
        ///  else we recur for left half.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="str"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        private static int SearchStr(string[] arr, string str, int first, int last)
        {
            if (first > last)
                return -1;

            // Move mid to the middle
            int mid = (last + first) / 2;

            // If mid is empty , find closet non-empty string
            if (arr[mid].Equals(string.Empty))
            {
                // If mid is empty, search in both sides of mid
                // and find the closest non-empty string, and
                // set mid accordingly.
                int left = mid - 1;
                int right = mid + 1;
                while (true)
                {
                    if (left < first && right > last)
                        return -1;
                    if (right <= last && !arr[right].Equals(string.Empty))
                    {
                        mid = right;
                        break;
                    }
                    if (left >= first && !arr[left].Equals(string.Empty))
                    {
                        mid = left;
                        break;
                    }
                    right++;
                    left--;
                }
            }

            // If str is found at mid
            if (String.Compare(str, arr[mid].ToString()) == 0)
                return mid;

            // If str is greater than mid
            if (String.Compare(str, arr[mid].ToString()) < 0)
                return SearchStr(arr, str, mid + 1, last);

            // If str is smaller than mid
            return SearchStr(arr, str, first, mid - 1);
        }

        public static void Test()
        {
            // Input arr of Strings.
            string[] arr = { "for", "", "", "", "geeks", "ide", "", "practice", "", "", "quiz", "", "" };

            // input Search String
            string str = "quiz";
            int n = arr.Length;

            Console.Write(str + " in position: " + SearchStr(arr, str, 0, n - 1));
        }
    }
}
