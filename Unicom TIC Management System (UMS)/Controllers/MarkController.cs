using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class MarkController
    {
        public static void AddMark(Mark mark)
        {
            MarkService.AddMark(mark);
        }

        public static List<Mark> GetMarksByStudent(int studentId)
        {
            return MarkService.GetMarksByStudent(studentId);
        }

        public static List<MarkWithDetails> GetAllMarksWithDetails()
        {
            return MarkService.GetAllMarksWithDetails();
        }

    }
}
