using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class Timetable
    {
        public int Id { get; set; }
        public string Day { get; set; }           
        public string StartTime { get; set; }     
        public string EndTime { get; set; }
        public int SubjectId { get; set; }
        public int LectureId { get; set; }
        public string TimeSlot { get; set; }
        public int RoomId { get; set; }
    }
}
