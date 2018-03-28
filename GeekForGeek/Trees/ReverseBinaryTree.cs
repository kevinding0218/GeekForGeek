using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// reverse a general binary tree, like flip it from right to left.
    /// So for example if we had the binary tree
    ///         6
    ///       /   \
    ///      3     4
    ///     / \   / \
    ///    7   3 8   1
    /// Reversing it would create
    ///     6
    ///   /   \
    ///  4     3
    /// / \   / \
    ///1   8 3   7
    /// </summary>
    public static class ReverseBinaryTree
    {
        private static void ReverseTree(BinaryNodeInt root)
        {
            if (root == null)
            {
                return;
            }

            // swap root.left with root.right
            BinaryNodeInt temp = root.Right;
            root.Right = root.Left;
            root.Left = temp;

            ReverseTree(root.Left);

            ReverseTree(root.Right);
        }
    }
}
