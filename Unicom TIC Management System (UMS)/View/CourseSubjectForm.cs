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
        private int selectedCourseId = -1;
        private int selectedSubjectId = -1;
        private List<Course> courseList = new List<Course>();
        private List<Subject> subjectList = new List<Subject>();

        public CourseSubjectForm()
        {
            InitializeComponent();

            try
            {
                LoadCourses();
                LoadSubjects();
                LoadCourseCombo();
                LoadSubjectCombo();
                LoadCourseSubjectView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCourseSubjectView()
        {
            var list = SubjectController.GetCourseSubjectView();

            courseSubjectDataGridView.Columns.Clear();
            courseSubjectDataGridView.Columns.Add("SubjectId", "Subject ID");
            courseSubjectDataGridView.Columns.Add("SubjectName", "Subject Name");
            courseSubjectDataGridView.Columns.Add("CourseName", "Course Name");
            courseSubjectDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            courseSubjectDataGridView.Rows.Clear();
            foreach (var item in list)
            {
                courseSubjectDataGridView.Rows.Add(item.SubjectId, item.SubjectName, item.CourseName);
            }
        }

        private void LoadCourseCombo()
        {
            Coursenamecombo.Items.Clear();
            courseList = CourseController.GetAllCourses();

            //foreach (var course in courseList)
            //{
             //   Coursenamecombo.Items.Add(courseList);
            //}
            Coursenamecombo.Items.Add(courseList);
            Coursenamecombo.SelectedIndex = -1;
        }

        private void LoadSubjectCombo()
        {
            Subjectnamecombo.Items.Clear();
            subjectList = SubjectController.GetAllSubjects();
            foreach (var subject in subjectList)
            {
                Subjectnamecombo.Items.Add(subject.SubjectName);
            }
            Subjectnamecombo.SelectedIndex = -1;
        }

        private void LoadCourses()
        {
            courseDataGridView.Columns.Clear();
            courseDataGridView.Columns.Add("CourseId", "Course ID");
            courseDataGridView.Columns.Add("CourseName", "Course Name");
            courseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            courseDataGridView.Rows.Clear();
            courseList = CourseController.GetAllCourses();
            foreach (var course in courseList)
            {
                courseDataGridView.Rows.Add(course.Id, course.CourseName);
            }

            courseSEARCH.DataSource = courseList;
            courseSEARCH.DisplayMember = "Name";
            courseSEARCH.ValueMember = "Id";

            selectedCourseId = -1;
        }

        private void LoadSubjects()
        {
            subjectDataGridView.Columns.Clear();
            subjectDataGridView.Columns.Add("SubjectId", "Subject ID");
            subjectDataGridView.Columns.Add("SubjectName", "Subject Name");
            subjectDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            subjectList = SubjectController.GetAllSubjects();
            subjectDataGridView.Rows.Clear();
            foreach (var subject in subjectList)
            {
                subjectDataGridView.Rows.Add(subject.Id, subject.SubjectName);
            }

            Subjectnamecombo.DataSource = subjectList;
            Subjectnamecombo.DisplayMember = "Name";
            Subjectnamecombo.ValueMember = "Id";

            selectedSubjectId = -1;
        }

        private void courseAddButton_Click(object sender, EventArgs e)
        {
            Course course = new Course 
            { 
                CourseName = courseNameTextBox.Text.Trim() 
            };
            CourseController.AddCourse(course);
            courseNameTextBox.Clear();
            LoadCourses();
        }

        private void courseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = courseDataGridView.Rows[e.RowIndex];
                selectedCourseId = Convert.ToInt32(row.Cells[0].Value);
                courseNameTextBox.Text = row.Cells[1].Value.ToString();
            }
        }

        private void courseUpdatebutton_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1 || string.IsNullOrEmpty(courseNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Select a course and enter new name.");
                return;
            }

            Course updatedCourse = new Course
            {
                Id = selectedCourseId,
                CourseName = courseNameTextBox.Text.Trim()
            };
            CourseController.UpdateCourse(updatedCourse);
            LoadCourses();
            courseNameTextBox.Clear();
            selectedCourseId = -1;
            MessageBox.Show("Course updated.");
        }

        private void courseDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1) return;
            if (MessageBox.Show("Delete course?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CourseController.DeleteCourse(selectedCourseId);
                LoadCourses();
                selectedCourseId = -1;
                courseNameTextBox.Clear();
            }
        }

        private void Subjectaddbtn_Click(object sender, EventArgs e)
        {
            if (Coursenamecombo.SelectedIndex == -1)
            {
                MessageBox.Show("Select a course before adding subject.");
                return;
            }

            Subject subject = new Subject
            {
                SubjectName = subjectNameTextBox.Text.Trim(),
                CourseId = CourseController.GetCourseByName(Coursenamecombo.SelectedItem.ToString()).Id
            };

            SubjectController.AddSubject(subject);
            subjectNameTextBox.Clear();
            LoadSubjects();
            LoadCourseSubjectView();
        }

        private void subjectUpdateButton_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1 || string.IsNullOrEmpty(subjectNameTextBox.Text.Trim())) return;

            Subject updatedSubject = new Subject
            {
                Id = selectedSubjectId,
                SubjectName = subjectNameTextBox.Text.Trim(),
                CourseId = SubjectController.GetAllSubjects()
                    .FirstOrDefault(x => x.Id == selectedSubjectId)?.CourseId ?? 0
            };

            SubjectController.UpdateSubject(updatedSubject);
            LoadSubjects();
            LoadCourseSubjectView();
            selectedSubjectId = -1;
            subjectNameTextBox.Clear();
        }

        private void subjectDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1) return;
            if (MessageBox.Show("Delete subject?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SubjectController.DeleteSubject(selectedSubjectId);
                LoadSubjects();
                LoadCourseSubjectView();
                selectedSubjectId = -1;
                subjectNameTextBox.Clear();
            }
        }

        private void subjectDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = subjectDataGridView.Rows[e.RowIndex];
                selectedSubjectId = Convert.ToInt32(row.Cells[0].Value);
                subjectNameTextBox.Text = row.Cells[1].Value.ToString();
            }
        }

        private void coursesearchbutton_Click(object sender, EventArgs e)
        {
            if (Coursenamecombo.SelectedIndex == -1) return;
            string selectedCourse = Coursenamecombo.SelectedItem.ToString();
            Course course = CourseController.GetCourseByName(selectedCourse);
            courseDataGridView.Rows.Clear();
            if (course != null)
            {
                courseDataGridView.Rows.Add(course.Id, course.CourseName);
            }
        }

        private void Subjectsearchbutton_Click(object sender, EventArgs e)
        {
            if (Subjectnamecombo.SelectedIndex == -1) return;
            string selectedSubject = Subjectnamecombo.SelectedItem.ToString();
            var subject = SubjectController.GetAllSubjects().FirstOrDefault(s => s.SubjectName == selectedSubject);
            subjectDataGridView.Rows.Clear();
            if (subject != null)
            {
                subjectDataGridView.Rows.Add(subject.Id, subject.SubjectName);
            }
        }

        private void CourseSubjectForm_Load(object sender, EventArgs e)
        {
            LoadCourseSubjectView();
        }

        private void Coursenamecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
