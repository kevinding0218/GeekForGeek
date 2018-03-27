using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/
    ///         1
    ///        / \
    ///       2   3
    ///      / \  
    ///     4   5
    /// Inorder (Left, Root, Right) : 4 2 5 1 3
    /// Preorder (Root, Left, Right) : 1 2 4 5 3
    /// Postorder (Left, Right, Root) : 4 5 2 3 1
    /// </summary>
    public static class TraversalTree
    {

        /* Given a binary tree, print its nodes in inorder*/
        /// <summary>
        /// Algorithm Inorder(tree)
        /// 1. Traverse the left subtree, i.e., call Inorder(left-subtree)
        /// 2. Visit the root.
        /// 3. Traverse the right subtree, i.e., call Inorder(right-subtree)
        /// </summary>
        /// <param name="node"></param>
        private static void PrintInOrder(BinaryNodeInt node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInOrder(node.Left);

            /* then print the data of node */
            Console.Write(node.Value + " ");

            /* now recur on right child */
            PrintInOrder(node.Right);
        }

        /// <summary>
        /// Algorithm Preorder(tree)
        /// 1. Visit the root.
        /// 2. Traverse the left subtree, i.e., call Preorder(left-subtree)
        /// 3. Traverse the right subtree, i.e., call Preorder(right-subtree)
        /// </summary>
        private static void PrintPreOrder(BinaryNodeInt node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.Write(node.Value + " ");

            /* then recur on left sutree */
            PrintPreOrder(node.Left);

            /* now recur on right subtree */
            PrintPreOrder(node.Right);
        }

        /// <summary>
        /// Algorithm Postorder(tree)
        /// 1. Traverse the left subtree, i.e., call Postorder(left-subtree)
        /// 2. Traverse the right subtree, i.e., call Postorder(right-subtree)
        /// 3. Visit the root.
        /// </summary>
        /// <param name="node"></param>
        private static void PrintPostOrder(BinaryNodeInt node)
        {
            if (node == null)
                return;

            // first recur on left subtree
            PrintPostOrder(node.Left);

            // then recur on right subtree
            PrintPostOrder(node.Right);

            // now deal with the node
            Console.Write(node.Value + " ");
        }

        /// <summary>
        ///     1
        ///    / \
        ///   2   3
        ///  / \
        /// 4   5
        /// </summary>
        public static void TestTraversalOrder()
        {
            BinaryNodeInt root = new BinaryNodeInt(1);
            root.Left = new BinaryNodeInt(2);
            root.Right = new BinaryNodeInt(3);
            root.Left.Left = new BinaryNodeInt(4);
            root.Left.Right = new BinaryNodeInt(5);

            // 1 2 4 5 3 
            Console.Write("Preorder traversal of binary tree is \n");
            PrintPreOrder(root);


            // 4 2 5 1 3 
            Console.Write("\nInorder traversal of binary tree is \n");
            PrintInOrder(root);

            // 4 5 2 3 1
            Console.Write("\nPostorder traversal of binary tree is \n");
            PrintPostOrder(root);
        }
    }
}
