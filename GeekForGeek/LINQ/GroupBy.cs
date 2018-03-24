using GeekForGeek.Model;
using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// http://csharp-video-tutorials.blogspot.com/2014/07/part-18-groupby-in-linq.html
    /// </summary>
    public static class GroupBy
    {
        /// <summary>
        /// Case 1: Get Employee Count By Department
        /// </summary>
        public static void GetEmployeeCountByDepartment()
        {
            //var employeeGroup = Employee.GetAllEmployees().GroupBy(x => x.Department);
            var employeeGroup = from employee in Employee.GetAllEmployees()
                                group employee by employee.Department;

            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
            }
        }

        /// <summary>
        /// Case 2: Get Employee Count By Department and also each employee and department name
        /// </summary>
        public static void GetEmployeeCountByDepartmentWithEmployeeDepartmentName()
        {
            var employeeGroup = from employee in Employee.GetAllEmployees()
                                group employee by employee.Department;

            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
                Console.WriteLine("----------");
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Department);
                }
                Console.WriteLine(); Console.WriteLine();
            }
        }

        /// <summary>
        /// Case 3: Get Employee Count By Department and also each employee and department name. 
        /// Data should be sorted first by Department in ascending order and then by Employee Name in ascending order.
        /// </summary>
        public static void GetEmployeeCountByDepartmentWithOrderByDepartmentAndEmployeeName()
        {
            var employeeGroup = from employee in Employee.GetAllEmployees()
                                group employee by employee.Department into eGroup
                                orderby eGroup.Key
                                select new
                                {
                                    Key = eGroup.Key,
                                    Employees = eGroup.OrderBy(x => x.Name)
                                };

            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Employees.Count());
                Console.WriteLine("----------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Department);
                }
                Console.WriteLine(); Console.WriteLine();
            }
        }

    }
}
