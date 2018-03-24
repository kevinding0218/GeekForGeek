using System.Collections.Generic;

namespace GeekForGeek.Model
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }

        public Student(int _id, string _name)
        {
            this.StudentID = _id;
            this.StudentName = _name;
        }

        public static List<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student(1, "jason"),
                    new Student(2, "mike"),
                    new Student(3, "david"),
                    new Student(4, "allen"),
                    new Student(5, "jason"),
                    new Student(6, "allen"),
                    new Student(7, "bob"),
                    new Student(8, "david"),
                    new Student(9, "jason")
            };
        }
    }
}
