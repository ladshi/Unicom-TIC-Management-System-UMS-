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
    public class TimeTableService
    {
        public void AddTimetable(Timetable t)
        {
            using (var con = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Timetables (Day, StartTime, EndTime, SubjectId, LectureId, TimeSlot, RoomId) VALUES (@Day, @StartTime, @EndTime, @SubjectId, @LectureId, @TimeSlot, @RoomId)", con);
                cmd.Parameters.AddWithValue("@Day", t.Day);
                cmd.Parameters.AddWithValue("@StartTime", t.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", t.EndTime);
                cmd.Parameters.AddWithValue("@SubjectId", t.SubjectId);
                cmd.Parameters.AddWithValue("@LectureId", t.LectureId);
                cmd.Parameters.AddWithValue("@TimeSlot", t.TimeSlot);
                cmd.Parameters.AddWithValue("@RoomId", t.RoomId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTimetable(Timetable t)
        {
            using (var con = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Timetables SET Day=@Day, StartTime=@StartTime, EndTime=@EndTime, SubjectId=@SubjectId, LectureId=@LectureId, TimeSlot=@TimeSlot, RoomId=@RoomId WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Day", t.Day);
                cmd.Parameters.AddWithValue("@StartTime", t.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", t.EndTime);
                cmd.Parameters.AddWithValue("@SubjectId", t.SubjectId);
                cmd.Parameters.AddWithValue("@LectureId", t.LectureId);
                cmd.Parameters.AddWithValue("@TimeSlot", t.TimeSlot);
                cmd.Parameters.AddWithValue("@RoomId", t.RoomId);
                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTimetable(int id)
        {
            using (var con = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Timetable WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Timetable> GetAllTimetables()
        {
            var list = new List<Timetable>();
            using (var con = DataConfig.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Timetable", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Timetable
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Day = reader["Day"].ToString(),
                        StartTime = reader["StartTime"].ToString(),
                        EndTime = reader["EndTime"].ToString(),
                        SubjectId = Convert.ToInt32(reader["SubjectId"]),
                        LectureId = Convert.ToInt32(reader["LectureId"]),
                        TimeSlot = reader["TimeSlot"].ToString(),
                        RoomId = Convert.ToInt32(reader["RoomId"])
                    });
                }
            }
            return list;
        }
    }
}

