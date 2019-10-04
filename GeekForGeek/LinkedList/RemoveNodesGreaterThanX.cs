using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.LinkedList
{
    public static class RemoveNodesGreaterThanX
    {
        public static Node removeNodesGreaterThanX(Node listHead, int x)
        {
            Node current = listHead;
            Node previous = null;

            // if header's data is > x
            while (current != null && current.Value > x)
            {
                // remove listHead and move current forward
                listHead = current.Next;
                current = listHead;
            }

            while (current != null)
            {
                // remove node if data is > x
                if (current.Value > x)
                {
                    previous.Next = current.Next;
                    current = previous.Next;
                }
                else // else keep iterating
                {
                    previous = current;
                    current = current.Next;
                }
            }

            return listHead;
        }
    }
}
