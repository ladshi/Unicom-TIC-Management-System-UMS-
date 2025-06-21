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
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
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

                      CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        First_name TEXT NOT NULL,
                        Last_name TEXT NOT NULL,
                        DOB TEXT NOT NULL, 
                        Gender INTEGER NOT NULL ,
                        Email TEXT NOT NULL UNIQUE,
                        PhoneNumber TEXT NOT NULL ,
                        Address  TEXT NOT NULL,
                        Enrollment_date TEXT, 
                        CourseId INTEGER,
                        UserId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(Id),
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                        
                    );
               

                    CREATE TABLE IF NOT EXISTS Gurdians(
                        Gurdian_Name TEXT NOT NULL,
                        PhoneNumber TEXT NOT NULL,
                        StudentId INTEGER,
                        FOREIGN KEY (StudentId) REFERENCES Students(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Admin (
                       Id INTEGER PRIMARY KEY AUTOINCREMENT,
                       FirstName TEXT NOT NULL,
                       LastName TEXT NOT NULL,
                       PhoneNumber TEXT,
                       Email TEXT,
                       Address TEXT,
                       DOB TEXT,
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
                        DOB TEXT,
                        UserId INTEGER,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );

                    CREATE TABLE IF NOT EXISTS RoomAllocation (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Lectures (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        PhoneNumber TEXT,
                        Email TEXT,
                        Address TEXT,
                        DOB TEXT,
                        UserId INTEGER NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    );
                    
                    CREATE TABLE IF NOT EXISTS Exams (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        ExamDate TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Marks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER,
                        SubjectId INTEGER,
                        ExamId INTEGER,
                        MarksObtained REAL,
                        MaxMarks REAL,
                        FOREIGN KEY(StudentId) REFERENCES Students(Id),
                        FOREIGN KEY(SubjectId) REFERENCES Subjects(Id),
                        FOREIGN KEY(ExamId) REFERENCES Exams(Id)
                    );
                    
                    CREATE TABLE Timetable (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Day TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        SubjectId INTEGER NOT NULL,
                        LectureId INTEGER NOT NULL,
                        TimeSlot TEXT NOT NULL,
                        RoomId INTEGER NOT NULL,
                        FOREIGN KEY(SubjectId) REFERENCES Subjects(Id),
                        FOREIGN KEY(LectureId) REFERENCES Lecturers(Id),
                        FOREIGN KEY(RoomId) REFERENCES Rooms(Id)
                    );


                ";
                cmd.ExecuteNonQuery();
            }

        }
    }
}