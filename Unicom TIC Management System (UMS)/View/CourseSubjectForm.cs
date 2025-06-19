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

            try
            {
                LoadCourses();    // optional
                LoadSubjects();   // optional
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCourses()
        {
            // example stub logic — replace with your actual course load code
            //var courses = CourseController.GetAllCourses();
            // example: comboBoxCourses.DataSource = courses;
        }

        private void LoadSubjects()
        {
            // example stub logic — replace with your actual subject load code
            //var subjects = SubjectController.GetAllSubjects();
            // example: dataGridViewSubjects.DataSource = subjects;
        }
    }
}
