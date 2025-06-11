using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;
using Unicom_TIC_Management_System__UMS_.View;
using static System.Collections.Specialized.BitVector32;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    internal class CourseController
    {
        public List<Course> GetAllCourses()
        {
            var course = new List<Course>();

            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Courses", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    course.Add(new Course
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            return course;
        }
        public void AddCourse(Course course)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Courses (CourseName) VALUES (@Name)", conn);
                cmd.Parameters.AddWithValue("@Name", course.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course course)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Courses SET CourseName = @Name WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Name", course.Name);
                cmd.Parameters.AddWithValue("@Id", course.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int sectionId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Courses WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", sectionId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Course> SearchCourses(string name)
        {
            var courseList = new List<Course>();
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Courses WHERE CourseName LIKE @name", conn);
                cmd.Parameters.AddWithValue("@name", $"%{name}%");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    courseList.Add(new Course
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return courseList;
        }
    }
}
