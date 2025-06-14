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
    internal class AdminService
    {
        public bool AddAdmin(Admin admin)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string sql = @"INSERT INTO Admin 
                    (FirstName, LastName, ContactNo, Email, Address, UserId)
                    VALUES (@first, @last, @contact, @email, @address, @userId)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@first", admin.FirstName);
                    cmd.Parameters.AddWithValue("@last", admin.LastName);
                    cmd.Parameters.AddWithValue("@contact", admin.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email", admin.Email);
                    cmd.Parameters.AddWithValue("@address", admin.Address);
                    cmd.Parameters.AddWithValue("@userId", admin.UserId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
