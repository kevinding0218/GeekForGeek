using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    public class LinkedList
    {
        public Node head { get; set; }

        public void PrintList()
        {
            Console.Write("----------------------\n");
            while (head != null)
            {
                Console.Write(head.Value + " ");
                head = head.Next;
            }
            Console.Write("----------------------\n");
        }
    }
}
