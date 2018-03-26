using GeekForGeek.Strings;
using System;

namespace GeekForGeek
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array
            #region Find Duplicate Item and Count in Array
            //FindDuplicateInStringArray.FindDuplicateStringWithCount();

            //FindDuplicateInStringArray.FindDuplicateObjectByPropertyWithCount();

            //int[] arr = { 1, 2, 3, 1, 3, 6, 6 };
            //int arr_size = arr.Length;

            //FindTwoDuplicatesIntAppearTwice.WithEncodeArray(arr, arr_size);

            //arr = new int[] { 1, 6, 3, 1, 3, 6, 6 };
            //FindDuplicateIntAppearN.FindRepeating(arr, arr_size);
            #endregion

            #region Common
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine("\ni:" + i + "\tFib: " + Fibonacci.GenerateFibNumberNonRecursive(i));
            //    Console.WriteLine("--------------------");
            //}
            #endregion

            #region String
            string str = "geeksforgeeks";
            Console.WriteLine("str before: \t" + str + "\tstr after: \t" + RemoveDuplicateCharInString.removeDupsUsingHash("geeksforgeeks"));
            #endregion

            Console.ReadKey();
        }
    }
}
