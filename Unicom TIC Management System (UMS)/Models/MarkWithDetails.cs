using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class MarkWithDetails
    {
        public string StudentName { get; set; }
        public string ExamName { get; set; }
        public string SubjectName { get; set; }
        public double MarksObtained { get; set; }
        public double MaxMarks { get; set; }
        public double Percentage { get; set; }
        public string Grade { get; set; }
    }
}
