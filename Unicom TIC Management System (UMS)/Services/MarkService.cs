using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    public class MarkService
    {
        public static void AddMark(Mark mark)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "INSERT INTO Marks (StudentId, SubjectId, ExamId, MarksObtained, MaxMarks) VALUES (@student, @subject, @exam, @marks, @max)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@student", mark.StudentId);
                    cmd.Parameters.AddWithValue("@subject", mark.SubjectId);
                    cmd.Parameters.AddWithValue("@exam", mark.ExamId);
                    cmd.Parameters.AddWithValue("@marks", mark.MarksObtained);
                    cmd.Parameters.AddWithValue("@max", mark.MaxMarks);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Mark> GetMarksByStudent(int studentId)
        {
            List<Mark> marks = new List<Mark>();
            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT * FROM Marks WHERE StudentId = @studentId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marks.Add(new Mark
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                ExamId = Convert.ToInt32(reader["ExamId"]),
                                MarksObtained = Convert.ToDouble(reader["MarksObtained"]),
                                MaxMarks = Convert.ToDouble(reader["MaxMarks"])
                            });
                        }
                    }
                }
            }
            return marks;
        }

        public static List<MarkWithDetails> GetAllMarksWithDetails()
        {
            List<MarkWithDetails> list = new List<MarkWithDetails>();

            using (var conn = DataConfig.GetConnection())
            {
                string query = @"
            SELECT 
                s.FirstName || ' ' || s.LastName AS StudentName,
                e.ExamName,
                sub.SubjectName,
                m.MarksObtained,
                m.MaxMarks
            FROM Marks m
            JOIN Students s ON m.StudentId = s.Id
            JOIN Subjects sub ON m.SubjectId = sub.SubjectId
            JOIN Exams e ON m.ExamId = e.Id";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double marks = Convert.ToDouble(reader["MarksObtained"]);
                        double max = Convert.ToDouble(reader["MaxMarks"]);
                        double percentage = (marks / max) * 100;

                        list.Add(new MarkWithDetails
                        {
                            StudentName = reader["StudentName"].ToString(),
                            ExamName = reader["ExamName"].ToString(),
                            SubjectName = reader["SubjectName"].ToString(),
                            MarksObtained = marks,
                            MaxMarks = max,
                            Percentage = Math.Round(percentage, 2),
                            Grade = GetGrade(percentage)
                        });
                    }
                }
            }

            return list;
        }

        public static string GetGrade(double percentage)
        {
            if (percentage >= 90) return "A+";
            if (percentage >= 75) return "A";
            if (percentage >= 60) return "B";
            if (percentage >= 45) return "C";
            return "F";
        }

        public static List<MarkWithDetails> GetTopThreeStudents()
        {
            return GetAllMarksWithDetails()
                .OrderByDescending(m => m.Percentage)
                .Take(3)
                .ToList();
        }

    }
}
