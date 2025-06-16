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
        public CourseSubjectForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadSubjects();
            LoadCourseSubjectMapping();
        }

        // === COURSE ===
        private void courseAddButton_Click(object sender, EventArgs e)
        {
            string courseName = courseNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter a course name.");
                return;
            }

            var ccourse = new Course { Name = courseName };
            CourseController.AddCourse(ccourse);

            MessageBox.Show("Course added successfully!");
            courseNameTextBox.Clear();
            LoadCourses();
            LoadCourseSubjectMapping();
        }

        private void courseUpdateButton_Click(object sender, EventArgs e)
        {
            if (courseDataGridView.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(courseDataGridView.SelectedRows[0].Cells["Id"].Value);
            string name = courseNameTextBox.Text.Trim();

            CourseController.UpdateCourse(new Course { Id = id, Name = name });

            MessageBox.Show("Course updated!");
            LoadCourses();
            LoadCourseSubjectMapping();
        }

        private void courseDeleteButton_Click(object sender, EventArgs e)
        {
            if (courseDataGridView.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(courseDataGridView.SelectedRows[0].Cells["Id"].Value);
            CourseController.DeleteCourse(id);

            MessageBox.Show("Course deleted!");
            LoadCourses();
            LoadCourseSubjectMapping();
        }

        private void LoadCourses()
        {
            var courses = CourseController.GetAllCourses();
            courseDataGridView.DataSource = courses;
            courseSEARCH.DataSource = courses;
            courseSEARCH.DisplayMember = "Name";
            courseSEARCH.ValueMember = "Id";
        }

        private void courseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (courseDataGridView.SelectedRows.Count > 0)
            {
                courseNameTextBox.Text = courseDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
            }
        }

        // === SUBJECT ===
        private void subjectAddButton_Click(object sender, EventArgs e)
        {
            if (courseSEARCH.SelectedItem == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }

            string subjectName = subjectNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show("Enter subject name.");
                return;
            }

            int courseId = (int)courseSEARCH.SelectedValue;

            var subject = new Subject
            {
                Name = subjectName,
                Id = courseId
            };

            SubjectController.AddSubject(subject);
            MessageBox.Show("Subject added!");

            subjectNameTextBox.Clear();
            LoadSubjects();
            LoadCourseSubjectMapping();
        }

        private void subjectUpdateButton_Click(object sender, EventArgs e)
        {
            if (subjectDataGridView.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(subjectDataGridView.SelectedRows[0].Cells["Id"].Value);
            string name = subjectNameTextBox.Text.Trim();
            int courseId = (int)courseSEARCH.SelectedValue;

            SubjectController.UpdateSubject(new Subject { Id = id, Name = name, CourseId = courseId });

            MessageBox.Show("Subject updated!");
            LoadSubjects();
            LoadCourseSubjectMapping();
        }

        private void subjectDeleteButton_Click(object sender, EventArgs e)
        {
            if (subjectDataGridView.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(subjectDataGridView.SelectedRows[0].Cells["Id"].Value);
            SubjectController.DeleteSubject(id);

            MessageBox.Show("Subject deleted!");
            LoadSubjects();
            LoadCourseSubjectMapping();
        }

        private void LoadSubjects()
        {
            var subjects = SubjectController.GetAllSubjects();
            subjectDataGridView.DataSource = subjects;
        }

        private void subjectDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (subjectDataGridView.SelectedRows.Count > 0)
            {
                subjectNameTextBox.Text = subjectDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();

                int courseId = Convert.ToInt32(subjectDataGridView.SelectedRows[0].Cells["CourseId"].Value);
                courseSEARCH.SelectedValue = courseId;
            }
        }

        // === COMBINED VIEW ===
        private void LoadCourseSubjectMapping()
        {
            var list = SubjectController.GetCourseSubjectView(); // Should return List<CourseSubjectViewModel>
            courseSubjectDataGridView.DataSource = list;
        }

        private void CourseSubjectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
