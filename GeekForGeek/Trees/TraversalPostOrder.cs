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
    /// Postorder (Left, Right, Root) : 4 5 2 3 1
    /// </summary>
    public static class TraversalPostOrder
    {
        /// <summary>
        /// Algorithm Postorder(tree)
        /// 1. Traverse the left subtree, i.e., call Postorder(left-subtree)
        /// 2. Traverse the right subtree, i.e., call Postorder(right-subtree)
        /// 3. Visit the root.
        /// https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
        /// </summary>
        /// <param name="node"></param>
        private static void RecursivePostOrder(BinaryNodeInt node)
        {
            if (node == null)
                return;

            // first recur on left subtree
            RecursivePostOrder(node.Left);

            // then recur on right subtree
            RecursivePostOrder(node.Right);

            // now deal with the node
            Console.Write(node.Value + " ");
        }

        private static void IterativePostOrderUsingStack(BinaryNodeInt root)
        {
            Stack<BinaryNodeInt> stack = new Stack<BinaryNodeInt>();

            // Check for empty tree
            if (root == null)
                return;
            stack.Push(root);

            BinaryNodeInt prev = null;
            while (stack.Count > 0)
            {
                BinaryNodeInt current = stack.Peek();

                if (prev == null || prev.Left == current || prev.Right == current)
                {
                    if (current.Left != null)
                        stack.Push(current.Left);
                    else if (current.Right != null)
                        stack.Push(current.Right);
                    else
                    {
                        stack.Pop();
                        Console.Write(current.Value + " ");
                    }
                }
                else if (current.Left == prev)
                {
                    if (current.Right != null)
                        stack.Push(current.Right);
                    else
                    {
                        stack.Pop();
                        Console.Write(current.Value + " ");
                    }
                }
                else if (current.Right == prev)
                {
                    stack.Pop();
                    Console.Write(current.Value + " ");
                }

                prev = current;
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
            RecursivePostOrder(root);
            Console.Write("\n");
            IterativePostOrderUsingStack(root);
        }
    }
}
