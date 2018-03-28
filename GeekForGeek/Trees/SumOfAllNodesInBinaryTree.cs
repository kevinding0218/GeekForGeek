using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// The idea is to recursively, call left subtree sum, right subtree sum and add their values to current node’s data.
    /// https://www.geeksforgeeks.org/sum-nodes-binary-tree/
    /// </summary>
    public static class SumOfAllNodesInBinaryTree
    {
        private static int SumOfAllNodes(BinaryNodeInt root)
        {
            if (root == null)
                return 0;
            else
                return (root.Value + SumOfAllNodes(root.Left) + SumOfAllNodes(root.Right));
        }

        /* Constructed binary tree is
              10
             /  \
           8     2
          / \   /
         3   5 2
        */
        public static void Test()
        {
            BinaryNodeInt root = new BinaryNodeInt(10);
            root.Left = new BinaryNodeInt(8);
            root.Right = new BinaryNodeInt(2);
            root.Left.Left = new BinaryNodeInt(3);
            root.Left.Right = new BinaryNodeInt(5);
            root.Right.Left = new BinaryNodeInt(2);

            Console.Write("Sum of all nodes is: " + SumOfAllNodesInBinaryTree.SumOfAllNodes(root));
        }
    }
}
