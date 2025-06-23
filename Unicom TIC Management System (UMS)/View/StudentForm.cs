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
using Unicom_TIC_Management_System__UMS_.Enum;
using Unicom_TIC_Management_System__UMS_.Models;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class StudentForm : Form
    {
        private int selectedStudentId = -1;
        private int selectedUserId = -1;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void LoadCoursesToComboBox()
        {
            var courses = CourseController.GetAllCourses();
            courseCombo.DataSource = courses;
            courseCombo.DisplayMember = "Name";
            courseCombo.ValueMember = "Id";
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            InitializeStudentGrid();
            comboGender.DataSource = System.Enum.GetValues(typeof(Gender));
            LoadCoursesToComboBox();
            LoadStudentsToGrid();
        }

        private void InitializeStudentGrid()
        {
            studentsgridview.Columns.Clear();

            studentsgridview.Columns.Add("Id", "Student ID");                      
            studentsgridview.Columns.Add("FirstName", "First Name");              
            studentsgridview.Columns.Add("LastName", "Last Name");                
            studentsgridview.Columns.Add("Gender", "Gender");                      
            studentsgridview.Columns.Add("DOB", "DateOfBirth");                    
            studentsgridview.Columns.Add("PhoneNumber", "Phone Number");
            studentsgridview.Columns.Add("Email", "Email");
            studentsgridview.Columns.Add("Address", "Address");                   
            studentsgridview.Columns.Add("GuardianName", "Guardian Name");         
            studentsgridview.Columns.Add("GuardianContact", "Guardian Contact");   
            studentsgridview.Columns.Add("UserId", "User ID");
            studentsgridview.Columns.Add("Username", "Username");
            studentsgridview.Columns.Add("Password", "Password");
            studentsgridview.Columns.Add("CourseName", "Course");

            studentsgridview.Columns["UserId"].Visible = false;
            studentsgridview.Columns["Password"].Visible = false;
        }

        private void LoadStudentsToGrid()
        {
            studentsgridview.Rows.Clear();
            var students = StudentController.GetAllStudentsWithUserData();

            foreach (var (student, guardian, username, password, courseName) in students)
            {
                studentsgridview.Rows.Add(
                    student.Id,
                    student.FirstName,
                    student.LastName,
                    student.Gender.ToString(),
                    student.DOB.ToString(),
                    student.PhoneNumber,
                    student.Email,
                    student.Address,
                    guardian.GuardianName,
                    guardian.GuardianContact,
                    student.UserId,
                    username,
                    password,
                    courseName
                );
            }

            studentsgridview.Columns["UserId"].Visible = false;
            studentsgridview.Columns["Password"].Visible = false;
        }

        private void ButtonADD_Click(object sender, EventArgs e)
        {
            var username = textSusername.Text.Trim();
            var password = textSpassword.Text.Trim();

            if (UserController.IsUsernameExists(username))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            var user = new User
            {
                UserName = textSusername.Text,
                Password = textSpassword.Text,
                Role = UserRole.Student
            };

            int userId = UserController.AddUser(user);


            var student = new Student
            {
                FirstName = textfirstname.Text,
                LastName = textSlastname.Text,
                DOB = dateTimePickerDOB.Value.ToString("yyyy-MM-dd"),
                Gender = (Gender)comboGender.SelectedItem,
                PhoneNumber = textSPhoneNo.Text,
                Address = textSaddress.Text,
                Email = textEmail.Text,
                CourseId = Convert.ToInt32(courseCombo.SelectedValue),

                UserId = userId
            };

            var guardian = new Guardian
            {
                GuardianName = textGurname.Text,
                PhoneNumber = textGurPhoNo.Text
            };

            StudentController.AddStudent(student, guardian);

            MessageBox.Show("Student added successfully.");
            ClearFields();
            LoadStudentsToGrid();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1 || selectedUserId == -1)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this student?",
                                           "Confirm Delete", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                StudentController.DeleteStudent(selectedStudentId, selectedUserId);
                MessageBox.Show("Student deleted successfully.");
                ClearFields();
                LoadStudentsToGrid();
            }
        }

        private void buttonSEARCH_Click(object sender, EventArgs e)
        {
            string keyword = searchstudent.Text.Trim();
            studentsgridview.Rows.Clear();

            var students = StudentController.SearchByName(keyword);
            foreach (var (student, guardian) in students)
            {
                studentsgridview.Rows.Add(
                    student.Id,
                    student.FirstName,
                    student.LastName,
                    student.Gender.ToString(),
                    student.DOB.ToString(),
                    student.PhoneNumber,
                    student.Email,
                    student.Address,
                    guardian.GuardianName,
                    guardian.GuardianContact,
                    student.UserId
                );
            }
        }
         
        private void ClearFields()
        {
            textfirstname.Clear();
            textSlastname.Clear();
            textSPhoneNo.Clear();
            textEmail.Clear();
            textSaddress.Clear();
            textSusername.Clear();
            textSpassword.Clear();
            textGurname.Clear();
            textGurPhoNo.Clear();
            dateTimePickerDOB.Value = DateTime.Today;
            comboGender.SelectedIndex = 0;
            selectedStudentId = -1;
            selectedUserId = -1;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1 || selectedUserId == -1)
            {
                MessageBox.Show("Please select a student from the table first.");
                return;
            }

            var user = new User
            {
                UserId = selectedUserId,
                UserName = textSusername.Text,
                Password = textSpassword.Text,
                Role = UserRole.Student
            };

            UserController.UpdateUser(user);

            var student = new Student
            {
                Id = selectedStudentId,
                UserId = selectedUserId,
                FirstName = textfirstname.Text,
                LastName = textSlastname.Text,
                DOB = dateTimePickerDOB.Value.ToString("yyyy-MM-dd"),
                Gender = (Gender)comboGender.SelectedItem,
                PhoneNumber = textSPhoneNo.Text,
                Address = textSaddress.Text,
                Email = textEmail.Text,
                CourseId = Convert.ToInt32(courseCombo.SelectedValue)
            };

            var guardian = new Guardian
            {
                StudentId = selectedStudentId,
                GuardianName = textGurname.Text,
                PhoneNumber = textGurPhoNo.Text
            };

            StudentController.UpdateStudent(student, guardian);

            MessageBox.Show("Student updated successfully.");
            ClearFields();
            LoadStudentsToGrid();
        }

        private void StudentForm_MouseEnter(object sender, EventArgs e)
        {
            studentsgridview.Cursor = Cursors.Hand;
        }

        private void StudentForm_MouseLeave(object sender, EventArgs e)
        {
            studentsgridview.Cursor = Cursors.Default;
        }

        private void studentsgridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = studentsgridview.Rows[e.RowIndex];

                selectedStudentId = Convert.ToInt32(row.Cells[0].Value ?? -1);
                textfirstname.Text = row.Cells[1].Value?.ToString() ?? "";
                textSlastname.Text = row.Cells[2].Value?.ToString() ?? "";
                comboGender.SelectedItem = System.Enum.Parse(typeof(Gender), row.Cells[3].Value?.ToString() ?? "");


                if (DateTime.TryParse(row.Cells[4].Value?.ToString(), out var dob))
                    dateTimePickerDOB.Value = dob;

                textSPhoneNo.Text = row.Cells[5].Value?.ToString() ?? "";
                textEmail.Text = row.Cells[6].Value?.ToString() ?? "";
                textSaddress.Text = row.Cells[7].Value?.ToString() ?? "";
                textGurname.Text = row.Cells[8].Value?.ToString() ?? "";
                textGurPhoNo.Text = row.Cells[9].Value?.ToString() ?? "";
                selectedUserId = Convert.ToInt32(row.Cells[10].Value ?? -1);
            }
        }
    }
}
