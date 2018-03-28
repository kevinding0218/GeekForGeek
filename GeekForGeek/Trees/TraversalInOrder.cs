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
    /// Inorder (Left, Root, Right) : 4 2 5 1 3
    /// </summary>
    public static class TraversalInOrder
    {
        /* Given a binary tree, print its nodes in inorder*/
        /// <summary>
        /// Algorithm Inorder(tree)
        /// 1. Traverse the left subtree, i.e., call Inorder(left-subtree)
        /// 2. Visit the root.
        /// 3. Traverse the right subtree, i.e., call Inorder(right-subtree)
        /// https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
        /// </summary>
        /// <param name="node"></param>
        private static void RecursiveInOrder(BinaryNodeInt node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            RecursiveInOrder(node.Left);

            /* then print the data of node */
            Console.Write(node.Value + " ");

            /* now recur on right child */
            RecursiveInOrder(node.Right);
        }

        /// <summary>
        /// 1) Create an empty stack S.
        /// 2) Initialize current node as root
        /// 3) Push the current node to S and set current = current->left until current is NULL
        /// 4) If current is NULL and stack is not empty then
        ///     a) Pop the top item from stack.
        ///     b) Print the popped item, set current = popped_item->right
        ///     c) Go to step 3.
        /// 5) If current is NULL and stack is empty then we are done.
        /// https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
        /// </summary>
        /// <param name="root"></param>
        private static void IterativeInOrderUsingStack(BinaryNodeInt root)
        {
            if (root == null)
                return;

            Stack<BinaryNodeInt> stack = new Stack<BinaryNodeInt>();

            while (root != null)
            {
                stack.Push(root);
                root = root.Left;
            }

            while (stack.Count > 0)
            {
                root = stack.Pop();
                Console.Write(root.Value + " ");
                if (root.Right != null)
                {
                    root = root.Right;

                    while (root != null)
                    {
                        stack.Push(root);
                        root = root.Left;
                    }
                }
            }
        }

        /// <summary>
        /// 1. Initialize current as root
        /// 2. While current is not NULL
        /// If current does not have left child
        ///     a) Print current’s data
        ///     b) Go to the right, i.e., current = current->right
        /// Else
        ///     a) Make current as right child of the rightmost node in current's left subtree
        ///     b) Go to this left child, i.e., current = current->left
        /// https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion-and-without-stack/
        /// </summary>
        /// <param name="root"></param>
        private static void IterativeInOrderUsingNonStack(BinaryNodeInt root)
        {
            if (root == null)
                return;

            BinaryNodeInt current, pre;
            current = root;
            while (current != null)
            {
                if (current.Left == null)
                {
                    Console.Write(current.Value + " ");
                    current = current.Right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pre = current.Left;
                    while (pre.Right != null && pre.Right != current)
                    {
                        pre = pre.Right;
                    }

                    /* Make current as right child of its inorder predecessor */
                    if (pre.Right == null)
                    {
                        pre.Right = current;
                        current = current.Left;
                    }
                    /* Revert the changes made in if part to restore the 
                    original tree i.e.,fix the right child of predecssor*/
                    else
                    {
                        pre.Right = null;
                        Console.Write(current.Value + " ");
                        current = current.Right;
                    }   /* End of if condition pre->right == NULL */
                }   /* End of if condition current->left == NULL*/
            }

        }

        public static void Test()
        {
            BinaryNodeInt root = new BinaryNodeInt(1);
            root.Left = new BinaryNodeInt(2);
            root.Right = new BinaryNodeInt(3);
            root.Left.Left = new BinaryNodeInt(4);
            root.Left.Right = new BinaryNodeInt(5);
            root.Left.Right.Left = new BinaryNodeInt(6);

            // 1 2 4 5 3 
            Console.Write("Inorder traversal of binary tree is \n");
            RecursiveInOrder(root);
            Console.Write("\n");
            IterativeInOrderUsingStack(root);
            Console.Write("\n");
            IterativeInOrderUsingNonStack(root);
        }
    }
}
