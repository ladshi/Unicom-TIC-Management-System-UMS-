using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class TimeTableController
    {
        private TimeTableService service = new TimeTableService();

        public void AddTimetable(Timetable t)
        {
            service.AddTimetable(t);
        }

        public void UpdateTimetable(Timetable t)
        {
            service.UpdateTimetable(t);
        }

        public void DeleteTimetable(int id)
        {
            service.DeleteTimetable(id);
        }

        public List<Timetable> GetAllTimetables()
        {
            return service.GetAllTimetables();
        }

        public static List<Timetable> GetAllTimetablesByStudentId(int studentId)
        {
            TimeTableService service = new TimeTableService();
            List<Timetable> allTimetables = service.GetAllTimetables();

            var student = StudentController
                            .GetAllStudentsWithUserData()
                            .FirstOrDefault(s => s.Item1.Id == studentId);

            if (student.Item1 == null)
                return new List<Timetable>();

            int courseId = student.Item1.CourseId;
            return allTimetables;
        }
    }
}
