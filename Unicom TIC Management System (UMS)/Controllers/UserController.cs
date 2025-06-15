using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    internal class UserController
    {
        public static bool ValidateLogin(string username, string password)
        {
            List<User> users = UserService.GetAllUsers();

            foreach (var user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public static int AddUser(User user)
        {
            return UserService.AddUser(user);
        }

        public bool IsUserTableEmpty()
        {
            return UserService.IsUserTableEmpty();
        }

        public static string GetAccessLevel(string username)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = @"
                    SELECT A.AccessLevel
                    FROM Admin A
                    INNER JOIN Users U ON A.UserId = U.Id
                    WHERE U.UserName = @username";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "Admin"; // fallback default
                }
            }
        }


    }
}
