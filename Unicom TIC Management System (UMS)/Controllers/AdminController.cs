using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Repositaries;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    internal class AdminController
    {
        private AdminService adminService = new AdminService();

        public bool AddAdmin(Admin admin)
        {
            return adminService.AddAdmin(admin);  // returns true if insert successful
        }
    }
}
