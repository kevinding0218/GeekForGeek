using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    /*
     * When we think about O(1) lookup , obvious data structure comes in our mind is HashMap. 
     * HashMap provide O(1) insertion and lookup. but HashMap does not has mechanism of tracking which entry has been queried recently and which not.
     * 
     * To track this we require another data-structure which provide fast insertion ,deletion and updation, in case of LRU we use Doubly Linkedlist. 
     * Reason for choosing doubly LinkList is O(1) deletion, updation and insertion if we have the address of Node on which this operation has to perform.
     * 
     * So our Implementation of LRU cache will have HashMap and Doubly LinkedList. 
     * In Which HashMap will hold the keys and address of the Nodes of Doubly LinkedList. 
     * And Doubly LinkedList will hold the values of keys.
     * 
     * We will remove element from bottom and add element on start of LinkedList and whenever any entry is accessed, 
     * it will be moved to top. so that recently used entries will be on Top and Least used will be on Bottom.
     */

    // https://medium.com/@krishankantsinghal/my-first-blog-on-medium-583159139237
    /*
     * capacity of 5
     * put(1,1)
     * Header -> (1,1) -> Tail
     * put(2,3)
     * H -> (2,3) -> (1,1) -> T
     * put(3,4)
     * H -> (3,4) -> (2,3) -> (1,1) -> T
     * put(4,7)
     * H -> (4,7) -> (3,4) -> (2,3) -> (1,1) -> T
     * put(6,10)
     * H -> (6,10) -> (4,7) -> (3,4) -> (2,3) -> (1,1) -> T
     * get(1)
     * H -> (1,1) -> (6,10) -> (4,7) -> (3,4) -> (2,3) -> T
     * get(3)
     * H -> (3,4) -> (1,1) -> (6,10) -> (4,7) -> (2,3) -> T
     * put(1,5)
     * H -> (1,5) -> (3,4) -> (6,10) -> (4,7) -> (2,3) -> T
     * put(12,7)
     * H -> (12,7) -> (1,5) -> (3,4) -> (6,10) -> (4,7) -> T
     * put(5,2)
     * H -> (5,2) -> (12,7) -> (1,5) -> (3,4) -> (6,10) -> T
     * get(4)
     * 
     */
    public class LRUCache
    {
        private class ListNode
        {
            public int key { get; set; }
            public int value { get; set; }

            public ListNode prev { get; set; }
            public ListNode next { get; set; }
        }

        // Hashtable backs up the Doubly Linked List for O(1) access to cache items
        Dictionary<int, ListNode> hashtable = new Dictionary<int, ListNode>();
        ListNode head;
        ListNode tail;

        //int totalItemsInCache;
        //int maxCapacity;
        public int totalItemsInCache { get; set; }
        public int maxCapacity { get; set; }

        public LRUCache(int maxCapacity)
        {
            // Cache starts empty and capacity is set by client
            totalItemsInCache = 0;
            this.maxCapacity = maxCapacity;

            // Dummy head and tail nodes to avoid empty states
            head = new ListNode();
            tail = new ListNode();

            // Wire the head and tail together
            head.next = tail;
            tail.prev = head;
        }

        public int get(int key)
        {
            ListNode node = null;
            if (hashtable.TryGetValue(key, out node))
            {
                // Item has been accessed. Move to the front of the cache
                moveToHead(node);

                return node.value;
            } else
            {
                return -1; // we should throw an exception here, but for Leetcode's sake
            }
        }

        public void put(int key, int value)
        {
            ListNode node = null;

            if (hashtable.TryGetValue(key, out node))
            {
                // If item is found in the cache, just update it and move it to the head of the list
                node.value = value;
                moveToHead(node);
            }
            else {
                // Item not found, create a new entry
                ListNode newNode = new ListNode();
                newNode.key = key;
                newNode.value = value;

                // Add to the hashtable and the actual list that represents the cache
                hashtable.Add(key, newNode);
                addToFront(newNode);
                totalItemsInCache++;

                // If over capacity remove the LRU item
                if (totalItemsInCache > maxCapacity)
                {
                    removeLRUEntry();
                }
            }
        }

        private void removeLRUEntry()
        {
            ListNode tail = popTail();

            hashtable.Remove(tail.key);
            --totalItemsInCache;
        }

        private ListNode popTail()
        {
            ListNode tailItem = tail.prev;
            removeFromList(tailItem);

            return tailItem;
        }

        private void addToFront(ListNode node)
        {
            // Wire up the new node being to be inserted
            node.prev = head;
            node.next = head.next;

            /*
              Re-wire the node after the head. Our node is still sitting "in the middle of nowhere".
              We got the new node pointing to the right things, but we need to fix up the original
              head & head's next.
              head <-> head.next <-> head.next.next <-> head.next.next.next <-> ...
              ^            ^
              |- new node -|
              That's where we are before these next 2 lines.
            */
            head.next.prev = node;
            head.next = node;
        }

        private void removeFromList(ListNode node)
        {
            ListNode savedPrev = node.prev;
            ListNode savedNext = node.next;

            savedPrev.next = savedNext;
            savedNext.prev = savedPrev;
        }

        private void moveToHead(ListNode node)
        {
            removeFromList(node);
            addToFront(node);
        }

        public static void test(String[] args)
        {
            // your code goes here
            LRUCache lrucache = new LRUCache(5);
        }
    }
}
