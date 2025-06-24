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
        public static bool UpdateLecturer(Lecturer lec)
        {
            return LectureService.UpdateLecturer(lec);
        }

        public static bool DeleteLecturer(int userId)
        {
            return LectureService.DeleteLecturer(userId);
        }

        public static List<Lecturer> SearchLecturers(string keyword)
        {
            return LectureService.SearchLecturers(keyword);
        }

        public static string GetLecturerNameById(int userId)
        {
            return LectureService.GetLecturerNameById(userId);
        }

        public static int GetLecturerCount()
        {
            return LectureService.GetLecturerCount();
        }


    }
}
