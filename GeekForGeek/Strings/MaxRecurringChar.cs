using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Write an efficient C function to return maximum occurring character in the input string 
    /// e.g., if input string is “test” then function should return ‘t’.
    /// 
    /// </summary>
    public static class MaxRecurringChar
    {
        const int ASCII_SIZE = 256;
        /// <summary>
        /// Typically, ASCII characters are 256, so we use our Hash array size as 256. 
        /// But if we know that our input string will have characters with value from 0 to 127 only, 
        /// we can limit Hash array size as 128. 
        /// Similarly, based on extra info known about input string, 
        /// the Hash array size can be limited to 26
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static char getMaxOccuringChar(string str)
        {
            // Create array to keep the count of
            // individual characters and 
            // initialize the array as 0
            int[] count = new int[ASCII_SIZE];

            // Construct character count array
            // from the input string.
            int len = str.Length;
            for (int i = 0; i < len; i++)
                count[str[i]]++;

            int max = -1; // Initialize max count
            char result = ' '; // Initialize result

            // Traversing through the string and 
            // maintaining the count of each character
            for (int i = 0; i < len; i++)
            {
                if (max < count[str[i]])
                {
                    max = count[str[i]];
                    result = str[i];
                }
            }

            return result;
        }

        public static void Test()
        {
            Console.Write(getMaxOccuringChar("ageeksforgeeks"));
        }
    }
}
