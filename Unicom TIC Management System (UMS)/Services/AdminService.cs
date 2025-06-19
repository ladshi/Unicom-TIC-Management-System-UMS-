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
        /*
        public bool AddAdmin(Admin admin)
        {
            
            using (var conn = DataConfig.GetConnection())
            {
                try
                {
                    string sql = @"INSERT INTO Admin 
                (FirstName, LastName, ContactNo, Email, Address, UserId, AccessLevel)
                VALUES (@first, @last, @contact, @email, @address, @userId,@accesslevel)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", admin.FirstName);
                        cmd.Parameters.AddWithValue("@last", admin.LastName);
                        cmd.Parameters.AddWithValue("@contact", admin.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", admin.Email);
                        cmd.Parameters.AddWithValue("@address", admin.Address);
                        cmd.Parameters.AddWithValue("@userId", admin.UserId);
                        cmd.Parameters.AddWithValue("@accesslevel",admin.AccessLevel);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show("Admin insert rows: " + rows); // Add this line to see if rows > 0
                        return rows > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert Error: " + ex.Message); // Show what went wrong
                    return false;
                }
            }
        }*/
    }
}






