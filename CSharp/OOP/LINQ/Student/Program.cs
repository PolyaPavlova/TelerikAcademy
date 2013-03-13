using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {
                                     new Student("Anna", "Petrova", 15),
                                     new Student("Ivan", "Ivanov", 26),
                                     new Student("Gerasim", "Bozadjiev", 20),
                                     new Student("Bojan", "Zahariev", 26),
                                     new Student("Elena", "Canova", 22)
                                 };

            var studentsFirstNames = 
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            var youngAdultStudents =
                from student in students
                where student.Age > 18 && student.Age < 24
                select new { FirstName = student.FirstName, LastName = student.LastName };

            var orderedStudentsLambda = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            var orderedStudentsLinqu =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
                
        }
    }
}
