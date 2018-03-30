using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given a string s1 and a string s2, write a snippet to say whether s2 is a rotation of s1 using only one call to strstr routine?
    /// (eg given s1 = ABCD and s2 = CDAB, return true, given s1 = ABCD, and s2 = ACBD , return false)
    /// </summary>
    public static class CheckRotationStrings
    {
        /// <summary>
        /// 1. Create a temp string and store concatenation of str1 to str1 in temp.
        ///     temp = str1.str1
        /// 2. If str2 is a substring of temp then str1 and str2 are rotations of each other.
        /// Example:                 
        ///     str1 = "ABACD"
        ///     str2 = "CDABA"
        ///     temp = str1.str1 = "ABACDABACD"
        /// Since str2 is a substring of temp, str1 and str2 are rotations of each other.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        private static bool areRotations(String str1, String str2)
        {
            // There lengths must be same and str2 must be 
            // a substring of str1 concatenated with str1.  
            return (str1.Length == str2.Length) &&
                   ((str1 + str1).IndexOf(str2) != -1);
        }
    }
}
