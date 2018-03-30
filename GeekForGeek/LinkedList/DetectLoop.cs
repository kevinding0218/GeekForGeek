using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Given a linked list, check if the the linked list has loop or not. Below diagram shows a linked list with a loop.
    /// E.g: 123452 --> loop 23452
    /// </summary>
    public static class DetectLoop
    {
        /// <summary>
        /// Traverse linked list using two pointers. 
        /// Move one pointer by one and other pointer by two.  
        /// If these pointers meet at some node then there is a loop.  
        /// If pointers do not meet then linked list doesn’t have loop.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private static int DetectLoopInList(Node head)
        {
            Node slow_p = head, fast_p = head;
            while (slow_p != null && fast_p != null && fast_p.Next != null)
            {
                slow_p = slow_p.Next;
                fast_p = fast_p.Next.Next;
                if (fast_p != null && slow_p.Value == fast_p.Value)
                {
                    Console.Write("Found loop\n");
                    return 1;
                }
            }
            Console.Write("No Found loop\n");
            return 0;
        }

        public static void Test()
        {
            LinkedList list = new LinkedList();
            list.head = new Node(1);
            list.head.Next = new Node(2);
            list.head.Next.Next = new Node(3);
            list.head.Next.Next.Next = new Node(4);

            //list.head.PrintListFromNode();
            DetectLoopInList(list.head);
            list.head.Next.Next.Next.Next = new Node(5);
            list.head.Next.Next.Next.Next.Next = list.head.Next;
            //list.head.PrintListFromNode();
            DetectLoopInList(list.head);
        }
    }
}
