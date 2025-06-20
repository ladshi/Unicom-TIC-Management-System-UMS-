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
    public partial class MarksForm : Form
    {
        public MarksForm()
        {
            InitializeComponent();
        }

        private void ClearInputs()
        {
            textobmarks.Clear();
            textmaxmarks.Clear();
        }

        private void LoadMarksToGrid()
        {
            dataGridViewMarks.Rows.Clear();
            var marksList = MarkController.GetAllMarksWithDetails();

            foreach (var mark in marksList)
            {
                dataGridViewMarks.Rows.Add(
                    mark.StudentName,
                    mark.ExamName,
                    mark.SubjectName,
                    mark.MarksObtained,
                    mark.MaxMarks,
                    mark.Percentage,
                    mark.Grade
                );
            }
        }

        private void SetupGrid()
        {
            dataGridViewMarks.Columns.Clear();
            dataGridViewMarks.Columns.Add("StudentName", "Student Name");
            dataGridViewMarks.Columns.Add("ExamName", "Exam");
            dataGridViewMarks.Columns.Add("SubjectName", "Subject");
            dataGridViewMarks.Columns.Add("MarksObtained", "Marks");
            dataGridViewMarks.Columns.Add("MaxMarks", "Max Marks");
            dataGridViewMarks.Columns.Add("Percentage", "Percentage");
            dataGridViewMarks.Columns.Add("Grade", "Grade");
        }


        private void MarkEntryForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadMarksToGrid();
            // Load Exams
            comboExam.DataSource = ExamController.GetAllExams();
            comboExam.DisplayMember = "ExamName";
            comboExam.ValueMember = "Id";

            // Load Students
            comboStudent.DataSource = StudentController.GetAllStudents(); 
            comboStudent.DisplayMember = "FirstName"; // or full name
            comboStudent.ValueMember = "Id";

            // Load Subjects
            comboSubject.DataSource = SubjectController.GetAllSubjects(); // Already done in SubjectService
            comboSubject.DisplayMember = "SubjectName";
            comboSubject.ValueMember = "Id";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Mark mark = new Mark
            {
                StudentId = Convert.ToInt32(comboStudent.SelectedValue),
                SubjectId = Convert.ToInt32(comboSubject.SelectedValue),
                ExamId = Convert.ToInt32(comboExam.SelectedValue),
                MarksObtained = Convert.ToDouble(textobmarks.Text),
                MaxMarks = Convert.ToDouble(textmaxmarks.Text)
            };

            MarkController.AddMark(mark);
            MessageBox.Show("Marks added successfully!");
            ClearInputs();
        }

        private void MarksViewForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadMarksToGrid();
        }

        private void dataGridViewMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
