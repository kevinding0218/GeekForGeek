using GeekForGeek.Model;
using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// http://csharp-video-tutorials.blogspot.com/2014/07/part-19-group-by-multiple-keys-in-linq.html
    /// </summary>
    public static class GroupByMultipleKeys
    {
        /// <summary>
        /// Group employees by Department and then by Gender. 
        /// The employee groups should be sorted first by Department and then by Gender in ascending order. 
        /// Also, employees with in each group must be sorted in ascending order by Name.
        /// </summary>
        public static void GetEmployeesByDepartmentGender()
        {
            var employeeGroups = Employee.GetAllEmployees()
                                        .GroupBy(x => new { x.Department, x.Gender })
                                        .OrderBy(g => g.Key.Department).ThenBy(g => g.Key.Gender)
                                        .Select(g => new
                                        {
                                            Dept = g.Key.Department,
                                            Gender = g.Key.Gender,
                                            Employees = g.OrderBy(x => x.Name)
                                        });

            foreach (var group in employeeGroups)
            {
                Console.WriteLine("{0} department {1} employees count = {2}",
                    group.Dept, group.Gender, group.Employees.Count());
                Console.WriteLine("--------------------------------------------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Gender
                        + "\t" + employee.Department);
                }
                Console.WriteLine(); Console.WriteLine();
            }
        }

        /// <summary>
        /// Rewrite Example 1 using SQL like syntax
        /// </summary>
        public static void GetEmployeesByDepartmentGenderInSqlSyntax()
        {
            var employeeGroups = from employee in Employee.GetAllEmployees()
                                 group employee by new
                                 {
                                     employee.Department,
                                     employee.Gender
                                 } into eGroup
                                 orderby eGroup.Key.Department ascending,
                                               eGroup.Key.Gender ascending
                                 select new
                                 {
                                     Dept = eGroup.Key.Department,
                                     Gender = eGroup.Key.Gender,
                                     Employees = eGroup.OrderBy(x => x.Name)
                                 };

            foreach (var group in employeeGroups)
            {
                Console.WriteLine("{0} department {1} employees count = {2}",
                    group.Dept, group.Gender, group.Employees.Count());
                Console.WriteLine("--------------------------------------------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Gender
                        + "\t" + employee.Department);
                }
                Console.WriteLine(); Console.WriteLine();
            }
        }
    }
}
