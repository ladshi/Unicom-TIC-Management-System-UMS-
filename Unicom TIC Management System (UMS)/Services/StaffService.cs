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
    internal class StaffService
    {
        public static bool AddStaff(Staff staff)
        {
            using (var conn = DataConfig.GetConnection())
            {
                try
                {
                    string sql = @"INSERT INTO Staff 
                (FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId)
                VALUES (@first, @last, @phonenum, @email, @address, @DOB, @userId)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", staff.FirstName);
                        cmd.Parameters.AddWithValue("@last", staff.LastName);
                        cmd.Parameters.AddWithValue("@phonenum", staff.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", staff.Email);
                        cmd.Parameters.AddWithValue("@address", staff.Address);
                        cmd.Parameters.AddWithValue("@DOB", staff.DOB);
                        cmd.Parameters.AddWithValue("@userId", staff.UserId);

                        int rows = cmd.ExecuteNonQuery();
                        //MessageBox.Show("Admin insert rows: " + rows); // Add this line to see if rows > 0
                        MessageBox.Show("Staff added successfully");
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
        public static List<Staff> GetAllStaffs()
        {
            List<Staff> staffList = new List<Staff>();

            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId FROM Staff";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Staff staff = new Staff
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            DOB = reader["DOB"].ToString(),
                            UserId = Convert.ToInt32(reader["UserId"])
                        };

                        staffList.Add(staff);
                    }
                }
            }

            return staffList;
        }

        public static bool UpdateStaff(Staff staff)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"UPDATE Staff 
                                SET FirstName = @FirstName, LastName = @LastName,
                                    PhoneNumber = @PhoneNumber, Email = @Email,
                                    Address = @Address, DOB = @DOB
                                WHERE UserId = @UserId";

                MessageBox.Show("Reached StaffService: " + staff.FirstName);
                MessageBox.Show("Trying to update UserId: " + staff.UserId +
                "\nFirstName: " + staff.FirstName +
                "\nLastName: " + staff.LastName +
                "\nPhone: " + staff.PhoneNumber +
                "\nEmail: " + staff.Email +
                "\nAddress: " + staff.Address +
                "\nDOB: " + staff.DOB);


                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", staff.Email);
                    cmd.Parameters.AddWithValue("@Address", staff.Address);
                    cmd.Parameters.AddWithValue("@DOB", staff.DOB);
                    cmd.Parameters.AddWithValue("@UserId", staff.UserId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show("Rows affected: " + rowsAffected);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteStaff(int userId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "DELETE FROM Staff WHERE UserId = @userId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Staff> SearchStaffs(string keyword)
        {
            List<Staff> result = new List<Staff>();
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB, UserId 
                            FROM Staff 
                            WHERE FirstName LIKE @kw OR LastName LIKE @kw OR Email LIKE @kw";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Staff staff = new Staff
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                UserId = Convert.ToInt32(reader["UserId"])
                            };
                            result.Add(staff);
                        }
                    }
                }
            }
            return result;
        }
    }
}
 
