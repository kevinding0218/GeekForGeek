using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// Given a simple expression tree, consisting of basic binary operators
    /// i.e., + , – ,* and / and some integers, evaluate the expression tree.
    ///      +
    ///    /   \
    ///   *     -
    ///  / \   / \
    /// 5  4 100 20
    /// result: 5*4 + (100-20) = 100
    ///      +
    ///    /   \
    ///   *     -
    ///  / \   / \
    /// 5   4 100 /
    ///          / \
    ///         20  2
    /// result: 5 * 4 + (100 - (20/2)) = 110
    /// https://www.geeksforgeeks.org/evaluation-of-expression-tree/
    /// </summary>
    public static class EvaluationExpressionTree
    {
        private static int EvaluateTree(BinaryNodeExpression root)
        {
            // empty tree
            if (root == null)
                return 0;

            // leaf node i.e, an integer
            if (root.Left == null && root.Right == null)
                return Convert.ToInt32(root.Value);

            // Evaluate left subtree
            int l_val = EvaluateTree(root.Left);

            // Evaluate right subtree
            int r_val = EvaluateTree(root.Right);

            // Check which operator to apply
            if (root.Value == "+")
                return l_val + r_val;

            if (root.Value == "-")
                return l_val - r_val;

            if (root.Value == "*")
                return l_val * r_val;

            return l_val / r_val;
        }

        public static void Test()
        {
            ///      +
            ///    /   \
            ///   *     -
            ///  / \   / \
            /// 5  4 100 20
            /// result: 5*4 + (100-20) = 100
            BinaryNodeExpression root = new BinaryNodeExpression("+");
            root.Left = new BinaryNodeExpression("*");
            root.Left.Left = new BinaryNodeExpression("5");
            root.Left.Right = new BinaryNodeExpression("4");
            root.Right = new BinaryNodeExpression("-");
            root.Right.Left = new BinaryNodeExpression("100");
            root.Right.Right = new BinaryNodeExpression("20");

            Console.Write("Tree 1 result: " + EvaluateTree(root));

            BinaryNodeExpression root2 = new BinaryNodeExpression("+");
            root2.Left = new BinaryNodeExpression("*");
            root2.Left.Left = new BinaryNodeExpression("5");
            root2.Left.Right = new BinaryNodeExpression("4");
            root2.Right = new BinaryNodeExpression("-");
            root2.Right.Left = new BinaryNodeExpression("100");
            root2.Right.Right = new BinaryNodeExpression("/");
            root2.Right.Right.Left = new BinaryNodeExpression("20");
            root2.Right.Right.Right = new BinaryNodeExpression("2");
            Console.Write("\nTree 2 result: " + EvaluateTree(root2));
        }
    }
}
