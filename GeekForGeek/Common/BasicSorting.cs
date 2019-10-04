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

        //Merge Sort vs Quick Sort
        //Similarities:
        //Both follow the concept of Divide and Conquer
        //Differences:
        //Merge sort will divide the array exactly at mid point, while quick sort may or may not parition into equal parts.
        //Merge sort require additional space of O(n), while quick sort may not need
        //Merge sort is stable while quick sort is unstable, meaning if array contains duplicate elements, element will remain previous order after sorting.
        //Merge sort will perform 2*T(n/2) then O(n) while quick sort will do O(n) then 2*T(n/2)
        //Merge sort best/worst case is O(nlogn), while quick sort best case O(nlogn) worst case O(n^2)
    }
}
