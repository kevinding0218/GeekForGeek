using GeekForGeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// Quantifiers category
    /// http://csharp-video-tutorials.blogspot.com/2014/08/part-31-quantifiers-in-linq.html
    /// </summary>
    public static class AllAnyContains
    {
        /// <summary>
        /// All() method returns true if all the elements in a sequence satisfy a given condition, otherwise false.
        /// </summary>
        public static void All()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var result = numbers.All(x => x < 10);

            Console.WriteLine(result);
        }

        /// <summary>
        ///  Returns true as the sequence contains at least one element
        /// </summary>
        public static void AnyOne()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var result = numbers.Any();

            Console.WriteLine(result);
        }

        /// <summary>
        /// Returns false as the sequence does not contain any element that satisfies the given condition (No element in the sequence is greater than 10)
        /// </summary>
        public static void AnyTwo()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var result = numbers.Any(x => x > 10);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Returns true as the sequence contains number 3. In this case the default equality comparer is used.
        /// </summary>
        public static void ContainsOne()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            var result = numbers.Contains(3);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Returns true. In this case we are using an alternate equality comparer (StringComparer) for the comparison to be case-insensitive.
        /// </summary>
        public static void ContainsTwo()
        {
            string[] countries = { "USA", "INDIA", "UK" };

            var result = countries.Contains("india", StringComparer.OrdinalIgnoreCase);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Returns false, as the default comparer will only check if the object references are equal.
        /// </summary>
        public static void ContainsThree()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Rosy"},
                new Employee { ID = 102, Name = "Susy"}
            };

            var result = employees.Contains(new Employee { ID = 101, Name = "Rosy" });

            Console.WriteLine(result);
        }
    }
}
