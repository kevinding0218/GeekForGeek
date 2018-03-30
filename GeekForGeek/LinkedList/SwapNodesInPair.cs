using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Given a linked list, swap every two adjacent nodes and return its head.
    /// For example,
    /// Given 1  2  3  4, you should return the list as 2  1  4  3.
    /// </summary>
    public static class SwapNodesInPair
    {
        /// <summary>
        /// Let’s assume p, q, r are the current, next, and next’s next node.
        /// We could swap the nodes pairwise by adjusting where it’s pointing next:
        /// q.next = p;
        /// p.next = r;
        /// The above operations transform the list from { p  q  r  s} to { q  p  r  s }.
        /// 
        /// If the next pair of nodes exists, we should remember to connect p’s next to s.Therefore,
        /// we should record the current node before advancing to the next pair of nodes.
        /// To determine the new list’s head, you look at if the list contains two or more elements.
        /// Basically, these extra conditional statements could be avoided by inserting an extra node
        /// (also known as the dummy head) to the front of the list.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private static Node swapPairs(Node head)
        {
            Node dummy = new Node(0);
            dummy.Next = head;
            Node p = head;
            Node prev = dummy;
            while (p != null && p.Next != null)
            {
                Node q = p.Next, r = p.Next.Next;
                prev.Next = q;
                q.Next = p;
                p.Next = r;
                prev = p;
                p = r;
            }
            return dummy.Next;
        }
    }
}
