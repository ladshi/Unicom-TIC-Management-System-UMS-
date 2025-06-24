using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System__UMS_.Models;
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.Controllers
{
    public class StaffController
    {
        //private StaffService staffService = new StaffService();

        public static  bool AddStaff(Staff staff)
        {
            return StaffService.AddStaff(staff);  
        }

        public static List<Staff> GetAllStaffs()
        {
            return StaffService.GetAllStaffs();
        }

        public static bool UpdateStaff(Staff staff)
        {
            bool result = StaffService.UpdateStaff(staff);

            if (result)
            {
                MessageBox.Show("control ok");
            }

            return result;
            //return StaffService.UpdateStaff(staff);
            //MessageBox.Show("control ok");
        }

        public static bool DeleteStaff(int userId)
        {
            return StaffService.DeleteStaff(userId);
        }

        public static List<Staff> SearchStaffs(string keyword)
        {
            return StaffService.SearchStaffs(keyword);
        }

        public static int GetStaffCount()
        {
            return StaffService.GetStaffCount();
        }

    }
}
