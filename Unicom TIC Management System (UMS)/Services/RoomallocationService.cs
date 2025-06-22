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
    public static class RoomallocationService
    {
        public static void AddRoom(RoomAllocation room)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "INSERT INTO RoomAllocation (RoomName, RoomType) VALUES (@RoomName, @RoomType)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRoom(RoomAllocation room)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "UPDATE RoomAllocation SET RoomName = @RoomName, RoomType = @RoomType WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@Id", room.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteRoom(int roomId)
        {
            using (var conn = DataConfig.GetConnection())
            {
                string query = "DELETE FROM RoomAllocation WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", roomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<RoomAllocation> GetAllRooms()
        {
            List<RoomAllocation> rooms = new List<RoomAllocation>();

            using (var conn = DataConfig.GetConnection())
            {
                string query = "SELECT * FROM RoomAllocation";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RoomAllocation room = new RoomAllocation
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString()
                        };
                        rooms.Add(room);
                    }
                }
            }

            return rooms;
        }
    }
}
