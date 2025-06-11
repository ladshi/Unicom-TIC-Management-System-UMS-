using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string  FirstName { get; set; }
        private string LastName { get; set; }   
        private string DOB { get; set; }
        private string Gender { get; set; }
        private string phone_no { get; set; }

        private string Address { get; set; }
        private string  email { get; set; }
        private int CourseId { get; set; }
        private int UserId { get; set; }
        
    }
}
