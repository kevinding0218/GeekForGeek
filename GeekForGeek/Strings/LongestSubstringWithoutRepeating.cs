using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters. For
    /// example, the longest substring without repeating letters for “abcabcbb” is “abc”, which
    /// the length is 3. For “bbbbb” the longest substring is “b”, with the length of 1.
    /// </summary>
    public static class LongestSubstringWithoutRepeating
    {
        /// <summary>
        /// How can we look up if a character exists in a substring instantaneously? The answer is to
        /// use a simple table to store the characters that have appeared.Make sure you communicate
        /// with your interviewer if the string can have characters other than ‘a’–‘z’. (ie, Digits?
        /// Upper case letter? Does it contain ASCII characters only? Or even unicode character sets?)
        /// 
        /// The next question is to ask yourself what happens when you found a repeated character?
        /// For example, if the string is “abcdcedf”, what happens when you reach the second
        /// appearance of ‘c’?
        /// 
        /// When you have found a repeated character(let’s say at index j), it means that the current
        /// substring(excluding the repeated character of course) is a potential maximum, so update
        /// the maximum if necessary.It also means that the repeated character must have appeared
        /// before at an index i, where i is less than j.
        /// 
        /// Since you know that all substrings that start before or at index i would be less than your
        /// current maximum, you can safely start to look for the next substring with head which
        /// starts exactly at index i + 1.
        /// 
        /// Therefore, you would need two indices to record the head and the tail of the current
        /// substring.Since i and j both traverse at most n steps, the worst case would be 2n steps,
        /// which the runtime complexity must be O(n).
        /// 
        /// Note that the space complexity is constant O(1), even though we are allocating an array.
        /// This is because no matter how long the string is, the size of the array stays the same at 256.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int LengthOfLongestSubstring(String s)
        {
            bool[] exist = new bool[256];
            int i = 0, maxLen = 0;
            for (int j = 0; j < s.Length; j++)
            {
                while (exist[s.ToCharArray()[j]])
                {
                    exist[s.ToCharArray()[i]] = false;
                    i++;
                }
                exist[s.ToCharArray()[j]] = true;
                maxLen = Math.Max(j - i + 1, maxLen);
            }
            return maxLen;
        }

        /// <summary>
        /// The above solution requires at most 2n steps. In fact, it could be optimized to require only
        /// n steps.Instead of using a table to tell if a character exists or not, we could define a
        /// mapping of the characters to its index.Then we can skip the characters immediately
        /// when we found a repeated character.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int LengthOfLongestSubstringIterative(String s)
        {
            int[] charMap = new int[256];
            System.Array.Fill(charMap, -1);
            int i = 0, maxLen = 0;
            for (int j = 0; j < s.Length; j++)
            {
                Console.Write("\ni:" + i + "\tj:" + j);
                Console.Write("\nbefore s.ToCharArray()[j]:" + s.ToCharArray()[j] + "\tcharMap[s.ToCharArray()[j]]:" + charMap[s.ToCharArray()[j]]);
                if (charMap[s.ToCharArray()[j]] >= i)
                {
                    Console.Write("\nDuplicate Char Found which is " + s.ToCharArray()[j] + " at index " + j);
                    i = charMap[s.ToCharArray()[j]] + 1;
                    Console.Write("\ni updated to be " + i + "\n");
                }
                charMap[s.ToCharArray()[j]] = j;
                Console.Write("\nafter s.ToCharArray()[j]:" + s.ToCharArray()[j] + "\tcharMap[s.ToCharArray()[j]] become:" + charMap[s.ToCharArray()[j]]);
                int currentSubStringWithoutDuplicateLength = j - i + 1;
                Console.Write("\ncurrentSubStringWithoutDuplicateLength " + currentSubStringWithoutDuplicateLength + "\n");
                maxLen = Math.Max(currentSubStringWithoutDuplicateLength, maxLen);
            }
            return maxLen;
        }

        public static void Test()
        {
            string str = "abcdcedf";
            //Console.Write("Max length of substring from abcdcedf is " + LengthOfLongestSubstring(str));
            Console.Write("Max length of substring from abcdcedf is " + LengthOfLongestSubstringIterative(str));
        }
    }
}
