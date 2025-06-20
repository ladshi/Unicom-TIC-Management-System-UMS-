using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class ExamController
    {
        public static void AddExam(Exam exam)
        {
            ExamService.AddExam(exam);
        }

        public static void UpdateExam(Exam exam)
        {
            ExamService.UpdateExam(exam);
        }

        public static void DeleteExam(int id)
        {
            ExamService.DeleteExam(id);
        }

        public static List<Exam> GetAllExams()
        {
            return ExamService.GetAllExams();
        }
    }
}
