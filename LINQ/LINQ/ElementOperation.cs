using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// http://csharp-video-tutorials.blogspot.com/2014/07/part-20-element-operators-in-linq.html
    /// </summary>
    public static class ElementOperation
    {
        /// <summary>
        /// First : There are 2 overloaded versions of this method. 
        /// Last : Very similar to First, except it returns the last element of the sequence.
        /// </summary>
        public static void First()
        {
            /// The first overloaded version that does not have any parameters simply returns the first element of a sequence.
            /// If the sequence does not contain any elements, then First() method throws an InvalidOperationException.
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result1 = numbers.First();
            Console.WriteLine("Result = " + result1);

            ///The second overloaded version is used to find the first element in a sequence based on a condition.
            ///If the sequence does not contain any elements or if no element in the sequence satisfies the condition then an InvalidOperationException is thrown.
            int result2 = numbers.First(x => x % 2 == 0);
            Console.WriteLine("Result = " + result2);
        }

        /// <summary>
        /// FirstOrDefault : This is very similar to First, except that this method does not throw an exception when 
        /// there are no elements in the sequence or when no element satisfies the condition specified by the predicate. 
        /// Instead, a default value of the type that is expected is returned. 
        /// For reference types the default is NULL and for value types the default depends on the actual type expected.
        /// ///LastOrDefault : Very similar to FirstOrDefault, except it returns the last element of the sequence.
        /// </summary>
        public static void FirstOrDefault()
        {
            ///Returns ZERO. No element in the sequence satisfies the condition, 
            ///so the default value (ZERO) for int is returned.
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = numbers.FirstOrDefault(x => x % 2 == 100);
            Console.WriteLine("Result = " + result);
        }

        /// <summary>
        /// Returns an element at a specified index. 
        /// If the sequence is empty or if the provided index value is out of range, 
        /// then an ArgumentOutOfRangeException is thrown.
        /// </summary>
        public static void ElementAt()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = numbers.ElementAt(1);
            Console.WriteLine("Result = " + result);
        }

        /// <summary>
        /// Similar to ElementAt except that this method does not throw an exception, 
        /// if the sequence is empty or if the provided index value is out of range. 
        /// Instead, a default value of the type that is expected is returned.
        /// </summary>
        public static void ElementAtOrDefault()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int result = numbers.ElementAt(1);
            Console.WriteLine("Result = " + result);
        }

        /// <summary>
        /// Single : There are 2 overloaded versions of this method. 
        /// </summary>
        public static void Single()
        {
            int[] numbers = { 1 };
            int result = numbers.Single();
            Console.WriteLine("Result = " + result);

            int[] numbers2 = { 1, 2 };
            int result2 = numbers2.Single();
            Console.WriteLine("Result = " + result2);


            ///find the only element in a sequence that satisfies a given condition. 
            ///An exception will be thrown if any of the following is true
            ///a) If the sequence does not contain any elements OR
            ///b) If no element in the sequence satisfies the condition OR
            ///c) If more than one element in the sequence satisfies the condition
            int[] numbers3 = { 1, 2, 4 };
            int result3 = numbers3.Single(x => x % 2 == 0);
            Console.WriteLine("Result = " + result3);
        }

        /// <summary>
        /// Very similar to Single(), except this method does not throw an exception when the sequence is empty 
        /// or when no element in the sequence satisfies the given condition. 
        /// Just like Single(), this method will still throw an exception, 
        /// if more than one element in the sequence satisfies the given condition.
        /// </summary>
        public static void SingleOrDefault()
        {
            ///Throws InvalidOperationException as more than one element in the sequence satisfies the given condition
            int[] numbers = { 1, 2, 4 };
            int result = numbers.SingleOrDefault(x => x % 2 == 0);
            Console.WriteLine("Result = " + result);
        }

        /// <summary>
        /// If the sequence on which this method is called is not empty, then the values of the original sequence are returned.
        /// </summary>
        public static void DefaultIfEmpty()
        {
            ///Output:1 2 3
            int[] numbers = { 1, 2, 3 };
            IEnumerable<int> result = numbers.DefaultIfEmpty();
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

            ///If the sequence is empty, then DefaultIfEmpty() returns a sequence with the default value of the expected type.

            ///The other overloaded version with a parameter allows us to specify a default value. 
            ///If this method is called on a sequence that is not empty, then the values of the original sequence are returned. 
            ///If the sequence is empty, then this method returns a sequence with the specified defualt value.
            ///Since the sequence is empty, a sequence containing the specified default value (10) is returned.
            ///Output: 10
            int[] numbers2 = { };
            IEnumerable<int> result2 = numbers.DefaultIfEmpty(10);
            foreach (int i in result2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
