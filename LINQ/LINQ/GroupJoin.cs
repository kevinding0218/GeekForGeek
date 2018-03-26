using GeekForGeek.Model;
using System;
using System.Linq;

namespace GeekForGeek.LINQ
{
    /// <summary>
    /// Group Join produces hierarchical data structures. 
    /// Each element from the first collection is paired with a set of correlated elements from the second collection. 
    /// </summary>
    public static class GroupJoin
    {
        public static void GetEmployeesByDepartment()
        {
            var employeesByDepartment = Department.GetAllDepartments()
                                                .GroupJoin(EmployeeWithDepartment.GetAllEmployees(),
                                                    d => d.ID,
                                                    e => e.DepartmentID,
                                                    (department, employees) => new
                                                    {
                                                        Department = department,
                                                        Employees = employees
                                                    });

            var employeesByDepartment2 = from d in Department.GetAllDepartments()
                                         join e in EmployeeWithDepartment.GetAllEmployees()
                                         on d.ID equals e.DepartmentID into eGroup
                                         select new
                                         {
                                             Department = d,
                                             Employees = eGroup
                                         };

            foreach (var department in employeesByDepartment)
            {
                Console.WriteLine(department.Department.Name);
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(" " + employee.Name);
                }
                Console.WriteLine();
            }
        }
    }
}
