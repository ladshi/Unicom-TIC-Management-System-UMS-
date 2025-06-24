using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System__UMS_.Controllers;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class defaultForm : Form
    {
        public defaultForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void defaultForm_Load(object sender, EventArgs e)
        {
            lblTotalStudents.Text = "Total Students: 0";
            lblTotalStaffs.Text = "Total Staffs: 0";
            lblTotalCourses.Text = "Total Courses: 0";
            lblTotalAdmins.Text = "Total Admins: 0";
            lblTotalLecturers.Text = "Total Lecturers: 0";
            lblTotalSubjects.Text = "Total Subjects: 0";

            lblTotalStudents.Text = $"Total Students: {StudentController.GetStudentCount()}";
            lblTotalStaffs.Text = $"Total Staffs: {StaffController.GetStaffCount()}";
            lblTotalCourses.Text = $"Total Courses: {CourseController.GetCourseCount()}";
            lblTotalAdmins.Text = $"Total Admins: {AdminController.GetAdminCount()}";
            lblTotalLecturers.Text = $"Total Lecturers: {LectureController.GetLecturerCount()}";
            lblTotalSubjects.Text = $"Total Subjects: {SubjectController.GetSubjectCount()}";

        }
    }
}
