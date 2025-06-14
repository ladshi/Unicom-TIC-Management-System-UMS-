using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Enum;

namespace Unicom_TIC_Management_System__UMS_.Models
{
    public class User
    {
       public int Id { get; set; }
       public string UserName { get; set; }
       public string Password {  get; set; }
       public UserRole Role { get; set; }

    }
}
