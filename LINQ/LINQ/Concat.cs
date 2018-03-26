using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// Concat operator concatenates two sequences into one sequence.
    /// Concat operator combines 2 sequences into 1 sequence. Duplicate elements are not removed. 
    /// It simply returns the items from the first sequence followed by the items from the second sequence. 
    /// Union operator also combines 2 sequences into 1 sequence, but will remove the duplicate elements. 
    /// </summary>
    public static class Concat
    {
        public static void ConcatNumberArray()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 1, 4, 5 };

            var result = numbers1.Concat(numbers2);

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }
        }
    }
}
