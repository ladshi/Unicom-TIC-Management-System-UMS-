using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class CourseController
    {
        public static List<Course> GetAllCourses()
        {
            return CourseService.GetAll();
        }

        public static void AddCourse(Course course)
        {
            CourseService.AddCourse(course);  
        }

        public static void UpdateCourse(Course course)
        {
            CourseService.UpdateCourse(course);
        }

        
        public static void DeleteCourse(int courseId)
        {
            CourseService.Delete(courseId);
        }

        
        public static Course GetCourseById(int id)
        {
            return CourseService.GetById(id);
        }

        public static Course GetCourseByName(string name)
        {
            return CourseService.GetByName(name);
        }

        public static int GetCourseCount()
        {
            return CourseService.GetCourseCount();
        }

        public static string GetCourseNameById(int courseId)
        {
            var courses = CourseService.GetAll();
            foreach (var course in courses)
            {
                if (course.Id == courseId)
                    return course.CourseName;
            }
            return "";
        }


    }
}
