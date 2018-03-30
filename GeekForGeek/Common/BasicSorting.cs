using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Common
{
    public static class BasicSorting
    {
        //Bubble Sort:
        //Start at the beginning of an array and swap the first two elements if the first is bigger than
        //the second.Go to the next pair, etc, continuously making sweeps of the array until sorted.
        //O(n^2).

        //Selection Sort:
        //Find the smallest element using a linear scan and move it to the front.Then, find the second
        //smallest and move it, again doing a linear scan.Continue doing this until all the elements
        //are in place.O(n^2).

        //Merge Sort:
        //Sort each pair of elements.Then, sort every four elements by merging every two pairs.Then,
        //sort every 8 elements, etc.O(n log n).

        //Quick Sort:
        //Pick a random element and partition the array, such that all numbers that are less than it
        //come before all elements that are greater than it.Then do that for each half, then each quarter,
        //etc. O(n log n).

        //Bucket Sort:
        //Partitions the array into a finite number of buckets, and then sorts each bucket individually.
        //It gives a time of O(n + m), where n is the number of items and m is the number of distinct
        //items.
    }
}
