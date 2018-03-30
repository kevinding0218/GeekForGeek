using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Given a singly linked list, write a function to swap elements pairwise. 
    /// For example, if the linked list is 1->2->3->4->5 then the function should change it to 2->1->4->3->5, 
    /// and if the linked list is 1->2->3->4->5->6 then the function should change it to 2->1->4->3->6->5.
    /// https://www.geeksforgeeks.org/pairwise-swap-elements-of-a-given-linked-list/
    /// </summary>
    public static class PairwiseSwapEementsInList
    {
        /// <summary>
        /// Start from the head node and traverse the list. 
        /// While traversing swap data of each node with its next node’s data.
        /// </summary>
        /// <param name="head"></param>
        private static void PairwiseSwap(Node head)
        {
            Node temp = head;

            while (temp != null && temp.Next != null)
            {
                /* Swap the data */
                int k = temp.Value;
                temp.Value = temp.Next.Value;
                temp.Next.Value = k;
                temp = temp.Next.Next;
            }
        }

        public static void Test()
        {
            LinkedList list = new LinkedList();
            list.head = new Node(1);
            list.head.Next = new Node(2);
            list.head.Next.Next = new Node(3);
            list.head.Next.Next.Next = new Node(4);
            list.head.Next.Next.Next.Next = new Node(5);
            list.head.Next.Next.Next.Next.Next = new Node(6);

            PairwiseSwap(list.head);
            list.head.PrintListFromNode();
        }
    }
}
