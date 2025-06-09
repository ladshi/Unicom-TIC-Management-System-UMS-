using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Repositaries
{
    public static class DataConfig
    {
        private static string connectionstring = "Data Source=unicomtic.db;version=3";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionstring);
            conn.Open();
            return conn;
        }
    }
}
