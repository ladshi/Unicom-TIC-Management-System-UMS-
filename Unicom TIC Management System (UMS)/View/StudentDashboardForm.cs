using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Unicom_TIC_Management_System__UMS_.Controllers;
using Unicom_TIC_Management_System__UMS_.Models;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class StudentDashboardForm : Form
    {
        private string username;

        public StudentDashboardForm(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadStudentProfile();
            LoadMarks();
            LoadTimetable();
        }

        private void LoadStudentDashboard()
        {
            int userId = UserController.GetUserIdByUsername(username);

            var studentList = StudentController.GetAllStudentsWithUserData();

            foreach (var (student, guardian, uname, pwd, courseName) in studentList)
            {
                if (student.UserId == userId)
                {
                    textName.Text = student.FirstName + " " + student.LastName;
                    textDOB.Text = student.DOB;
                    textGender.Text = student.Gender.ToString();
                    textCourse.Text = courseName;

                    textGuardian.Text = guardian.GuardianName;
                    textContact.Text = guardian.PhoneNumber;

                    break;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxProfile_Enter(object sender, EventArgs e)
        {

        }

        private void StudentDashboardForm_Load(object sender, EventArgs e)
        {
            LoadStudentProfile();
        }

        private void LoadStudentProfile()
        {
            //int userId = UserController.GetUserIdByUsername(username); 
            /*Student student = StudentController.GetStudentByUserId(userId); 
            //Guardian guardian = GuardianController.GetGuardianById(student.GuardianId); 
            if (student != null)
            {
                textName.Text = student.FirstName + " " + student.LastName;
                textDOB.Text = student.DOB;
                textGender.Text = student.Gender.ToString();
                textCourse.Text = CourseController.GetCourseNameById(student.CourseId);
                textGuardian.Text = guardian?.Name ?? "";
                textContact.Text = guardian?.ContactNo ?? "";
            }*/
        }

        private void LoadMarks()
        {
            int userId = UserController.GetUserIdByUsername(username);

            var studentList = StudentController.GetAllStudentsWithUserData();
            int studentId = -1;

            foreach (var (student, guardian, uname, pwd, courseName) in studentList)
            {
                if (student.UserId == userId)
                {
                    studentId = student.Id;
                    break;
                }
            }

            if (studentId != -1)
            {
                var marks = MarkController.GetMarksByStudent(studentId);

                dataGridViewMarks.DataSource = marks;
               
            }
        }

        private void LoadTimetable()
        {
            int userId = UserController.GetUserIdByUsername(username);
            int studentId = -1;

            var studentList = StudentController.GetAllStudentsWithUserData();
            foreach (var (student, _, uname, _, _) in studentList)
            {
                if (student.UserId == userId)
                {
                    studentId = student.Id;
                    break;
                }
            }

            if (studentId != -1)
            {
                var timetables = TimeTableController.GetAllTimetablesByStudentId(studentId);
                dataGridViewTimeTable.DataSource = timetables;
            }
        }
        
        
    }
}
