using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// Intersect() returns the common elements between the 2 collections.
    /// Except() returns the elements that are present in the first collection but not in the second collection.
    /// http://csharp-video-tutorials.blogspot.com/2014/08/part-27-union-intersect-and-except.html
    /// </summary>
    public static class IntersectExcept
    {
        /// <summary>
        /// Intersect() returns the common elements between the 2 collections.
        /// Output: 1 3
        /// </summary>
        public static void IntersectNumberArray()
        {
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

            var result = numbers1.Intersect(numbers2);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }

        /// <summary>
        /// Except() returns the elements that are present in the first collection but not in the second collection.
        /// Output: 2 4 5
        /// </summary>
        public static void ExceptNumberArray()
        {
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

            var result = numbers1.Except(numbers2);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }
    }
}
