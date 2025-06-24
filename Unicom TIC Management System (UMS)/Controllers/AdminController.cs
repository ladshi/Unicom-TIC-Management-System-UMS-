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
        public static bool AddAdmin(Admin admin)
        {
            return AdminService.AddAdmin(admin);  
        }

        public static List<Admin> GetAdmins()
        {
            return AdminService.GetAllAdmins();
        }

        public static bool UpdateAdmin(Admin admin)
        {
            return AdminService.UpdateAdmin(admin);
        }

        public static bool DeleteAdmin(int userId)
        {
            return AdminService.DeleteAdmin(userId);
        }

        public static List<Admin> SearchAdmins(string keyword)
        {
            return AdminService.SearchAdmins(keyword);
        }

        public static int GetAdminCount()
        {
            return AdminService.GetAdminCount();
        }

    }
}
