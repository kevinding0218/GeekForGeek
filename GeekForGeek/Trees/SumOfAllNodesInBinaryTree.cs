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
        public static int SumOfAllNodes(BinaryNodeInt root)
        {
            if (root == null)
                return 0;
            else
                return (root.Value + SumOfAllNodes(root.Left) + SumOfAllNodes(root.Right));
        }
    }
}
