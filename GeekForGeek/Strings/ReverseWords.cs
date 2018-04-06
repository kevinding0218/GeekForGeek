using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given an input string s, reverse the string word by word.
    /// For example, given s = "the sky is blue", return "blue is sky the".
    /// </summary>
    public static class ReverseWords
    {
        /// <summary>
        /// First pass to split the string by spaces into an
        /// array of words, then second pass to extract the words in reversed order.
        /// We can do better in one-pass.While iterating the string in reverse order, we keep track of
        /// a word’s begin and end position.When we are at the beginning of a word, we append it.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static String ReverseWordsWithLeadingTrailingSpace(String s)
        {
            StringBuilder reversed = new StringBuilder();
            int j = s.Length;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s.ToCharArray()[i] == ' ')
                {
                    j = i;
                }
                else if (i == 0 || s.ToCharArray()[i - 1] == ' ')
                {
                    if (reversed.Length != 0)
                    {
                        reversed.Append(' ');
                    }
                    reversed.Append(s.Substring(i, j - i));
                }
            }
            return reversed.ToString();
        }

        /// <summary>
        /// Let us indicate the ith word by wi and its reversal as wi′. Notice that when you reverse a
        /// word twice, you get back the original word.That is, (wi′)′ = wi.
        /// The input string is w1 w2 … wn.If we reverse the entire string, it becomes wn′ … w2′ w1′.
        /// Finally, we reverse each individual word and it becomes wn … w2 w1.Similarly, the same
        /// result could be reached by reversing each individual word first, and then reverse the entire string.
        /// e.g:
        /// the sky is blue
        /// --> eulb si yks eht
        /// --> blue si yks eht
        /// --> blue is yks eht
        /// --> blue is sky eht
        /// --> blue is sky the
        /// </summary>
        /// <param name="s"></param>
        private static void ReverseWordsWithoutLeadingSpace(char[] s)
        {
            Console.Write("\nReverseWordsWithoutLeadingSpace before: " + String.Join(' ', s).ToString());
            Console.Write("\n-----------------------------");
            reverse(s, 0, s.Length);
            for (int i = 0, j = 0; j <= s.Length; j++)
            {
                if (j == s.Length || s[j] == ' ')
                {
                    reverse(s, i, j);
                    i = j + 1;
                }
            }
            Console.Write("\nReverseWordsWithoutLeadingSpace after: " + String.Join(' ', s).ToString());
        }

        private static void reverse(char[] s, int begin, int end)
        {
            Console.Write("\nbegin: " + begin + "\tend: " + end);
            Console.Write("\nreverse before: " + String.Join(' ', s).ToString());
            for (int i = 0; i < (end - begin) / 2; i++)
            {
                Console.Write("\nswap s[begin + i] " + s[begin + i] + " with s[end - i - 1] " + s[end - i - 1]);
                char temp = s[begin + i];
                s[begin + i] = s[end - i - 1];
                s[end - i - 1] = temp;
            }
            Console.Write("\nreverse after: " + String.Join(' ', s).ToString());
            Console.Write("\n-----------------------------");
        }


        public static void Test()
        {
            string str = "the sky is blue";
            //Console.Write("After reverse string become: " + ReverseWordsWithLeadingTrailingSpace(str));
            ReverseWordsWithoutLeadingSpace(str.ToCharArray());
        }
    }
}
