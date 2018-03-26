using GeekForGeek.Model;
using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// With INNER JOIN only the matching elements are included in the result set. 
    /// Non-matching elements are excluded from the result set. 
    /// 
    /// With LEFT OUTER JOIN all the matching elements + 
    /// all the non matching elements from the left collection are included in the result set. 
    /// </summary>
    public static class LeftJoin
    {
        public static void GetEmployeesByDepartment()
        {
            var result = from e in EmployeeWithDepartment.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID into eGroup
                         from d in eGroup.DefaultIfEmpty()
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d == null ? "No Department" : d.Name
                         };

            ///Rewrite Example 1 using extension method syntax. 
            ///To implement Left Outer Join, with extension method syntax we use the GroupJoin() method along with SelectMany() and DefaultIfEmpty() methods. 
            var result2 = EmployeeWithDepartment.GetAllEmployees()
                        .GroupJoin(Department.GetAllDepartments(),
                                e => e.DepartmentID,
                                d => d.ID,
                                (emp, depts) => new { emp, depts })
                        .SelectMany(z => z.depts.DefaultIfEmpty(),
                                (a, b) => new
                                {
                                    EmployeeName = a.emp.Name,
                                    DepartmentName = b == null ? "No Department" : b.Name
                                });

            foreach (var v in result)
            {
                Console.WriteLine(v.EmployeeName + "\t" + v.DepartmentName);
            }
        }
    }
}
