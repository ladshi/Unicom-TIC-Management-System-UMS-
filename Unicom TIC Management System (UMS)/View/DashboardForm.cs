using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System__UMS_.Enum;
using Unicom_TIC_Management_System__UMS_.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class DashboardForm : Form
    {
        private UserRole currentRole;
        private string username;

        public DashboardForm(UserRole role, string username)
        {
            InitializeComponent();
            this.currentRole = role;
            this.username = username;
            //this.accessLevel = accessLevel;

            LoadForm(new defaultForm());


            LoadTreeViewForRole(currentRole);
            ShowWelcomeMessage();
        }

        public void LoadForm(object formObj)
        {
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.RemoveAt(0);
            }

            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            this.mainPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void ShowWelcomeMessage()
        {
            lblWelcome.Text = $"Welcome, {username}  ({currentRole})";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadTreeViewForRole(UserRole role)
        {
            treeView1.Nodes.Clear();

            if (currentRole == UserRole.MainAdmin)
            {
                TreeNode userNode = new TreeNode("Manage Users");
                userNode.Nodes.Add("Manage Admins");
                userNode.Nodes.Add("Manage Staffs");
                userNode.Nodes.Add("Manage Students");
                userNode.Nodes.Add("Manage Lecturers");

                TreeNode academicNode = new TreeNode("Manage Academics");
                academicNode.Nodes.Add("Manage Courses & Subjects");
                academicNode.Nodes.Add("Manage Exams");
                academicNode.Nodes.Add("Manage Marks");
                academicNode.Nodes.Add("Manage RoomAllocation");
                academicNode.Nodes.Add("Manage Timetables");

                treeView1.Nodes.Add(userNode);
                treeView1.Nodes.Add(academicNode);
            }
            else if (currentRole == UserRole.Admin)
            {
                TreeNode userNode = new TreeNode("Manage Users");

                userNode.Nodes.Add("Manage Staffs");
                userNode.Nodes.Add("Manage Students");
                userNode.Nodes.Add("Manage Lecturers");

                TreeNode academicNode = new TreeNode("Manage Academics");
                academicNode.Nodes.Add("Manage Courses & Subjects");
                academicNode.Nodes.Add("Manage Exams");
                academicNode.Nodes.Add("Manage Marks");
                academicNode.Nodes.Add("Manage RoomAllocation");
                academicNode.Nodes.Add("Manage Timetables");

                treeView1.Nodes.Add(userNode);
                treeView1.Nodes.Add(academicNode);
            }
            else if (currentRole == UserRole.Staff)
            {
                TreeNode academicNode = new TreeNode("Manage Academics");
                academicNode.Nodes.Add("Manage Marks");
                academicNode.Nodes.Add("Manage Exams");
                academicNode.Nodes.Add("Manage Timetables");

                treeView1.Nodes.Add(academicNode);
            }
            else if (currentRole == UserRole.Lecturer)
            {
                TreeNode academicNode = new TreeNode("Manage Academics");
                academicNode.Nodes.Add("Manage Marks");
                academicNode.Nodes.Add("Manage Timetables");

                treeView1.Nodes.Add(academicNode);
            }
            /*else if (currentRole == UserRole.Student)
            {
                StudentDashboardForm studentdashboardForm = new StudentDashboardForm(currentRole, username);
                studentdashboardForm.Show();
                this.Hide(); 
                return;
            }*/
                /*else if (currentRole == UserRole.Student)
                {
                    TreeNode studentNode = new TreeNode("Student Portal");
                    studentNode.Nodes.Add("My Marks");
                    studentNode.Nodes.Add("My Timetable");
                    studentNode.Nodes.Add("My Profile");

                    treeView1.Nodes.Add(studentNode);
                }*/

                treeView1.ExpandAll(); // optional
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNode = e.Node.Text;

            switch (selectedNode)
            {
                case "Manage Admins":
                    LoadForm(new AdminForm());  
                    break;

                case "Manage Staffs":
                    LoadForm(new AdminForm(false, UserRole.Staff));  
                    break;

                case "Manage Lecturers":
                    LoadForm(new AdminForm(false, UserRole.Lecturer));  
                    break;

                case "Manage Students":
                    LoadForm(new StudentForm());  
                    break;

                case "Manage Courses & Subjects":
                    //MessageBox.Show("Trying to open CourseSubjectForm");
                    //LoadForm(new CourseSubjectForm());
                    //break;
                    LoadForm(new CourseSubjectForm());  
                    break;

                case "Manage Exams":
                    LoadForm(new ExamForm());  
                    break;

                case "Manage Marks":
                    LoadForm(new MarksForm()); 
                    break;

                case "Manage RoomAllocation":
                    LoadForm(new RoomAllocationForm());
                    break;

                case "Manage Timetables":
                    LoadForm(new TimeTableForm());
                    break;

                /*case "Manage Timetables":
                case "View Timetables":
                    LoadForm(new TimetableForm());
                    break;

                case "My Marks":
                    LoadForm(new MyMarksForm(username)); 

                case "My Timetable":
                    LoadForm(new MyTimetableForm());
                    break;

                /*case "My Profile":
                    LoadForm(new MyProfileForm(username));  
                    break;*/

                default:
                    LoadForm(new defaultForm());
                    break;
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
