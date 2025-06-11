using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Repositaries;

namespace Unicom_TIC_Management_System__UMS_.Repositaries
{
    public static class Migration
    {
        public static void CreateTables()
        {
            using (var conn = DataConfig.GetConnection())
            { 
                var cmd = conn.CreateCommand();
            
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL
                        
                    );

                    CREATE TABLE IF NOT EXISTS Courses(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                        
                    );

                    CREATE TABLE IF NOT EXISTS Roles(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoleName TEXT NOT NULL

                    );
                ";
                cmd.ExecuteNonQuery();
            }

        }
    }
}