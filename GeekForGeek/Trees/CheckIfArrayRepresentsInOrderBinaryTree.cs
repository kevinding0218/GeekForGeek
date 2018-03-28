using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// The task is to check if it is Inorder traversal of any Binary Search Tree or not. 
    /// Print “Yes” if it is Inorder traversal of any Binary Search Tree else print “No”.
    /// https://www.geeksforgeeks.org/check-array-represents-inorder-binary-search-tree-not/
    /// </summary>
    public static class CheckIfArrayRepresentsInOrderBinaryTree
    {
        // Function that returns true if array is Inorder
        // traversal of any Binary Search Tree or not.
        // The idea is to use the fact that the inorder traversal of Binary Search Tree is sorted. 
        // So, just check if given array is sorted or not.
        private static bool IsInorder(int[] arr, int n)
        {
            // Array has one or no element
            if (n == 0 || n == 1)
                return true;

            for (int i = 1; i < n; i++)

                // Unsorted pair found
                if (arr[i - 1] > arr[i])
                    return false;

            // No unsorted pair found
            return true;
        }
    }
}
