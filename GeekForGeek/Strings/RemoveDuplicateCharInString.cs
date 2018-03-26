using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekForGeek.Strings
{
    public static class RemoveDuplicateCharInString
    {
        /// <summary>
        ///   1) Sort the elements.
        ///   2) Now in a loop, remove duplicates by comparing the current character with previous character.
        ///   3)  Remove extra characters at the end of the resultant string.
        ///   Input string:  geeksforgeeks
        ///   1) Sort the characters
        ///     eeeefggkkorss
        ///   2) Remove duplicates
        ///     efgkorskkorss
        ///   3) Remove extra characters
        ///     efgkors
        ///   Note that, this method doesn’t keep the original order of the input string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string removeDupsUsingSorted(string str)
        {
            int res_ind = 1, ip_ind = 1;

            // Character array for removal of duplicate characters
            char[] arr = str.ToCharArray();

            /* In place removal of duplicate characters*/
            while (ip_ind != arr.Length)
            {
                if (arr[ip_ind] != arr[ip_ind - 1])
                {
                    arr[res_ind] = arr[ip_ind];
                    res_ind++;
                }
                ip_ind++;

            }

            str = new String(arr);
            return str.Substring(0, res_ind);
        }

        static string removeDups(string str)
        {
            // Sort the character array
            str = String.Concat(str.OrderBy(c => c));

            // Remove duplicates from sorted
            return removeDupsUsingSorted(str);
        }


        public static string removeDupsUsingHash(string str)
        {
            HashSet<char> hs = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
                hs.Add(str.ToCharArray()[i]);

            // print string after deleting duplicate elements
            return string.Join("", hs);
        }
    }
}
