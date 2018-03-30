using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Given a singly linked list, find middle of the linked list. 
    /// For example, if given linked list is 1->2->3->4->5 then output should be 3.
    /// If there are even nodes, then there would be two middle nodes, we need to print second middle element.
    /// For example, if given linked list is 1->2->3->4->5->6 then output should be 4.
    /// https://www.geeksforgeeks.org/write-a-c-function-to-print-the-middle-of-the-linked-list/
    /// </summary>
    public static class FindMiddleOfGivenList
    {
        /// <summary>
        /// Traverse linked list using two pointers. 
        /// Move one pointer by one and other pointer by two. 
        /// When the fast pointer reaches end slow pointer will reach middle of the linked list.
        /// </summary>
        /// <param name="head"></param>
        private static void FindMiddleItem(Node head)
        {
            Node slow_ptr = head;
            Node fast_ptr = head;

            if (head != null)
            {
                while (fast_ptr != null && fast_ptr.Next != null)
                {
                    fast_ptr = fast_ptr.Next.Next;
                    slow_ptr = slow_ptr.Next;
                }

                Console.Write("Middle Item: " + slow_ptr.Value);
            }
        }

        private static void FindMiddleItem2(Node head)
        {
            int count = 0;
            Node mid = head;

            while (head != null)
            {
                /* update mid, when 'count' is odd number */
                if (count % 2 == 0)
                    mid = mid.Next;

                ++count;
                head = head.Next;
            }

            /* if empty list is provided */
            if (mid != null)
                Console.Write("Middle Item: " + mid.Value);
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

            FindMiddleItem(list.head);
            FindMiddleItem2(list.head);
        }
    }
}
