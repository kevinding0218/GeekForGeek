using System;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Given an array of n elements which contains elements from 0 to n-1, 
    /// with any of these numbers appearing any number of times. 
    /// Find these repeating numbers in O(n) and using only constant memory space.
    /// For example, let n be 7 and array be {1, 2, 3, 1, 3, 6, 6}, the answer should be 1, 3 and 6.
    /// For example, {1, 6, 3, 1, 3, 6, 6} with output 1 3 6
    /// </summary>
    public static class FindDuplicateIntAppearN
    {
        public static void FindRepeating(int[] arr, int size)
        {
            // First check all the values that are
            // present in an array then go to that
            // values as indexes and increment by
            // the size of array
            for (int i = 0; i < size; i++)
            {
                int index = arr[i] % size;
                arr[index] += size;

                Console.Write("i: " + i + "\t");
                for (int j = 0; j < size; j++)
                {
                    //Console.WriteLine();
                    Console.Write(arr[j] + " ");
                }
                Console.WriteLine();
            }


            // Now check which value exists more
            // than once by dividing with the size
            // of array
            for (int i = 0; i < size; i++)
            {
                if ((arr[i] / size) > 1)
                    Console.Write(i + " ");
            }
        }
    }
}
