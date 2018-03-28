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
    /// Preorder (Root, Left, Right) : 1 2 4 5 3
    /// </summary>
    public static class TraversalPreOrder
    {
        /// <summary>
        /// Algorithm Preorder(tree)
        /// 1. Visit the root.
        /// 2. Traverse the left subtree, i.e., call Preorder(left-subtree)
        /// 3. Traverse the right subtree, i.e., call Preorder(right-subtree)
        /// https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
        /// </summary>
        private static void RecursivePreOrder(BinaryNodeInt node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.Write(node.Value + " ");

            /* then recur on left sutree */
            RecursivePreOrder(node.Left);

            /* now recur on right subtree */
            RecursivePreOrder(node.Right);
        }

        /// <summary>
        /// PreOrder: root - left - right
        /// To convert an inherently recursive procedures to iterative, 
        /// we need an explicit stack. Following is a simple stack based iterative process to print Preorder traversal.
        /// 1) Create an empty stack nodeStack and push root node to stack.
        /// 2) Do following while nodeStack is not empty.
        /// ….a) Pop an item from stack and print it.
        /// ….b) Push right child of popped item to stack
        /// ….c) Push left child of popped item to stack
        /// 
        /// Right child is pushed before left child to make sure that left subtree is processed first.
        /// https://www.geeksforgeeks.org/iterative-preorder-traversal/ 
        /// </summary>
        /// <param name="root"></param>
        private static void IterativePreOrderUsingStack(BinaryNodeInt root)
        {
            // Base Case
            if (root == null)
                return;

            // Create an empty stack and push root to it
            Stack<BinaryNodeInt> nodeStack = new Stack<BinaryNodeInt>();
            nodeStack.Push(root);

            /* Pop all items one by one. Do following for every popped item
                a) print it
                b) push its right child
                c) push its left child
            Note that right child is pushed first so that left is processed first */
            while (nodeStack.Count > 0)
            {
                // Pop the top item from stack and print it
                BinaryNodeInt node = nodeStack.Peek();
                Console.Write(node.Value + " ");
                nodeStack.Pop();

                // Push right and left children of the popped node to stack
                if (node.Right != null)
                    nodeStack.Push(node.Right);

                if (node.Left != null)
                    nodeStack.Push(node.Left);
            }
        }

        public static void Test()
        {
            BinaryNodeInt root = new BinaryNodeInt(1);
            root.Left = new BinaryNodeInt(2);
            root.Right = new BinaryNodeInt(3);
            root.Left.Left = new BinaryNodeInt(4);
            root.Left.Right = new BinaryNodeInt(5);

            // 1 2 4 5 3 
            Console.Write("Preorder traversal of binary tree is \n");
            RecursivePreOrder(root);
            Console.Write("\n");
            IterativePreOrderUsingStack(root);
        }
    }
}
