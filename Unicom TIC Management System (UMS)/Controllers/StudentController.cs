using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class StudentController
    {
        private StudentService studentService = new StudentService();

        public bool AddStudent(Student student, Guardian guardian, User user)
        {
            return studentService.AddStudent(student, guardian, user);
        }

        public List<Student> GetAllStudents()
        {
            return studentService.GetAllStudentDetails();
        }

    }
}
