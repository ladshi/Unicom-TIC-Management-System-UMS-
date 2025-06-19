using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.View;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    internal class SubjectService
    {
        public static void AddSubject(Subject subject)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand("INSERT INTO Subjects (Name, CourseId) VALUES (@Name, @CourseId)", conn);
                cmd.Parameters.AddWithValue("@Name", subject.Name);
                cmd.Parameters.AddWithValue("@CourseId", subject.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateSubject(Subject subject)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand("UPDATE Subjects SET Name = @Name, CourseId = @CourseId WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Name", subject.Name);
                cmd.Parameters.AddWithValue("@CourseId", subject.CourseId);
                cmd.Parameters.AddWithValue("@Id", subject.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteSubject(int subjectId)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand("DELETE FROM Subjects WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();

            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand("SELECT * FROM Subjects", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    subjects.Add(new Subject
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        CourseId = Convert.ToInt32(reader["CourseId"])
                    });
                }
            }

            return subjects;
        }

        public static List<CourseSubject> GetCourseSubjectView()
        {
            var list = new List<CourseSubject>();

            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand(@"
                    SELECT s.Id AS Id, s.Name AS SubjectName, c.Name AS CourseName
                    FROM Subjects s
                    JOIN Courses c ON s.CourseId = c.Id
                ", conn);

                using (SQLiteDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        list.Add(new CourseSubject
                        {
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }

            return list;
        }
    }
}

