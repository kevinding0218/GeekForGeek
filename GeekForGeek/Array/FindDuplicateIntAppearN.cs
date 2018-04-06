using System;

namespace GeekForGeek.Array
{
    /// <summary>
    /// Given an array of n elements which contains elements from 0 to n-1, 
    /// with any of these numbers appearing any number of times. 
    /// Find these repeating numbers in O(n) and using only constant memory space.
    /// For example, let n be 7 and array be {1, 2, 3, 1, 3, 6, 6}, the answer should be 1, 3 and 6.
    /// For example, {1, 6, 3, 1, 3, 6, 6} with output 1 3 6
    /// https://www.geeksforgeeks.org/duplicates-array-using-o1-extra-space-set-2/
    /// </summary>
    public static class FindDuplicateIntAppearN
    {
        /// <summary>
        /// 1- Traverse the given array from i= 0 to n-1 elements
        /// Go to index arr[i]%n and increment its value by n.
        /// 3- Now traverse the array again and print all those
        /// indexes i for which arr[i]/n is greater than 1.
        /// 
        /// This approach works because all elements are in range
        /// from 0 to n-1 and arr[i]/n would be greater than 1
        /// only if a value "i" has appeared more than once.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        public static void FindRepeating(int[] arr, int size)
        {
            // First check all the values that are
            // present in an array then go to that
            // values as indexes and increment by
            // the size of array
            for (int i = 0; i < size; i++)
            {
                int index = arr[i] % size;
                Console.Write("\n------------------------");
                Console.Write("\ni: " + i + "\tarr[" + i + "] is " + arr[i] + "\tindex:" + index + "\tarr[index]:" + arr[index] + "\t");
                arr[index] += size;
                Console.Write("\narr[index]:" + arr[index] + "\n");
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

        public static void Test()
        {
            var arr = new int[] { 1, 2, 3, 4, 4 };
            foreach (var n in arr)
            {
                Console.Write(n + " ");
            }
            FindRepeating(arr, arr.Length);
        }
    }
}
