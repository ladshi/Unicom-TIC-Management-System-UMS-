using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using Unicom_TIC_Management_System__UMS_.Controllers;
using Unicom_TIC_Management_System__UMS_.Models;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class CourseForm : Form
    {
        private CourseController Coursecontroller = new CourseController();

        public CourseForm()
        {
            InitializeComponent();
            LoadSections();
        }

        private void LoadSections()
        {
            CourseGridView.DataSource = null;
            CourseGridView.DataSource = Coursecontroller.GetAllCourses();
            CourseGridView.ClearSelection();
        }

        private void Courses_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CourseGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(CourseGridView.SelectedRows[0].Cells["Id"].Value);
                Coursecontroller.DeleteCourse(id);
                LoadSections();
                textCoursename.Clear();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Course course = new Course
            {
                Name = textCoursename.Text.Trim()
            };
            Coursecontroller.AddCourse(course);
            LoadSections();
            textCoursename.Clear();
            
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (CourseGridView.SelectedRows.Count > 0)
            {
                textCoursename.Text = CourseGridView.SelectedRows[0].Cells["CourseName"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CourseGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(CourseGridView.SelectedRows[0].Cells["Id"].Value);
                var course = new Course
                {
                    Id = id,
                    Name = textCoursename.Text.Trim()
                };
                Coursecontroller.UpdateCourse(course);
                LoadSections();
                textCoursename.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textcoursesearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                CourseGridView.DataSource = null;
                CourseGridView.DataSource = Coursecontroller.SearchCourses(searchTerm);
                CourseGridView.ClearSelection();
            }
            else
            {
                LoadSections(); 
            }
        }

    }
}
