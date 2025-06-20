using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    internal class LectureService
    {
        public static bool AddLecturer(Lecturer lecturer)
        {
            using (var conn = DataConfig.GetConnection())
            {
                try
                {
                    string sql = @"INSERT INTO Lectures
                (FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId)
                VALUES (@first, @last, @phonenum, @email, @address, @DOB, @userId)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", lecturer.FirstName);
                        cmd.Parameters.AddWithValue("@last", lecturer.LastName);
                        cmd.Parameters.AddWithValue("@phonenum", lecturer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", lecturer.Email);
                        cmd.Parameters.AddWithValue("@address", lecturer.Address);
                        cmd.Parameters.AddWithValue("@DOB", lecturer.DOB);
                        cmd.Parameters.AddWithValue("@userId", lecturer.UserId);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show("Lecturer added successfully!");
                        return rows > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert Error: " + ex.Message); // Show what went wrong
                    return false;
                }
            }
        }

        public static List<Lecturer> GetAllLecturers()
        {
            List<Lecturer> lecturerList = new List<Lecturer>();

            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId FROM Lectures";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturer lecturer = new Lecturer
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            DOB = reader["DOB"].ToString(),
                            UserId = Convert.ToInt32(reader["UserId"])
                        };
                        lecturerList.Add(lecturer);
                    }
                }
            }
            return lecturerList;
        }

        public static Lecturer GetLecturerById(int userId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId 
                                 FROM Lectures 
                                 WHERE UserId = @userId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lecturer
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                UserId = Convert.ToInt32(reader["UserId"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool UpdateLecturer(Lecturer lec)
        {
            using (var conn = DataConfig.GetConnection())
            {
                // Replace the line: string query =;
                string query = @"UPDATE Lectures 
                                 SET FirstName = @FirstName, 
                                     LastName = @LastName, 
                                     PhoneNumber = @PhoneNumber, 
                                     Email = @Email, 
                                     Address = @Address, 
                                     DOB = @DOB 
                                 WHERE UserId = @UserId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", lec.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", lec.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", lec.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", lec.Email);
                    cmd.Parameters.AddWithValue("@Address", lec.Address);
                    cmd.Parameters.AddWithValue("@DOB", lec.DOB);
                    cmd.Parameters.AddWithValue("@UserId", lec.UserId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }   

        public static bool DeleteLecturer(int userId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "DELETE FROM Lectures WHERE UserId = @userId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Lecturer> SearchLecturers(string keyword)
        {
            List<Lecturer> result = new List<Lecturer>();
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId 
                                 FROM Lectures 
                                 WHERE FirstName LIKE @kw OR LastName LIKE @kw OR Email LIKE @kw";      

                using (var cmd = new SQLiteCommand(query, conn))        
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lecturer lec = new Lecturer
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                UserId = Convert.ToInt32(reader["UserId"])
                            };
                            result.Add(lec);
                        }
                    }
                }           
            }
            return result;
        }   

    }
}
