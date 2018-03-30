using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// Given a binary tree, determine if it is height-balanced.
    /// For this problem, a height-balanced binary tree is defined as a binary tree in which the
    /// depth of the two subtrees of every node never differs by more than 1.
    /// </summary>
    public static class CheckIfBalancedBinaryTree
    {
        private static bool isBalanced(BinaryNodeInt root)
        {
            return MaxDepth(root) != -1;
        }

        /// <summary>
        /// We could avoid the recalculation by passing the depth bottom-up.We use a sentinel value –1
        /// to represent that the tree is unbalanced so we could avoid unnecessary calculations.
        /// 
        /// In each step, we look at the left subtree’s depth(L), and ask: “Is the left subtree
        /// unbalanced?” If it is indeed unbalanced, we return –1 right away.Otherwise, L represents
        /// the left subtree’s depth. We then repeat the same process for the right subtree’s depth (R).
        /// 
        /// We calculate the absolute difference between L and R.If the subtrees’ depth difference is
        /// less than one, we could return the height of the current node, otherwise return –1 meaning
        /// the current tree is unbalanced.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int MaxDepth(BinaryNodeInt root)
        {
            if (root == null) return 0;
            int L = MaxDepth(root.Left);
            if (L == -1) return -1;
            int R = MaxDepth(root.Right);
            if (R == -1) return -1;
            return (Math.Abs(L - R) <= 1) ? (Math.Max(L, R) + 1) : -1;
        }

    }
}
