using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class RoomController
    {
        public static void AddRoom(RoomAllocation room)
        {
            RoomallocationService.AddRoom(room);
        }

        public static void UpdateRoom(RoomAllocation room)
        {
            RoomallocationService.UpdateRoom(room);
        }

        public static void DeleteRoom(int roomId)
        {
            RoomallocationService.DeleteRoom(roomId);
        }

        public List<RoomAllocation> GetAllRooms()
        {
            return RoomallocationService.GetAllRooms();
        }

        public static string GetRoomNameById(int id)
        {
            return RoomallocationService.GetRoomNameById(id);
        }

    }

}
