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
    public class AdminService
    {
        public static bool AddAdmin(Admin admin)
        {
            
            using (var conn = DataConfig.GetConnection())
            {
                try
                {
                    string sql = @"INSERT INTO Admin 
                (FirstName, LastName, PhoneNumber, Email, Address, DOB , UserId, AccessLevel)
                VALUES (@first, @last, @phonenum, @email, @address, @DOB, @userId,@accesslevel)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", admin.FirstName);
                        cmd.Parameters.AddWithValue("@last", admin.LastName);
                        cmd.Parameters.AddWithValue("@phonenum", admin.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", admin.Email);
                        cmd.Parameters.AddWithValue("@address", admin.Address);
                        cmd.Parameters.AddWithValue("@DOB", admin.DOB);
                        cmd.Parameters.AddWithValue("@userId", admin.UserId);
                        cmd.Parameters.AddWithValue("@accesslevel",admin.AccessLevel);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show("Admin added successfully."); 
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

        public static List<Admin> GetAllAdmins()
        {
            List<Admin> adminList = new List<Admin>();

            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT FirstName, LastName, PhoneNumber, Email, Address, DOB, AccessLevel FROM Admin";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Admin admin = new Admin
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            DOB = reader["DOB"].ToString(),
                            AccessLevel = reader["AccessLevel"].ToString()
                        };

                        adminList.Add(admin);
                    }
                }
            }

            return adminList;
        }


        /*public static bool UpdateAdmin(Admin admin)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"UPDATE Admins 
                         SET FirstName = @FirstName, LastName = @LastName,
                             ContactNo = @ContactNo, Email = @Email,
                             Address = @Address, AccessLevel = @AccessLevel
                         WHERE Username = @Username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                    cmd.Parameters.AddWithValue("@ContactNo", admin.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@Address", admin.Address);
                    cmd.Parameters.AddWithValue("@AccessLevel", admin.AccessLevel);
                    cmd.Parameters.AddWithValue("@Username", admin.Username);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }*/

    }
}






