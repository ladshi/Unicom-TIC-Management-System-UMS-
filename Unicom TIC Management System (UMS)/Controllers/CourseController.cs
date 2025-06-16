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

        // Add new course using the service
        public static void AddCourse(Course course)
        {
            CourseService.Add(course);
        }

        // Update course using the service
        public static void UpdateCourse(Course course)
        {
            CourseService.Update(course);
        }

        // Delete course by ID using the service
        public static void DeleteCourse(int courseId)
        {
            CourseService.Delete(courseId);
        }

        // Get a course by its ID
        public static Course GetCourseById(int id)
        {
            return CourseService.GetById(id);
        }

        // Get a course by its name (for ComboBox search)
        public static Course GetCourseByName(string name)
        {
            return CourseService.GetByName(name);
        }
    }
}
