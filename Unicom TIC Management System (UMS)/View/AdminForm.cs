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

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class AdminForm : Form
    {
        private bool isFirstTime;
        private UserRole currentMode; // Admin or Staff

        public AdminForm(bool firstTime = false, UserRole mode = UserRole.Admin)
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
                textsearch.Visible = false;
                admingridview.Visible = false;

                comboaccess.Items.Clear();
                comboaccess.Items.Add("Main Admin");
                comboaccess.Items.Add("Admin");
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
                labelaccess.Visible = false;
                comboaccess.Visible = false;
            }
            else if (currentMode == UserRole.Admin)
            {
                labeltitle.Text = "ADMIN DETAILS";
                labelaccess.Visible = true;
                comboaccess.Visible = true;
            }
        }

        private void LoadAdmins()
        {
            // Load admin list into grid here when not first-time
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            string usernameInput = textUsername.Text.Trim();

            if (UserService.IsUsernameExists(usernameInput))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            var user = new User
            {
                UserName = usernameInput,
                Password = textpassword.Text.Trim(),
                Role = currentMode
            };

            int userId = UserController.AddUser(user);

            if (userId > 0)
            {
                if (currentMode == UserRole.Admin)
                {
                    var admin = new Admin
                    {
                        FirstName = textfirstname.Text.Trim(),
                        LastName = textLastName.Text.Trim(),
                        PhoneNumber = textContactNo.Text.Trim(),
                        Email = textEmail.Text.Trim(),
                        Address = textAddress.Text.Trim(),
                        AccessLevel = comboaccess.Text,
                        UserId = userId
                    };

                    AdminController adminController = new AdminController();
                    if (adminController.AddAdmin(admin))
                    {
                        MessageBox.Show("Admin added successfully.");
                        this.Hide();
                        new Login().ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Admin creation failed.");
                    }
                }
                else if (currentMode == UserRole.Staff)
                {
                    var staff = new Staff
                    {
                        FirstName = textfirstname.Text.Trim(),
                        LastName = textLastName.Text.Trim(),
                        PhoneNumber = textContactNo.Text.Trim(),
                        Email = textEmail.Text.Trim(),
                        Address = textAddress.Text.Trim(),
                        DOB = dateTimePicker.Value,
                        UserId = userId
                    };

                    StaffController staffController = new StaffController();
                    if (staffController.AddStaff(staff))
                    {
                        MessageBox.Show("Staff added successfully.");
                        this.Hide();
                        new Login().ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Staff creation failed.");
                    }
                }
            }
            else
            {
                MessageBox.Show("User creation failed.");
            }
        }

        private void textUsername_TextChanged(object sender, EventArgs e) { }
        private void comboaccess_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
