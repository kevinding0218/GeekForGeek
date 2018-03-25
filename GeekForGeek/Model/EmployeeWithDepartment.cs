using System.Collections.Generic;

namespace GeekForGeek.Model
{
    public class EmployeeWithDepartment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public static List<EmployeeWithDepartment> GetAllEmployees()
        {
            return new List<EmployeeWithDepartment>()
        {
            new EmployeeWithDepartment { ID = 1, Name = "Mark", DepartmentID = 1 },
            new EmployeeWithDepartment { ID = 2, Name = "Steve", DepartmentID = 2 },
            new EmployeeWithDepartment { ID = 3, Name = "Ben", DepartmentID = 1 },
            new EmployeeWithDepartment { ID = 4, Name = "Philip", DepartmentID = 1 },
            new EmployeeWithDepartment { ID = 5, Name = "Mary" },
            new EmployeeWithDepartment { ID = 10, Name = "Andy"}
        };
        }
    }
}
