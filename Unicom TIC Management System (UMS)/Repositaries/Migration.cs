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
                        Username TEXT NOT NULL UNIQUE,
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
                         CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        First_name TEXT NOT NULL,
                        Last_name TEXT NOT NULL,
                        DOB TEXT NOT NULL, 
                        Gender INTEGER NOT NULL ,
                        Email TEXT NOT NULL UNIQUE,
                        Phone_Number TEXT NOT NULL ,
                        Address  TEXT NOT NULL,
                        Enrollment_date TEXT, 
                        CourseId INTEGER,
                        UserId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(Id)
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                        
                    );
               

                    CREATE TABLE IF NOT EXISTS Gurdians(
                        Gurdian_Name TEXT NOT NULL,
                        Contact_No TEXT NOT NULL,
                        StudentId INTEGER,
                        FOREIGN KEY (StudentId) REFERENCES Students(Id)
                    );

     
                ";
                cmd.ExecuteNonQuery();
            }

        }
    }
}