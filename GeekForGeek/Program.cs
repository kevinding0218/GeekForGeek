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
            #endregion

            #region String
            //string str = "geeksforgeeks";
            //Console.WriteLine("str before: \t" + str + "\tstr after: \t" + RemoveDuplicateCharInString.removeDupsUsingHash("geeksforgeeks"));
            #endregion

            #region Tree
            ///* Constructed binary tree is
            /* Constructed binary tree is
                  10
                 /  \
               8     2
              / \   /
             3   5 2
            */
            //BinaryNodeInt root = new BinaryNodeInt(10);
            //root.Left = new BinaryNodeInt(8);
            //root.Right = new BinaryNodeInt(2);
            //root.Left.Left = new BinaryNodeInt(3);
            //root.Left.Right = new BinaryNodeInt(5);
            //root.Right.Left = new BinaryNodeInt(2);

            //Console.Write("Sum of all nodes is: " + SumOfAllNodesInBinaryTree.SumOfAllNodes(root));


            //EvaluationExpressionTree.TestEvaluationExpressionTree();
            LevelOrder.TestLevelOrder();
            #endregion

            Console.ReadKey();
        }
    }
}
