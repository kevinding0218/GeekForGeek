using GeekForGeek.Model;
using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// Cross join produces a cartesian product i.e when we cross join two sequences, 
    /// every element in the first collection is combined with every element in the second collection. 
    /// The total number of elements in the resultant sequence will always be equal to the product of the elements in the two source sequences.
    /// The on keyword that specfies the JOIN KEY is not required.
    /// </summary>
    public static class CrossJoin
    {
        public static void GetEmployeesByDepartment()
        {
            var result = from e in EmployeeWithDepartment.GetAllEmployees()
                         from d in Department.GetAllDepartments()
                         select new { e, d };

            ///Rewrite Example 1 using extension method syntax
            ///To implement Cross Join using extension method syntax, we could either use SelectMany() method or Join() method
            var result1_extend = Employee.GetAllEmployees()
                        .SelectMany(e => Department.GetAllDepartments(), (e, d) => new { e, d });

            ///Implementing cross join using Join()
            var result1_extend2 = Employee.GetAllEmployees()
                                     .Join(Department.GetAllDepartments(),
                                               e => true,
                                               d => true,
                                               (e, d) => new { e, d });

            foreach (var v in result)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }

            ///In this case, every element from the Departments collection is combined with every element in the Employees collection. 
            var result2 = from d in Department.GetAllDepartments()
                          from e in Employee.GetAllEmployees()
                          select new { e, d };

            foreach (var v in result2)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }
        }
    }
}
