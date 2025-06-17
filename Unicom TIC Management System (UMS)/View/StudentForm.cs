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
        public partial class StudentForm : Form
        {
            private StudentController studentController = new StudentController();

            public StudentForm()
            {
                InitializeComponent();
                txtDOB.ReadOnly = true;
                dateTimePickerDOB.ValueChanged += dateTimePickerDOB_ValueChanged;
                LoadStudentData();
            }

            private void dateTimePickerDOB_ValueChanged(object sender, EventArgs e)
            {
                txtDOB.Text = dateTimePickerDOB.Value.ToString("yyyy-MM-dd");
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                // Build objects from form data
                var student = new Student
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DOB = txtDOB.Text,
                    Gender = cmbGender.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Address = txtAddress.Text,
                    Course = cmbCourse.Text,
                    Email = txtEmail.Text
                };

                var guardian = new Guardian
                {
                    Name = txtGuardianName.Text,
                    ContactNo = txtGuardianContactNo.Text
                };

                var user = new User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };

                // Add to database
                bool success = studentController.AddStudent(student, guardian, user);

                if (success)
                {
                    MessageBox.Show("Student added successfully!");
                    LoadStudentData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Error occurred while adding student.");
                }
            }

            private void LoadStudentData()
            {
                var students = studentController.GetAllStudents();
                dgvStudents.Rows.Clear();

                foreach (var student in students)
                {
                    dgvStudents.Rows.Add(
                        student.FirstName,
                        student.LastName,
                        student.DOB,
                        student.Gender,
                        student.PhoneNumber,
                        student.Address,
                        student.Course,
                        student.Email,
                        student.Guardian?.Name,
                        student.Guardian?.ContactNo
                    );
                }
            }

            private void ClearForm()
            {
                txtFirstName.Clear();
                txtLastName.Clear();
                txtDOB.Clear();
                txtPhoneNumber.Clear();
                txtAddress.Clear();
                cmbGender.SelectedIndex = -1;
                cmbCourse.SelectedIndex = -1;
                txtUsername.Clear();
                txtPassword.Clear();
                txtEmail.Clear();
                txtGuardianName.Clear();
                txtGuardianContactNo.Clear();
            }
        }

        private void LoadStudentsToGrid()
        {
            var students = studentController.GetAllStudents(); // Controller call

            dataGridView1.Rows.Clear();
            foreach (var student in students)
            {
                dataGridView1.Rows.Add(
                    student.FirstName,
                    student.LastName,
                    student.DOB,
                    student.Gender,
                    student.PhoneNumber,
                    student.Address,
                    student.Course,
                    student.Email,
                    student.Guardian?.Name,
                    student.Guardian?.ContactNo
                );
            }
        }

    }
}
