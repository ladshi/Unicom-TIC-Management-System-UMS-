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
    public class StudentService
    {
        /*
        public bool AddStudent(Student student)
        {
            using (var conn = DataConfig.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert into Users
                        /*var userCmd = conn.CreateCommand();
                        userCmd.CommandText = "INSERT INTO Users (Username, Password) VALUES (@username, @password); SELECT last_insert_rowid();";
                        userCmd.Parameters.AddWithValue("@username", user.UserName);
                        userCmd.Parameters.AddWithValue("@password", user.Password);
                        var userId = Convert.ToInt32(userCmd.ExecuteScalar());

                        // Insert into Guardians
                        var guardianCmd = conn.CreateCommand();
                        guardianCmd.CommandText = "INSERT INTO Guardians (Name, ContactNo) VALUES (@name, @contact); SELECT last_insert_rowid();";
                        guardianCmd.Parameters.AddWithValue("@name", guardian.Name);
                        guardianCmd.Parameters.AddWithValue("@contact", guardian.PhoneNumber);
                        var guardianId = Convert.ToInt32(guardianCmd.ExecuteScalar());

                        // Insert into Students
                        var studentCmd = conn.CreateCommand();
                        studentCmd.CommandText = @"
                    INSERT INTO Students 
                    (FirstName, LastName, DOB, Gender, PhoneNumber, Address, Course, Email, GuardianId, UserId)
                    VALUES 
                    (@fname, @lname, @dob, @gender, @phone, @address, @course, @email, @guardianId, @userId);";

                        studentCmd.Parameters.AddWithValue("@fname", student.FirstName);
                        studentCmd.Parameters.AddWithValue("@lname", student.LastName);
                        studentCmd.Parameters.AddWithValue("@dob", student.DOB);
                        studentCmd.Parameters.AddWithValue("@gender", student.Gender);
                        studentCmd.Parameters.AddWithValue("@phone", student.PhoneNumber);
                        studentCmd.Parameters.AddWithValue("@address", student.Address);
                        studentCmd.Parameters.AddWithValue("@course", student.CourseName);
                        studentCmd.Parameters.AddWithValue("@email", student.Email);
                        //studentCmd.Parameters.AddWithValue("@guardianId", guardianId);
                        //studentCmd.Parameters.AddWithValue("@userId", userId);

                        studentCmd.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<Student> GetAllStudentDetails()
        {
            var students = new List<Student>();

            using (var conn = DataConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT s.Id, s.FirstName, s.LastName, s.DOB, s.Gender, s.PhoneNumber, 
                   s.Address, s.Course, s.Email, 
                   g.Name AS GuardianName, g.ContactNo AS GuardianContact
            FROM Students s
            INNER JOIN Guardians g ON s.GuardianId = g.Id;
        ";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new Student
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DOB = reader["DOB"].ToString(),
                            //Gender = reader["Gender"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            CourseName = reader["Course"].ToString(),
                            Email = reader["Email"].ToString(),
                           /* Guardian = new Guardian
                            {
                                Name = reader["GuardianName"].ToString(),
                                PhoneNumber = reader["GuardianContact"].ToString()
                            }
                        };

                        students.Add(student);
                    }
                }
            }

            return students;
        }
        */
    }
}
