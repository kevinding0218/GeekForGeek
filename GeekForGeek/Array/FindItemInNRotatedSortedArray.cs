using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Array
{
    public static class FindItemInNRotatedSortedArray
    {
        public static int Search(int[] nums, int target)
        {
            int length = nums.Length;
            int pivot = findPivot(nums, 0, length - 1);

            // If we didn't find a pivot, then 
            // array is not rotated at all 
            if (pivot == -1)
                return binarySearch(nums, 0, length - 1, target);

            // If we found a pivot, then first 
            // compare with pivot and then 
            // search in two subarrays around pivot 
            if (nums[pivot] == target)
                return pivot;

            if (nums[0] <= target)
                return binarySearch(nums, 0, pivot - 1, target);

            return binarySearch(nums, pivot + 1, length - 1, target);
        }

        static int findPivot(int[] arr, int low, int high)
        {
            // base cases 
            if (high < low)
                return -1;
            if (high == low)
                return low;

            /* low + (high - low)/2; */
            int mid = (low + high) / 2;

            if (mid < high && arr[mid] > arr[mid + 1])
                return mid;

            if (mid > low && arr[mid] < arr[mid - 1])
                return (mid - 1);

            if (arr[low] >= arr[mid])
                return findPivot(arr, low, mid - 1);

            return findPivot(arr, mid + 1, high);
        }

        /* Standard Binary Search function */
        static int binarySearch(int[] arr, int low,
                                int high, int key)
        {
            if (high < low)
                return -1;

            /* low + (high - low)/2; */
            int mid = (low + high) / 2;

            if (key == arr[mid])
                return mid;
            if (key > arr[mid])
                return binarySearch(arr, (mid + 1), high, key);

            return binarySearch(arr, low, (mid - 1), key);
        }
    }
}
