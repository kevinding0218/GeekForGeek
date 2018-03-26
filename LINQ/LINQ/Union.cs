using GeekForGeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// Union combines two collections into one collection while removing the duplicate elements.
    /// http://csharp-video-tutorials.blogspot.com/2014/08/part-27-union-intersect-and-except.html
    /// </summary>
    public static class Union
    {
        /// <summary>
        /// numbers1 and numbers2 collections are combined into a single collection. 
        /// Notice that, the duplicate elements are removed.
        /// </summary>
        public static void UnionNumberArray()
        {
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

            var result = numbers1.Union(numbers2);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }

        /// <summary>
        ///When comparing elements, just like Distinct() method, Union(), Intersect() and Except() methods 
        ///work in a slightly different manner with complex types like Employee, Customer etc.
        ///Notice that in the output the duplicate employee objects are not removed. 
        ///This is because, the default comparer is being used which will just check for object references being equal and not the individual property values.
        /// </summary>
        public static void UnionObjectClass()
        {
            List<Employee> list1 = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Susy"},
                new Employee { ID = 103, Name = "Mary"}
            };

            List<Employee> list2 = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 104, Name = "John"}
            };

            var result = list1.Union(list2);

            foreach (var v in result)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
        }

        ///To solve the problem in Example 2, there are 3 ways
        ///1. Use the other overloaded version of Union() method to which we can pass a custom class that implements IEqualityComparer
        ///2. Override Equals() and GetHashCode() methods in Employee class
        ///3. Project the properties into a new anonymous type, which overrides Equals() and GetHashCode() methods
        public static void UnionObjectClassWithProjection()
        {
            List<Employee> list1 = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 102, Name = "Susy"},
                new Employee { ID = 103, Name = "Mary"}
            };

            List<Employee> list2 = new List<Employee>()
            {
                new Employee { ID = 101, Name = "Mike"},
                new Employee { ID = 104, Name = "John"}
            };

            var result = list1.Select(x => new { x.ID, x.Name })
                                .Union(list2.Select(x => new { x.ID, x.Name }));

            foreach (var v in result)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }
        }
    }
}
