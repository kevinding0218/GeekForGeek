using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Write a function to check whether two given strings are anagram of each other or not. 
    /// An anagram of a string is another string that contains same characters, 
    /// only the order of characters can be different. 
    /// For example, “abcd” and “dabc” are anagram of each other.
    /// https://www.geeksforgeeks.org/check-whether-two-strings-are-anagram-of-each-other/
    /// </summary>
    public static class CheckAnagramString
    {
        /// <summary>
        /// 1) Sort both strings
        /// 2) Compare the sorted strings
        /// O（NlogN)
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private static bool UseSorting(string s1, string s2)
        {
            char[] char1 = s1.ToLower().ToCharArray();
            char[] char2 = s2.ToLower().ToCharArray();

            if (char1.Length != char2.Length)
                return false;

            System.Array.Sort(char1);
            System.Array.Sort(char2);

            return char1.ToString() == char2.ToString();
        }

        const int NO_OF_CHARS = 256;
        private static bool UseStorage(string s1, string s2)
        {
            // Create 2 count arrays and initialize
            // all values as 0
            int[] count1 = new int[NO_OF_CHARS];
            System.Array.Fill(count1, 0);
            int[] count2 = new int[NO_OF_CHARS];
            System.Array.Fill(count2, 0);
            int i;

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (i = 0; i < s1.ToCharArray().Length && i < s2.ToCharArray().Length; i++)
            {
                count1[s1.ToCharArray()[i]]++;
                count2[s2.ToCharArray()[i]]++;
            }

            // If both strings are of different length.
            // Removing this condition will make the program 
            // fail for strings like "aaca" and "aca"
            if (s1.ToCharArray().Length != s2.ToCharArray().Length)
                return false;

            // Compare count arrays
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != count2[i])
                    return false;

            return true;
        }

        public static void Test()
        {
            if (UseStorage("ageeksforgeeks", "forgeeksgeeksa"))
                Console.Write("The two strings are" +
                                   "anagram of each other");
            else
                Console.Write("The two strings are not" +
                                   " anagram of each other");
        }
    }
}
