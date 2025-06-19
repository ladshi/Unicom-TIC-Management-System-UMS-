using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    internal class LectureController
    {
        public static bool AddLecture(Lecturer lecturer)
        {
            return LectureService.AddLecturer(lecturer);
        }
        public static List<Lecturer> GetLecturers()
        {
            return LectureService.GetAllLecturers();
        }
    }
}
