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
            else if (currentMode == UserRole.Admin)
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
                comboaccess.Visible =  true;
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
            admingridview.Rows.Clear();

            // Add columns only once
            if (admingridview.Columns.Count == 0)
            {
                admingridview.Columns.Add("FirstName", "First Name");
                admingridview.Columns.Add("LastName", "Last Name");
                admingridview.Columns.Add("PhoneNumber", "Phone Number");
                admingridview.Columns.Add("Email", "Email");
                admingridview.Columns.Add("Address", "Address");
                admingridview.Columns.Add("DOB", "DOB");
                admingridview.Columns.Add("AccessLevel", "Access Level"); // can be hidden for Staff/Lecturer
                admingridview.Columns.Add("UserId", "User ID");
                admingridview.Columns["UserId"].Visible = false;
            }

            if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
            {
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
                        "", // AccessLevel empty for staff
                        staff.UserId
                    );
                }
            }
            else if (currentMode == UserRole.Lecturer)
            {
                var lecturerList = LectureController.GetLecturers();
                foreach (var lec in lecturerList)
                {
                    admingridview.Rows.Add(
                        lec.FirstName,
                        lec.LastName,
                        lec.PhoneNumber,
                        lec.Email,
                        lec.Address,
                        lec.DOB,
                        "", // AccessLevel empty for lecturer
                        lec.UserId
                    );
                }
            }

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
                comboaccess.Text = row.Cells["AccessLevel"].Value.ToString();
                selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);
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
            UserRole selectedRole = (UserRole)System.Enum.Parse(typeof(UserRole), comboaccess.Text);

            // 1️⃣ UPDATE USERS table
            User user = new User
            {
                UserId = selectedUserId,
                UserName = username,
                Password = password,
                Role = selectedRole
            };
            UserService.UpdateUser(user);

            // 2️⃣ UPDATE Role-specific table
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
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // 1️⃣ Delete from role-specific table
                if (currentMode == UserRole.Admin || currentMode == UserRole.MainAdmin)
                    AdminController.DeleteAdmin(selectedUserId);
                else if (currentMode == UserRole.Staff)
                    StaffController.DeleteStaff(selectedUserId);
                else if (currentMode == UserRole.Lecturer)
                    LectureController.DeleteLecturer(selectedUserId);

                // 2️⃣ Delete from USERS table
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

