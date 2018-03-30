using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    public static class PrintList
    {
        public static void PrintListFromNode(this Node node)
        {
            while (node != null)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
        }
    }
}
