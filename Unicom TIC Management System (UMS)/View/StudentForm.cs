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
        public StudentForm()
        {
            InitializeComponent();
        }

        private void ButtonADD_Click(object sender, EventArgs e)
        {
            /*Student student = new Student
            {
                FirstName = textfirstname.Text.Trim(),
                LastName = textSlastname.Text.Trim(),
                DOB = dobPicker.Value.ToString("yyyy-MM-dd"),
                Gender = (Gender)comboGender.SelectedIndex,
                Email = textEmail.Text.Trim(),
                PhoneNumber = textPhoneNumber.Text.Trim(),
                Address = textAddress.Text.Trim(),
                EnrollmentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                CourseId = (int)comboCourse.SelectedValue
            };

            User user = new User
            {
                UserName = textUsername.Text.Trim(),
                Password = textPassword.Text.Trim(),
                Role = UserRole.Student
            };

            StudentController controller = new StudentController();
            bool isSuccess = controller.AddStudent(student, user);

            if (isSuccess)
                MessageBox.Show("Student added successfully!");
            else
                MessageBox.Show("Failed to add student.");*/
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
