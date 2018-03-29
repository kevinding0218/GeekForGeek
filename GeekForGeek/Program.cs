using GeekForGeek.Array;
using GeekForGeek.Common;
using GeekForGeek.LinkedList;
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
            //FindDuplicateIntAppearN.Test();
            //FindMaxProductSubArray.Test();
            //Shuffle2nIntegers.Test();
            FindPairOfSum.Test();
            #endregion

            #region Common
            //Fibonacci.Test();
            ///SumOfFirstNReciprocals.Test()
            //PowerOf2.Test();
            //FindNumberOf1InBinary.Test();
            //CountNumOf2s.Test();
            //CoinChange.Test();
            #endregion

            #region String
            //RemoveDuplicateCharInString.Test();
            //CheckAnagramString.Test();
            //MaxRecurringChar.Test();
            #endregion

            #region Tree
            ///* Constructed binary tree is
            //EvaluationExpressionTree.Test();
            //LevelOrder.Test();
            //TraversalPostOrder.Test();
            #endregion

            #region LinkedList
            //ReverseList.Test();
            #endregion

            Console.Write("\n");
            Console.ReadKey();
        }
    }
}
