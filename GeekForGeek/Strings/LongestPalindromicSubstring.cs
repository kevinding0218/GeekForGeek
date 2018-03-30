using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given a string S, find the longest palindromic substring in S. You may assume that the
    /// maximum length of S is 1000, and there exists one unique longest palindromic substring.
    /// Hint:
    /// First, make sure you understand what a palindrome means.A palindrome is a string
    /// which reads the same in both directions. For example, “aba” is a palindome, “abc” is not.
    /// </summary>
    public static class LongestPalindromicSubstring
    {
        /// <summary>
        /// first think how we can 
        /// avoid unnecessary re-computation in validating palindromes.Consider the case “ababa”.
        /// If we already knew that “bab” is a palindrome, it is obvious that “ababa” must be a
        /// palindrome since the two left and right end letters are the same.
        /// Stated more formally below:
        /// Define P[i, j] ← true iff the substring Si … Sj is a palindrome, otherwise false.
        /// Therefore,
        /// P[i, j] ← (P[i + 1, j - 1] and Si = Sj)
        /// The base cases are:
        /// P[i, i] ← true
        /// P[i, i + 1] ← (Si = Si+1 )
        /// This yields a straight forward DP solution, which we first initialize the one and two
        /// letters palindromes, and work our way up finding all three letters palindromes, and so on…
        /// This gives us a runtime complexity of O(n2) and uses O(n2) space to store the table.
        /// 
        /// In fact, we could solve it in O(n2) time using only constant space.
        /// We observe that a palindrome mirrors around its center.Therefore, a palindrome can be
        /// expanded from its center, and there are only 2n – 1 such centers.
        /// You might be asking why there are 2n – 1 but not n centers? The reason is the center of a
        /// palindrome can be in between two letters.Such palindromes have even number of letters
        /// (such as “abba”) and its center are between the two ‘b’s.
        /// Since expanding a palindrome around its center could take O(n) time, the overall complexity is O(n2).
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string longestPalindrome(String s)
        {
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        private static int expandAroundCenter(String s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s.ToCharArray()[L] == s.ToCharArray()[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }

        public static void Test()
        {
            string str = "abacdfgdcaba";
            Console.Write("Longest Palindromic Substring of " + str + " is: " + longestPalindrome(str));
        }
    }
}
