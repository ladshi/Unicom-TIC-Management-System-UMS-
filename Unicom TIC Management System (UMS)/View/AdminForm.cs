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
using Unicom_TIC_Management_System__UMS_.Models;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        /*public AdminForm(bool firstTime = false)
        {
            InitializeComponent();
            isFirstTime = firstTime;
        }*/

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (UserController.IsUserTableEmpty())
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
                LoadAdmins(); // normal case
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                Name = username,
                Password = password, // 🔐 hash later
                Role = role
            };

            int userId = UserController.AddUser(user);

            if (userId > 0)
            {
                var admin = new Admin
                {
                    FirstName = textfirstname.Text.Trim(),
                    LastName = textLastName.Text.Trim(),
                    ContactNo = textContactNo.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Address = textAddress.Text.Trim(),
                    UserId = userId
                };

                if (AdminController.AddAdmin(admin))
                {
                    MessageBox.Show("Main admin added successfully.");
                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Admin profile creation failed.");
                }
            }
            else
            {
                MessageBox.Show("User creation failed.");
            }
        }

    }
}
}
