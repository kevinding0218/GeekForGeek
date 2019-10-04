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
        private static void DetectLoopInList(Node head)
        {
            Node slow_p = head, fast_p = head;
            while (slow_p != null && fast_p != null && fast_p.Next != null)
            {
                slow_p = slow_p.Next;
                fast_p = fast_p.Next.Next;
                Console.Write("\nslow_p value: " + slow_p.Value + "\tfast_p value: " + fast_p.Value);
                if (fast_p != null && slow_p.Value == fast_p.Value)
                {
                    Console.Write("\nFound loop\n");
                }
            }
            Console.Write("\nNo Found loop\n");
        }

        public static void Test()
        {
            LinkedList list = new LinkedList();
            list.head = new Node(1);
            list.head.Next = new Node(2);
            list.head.Next.Next = new Node(3);
            list.head.Next.Next.Next = new Node(5);
            list.head.Next.Next.Next.Next = new Node(6);
            list.head.Next.Next.Next.Next.Next = list.head.Next;
            //list.head.PrintListFromNode();
            //while(list.head != null)
            //{
            //    Console.Write(list.head.Value + " ");
            //    list.head = list.head.Next;
            //}
            DetectLoopInList(list.head);
        }
    }
}
