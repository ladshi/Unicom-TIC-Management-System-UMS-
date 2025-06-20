using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public string ExamDate { get; set; } // stored as string (yyyy-MM-dd)
    }
}
