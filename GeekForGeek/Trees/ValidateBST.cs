using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// First, you must understand the difference between Binary Tree and BST. Binary tree is a
    /// tree data structure in which each node has at most two child nodes.A BST is based on
    /// binary tree, but with the following additional properties:
    /// - The left subtree of a node contains only nodes with keys less than the node’s key.
    /// - The right subtree of a node contains only nodes with keys greater than the node’s key.
    /// - Both the left and right subtrees must also be binary search trees.
    /// </summary>
    public static class ValidateBST
    {
        /// <summary>
        ///         10
        ///        /  \
        ///       5    15
        ///            / \
        ///           6   20
        /// We can avoid examining all nodes of both subtrees in
        /// each pass by passing down the low and high limits from the parent to its children.
        /// Refer back to the binary tree (1) above.As we traverse down the tree from node(10) to
        /// right node(15), we know for sure that the right node’s value fall between 10 and +∞.
        /// Then, as we traverse further down from node(15) to left node(6), we know for sure that
        /// the left node’s value fall between 10 and 15. And since(6) does not satisfy the above
        /// requirement, we can quickly determine it is not a valid BST.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static bool isValidBST(BinaryNodeInt root)
        {
            return valid(root, 0, 0);
        }
        private static bool valid(BinaryNodeInt p, int low, int high)
        {
            if (p == null) return true;
            return (low == 0 || p.Value > low) && (high == 0 || p.Value < high)
            && valid(p.Left, low, p.Value)
            && valid(p.Right, p.Value, high);
        }
    }
}
