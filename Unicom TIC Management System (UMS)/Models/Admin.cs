using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class Admin : Person
    {
        public int UserId { get; set; }
        public string AccessLevel { get; set; }
    }
}
