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
                string query = "SELECT UserId, Username, Password, Role FROM Users";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
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

        public static bool IsUsernameExists(string username)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool UpdateUser(User user)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"UPDATE Users 
                         SET Username = @username, Password = @password, Role = @role
                         WHERE UserId = @userId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.UserName);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role.ToString());
                    cmd.Parameters.AddWithValue("@userId", user.UserId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "DELETE FROM Users WHERE UserId = @userId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static int GetUserIdByUsername(string username)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT UserId FROM Users WHERE Username = @username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }
            return -1;
        }
        public static User GetUserById(int userId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE UserId = @userId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = (UserRole)System.Enum.Parse(typeof(UserRole), reader["Role"].ToString())
                            };
                        }
                    }
                }
            }
            return null;
        }

    }
}
