using GeekForGeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekForGeek.Array
{
    public static class FindDuplicateInArray
    {
        /// <summary>
        /// Given a string array find duplicate string with count
        /// 
        /// </summary>
        public static void FindDuplicateStringWithCount()
        {
            IEnumerable<string> inputList = new string[] { "jason", "mike", "david", "allen", "jason", "allen", "bob", "david", "jason" };

            ///https://stackoverflow.com/questions/454601/how-to-count-duplicates-in-list-with-linq
            #region Using extension methods
            var p = inputList.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => new
                        {
                            Name = group.Key,
                            Count = group.Count(),
                        })
                        .OrderByDescending(x => x.Count);

            Console.WriteLine("Using extension methods");
            foreach (var x in p)
            {
                Console.WriteLine("Name: " + x.Name + " Count: " + x.Count);
            }
            #endregion

            #region Using LINQ
            var q = from x in inputList
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    where count > 1
                    select new { Name = g.Key, Count = count };

            Console.WriteLine("Using LINQ");
            foreach (var x in q)
            {
                Console.WriteLine("Name: " + x.Name + " Count: " + x.Count);
            }
            #endregion

            #region Using Dictionary
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string item in inputList)
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    int count = 0;
                    dic.TryGetValue(item, out count);
                    dic[item] = count + 1;
                }
            }

            Console.WriteLine("Using Dictionary");
            foreach (KeyValuePair<string, int> entry in dic)
            {
                if (entry.Value > 1)
                    Console.WriteLine("Name: " + entry.Key + " Count: " + entry.Value);
            }
            #endregion

            ///https://answers.unity.com/questions/1219240/c-count-duplicates-in-list.html
            #region Using Dictionary with extend methods
            Dictionary<string, int> dic_linq = inputList.GroupBy(x => x)
                                                        .Where(group => group.Count() > 1)
                                                        .ToDictionary(g => g.Key, g => g.Count());

            var lines = dic_linq.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
            Console.WriteLine("Using Dictionary with extend methods");
            Console.WriteLine(string.Join(Environment.NewLine, lines));
            #endregion
        }

        /// <summary>
        /// Given a object array find duplicate by property
        /// </summary>
        public static void FindDuplicateObjectByPropertyWithCount()
        {
            var duplicates = Student.GetAllStudents().GroupBy(x => x.StudentName)
                                        .Where(group => group.Count() > 1)
                                        .Select(student => new { Name = student.Key, Count = student.Count() })
                                        .OrderByDescending(x => x.Count);

            Console.WriteLine("Using extension methods");
            foreach (var x in duplicates)
            {
                Console.WriteLine("Name: " + x.Name + " Count: " + x.Count);
            }
        }
    }
}
