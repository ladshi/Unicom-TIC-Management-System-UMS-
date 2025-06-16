using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Repositaries;
using Unicom_TIC_Management_System__UMS_.Models;
using static System.Collections.Specialized.BitVector32;
using System.Data.SQLite;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    internal class CourseService
    {
        public static void Add(Course course)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Courses (CourseName) VALUES (@name)";
                cmd.Parameters.AddWithValue("@name", course.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Course> GetAll()
        {
            var courses = new List<Course>();
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {

                var query = "SELECT * FROM Courses";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            Id = int.Parse(reader["CourseId"].ToString()),
                            Name = reader["CourseName"].ToString(),
                        });
                    }
                }
            }
            return courses;
        }

        public static void Update(Course course)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Courses SET Name = @name WHERE Id = @id";
                cmd.Parameters.AddWithValue("@name", course.Name);
                cmd.Parameters.AddWithValue("@id", course.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Courses WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static Course GetById(int id)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var query = "SELECT * FROM Courses WHERE CourseId = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Course
                            {
                                Id = int.Parse(reader["CourseId"].ToString()),
                                Name = reader["CourseName"].ToString(),
                            };
                        }
                    }
                }
            }
            return null;

        }


        public static Course GetByName(string name)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {

                var query = "SELECT * FROM Courses WHERE CourseName = @name";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Course
                            {
                                Id = int.Parse(reader["CourseId"].ToString()),
                                Name = reader["CourseName"].ToString(),
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
