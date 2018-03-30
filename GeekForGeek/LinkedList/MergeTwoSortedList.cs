using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    /// <summary>
    /// Merge two sorted linked lists and return it as a new list. The new list should be made by
    /// splicing together the nodes of the first two lists.
    /// </summary>
    public static class MergeTwoSortedList
    {
        /// <summary>
        /// We insert a dummy head before the new list so we don’t have to deal with special cases
        /// such as initializing the new list’s head.Then the new list’s head could just easily be
        /// returned as dummy head’s next node.
        /// Using dummy head allows you to write simpler code and adds as a powerful tool to your
        /// interview arsenal.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        private static Node mergeTwoLists(Node l1, Node l2)
        {
            Node dummyHead = new Node(0);
            Node p = dummyHead;
            while (l1 != null && l2 != null)
            {
                if (l1.Value < l2.Value)
                {
                    p.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    p.Next = l2;
                    l2 = l2.Next;
                }
                p = p.Next;
            }
            if (l1 != null) p.Next = l1;
            if (l2 != null) p.Next = l2;
            return dummyHead.Next;
        }
    }
}
