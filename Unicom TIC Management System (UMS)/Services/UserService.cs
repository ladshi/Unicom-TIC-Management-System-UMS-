using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Enum;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Services
{
    internal class UserService
    {
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT Id, Username, Password, Role FROM Users";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            UserName = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = System.Enum.TryParse(reader["Role"].ToString(), out UserRole role) ? role : UserRole.Student,
                        });
                    }
                }
            }
            return users;
        }

        public static int AddUser(User user)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string sql = "INSERT INTO Users (Username, Password, Role) VALUES (@user, @pass, @role)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user.UserName);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role.ToString()); // Enum to string
                    cmd.ExecuteNonQuery();
                    return (int)conn.LastInsertRowId;
                }
            }
        }

        public static bool IsUserTableEmpty()
        {
            using (var conn = DataConfig.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Users";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }
    }
}
