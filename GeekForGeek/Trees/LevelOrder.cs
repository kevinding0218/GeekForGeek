using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    ///         1
    ///        / \
    ///       2   3
    ///      / \  
    ///     4   5
    /// Levelorder: 1 2 3 4 5
    /// https://www.geeksforgeeks.org/level-order-tree-traversal/
    /// </summary>
    public static class LevelOrder
    {
        /// <summary>
        /// Algorithm:
        /// There are basically two functions in this method.One is to print all nodes at a given level(printGivenLevel), 
        /// and other is to print level order traversal of the tree(printLevelorder). 
        /// printLevelorder makes use of printGivenLevel to print nodes at all levels one by one starting from root.
        /// /*Function to print level order traversal of tree*/
        /// printLevelorder(tree)
        /// for d = 1 to height(tree)
        ///     printGivenLevel(tree, d);
        /// /*Function to print all nodes at a given level*/
        /// printGivenLevel(tree, level)
        /// if tree is NULL then return;
        /// if level is 1, then
        ///     print(tree->data);
        /// else if level greater than 1, then
        ///     printGivenLevel(tree->left, level-1);
        ///     printGivenLevel(tree->right, level-1);
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /* Compute the "height" of a tree -- the number of
        nodes along the longest path from the root node
        down to the farthest leaf node.*/
        private static int Height(BinaryNodeInt root)
        {
            if (root == null)
                return 0;
            else
            {
                /* compute  height of each subtree */
                int lheight = Height(root.Left);
                int rheight = Height(root.Right);

                /* use the larger one */
                if (lheight > rheight)
                    return (lheight + 1);
                else return (rheight + 1);
            }
        }

        /* Print nodes at the given level */
        private static void PrintGivenLevel(BinaryNodeInt root, int level)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(root.Value + " ");
            else if (level > 1)
            {
                PrintGivenLevel(root.Left, level - 1);
                PrintGivenLevel(root.Right, level - 1);
            }
        }

        /* function to print level order traversal of tree*/
        private static void PrintLevelOrder(BinaryNodeInt root)
        {
            int h = Height(root);
            int i;
            for (i = 1; i <= h; i++)
                PrintGivenLevel(root, i);
        }

        // Time Complexity: O(n^2) in worst case. For a skewed tree, 
        // printGivenLevel() takes O(n) time where n is the number of nodes in the skewed tree.
        // So time complexity of printLevelOrder() is O(n) + O(n-1) + O(n-2) + .. + O(1) which is O(n^2).

        // Method 2: Use Queue
        ///Algorithm:
        ///For each node, first the node is visited and then it’s child nodes are put in a FIFO queue.
        ///
        /// printLevelorder(tree)
        /// 1) Create an empty queue q
        /// 2) temp_node = root /*start from root*/
        /// 3) Loop while temp_node is not NULL
        ///     a) print temp_node->data.
        ///     b) Enqueue temp_node’s children(first left then right children) to 
        ///     c) Dequeue a node from q and assign it’s value to temp_node

        /// <summary>
        /// Given a binary tree. Print its nodes in level order using array for implementing queue
        /// </summary> 
        private static void PrintLevelOrderUsingQueue(BinaryNodeInt root)
        {
            Queue<BinaryNodeInt> queue = new Queue<BinaryNodeInt>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                BinaryNodeInt tempNode = queue.Dequeue();
                Console.Write(tempNode.Value + " ");

                /*Enqueue left child */
                if (tempNode.Left != null)
                {
                    queue.Enqueue(tempNode.Left);
                }

                /*Enqueue right child */
                if (tempNode.Right != null)
                {
                    queue.Enqueue(tempNode.Right);
                }
            }
        }

        public static void TestLevelOrder()
        {
            BinaryNodeInt root = new BinaryNodeInt(1);
            root.Left = new BinaryNodeInt(2);
            root.Right = new BinaryNodeInt(3);
            root.Left.Left = new BinaryNodeInt(4);
            root.Left.Right = new BinaryNodeInt(5);

            PrintLevelOrderUsingQueue(root);
        }
    }
}
