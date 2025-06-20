using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unicom_TIC_Management_System__UMS_.Controllers;
using Unicom_TIC_Management_System__UMS_.Models;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class CourseSubjectForm : Form
    {
        private int selectedCourseId = -1; // -1 means no selection yet
        private int selectedSubjectId = -1; // -1 means no selection yet

        public CourseSubjectForm()
        {
            InitializeComponent();

            try
            {
                LoadCourses();    // optional
                LoadSubjects();   // optional
                LoadCourseCombo();
                LoadSubjectCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCourseCombo()
        {
            Coursenamecombo.Items.Clear();
            List<Course> courseList = CourseController.GetAllCourses();

            foreach (var course in courseList)
            {
                Coursenamecombo.Items.Add(course.Name);
            }

            Coursenamecombo.SelectedIndex = -1; // No selection by default
        }

        private void LoadSubjectCombo()
        {
            Subjectnamecombo.Items.Clear();
            var subjects = SubjectController.GetAllSubjects();
            foreach (var subject in subjects)
            {
                Subjectnamecombo.Items.Add(subject.Name);
            }
            Subjectnamecombo.SelectedIndex = -1;
        }

        private void LoadCourses()
        {
           
            var courses = CourseController.GetAllCourses();
            Coursenamecombo.DataSource = courses;
            courseDataGridView.DataSource = courses;

            courseDataGridView.Rows.Clear();

            List<Course> courseList = CourseController.GetAllCourses();

            foreach (var course in courseList)
            {
                courseDataGridView.Rows.Add(course.Id, course.Name);
            }

            // For ComboBox search
            courseSEARCH.DataSource = courseList;
            courseSEARCH.DisplayMember = "Name";
            courseSEARCH.ValueMember = "Id";
        }

        private void LoadSubjects()
        {
            var subjects = SubjectController.GetAllSubjects();
            subjectDataGridView.DataSource = subjects;
        }

        private void courseAddButton_Click(object sender, EventArgs e)
        {
            Course course = new Course
            {
                Name = courseNameTextBox.Text.Trim()
            };
            CourseController.AddCourse(course);
            courseNameTextBox.Clear();
            LoadCourses();
        }

        private void courseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1️⃣ Get selected row
                DataGridViewRow row = courseDataGridView.Rows[e.RowIndex];

                // 2️⃣ Read values
                selectedCourseId = Convert.ToInt32(row.Cells[0].Value); // Id column
                string courseName = row.Cells[1].Value.ToString();      // Name column

                // 3️⃣ Display in textbox
                courseNameTextBox.Text = courseName;
            }
        }

        private void courseUpdatebutton_Click(object sender, EventArgs e)
        {
            // 1️⃣ Ensure a course is selected
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            // 2️⃣ Validate textbox input
            string updatedName = courseNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(updatedName))
            {
                MessageBox.Show("Course name cannot be empty.");
                return;
            }

            // 3️⃣ Create course object with updated data
            Course updatedCourse = new Course();
            updatedCourse.Id = selectedCourseId;  // already stored during row click
            updatedCourse.Name = updatedName;

            // 4️⃣ Send to Controller
            CourseController.UpdateCourse(updatedCourse);

            // 5️⃣ Refresh grid and reset form
            LoadCourses();
            courseNameTextBox.Clear();
            selectedCourseId = -1;

            MessageBox.Show("Course updated successfully!");
        }

        private void courseDeleteButton_Click(object sender, EventArgs e)
        {
            // 1️⃣ Ensure a course is selected
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            // 2️⃣ Ask user confirmation
            var confirm = MessageBox.Show("Are you sure you want to delete this course?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);
            if (confirm == DialogResult.No)
                return;

            // 3️⃣ Send to controller
            CourseController.DeleteCourse(selectedCourseId);

            // 4️⃣ Refresh grid and clear form
            LoadCourses();
            courseNameTextBox.Clear();
            selectedCourseId = -1;

            MessageBox.Show("Course deleted successfully.");
        }

        private void Subjectaddbtn_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject
            {
                Name = subjectNameTextBox.Text.Trim()
            };
            SubjectController.AddSubject(subject);
            subjectNameTextBox.Clear();
            LoadSubjects();
        }

        private void subjectUpdateButton_Click(object sender, EventArgs e)
        {
            // 1️⃣ Ensure a course is selected
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            // 2️⃣ Validate textbox input
            string updatedName = subjectNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(updatedName))
            {
                MessageBox.Show("Subject name cannot be empty.");
                return;
            }

            // 3️⃣ Create course object with updated data
            Subject updatedSubject = new Subject();
            updatedSubject.Id = selectedCourseId;  // already stored during row click
            updatedSubject.Name = updatedName;

            // 4️⃣ Send to Controller
            SubjectController.UpdateSubject(updatedSubject);

            // 5️⃣ Refresh grid and reset form
            LoadSubjects();
            subjectNameTextBox.Clear();
            selectedSubjectId = -1;

            MessageBox.Show("Course updated successfully!");
        }

        private void subjectDeleteButton_Click(object sender, EventArgs e)
        {
            // 1️⃣ Ensure a course is selected
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a select to delete.");
                return;
            }

            // 2️⃣ Ask user confirmation
            var confirm = MessageBox.Show("Are you sure you want to delete this subject?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);
            if (confirm == DialogResult.No)
                return;

            // 3️⃣ Send to controller
            SubjectController.DeleteSubject(selectedSubjectId);

            // 4️⃣ Refresh grid and clear form
            LoadSubjects();
            subjectNameTextBox.Clear();
            selectedSubjectId = -1;

            MessageBox.Show("Subject deleted successfully.");
        }

        private void subjectDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1️⃣ Get selected row
                DataGridViewRow row = subjectDataGridView.Rows[e.RowIndex];

                // 2️⃣ Read values
                selectedSubjectId = Convert.ToInt32(row.Cells[0].Value); // Id column
                string subjectName = row.Cells[1].Value.ToString();      // Name column

                // 3️⃣ Display in textbox
                subjectNameTextBox.Text = subjectName;
            }
        }

        private void combosubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coursesearchbutton_Click(object sender, EventArgs e)
        {
            if (Coursenamecombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course to search.");
                return;
            }

            string selectedCourse = Coursenamecombo.SelectedItem.ToString();

            // 1️⃣ Search using controller
            Course course = CourseController.GetCourseByName(selectedCourse);

            // 2️⃣ Clear grid first
            courseDataGridView.Rows.Clear();

            if (course != null)
            {
                courseDataGridView.Rows.Add(course.Id, course.Name);
            }
            else
            {
                MessageBox.Show("No course found.");
            }
        }

        private void Subjectsearchbutton_Click(object sender, EventArgs e)
        {
            if (Subjectnamecombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a subject to search.");
                return;
            }

            string selectedSubject = Subjectnamecombo.SelectedItem.ToString();

            // Search manually since GetSubjectByName does not exist
            var subjects = SubjectController.GetAllSubjects();
            var subject = subjects.FirstOrDefault(s => s.Name == selectedSubject);

            subjectDataGridView.Rows.Clear();

            if (subject != null)
            {
                subjectDataGridView.Rows.Add(subject.Id, subject.Name);
            }
            else
            {
                MessageBox.Show("No subject found.");
            }
        }

        private void Subjectnamecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
