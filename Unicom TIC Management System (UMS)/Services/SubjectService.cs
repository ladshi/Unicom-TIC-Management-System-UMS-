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
                var cmd = new SQLiteCommand("INSERT INTO Subjects (SubjectName, CourseId) VALUES (@SubjectName, @CourseId)", conn); 
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName); 
                cmd.Parameters.AddWithValue("@CourseId", subject.CourseId);

                int insertedSubjectId = Convert.ToInt32(cmd.ExecuteScalar());
                var csCmd = new SQLiteCommand("INSERT INTO CourseSubjects (CourseId, SubjectId) VALUES (@cid, @sid)", conn);
                csCmd.Parameters.AddWithValue("@cid", subject.CourseId);
                csCmd.Parameters.AddWithValue("@sid", insertedSubjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateSubject(Subject subject)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand("UPDATE Subjects SET SubjectName = @SubjectName, CourseId = @CourseId WHERE SubjectId = @Id", conn); 
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName); 
                cmd.Parameters.AddWithValue("@CourseId", subject.CourseId);
                cmd.Parameters.AddWithValue("@Id", subject.Id); 
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteSubject(int subjectId)
        {
            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectId = @Id", conn); 
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
                        Id = Convert.ToInt32(reader["SubjectId"]),             
                        SubjectName = reader["SubjectName"].ToString(),      
                        CourseId = Convert.ToInt32(reader["CourseId"])
                    });
                }
            }

            return subjects;
        }

        public static List<CourseSubject> GetCourseSubjectView()
        {
            var subjectList = new List<CourseSubject>();

            using (var conn = new SQLiteConnection(DataConfig.GetConnection()))
            {
                var cmd = new SQLiteCommand(@"
                         SELECT 
                         s.SubjectId AS SubjectId,
                         s.SubjectName AS SubjectName,
                         c.CourseName AS CourseName
                         FROM 
                         CourseSubjects cs
                         JOIN Subjects s ON cs.SubjectId = s.SubjectId
                         JOIN Courses c ON cs.CourseId = c.CourseId
                         ", conn);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjectList.Add(new CourseSubject
                        {
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            CourseName = reader["CourseName"].ToString()
                        });
                    }
                }
            }

            return subjectList;
        }

        public static string GetSubjectNameById(int id)
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectName FROM Subjects WHERE SubjectId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown";
            }
        }

        public static int GetSubjectCount()
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Subjects";
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

    }
}
