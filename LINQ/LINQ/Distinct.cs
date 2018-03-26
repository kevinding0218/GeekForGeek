using GeekForGeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// This operator returns distinct elements from a given collection.
    /// http://csharp-video-tutorials.blogspot.com/2014/08/part-26-set-operators-in-linq.html
    /// </summary>
    public static class Distinct
    {
        /// <summary>
        /// Example 1: Return distinct country names. 
        /// In this example the default comparer is being used and the comparison is case-sensitive, 
        /// so in the output we see country USA 2 times. 
        /// </summary>
        public static void DistinctCountryNameCaseSensitive()
        {
            string[] countries = { "USA", "usa", "INDIA", "UK", "UK" };

            var result = countries.Distinct();

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }

        /// <summary>
        /// For the comparison to be case-insensitive, 
        /// use the other overloaded version of Distinct() method to which we can pass a class that implements IEqualityComparer as an argument. 
        /// In this case we see country USA only once in the output.
        /// </summary>
        public static void DistinctCountryNameNonCaseSensitive()
        {
            string[] countries = { "USA", "usa", "INDIA", "UK", "UK" };

            var result = countries.Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }

        /// <summary>
        /// Notice that in the output we don't get unique employees. 
        /// This is because, the default comparer is being used which will just check for object references 
        /// being equal and not the individual property values.
        /// </summary>
        public static void DistinctObject()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Mary"}
            };

            var result = list.Distinct();

            foreach (var v in result)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
        }

        ///To solve the problem in Example 3, there are 3 ways
        ///1. Use the other overloaded version of Distinct() method to which we can pass a custom class that implements IEqualityComparer
        public static void DistinctObjectWithIEqualityComparer()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Mary"}
            };

            var result = list.Distinct(new EmployeeComparer());

            foreach (var v in result)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
        }

        ///2. Override Equals() and GetHashCode() methods in Employee class
        //public override bool Equals(object obj)
        //{
        //    return this.ID == ((Employee) obj).ID && this.Name == ((Employee) obj).Name;
        //}

        //public override int GetHashCode()
        //{
        //    return this.ID.GetHashCode() ^ this.Name.GetHashCode();
        //}

        ///3. Project the properties into a new anonymous type, which overrides Equals() and GetHashCode() methods
        public static void DistinctObjectWithProjectProperty()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Mary"}
            };

            var result = list.Select(x => new { x.ID, x.Name }).Distinct();

            foreach (var v in result)
            {
                Console.WriteLine(" " + v.ID + "\t" + v.Name);
            }
        }
    }


    /// <summary>
    /// Step 1 : Create a custom class that implements IEqualityComparer<T> and implement Equals() and GetHashCode() methods
    /// </summary>
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.ID == y.ID && x.Name == y.Name;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.ID.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
