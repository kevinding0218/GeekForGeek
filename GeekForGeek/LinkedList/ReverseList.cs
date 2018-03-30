using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Given pointer to the head node of a linked list, the task is to reverse the linked list. We need to reverse the list by changing links between nodes.
    /// Examples:
    /// Input : Head of following linked list  
    /// 1->2->3->4->NULL
    /// Output : Linked list should be changed to,
    /// 4->3->2->1->NULL
    /// Input : Head of following linked list  
    /// 1->2->3->4->5->NULL
    /// Output : Linked list should be changed to,
    /// 5->4->3->2->1->NULL
    /// Input : NULL
    /// Output : NULL
    /// 
    /// Input  : 1->NULL
    /// Output : 1->NULL
    /// https://www.geeksforgeeks.org/reverse-a-linked-list/
    /// </summary>
    public static class ReverseList
    {
        /// <summary>
        /// Initialize three pointers prev as NULL, curr as head and next as NULL.
        /// Iterate trough the linked list.In loop, do following.
        /// Before changing next of current,
        /// store next node
        /// next = curr->next
        /// This is where actual reversing happens
        /// curr->next = prev
        /// Move prev and curr one step forward
        /// prev = curr
        /// curr = next
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static Node Reverse(Node node)
        {
            Node prev = null;
            Node current = node;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            node = prev;
            return node;
        }



        public static void Test()
        {
            LinkedList list = new LinkedList();
            list.head = new Node(85);
            list.head.Next = new Node(15);
            list.head.Next.Next = new Node(4);
            list.head.Next.Next.Next = new Node(20);

            Console.Write("Given Linked list \n");
            list.head.PrintListFromNode();
            list.head = Reverse(list.head);
            Console.Write("\n");
            Console.Write("Reversed linked list \n");
            list.head.PrintListFromNode();
        }
    }
}
