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
using Unicom_TIC_Management_System__UMS_.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class AdminForm : Form
    {
        private bool isFirstTime;
        private UserRole currentMode; // Admin or Staff

        public AdminForm(bool firstTime = false, UserRole mode = UserRole.MainAdmin)
        {
            InitializeComponent();
            isFirstTime = firstTime;
            currentMode = mode;
            ApplyModeSettings();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                MessageBox.Show("First-time setup – please add the main admin.", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);

                buttonAdd.Visible = true;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
                buttonsearch.Visible = false;
                combosearch.Visible = false;
                admingridview.Visible = false;

                comboaccess.Items.Clear();
                //comboaccess.Items.Add("Main Admin");//hard coding method 
                //comboaccess.Items.Add("Admin");
                comboaccess.Items.Add(UserRole.MainAdmin.ToString());
                comboaccess.Items.Add(UserRole.Admin.ToString());
            }
            else
            {
                LoadAdmins();
            }
        }

        private void ApplyModeSettings()
        {
            if (currentMode == UserRole.Staff)
            {
                labeltitle.Text = "STAFF DETAILS";
                labelaccess.Visible = true;
                comboaccess.Visible = true;
                comboaccess.Items.Add(UserRole.Staff.ToString());
            }
            else if (currentMode == UserRole.Admin)
            {
                labeltitle.Text = "ADMIN DETAILS";
                labelaccess.Visible = true;
                comboaccess.Visible = true;  
            }
            else if (currentMode == UserRole.Lecturer)
            {
                labeltitle.Text = "LECTURER DETAILS";
                labelaccess.Visible = true;
                comboaccess.Visible =   true;
                comboaccess.Items.Add(UserRole.Lecturer.ToString());
            }
        }

        private void LoadAdmins()
        {
            // Load admin list into grid here when not first-time
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text.Trim();
            string password = textpassword.Text.Trim();
            UserRole selectedRole = (UserRole)Enum.Parse(typeof(UserRole), comboaccess.SelectedItem.ToString());

            if (UserService.IsUsernameExists(username))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            int userId = UserService.AddUser(new User
            {
                UserName = username,
                Password = password,
                Role = selectedRole
            });

            if (userId > 0)
            {
                if (selectedRole == UserRole.Admin || selectedRole == UserRole.MainAdmin)
                {
                    var admin = new Admin
                    {
                        FirstName = textfirstname.Text.Trim(),
                        LastName = textLastName.Text.Trim(),
                        PhoneNumber = textContactNo.Text.Trim(),
                        Email = textEmail.Text.Trim(),
                        Address = textAddress.Text.Trim(),
                        DOB = dateTimePicker.Text.Trim(),
                        AccessLevel = comboaccess.Text,
                        UserId = userId
                    };
                    AdminService.AddAdmin(admin);
                }
                else if (selectedRole == UserRole.Staff)
                {
                    var staff = new Staff
                    {
                        FirstName = textfirstname.Text.Trim(),
                        LastName = textLastName.Text.Trim(),
                        PhoneNumber = textContactNo.Text.Trim(),
                        Email = textEmail.Text.Trim(),
                        Address = textAddress.Text.Trim(),
                        DOB = dateTimePicker.Text.Trim(),
                        UserId = userId
                    };
                    StaffService.AddStaff(staff);
                }
                else if (selectedRole == UserRole.Lecturer)
                {
                    var lecturer = new Lecturer
                    {
                        FirstName = textfirstname.Text.Trim(),
                        LastName = textLastName.Text.Trim(),
                        ContactNo = textContactNo.Text.Trim(),
                        Email = textEmail.Text.Trim(),
                        Address = textAddress.Text.Trim(),
                        DOB = dateTimePicker.Text.Trim(),
                        UserId = userId
                    };
                    LecturerService.AddLecturer(lecturer);
                }

                MessageBox.Show("User added successfully!");
                LoadAdmins();
            }
            else
            {
                MessageBox.Show("Failed to create user.");
            }
        }


        private void textUsername_TextChanged(object sender, EventArgs e) { }
        private void comboaccess_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textsearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
