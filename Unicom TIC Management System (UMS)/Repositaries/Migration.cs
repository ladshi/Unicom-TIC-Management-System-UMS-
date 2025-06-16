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
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                        
                    );

                    CREATE TABLE IF NOT EXISTS CourseSubjects (
                        CourseId INTEGER NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        PRIMARY KEY (CourseId, SubjectId),
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId) ON DELETE CASCADE,
                        FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId) ON DELETE CASCADE
                    );


                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL UNIQUE
                    );
                    
                    CREATE TABLE IF NOT EXISTS Courses(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                        
                    );
                    -- optional role table for future use
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
                        FOREIGN KEY (CourseId) REFERENCES Courses(Id),
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                        
                    );
               

                    CREATE TABLE IF NOT EXISTS Gurdians(
                        Gurdian_Name TEXT NOT NULL,
                        Contact_No TEXT NOT NULL,
                        StudentId INTEGER,
                        FOREIGN KEY (StudentId) REFERENCES Students(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Admin (
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,
                       FirstName TEXT NOT NULL,
                       LastName TEXT NOT NULL,
                       ContactNo TEXT,
                        Email TEXT,
                        Address TEXT,
                        UserId INTEGER NOT NULL,
                        AccessLevel TEXT NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                        );

                    
                    CREATE TABLE IF NOT EXISTS Staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        PhoneNumber TEXT,
                        Email TEXT,
                        Address TEXT,
                        Subject TEXT,
                        UserId INTEGER,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );

                    CREATE TABLE IF NOT EXISTS RoomAllocation (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomNumber TEXT NOT NULL,
                        CourseId INTEGER,
                        LectureId INTEGER,
                        AllocationDate TEXT,
                        FOREIGN KEY (CourseId) REFERENCES Courses(Id),
                        FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Lectures (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        LectureTitle TEXT NOT NULL,
                        LectureDate TEXT NOT NULL,
                        CourseId INTEGER NOT NULL,
                        StaffId INTEGER NOT NULL,
                        FOREIGN KEY (CourseId) REFERENCES Courses(Id),
                        FOREIGN KEY (StaffId) REFERENCES Staff(Id)
                    );
                    
                    CREATE TABLE IF NOT EXISTS Exams (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamTitle TEXT NOT NULL,
                        ExamDate TEXT NOT NULL,
                        CourseId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Marks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER NOT NULL,
                        ExamId INTEGER NOT NULL,
                        Mark INTEGER NOT NULL,
                        Grade TEXT,
                        FOREIGN KEY (StudentId) REFERENCES Students(Id),
                        FOREIGN KEY (ExamId) REFERENCES Exams(Id)
                    );


                ";
                cmd.ExecuteNonQuery();
            }

        }
    }
}