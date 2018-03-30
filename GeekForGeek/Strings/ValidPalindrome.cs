using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
    /// For example,
    /// "A man a plan a canal Panama" is a palindrome.
    /// "race a car" is not a palindrome.
    /// Leetcode    Easy + Medium
    /// </summary>
    public static class ValidPalindrome
    {
        private static bool IsPalindrome(String s)
        {
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                while (i < j && (s.ToCharArray()[i] == ' ')) i++;
                while (i < j && (s.ToCharArray()[j] == ' ')) j--;
                if (s.ToCharArray()[i] != s.ToCharArray()[j])
                {
                    return false;
                }
                i++; j--;
            }
            return true;
        }

        public static void Test()
        {
            string str = "race a car";
            if (IsPalindrome(str.ToLower()))
                Console.Write(str + " is a valid palindrome");
            else
                Console.Write(str + " is not a valid palindrome");
        }
    }
}
