using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class Student : Person
    {
        public string DOB { get; set; }
        public string EnrollmentDate { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public string CourseName { get; set; }
    }
}
