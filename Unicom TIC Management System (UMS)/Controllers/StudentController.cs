using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class StudentController
    {
        public static void AddStudent(Student student, Guardian guardian)
        {
            StudentService.AddStudent(student, guardian);
        }

        public static void UpdateStudent(Student student, Guardian guardian)
        {
            StudentService.UpdateStudent(student, guardian);
        }

        public static void DeleteStudent(int studentId, int userId)
        {
            StudentService.DeleteStudent(studentId, userId);
        }

        public static List<(Student, Guardian)> GetAllStudents()
        {
            return StudentService.GetAllStudents();
        }

        public static List<(Student, Guardian)> SearchByName(string keyword)
        {
            return StudentService.SearchByName(keyword);
        }

        public static List<(Student, Guardian, string username, string password, string courseName)> GetAllStudentsWithUserData()
        {
            return StudentService.GetAllStudentsWithUserData();
        }
        public static List<object> GetStudentNames()
        {
            return StudentService.GetStudentNames();
        }


    }
}
