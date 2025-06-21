using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class Guardian : Person
    {
        public string GuardianName { get; set; }
        public string GuardianContact { get; set; }
        public int StudentId { get; set; }
    }
}
