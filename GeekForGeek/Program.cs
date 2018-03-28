using GeekForGeek.Array;
using GeekForGeek.Common;
using GeekForGeek.Strings;
using GeekForGeek.Trees;
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
            FindMaxProductSubArray.Test();
            #endregion

            #region Common
            ///Fibonacci
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine("\ni:" + i + "\tFib: " + Fibonacci.GenerateFibNumberNonRecursive(i));
            //    Console.WriteLine("--------------------");
            //}

            ///SumOfFirstNReciprocals
            //string output = SumOfFirstNReciprocals.SumUsingRecursion(5);
            //Console.Write("SumOfFirstNReciprocals of 5: \t" + output);
            //PowerOf2.Test();
            //FindNumberOf1InBinary.Test();
            #endregion

            #region String
            //string str = "geeksforgeeks";
            //Console.WriteLine("str before: \t" + str + "\tstr after: \t" + RemoveDuplicateCharInString.removeDupsUsingHash("geeksforgeeks"));
            //CheckAnagramString.Test();
            //MaxRecurringChar.Test();
            #endregion

            #region Tree
            ///* Constructed binary tree is
            //EvaluationExpressionTree.Test();
            //LevelOrder.Test();
            //TraversalPostOrder.Test();
            #endregion
            Console.Write("\n");
            Console.ReadKey();
        }
    }
}
