using GeekForGeek.Model;
using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// If you have 2 collections, and when you perform an inner join, 
    /// then only the matching elements between the 2 collections are included in the result set. 
    /// Non - Matching elements are excluded from the result set.
    /// In short, Join is similar to INNER JOIN in SQL and GroupJoin is similar to OUTER JOIN in SQL 
    /// </summary>
    public static class InnerJoin
    {
        public static void GetEmployeesByDepartment()
        {
            var result = EmployeeWithDepartment.GetAllEmployees().Join(Department.GetAllDepartments(),
                                        e => e.DepartmentID,
                                        d => d.ID, (employee, department) => new
                                        {
                                            EmployeeName = employee.Name,
                                            DepartmentName = department.Name
                                        });

            ///Rewrite Example 1 using SQL like syntax.
            ///Notice that we are using the join operator but without into 
            var result2 = from e in EmployeeWithDepartment.GetAllEmployees()
                          join d in Department.GetAllDepartments()
                           on e.DepartmentID equals d.ID
                          select new
                          {
                              EmployeeName = e.Name,
                              DepartmentName = d.Name
                          };
            ///Notice that, in the output we don't have Andy record. 
            ///This is because, Andy does not have a matching department in Department collection. 
            foreach (var employee in result)
            {
                Console.WriteLine(employee.EmployeeName + "\t" + employee.DepartmentName);
            }
        }
    }
}
