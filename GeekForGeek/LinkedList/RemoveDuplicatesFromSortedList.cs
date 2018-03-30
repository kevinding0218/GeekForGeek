using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    public static class RemoveDuplicatesFromSortedList
    {
        private static void RemoveDuplicates(Node head)
        {
            Node current = head;
            Node currentNext = head.Next;

            while (currentNext != null)
            {
                if ((int)current.Value == (int)currentNext.Value)
                {
                    current.Next = currentNext.Next;
                    currentNext = current.Next;
                }
                else
                {
                    current = current.Next;
                    currentNext = currentNext.Next;
                }
            }
        }
    }
}
