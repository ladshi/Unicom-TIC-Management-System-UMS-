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
        /*
        public static bool AddStaff(Staff staff)
        {
            using (var conn = DataConfig.GetConnection())
            {
                try
                {
                    string sql = @"INSERT INTO Admin 
                (FirstName, LastName, ContactNo, Email, Address, UserId)
                VALUES (@first, @last, @contact, @email, @address, @userId)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@first", staff.FirstName);
                        cmd.Parameters.AddWithValue("@last", staff.LastName);
                        cmd.Parameters.AddWithValue("@contact", staff.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", staff.Email);
                        cmd.Parameters.AddWithValue("@address", staff.Address);
                        cmd.Parameters.AddWithValue("@userId", staff.UserId);

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
