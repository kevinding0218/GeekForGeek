using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Write a method to compute all permutations of a string.
    /// </summary>
    public static class AllPermutationOfString
    {
        /// <summary>
        /// This solution takes O(n!) time, since there are n! permutations.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static ArrayList AllPermutation(String str)
        {
            ArrayList permutes = new ArrayList();
            foreach (char c in str.ToCharArray())
            {
                ArrayList words = AllPermutation(str.Remove(c));
                foreach (var word in words)
                {
                    permutes.Add(c + word.ToString());
                }
            }
            return permutes;
        }
    }
}
