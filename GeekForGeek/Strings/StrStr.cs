using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Implement strstr(). Returns the index of the first occurrence of needle in haystack, or –1
    /// if needle is not part of haystack.
    /// </summary>
    public static class StrStr
    {
        /// <summary>
        /// The brute force method is straightforward to implement. We scan the needle with the
        /// haystack from its first position and start matching all subsequent letters one by one.If one
        /// of the letters does not match, we start over again with the next position in the haystack.
        /// Assume that n = length of haystack and m = length of needle, then the runtime
        /// complexity is O(nm).
        /// Have you considered these scenarios?
        /// i. needle or haystack is empty.If needle is empty, always return 0. If haystack is 
        /// empty, then there will always be no match (return –1) unless needle is also empty which 0 is returned.
        /// ii.needle’s length is greater than haystack’s length.Should always return –1.
        /// iii.needle is located at the end of haystack. For example, “aaaba” and “ba”. Catch possible off-by-one errors.
        /// iv.needle occur multiple times in haystack.For example, “mississippi” and “issi”. It should return index 2 as the first match of “issi”.
        /// v.Imagine two very long strings of equal lengths = n, haystack = “aaa…aa” and needle = “aaa…ab”. You should not do more than n character comparisons, or
        /// else your code will get Time Limit Exceeded in OJ.
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        private static int IfStringContains(String haystack, String needle)
        {
            for (int i = 0; ; i++)
            {
                for (int j = 0; ; j++)
                {
                    if (j == needle.Length) return i;
                    if (i + j == haystack.Length) return -1;
                    if (needle.ToCharArray()[j] != haystack.ToCharArray()[i + j]) break;
                }
            }
        }

        public static void Test()
        {
            Console.Write("Position of strstr: " + IfStringContains("abababa", "bab"));
        }
    }
}
