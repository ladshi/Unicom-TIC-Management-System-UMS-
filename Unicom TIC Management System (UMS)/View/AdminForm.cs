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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class AdminForm : Form
    {
        private bool isFirstTime;

        public AdminForm(bool firstTime = false)
        {
            InitializeComponent();
            isFirstTime = firstTime;
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
                LoadAdmins(); // Load gridview and form normally
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text.Trim();
            string password = textpassword.Text.Trim();
            string role = comboaccess.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Username, Password and Access Level are required.");
                return;
            }

            var user = new User
            {
                UserName = username,
                Password = password,
                Role = System.Enum.TryParse(role, out UserRole parsedRole) ? parsedRole : UserRole.Admin
            };

            int userId = UserController.AddUser(user);

            if (userId > 0)
            {
                var admin = new Admin
                {
                    FirstName = textfirstname.Text.Trim(),
                    LastName = textLastName.Text.Trim(),
                    PhoneNumber = textContactNo.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Address = textAddress.Text.Trim(),
                    UserId = userId
                };

                AdminController adminController = new AdminController();
                adminController.AddAdmin(admin);

                MessageBox.Show("Main admin added successfully.");

                // Go to login
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("User creation failed.");
            }
        }

        // Example placeholder
        private void LoadAdmins()
        {
            // Load admin list into grid here when not first-time
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            var user = new User
            {
                UserName = textUsername.Text.Trim(),
                Password = textpassword.Text.Trim(),
                Role = System.Enum.TryParse("Admin", out UserRole parsedRole) ? parsedRole : UserRole.Admin
            };

            int userId = UserController.AddUser(user);  // static call

            if (userId > 0)
            {
                var admin = new Admin
                {
                    FirstName = textfirstname.Text.Trim(),
                    LastName = textLastName.Text.Trim(),
                    PhoneNumber = textContactNo.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Address = textAddress.Text.Trim(),
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
            else
            {
                MessageBox.Show("User creation failed.");
            }
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
