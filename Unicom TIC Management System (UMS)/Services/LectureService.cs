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
                string query = "SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB FROM Lectures";

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
                            DOB = reader["DOB"].ToString()
                        };

                        lecturerList.Add(lecturer);
                    }
                }
            }

            return lecturerList;
        }

    }
}
