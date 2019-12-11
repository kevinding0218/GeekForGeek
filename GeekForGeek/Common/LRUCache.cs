﻿using System;
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
    public class Entry
    {
        public int value { get; set; }
        public int key { get; set; }
        public Entry left { get; set; }
        public Entry right { get; set; }
    }

    // https://medium.com/@krishankantsinghal/my-first-blog-on-medium-583159139237
    public class LRUCache
    {
        Dictionary<int, Entry> hashmap;
        Entry start, end;
        int LRU_SIZE = 4; // Here i am setting 4 to test the LRU cache
                          // implementation, it can make be dynamic
        public LRUCache()
        {
            hashmap = new Dictionary<int, Entry>();
        }

        public int getEntry(int key)
        {
            if (hashmap.ContainsKey(key)) // Key Already Exist, just update the
            {
                Entry entry;
                if (hashmap.TryGetValue(key, out entry))
                {
                    removeNode(entry);
                    addAtTop(entry);
                    return entry.value;
                }
            }
            return -1;
        }

        public void putEntry(int key, int value)
        {
            if (hashmap.ContainsKey(key)) // Key Already Exist, just update the value and move it to top
            {
                Entry entry;
                if (hashmap.TryGetValue(key, out entry))
                {
                    entry.value = value;
                    removeNode(entry);
                    addAtTop(entry);
                }
            }
            else
            {
                Entry newnode = new Entry();
                newnode.left = null;
                newnode.right = null;
                newnode.value = value;
                newnode.key = key;
                if (hashmap.Count > LRU_SIZE) // We have reached maxium size so need to make room for new element.
                {
                    hashmap.Remove(end.key);
                    removeNode(end);
                    addAtTop(newnode);

                }
                else
                {
                    addAtTop(newnode);
                }

                hashmap.Add(key, newnode);
            }
        }

        public void addAtTop(Entry node)
        {
            node.right = start;
            node.left = null;
            if (start != null)
                start.left = node;
            start = node;
            if (end == null)
                end = start;
        }

        public void removeNode(Entry node)
        {

            if (node.left != null)
            {
                node.left.right = node.right;
            }
            else
            {
                start = node.right;
            }

            if (node.right != null)
            {
                node.right.left = node.left;
            }
            else
            {
                end = node.left;
            }
        }

        public static void test(String[] args)
        {
            // your code goes here
            LRUCache lrucache = new LRUCache();
            lrucache.putEntry(1, 1);
            lrucache.putEntry(10, 15);
            lrucache.putEntry(15, 10);
            lrucache.putEntry(10, 16);
            lrucache.putEntry(12, 15);
            lrucache.putEntry(18, 10);
            lrucache.putEntry(13, 16);

            Console.WriteLine(lrucache.getEntry(1));
            Console.WriteLine(lrucache.getEntry(10));
            Console.WriteLine(lrucache.getEntry(15));
        }
    }
}
}
