using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Enum;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    public class StudentService
    {
        public static void AddStudent(Student student, Guardian guardian)
        {
            using (var conn = DataConfig.GetConnection())
            {
                // 1. Insert student
                var studentCmd = conn.CreateCommand();
                studentCmd.CommandText = @"INSERT INTO Students 
                    (UserId, FirstName, LastName, DOB, Gender, PhoneNumber, Address, Email, CourseId) 
                    VALUES (@uid, @fname, @lname, @dob, @gender, @phone, @addr, @mail, @course);
                    SELECT last_insert_rowid();";

                studentCmd.Parameters.AddWithValue("@uid", student.UserId);
                studentCmd.Parameters.AddWithValue("@fname", student.FirstName);
                studentCmd.Parameters.AddWithValue("@lname", student.LastName);
                studentCmd.Parameters.AddWithValue("@dob", student.DOB);
                studentCmd.Parameters.AddWithValue("@gender", student.Gender.ToString());
                studentCmd.Parameters.AddWithValue("@phone", student.PhoneNumber);
                studentCmd.Parameters.AddWithValue("@addr", student.Address);
                studentCmd.Parameters.AddWithValue("@mail", student.Email);
                studentCmd.Parameters.AddWithValue("@course", student.CourseId);

                int studentId = Convert.ToInt32(studentCmd.ExecuteScalar());

                // 2. Insert guardian
                var guardianCmd = conn.CreateCommand();
                guardianCmd.CommandText = @"INSERT INTO Guardians (StudentId, GuardianName, PhoneNumber)
                                            VALUES (@sid, @gname, @gcontact)";
                guardianCmd.Parameters.AddWithValue("@sid", studentId);
                guardianCmd.Parameters.AddWithValue("@gname", guardian.GuardianName);
                guardianCmd.Parameters.AddWithValue("@gcontact", guardian.PhoneNumber);
                guardianCmd.ExecuteNonQuery();
            }
        }

        public static void UpdateStudent(Student student, Guardian guardian)
        {
            using (var conn = DataConfig.GetConnection())
            {
                // Update Students
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Students 
                            SET FirstName = @fname, LastName = @lname, DOB = @dob, 
                                Gender = @gender, PhoneNumber = @phone, Address = @addr, 
                                Email = @mail, CourseId = @course
                            WHERE Id = @id";

                cmd.Parameters.AddWithValue("@fname", student.FirstName);
                cmd.Parameters.AddWithValue("@lname", student.LastName);
                cmd.Parameters.AddWithValue("@dob", student.DOB);
                cmd.Parameters.AddWithValue("@gender", student.Gender.ToString());
                cmd.Parameters.AddWithValue("@phone", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@addr", student.Address);
                cmd.Parameters.AddWithValue("@mail", student.Email);
                cmd.Parameters.AddWithValue("@course", student.CourseId);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.ExecuteNonQuery();

                // Update Guardians
                var gCmd = conn.CreateCommand();
                gCmd.CommandText = @"UPDATE Guardians 
                             SET GuardianName = @gname, PhoneNumber = @gcontact 
                             WHERE StudentId = @sid";

                gCmd.Parameters.AddWithValue("@gname", guardian.GuardianName);
                gCmd.Parameters.AddWithValue("@gcontact", guardian.PhoneNumber);
                gCmd.Parameters.AddWithValue("@sid", guardian.StudentId);
                gCmd.ExecuteNonQuery();
            }
        }

        public static void DeleteStudent(int studentId, int userId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                // Deleting Guardian (FK to StudentId)
                var gCmd = conn.CreateCommand();
                gCmd.CommandText = "DELETE FROM Guardians WHERE StudentId = @sid";
                gCmd.Parameters.AddWithValue("@sid", studentId);
                gCmd.ExecuteNonQuery();

                // Deleting Student in student table
                var sCmd = conn.CreateCommand();
                sCmd.CommandText = "DELETE FROM Students WHERE Id = @id";
                sCmd.Parameters.AddWithValue("@id", studentId);
                sCmd.ExecuteNonQuery();

                // Deleting User in users table
                var uCmd = conn.CreateCommand();
                uCmd.CommandText = "DELETE FROM Users WHERE UserId = @uid";
                uCmd.Parameters.AddWithValue("@uid", userId);
                uCmd.ExecuteNonQuery();
            }
        }

        public static List<(Student, Guardian)> GetAllStudents()
        {
            var list = new List<(Student, Guardian)>();
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT s.*, g.GuardianName, g.PhoneNumber
                                  FROM Students s
                                  JOIN Guardians g ON s.Id = g.StudentId";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DOB = reader["DOB"].ToString(),
                            Gender = (Gender)System.Enum.Parse(typeof(Gender), reader["Gender"].ToString()),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            CourseId = Convert.ToInt32(reader["CourseId"])
                        };

                        var guardian = new Guardian
                        {
                            GuardianName = reader["GuardianName"].ToString(),
                            PhoneNumber = reader["GuardianContact"].ToString()
                        };

                        string username = reader["UserName"].ToString();
                        string password = reader["Password"].ToString();
                        string courseName = reader["CourseName"].ToString();


                        list.Add((student, guardian));
                    }
                }
            }

            return list;
        }

        public static List<(Student student, Guardian guardian, string username, string password, string courseName)> GetAllStudentsWithUserData()
        {
            var list = new List<(Student, Guardian, string, string, string)>();

            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT s.*, g.GuardianName, g.PhoneNumber AS GuardianContact, 
                                        u.UserName, u.Password, c.CourseName AS CourseName
                                FROM Students s
                                JOIN Guardians g ON s.Id = g.StudentId
                                JOIN Users u ON s.UserId = u.UserId
                                JOIN Courses c ON s.CourseId = c.CourseId";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DOB = reader["DOB"].ToString(),
                            Gender = (Gender)System.Enum.Parse(typeof(Gender), reader["Gender"].ToString()),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            CourseId = Convert.ToInt32(reader["CourseId"])
                        };

                        var guardian = new Guardian
                        {
                            GuardianName = reader["GuardianName"].ToString(),
                            PhoneNumber = reader["GuardianContact"].ToString()
                        };

                        string username = reader["UserName"].ToString();
                        string password = reader["Password"].ToString();
                        string courseName = reader["CourseName"].ToString();

                        list.Add((student, guardian, username, password, courseName));
                    }
                }
            }
            return list;
        }

        public static List<(Student, Guardian)> SearchByName(string keyword)
        {
            var list = new List<(Student, Guardian)>();
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT s.*, g.GuardianName, g.PhoneNumber
                            FROM Students s
                            JOIN Guardians g ON s.Id = g.StudentId
                            WHERE s.FirstName LIKE @kw OR s.LastName LIKE @kw";
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DOB = reader["DateOfBirth"].ToString(),
                            Gender = (Gender)System.Enum.Parse(typeof(Gender), reader["Gender"].ToString()),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            CourseId = Convert.ToInt32(reader["CourseId"])
                        };

                        var guardian = new Guardian
                        {
                            GuardianName = reader["GuardianName"].ToString(),
                            PhoneNumber = reader["ContactNo"].ToString()
                        };

                        list.Add((student, guardian));
                    }
                }
            }

            return list;
        }
        //this is for sending student id and name to the marks form
        public static List<object> GetStudentNames()
        {
            var list = new List<object>();

            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, FirstName, LastName FROM Students";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string fullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();

                        list.Add(new
                        {
                            StudentId = id,
                            FullName = fullName
                        });
                    }
                }
            }

            return list;
        }

        public static int GetStudentCount()
        {
            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Students";
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


    }

}

