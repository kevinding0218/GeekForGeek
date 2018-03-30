using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    public static class MaxMinDepthOfBT
    {
        /// <summary>
        /// Given a binary tree, find its maximum depth.
        /// The maximum depth is the number of nodes along the longest path from the root node
        /// down to the farthest leaf node.
        /// 
        //  We could solve this easily using recursion, because each of the left child and right child
        //  of a node is a sub-tree itself.We first compute the max height of left sub-tree, and then
        //  compute the max height of right sub-tree.The maximum depth of the current node is the
        //  greater of the two maximums plus one. For the base case, we look at a tree that is empty,
        //  which we return 0.
        //  Assume that n is the total number of nodes in the tree. The runtime complexity is O(n)
        //  because it traverse each node exactly once. As the maximum depth of a binary tree is
        //  O(log n), the extra space cost is O(log n) due to the extra stack space used by the
        //  recursion.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int MaxDepth(BinaryNodeInt root)
        {
            if (root == null) return 0;
            return Math.Max(MaxDepth(root.Left), MaxDepth(root.Right)) + 1;
        }

        /// <summary>
        /// Given a binary tree, find its minimum depth.
        /// The minimum depth is the number of nodes along the shortest path from the root node
        /// down to the nearest leaf node.
        /// 
        /// Similar to the [Recursion] approach to find the maximum depth, but make sure you
        /// consider these cases:
        /// i.The node itself is a leaf node.The minimum depth is one.
        /// ii.Node that has one empty sub-tree while the other one is non-empty.Return
        /// the minimum depth of that non-empty sub-tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int MinDepth(BinaryNodeInt root)
        {
            if (root == null) return 0;
            if (root.Left == null) return MinDepth(root.Right) + 1;
            if (root.Right == null) return MinDepth(root.Left) + 1;
            return Math.Min(MinDepth(root.Left), MinDepth(root.Right)) + 1;
        }

        /// <summary>
        /// In fact, we could optimize this scenario by doing a breadth-first traversal (also known as
        /// level-order traversal). When we encounter the first leaf node, we immediately stop the
        /// traversal.
        /// We also keep track of the current depth and increment it when we reach the end of level.
        /// 
        /// We know that we have reached the end of level when the current node is the right-most node.
        /// 
        /// Compared to the recursion approach, the breadth-first traversal works well for highly
        /// unbalanced tree because it does not need to traverse all nodes. The worst case is when the
        /// tree is a full binary tree with a total of n nodes. In this case, we have to traverse all nodes.
        /// 
        /// The worst case space complexity is O(n), due to the extra space needed to store current
        /// level nodes in the queue.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int MinDepthBreadthFirst(BinaryNodeInt root)
        {
            if (root == null) return 0;
            Queue<BinaryNodeInt> q = new Queue<BinaryNodeInt>();
            q.Enqueue(root);
            BinaryNodeInt rightMost = root;
            int depth = 1;
            while (q.Count > 0)
            {
                BinaryNodeInt node = q.Dequeue();
                if (node.Left == null && node.Right == null) break;
                if (node.Left != null) q.Enqueue(node.Right);
                if (node.Right != null) q.Enqueue(node.Right);
                if (node == rightMost)
                {
                    depth++;
                    rightMost = (node.Right != null) ? node.Right : node.Left;
                }
            }
            return depth;
        }
    }
}
