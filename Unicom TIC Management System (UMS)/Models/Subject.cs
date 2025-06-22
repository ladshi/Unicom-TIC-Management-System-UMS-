using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; internal set; }
    }
}
