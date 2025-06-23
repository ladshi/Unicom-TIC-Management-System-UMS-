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
        private UserRole currentMode;
        private int selectedUserId = -1;

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
                //MessageBox.Show("First-time setup – please add the main admin.", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                LoadUsers();
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
            else if (currentMode == UserRole.MainAdmin)
            {
                labeltitle.Text = "ADMIN DETAILS";
                labelaccess.Visible = true;
                comboaccess.Visible = true;
                comboaccess.Items.Add(UserRole.MainAdmin.ToString());
                comboaccess.Items.Add(UserRole.Admin.ToString());
            }
            else if (currentMode == UserRole.Lecturer)
            {
                labeltitle.Text = "LECTURER DETAILS";
                labelaccess.Visible = true;
                comboaccess.Visible = true;
                comboaccess.Items.Add(UserRole.Lecturer.ToString());
            }
        }

        private void ClearForm()
        {
            textUsername.Clear();
            textpassword.Clear();
            textfirstname.Clear();
            textLastName.Clear();
            textContactNo.Clear();
            textEmail.Clear();
            textAddress.Clear();
            comboaccess.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Today;
        }

        private void LoadUsers()
        {
            // Remove all columns before adding new ones
            admingridview.Columns.Clear();
            admingridview.Rows.Clear();

            // Define columns
            admingridview.Columns.Add("FirstName", "First Name");
            admingridview.Columns.Add("LastName", "Last Name");
            admingridview.Columns.Add("PhoneNumber", "Phone Number");
            admingridview.Columns.Add("Email", "Email");
            admingridview.Columns.Add("Address", "Address");
            admingridview.Columns.Add("DOB", "DOB");

            // Conditionally add extra columns based on user role
            if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
            {
                admingridview.Columns.Add("AccessLevel", "Access Level");
                admingridview.Columns.Add("UserId", "User ID");
                admingridview.Columns["UserId"].Visible = false;

                var adminList = AdminController.GetAdmins();
                foreach (var admin in adminList)
                {
                    admingridview.Rows.Add(
                        admin.FirstName,
                        admin.LastName,
                        admin.PhoneNumber,
                        admin.Email,
                        admin.Address,
                        admin.DOB,
                        admin.AccessLevel,
                        admin.UserId
                    );
                }
            }
            else if (currentMode == UserRole.Staff)
            {
                admingridview.Columns.Add("UserId", "User ID");
                admingridview.Columns["UserId"].Visible = false;

                var staffList = StaffController.GetAllStaffs();
                foreach (var staff in staffList)
                {
                    admingridview.Rows.Add(
                        staff.FirstName,
                        staff.LastName,
                        staff.PhoneNumber,
                        staff.Email,
                        staff.Address,
                        staff.DOB,
                        "", // AccessLevel is empty for staff
                        staff.UserId
                    );
                }
            }
            else if (currentMode == UserRole.Lecturer)
            {
                admingridview.Columns.Add("UserId", "User ID");
                admingridview.Columns["UserId"].Visible = false;

                var lecturerList = LectureController.GetLecturers();
                foreach (var lecturer in lecturerList)
                {
                    admingridview.Rows.Add(
                        lecturer.FirstName,
                        lecturer.LastName,
                        lecturer.PhoneNumber,
                        lecturer.Email,
                        lecturer.Address,
                        lecturer.DOB,
                        "", // AccessLevel is empty for lecturer
                        lecturer.UserId
                    );
                }
            }

            // Clear selection after loading
            admingridview.ClearSelection();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text.Trim();
            string password = textpassword.Text.Trim();
            UserRole selectedRole = (UserRole)System.Enum.Parse(typeof(UserRole), comboaccess.Text);

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
                        DOB = dateTimePicker.Value.ToString("yyyy-MM-dd"),
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
                        DOB = dateTimePicker.Value.ToString("yyyy-MM-dd"),
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
                        PhoneNumber = textContactNo.Text.Trim(),
                        Email = textEmail.Text.Trim(),
                        Address = textAddress.Text.Trim(),
                        DOB = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                        UserId = userId
                    };
                    LectureService.AddLecturer(lecturer);
                }

                MessageBox.Show("User added successfully!");
                if (isFirstTime)
                {
                    this.Hide();
                    Login loginForm = new Login();
                    loginForm.Show();
                }
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Failed to create user.");
            }
            ClearForm();
            LoadUsers();
        }

        private void admingridview_SelectionChanged(object sender, EventArgs e)
        {
            if (admingridview.SelectedRows.Count > 0)
            {
                var row = admingridview.SelectedRows[0];
                textfirstname.Text = row.Cells["FirstName"].Value.ToString();
                textLastName.Text = row.Cells["LastName"].Value.ToString();
                textContactNo.Text = row.Cells["PhoneNumber"].Value.ToString();
                textEmail.Text = row.Cells["Email"].Value.ToString();
                textAddress.Text = row.Cells["Address"].Value.ToString();
                dateTimePicker.Text = row.Cells["DOB"].Value.ToString();
                //comboaccess.Text = row.Cells["AccessLevel"].Value.ToString();
                if (admingridview.Columns.Contains("AccessLevel") && comboaccess.Visible)
                {
                    comboaccess.Text = row.Cells["AccessLevel"].Value?.ToString();
                }
                selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);

                /*if (admingridview.Columns.Contains("UserId"))
                {
                    selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);
                }*/
            }
        }



        private void textUsername_TextChanged(object sender, EventArgs e) { }
        private void comboaccess_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            string username = textUsername.Text.Trim();
            string password = textpassword.Text.Trim();
            //UserRole selectedRole = (UserRole)System.Enum.Parse(typeof(UserRole), comboaccess.Text);

            UserRole selectedRole;

            // For Admin and MainAdmin, parse from comboaccess
            if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
            {
                if (string.IsNullOrWhiteSpace(comboaccess.Text))
                {
                    MessageBox.Show("Please select an Access Level.");
                    return;
                }

                selectedRole = (UserRole)System.Enum.Parse(typeof(UserRole), comboaccess.Text);
            }
            // For Staff or Lecturer, directly assign the current mode
            else
            {
                selectedRole = currentMode;
            }


            /*User user = new User
            {
                UserId = selectedUserId,
                UserName = username,
                Password = password,
                Role = selectedRole
            };
            UserService.UpdateUser(user);*/

            if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
            {
                var admin = new Admin
                {
                    FirstName = textfirstname.Text.Trim(),
                    LastName = textLastName.Text.Trim(),
                    PhoneNumber = textContactNo.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Address = textAddress.Text.Trim(),
                    DOB = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    AccessLevel = comboaccess.Text,
                    UserId = selectedUserId
                };
                AdminController.UpdateAdmin(admin);
            }
            else if (currentMode == UserRole.Staff)
            {
                MessageBox.Show("Entering Staff update block");

                var staff = new Staff
                {
                    FirstName = textfirstname.Text.Trim(),
                    LastName = textLastName.Text.Trim(),
                    PhoneNumber = textContactNo.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Address = textAddress.Text.Trim(),
                    DOB = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    UserId = selectedUserId
                };
                StaffController.UpdateStaff(staff);
                MessageBox.Show("ok");
            }
            else if (currentMode == UserRole.Lecturer)
            {
                var lec = new Lecturer
                {
                    FirstName = textfirstname.Text.Trim(),
                    LastName = textLastName.Text.Trim(),
                    PhoneNumber = textContactNo.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Address = textAddress.Text.Trim(),
                    DOB = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    UserId = selectedUserId
                };
                LectureController.UpdateLecturer(lec);
            }

            MessageBox.Show("Updated Successfully!");
            ClearForm();
            LoadUsers();
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            /*if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
                    AdminController.DeleteAdmin(selectedUserId);
                else if (currentMode == UserRole.Staff)
                    StaffController.DeleteStaff(selectedUserId);
                else if (currentMode == UserRole.Lecturer)
                    LectureController.DeleteLecturer(selectedUserId);

                UserService.DeleteUser(selectedUserId);

                MessageBox.Show("Deleted Successfully!");
                ClearForm();
                LoadUsers();
            }*/
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
                {
                    AdminController.DeleteAdmin(selectedUserId);
                }
                else if (currentMode == UserRole.Staff)
                {
                    StaffController.DeleteStaff(selectedUserId);
                }
                else if (currentMode == UserRole.Lecturer)
                {
                    LectureController.DeleteLecturer(selectedUserId);
                }

                UserService.DeleteUser(selectedUserId);

                MessageBox.Show("Deleted Successfully!");
                ClearForm();
                LoadUsers();
            }
        }


        private void buttonsearch_Click(object sender, EventArgs e)
        {
            string keyword = combosearch.Text.Trim();
            var results = AdminController.SearchAdmins(keyword);
            admingridview.Rows.Clear();

            foreach (var admin in results)
            {
                admingridview.Rows.Add(
                    admin.FirstName,
                    admin.LastName,
                    admin.PhoneNumber,
                    admin.Email,
                    admin.Address,
                    admin.DOB,
                    admin.AccessLevel,
                    admin.UserId
                );
            }
        }

        private void admingridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = admingridview.Rows[e.RowIndex];

                textfirstname.Text = row.Cells["FirstName"].Value.ToString();
                textLastName.Text = row.Cells["LastName"].Value.ToString();
                textContactNo.Text = row.Cells["PhoneNumber"].Value.ToString();
                textEmail.Text = row.Cells["Email"].Value.ToString();
                textAddress.Text = row.Cells["Address"].Value.ToString();
                dateTimePicker.Text = row.Cells["DOB"].Value.ToString();

                // Use AccessLevel only if visible
                /*if (comboaccess.Visible)
                {
                    comboaccess.Text = row.Cells["AccessLevel"].Value.ToString();
                }

                selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);
                */

                if (admingridview.Columns.Contains("AccessLevel") && row.Cells["AccessLevel"].Value != null)
                {
                    comboaccess.Text = row.Cells["AccessLevel"].Value.ToString();
                }
                else
                {
                    comboaccess.Text = "";
                }

            }
        }

        private void admingridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = admingridview.Rows[e.RowIndex];

                textfirstname.Text = row.Cells["FirstName"].Value.ToString();
                textLastName.Text = row.Cells["LastName"].Value.ToString();
                textContactNo.Text = row.Cells["PhoneNumber"].Value.ToString();
                textEmail.Text = row.Cells["Email"].Value.ToString();
                textAddress.Text = row.Cells["Address"].Value.ToString();
                dateTimePicker.Text = row.Cells["DOB"].Value.ToString();

                // Use AccessLevel only if visible
                if (admingridview.Columns.Contains("AccessLevel") && row.Cells["AccessLevel"].Value != null)
                {
                    comboaccess.Text = row.Cells["AccessLevel"].Value.ToString();
                }
                else
                {
                    comboaccess.Text = "";
                }

                // Attempt to parse the UserId and handle invalid values
                string userIdValue = row.Cells["UserId"].Value?.ToString();

                if (!string.IsNullOrEmpty(userIdValue) && int.TryParse(userIdValue, out int userId))
                {
                    selectedUserId = userId;
                }
                else
                {
                    selectedUserId = -1;  // If UserId is invalid or empty, set it to -1 (or another default value)
                }

                // Optional: You can log or display the UserId to verify
                Console.WriteLine("Selected UserId: " + selectedUserId);
            }
        }

    }


    /*private void buttonUpdate_Click(object sender, EventArgs e)
    {
        string username = textUsername.Text.Trim();
        string password = textpassword.Text.Trim();
        string firstName = textfirstname.Text.Trim();
        string lastName = textLastName.Text.Trim();
        string contactNo = textContactNo.Text.Trim();
        string email = textEmail.Text.Trim();
        string address = textAddress.Text.Trim();
        string dob = dateTimePicker.Value.ToString("yyyy-MM-dd"),

        //  Updating  user in Users table
        User user = new User
        {
            UserName = username,
            Password = password,
            Role = currentMode

        };

        UserService.UpdateUser(user);

        if (currentMode == UserRole.Admin)
        {
            string accessLevel = comboaccess.Text;

            Admin admin = new Admin
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = contactNo,
                Email = email,
                Address = address,
                DOB = dob,
                AccessLevel = accessLevel
            };

            AdminService.UpdateAdmin(admin);
        }

        else if (currentMode == UserRole.Staff)
        {
            Staff staff = new Staff
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = contactNo,
                Email = email,
                Address = address,
                DOB = dob
            };

            StaffService.UpdateStaff(staff);
        }
        else if (currentMode == UserRole.Lecturer)
        {
            Lecturer lecturer = new Lecturer
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = contactNo,
                Email = email,
                Address = address,
                DOB = dob
            };

            LecturerService.UpdateLecturer(lecturer);
        }
        ClearForm();
        LoadAdmins();

    }*/

}

