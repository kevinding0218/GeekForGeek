using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    public static class ReverseArrayItem
    {
        private static void ReverseArray(int[] arr, int start, int end)
        {
            int temp;
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        /// <summary>
        /// https://www.geeksforgeeks.org/reverse-an-array-without-affecting-special-characters/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private static void ReserveArrayExcludeSpecialChar(char[] arr, int start, int end)
        {
            // Traverse string from both ends until
            // 'l' and 'r'
            while (start < end)
            {
                // Ignore special characters
                if (!IsAlphabet(arr[start]))
                    start++;
                else if (!IsAlphabet(arr[end]))
                    end--;

                else // Both str[l] and str[r] are not spacial
                {
                    char temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                    start++;
                    end--;
                }
            }
        }

        // Returns true if x is an aplhabatic character, false otherwise
        static bool IsAlphabet(char x)
        {
            return ((x >= 'A' && x <= 'Z') ||
                     (x >= 'a' && x <= 'z'));
        }

        public static void Test()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ReverseArray(array, 0, array.Length - 1);
            foreach (var item in array)
                Console.Write(item + " ");
        }
    }
}
