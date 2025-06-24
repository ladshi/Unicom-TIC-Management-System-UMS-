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
            SetupGrid();
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
            // dataGridViewMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMarks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewMarks.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewMarks.Columns.Clear();
            dataGridViewMarks.Columns.Add("StudentName", "Student Name");
            dataGridViewMarks.Columns.Add("ExamName", "Exam");
            dataGridViewMarks.Columns.Add("SubjectName", "Subject");
            dataGridViewMarks.Columns.Add("MarksObtained", "Marks");
            dataGridViewMarks.Columns.Add("MaxMarks", "Max Marks");
            dataGridViewMarks.Columns.Add("Percentage", "Percentage");
            dataGridViewMarks.Columns.Add("Grade", "Grade");
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

            LoadMarksToGrid();
            LoadTopThree();
        }
        private void SetupTopThreeGrid()
        {
            dataGridTopThree.Columns.Clear();
            dataGridTopThree.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridTopThree.Columns.Add("StudentName", "Student Name");
            dataGridTopThree.Columns.Add("ExamName", "Exam");
            dataGridTopThree.Columns.Add("SubjectName", "Subject");
            dataGridTopThree.Columns.Add("MarksObtained", "Marks");
            dataGridTopThree.Columns.Add("MaxMarks", "Max Marks");
            dataGridTopThree.Columns.Add("Percentage", "Percentage");
            dataGridTopThree.Columns.Add("Grade", "Grade");
        }

        private void LoadTopThree()
        {
            var topThree = MarkController.GetTopThreeStudents();
            dataGridTopThree.Rows.Clear();

            foreach (var item in topThree)
            {
                dataGridTopThree.Rows.Add(
                    item.StudentName,
                    item.ExamName,
                    item.SubjectName,
                    item.MarksObtained,
                    item.MaxMarks,
                    item.Percentage,
                    item.Grade
                );
            }
        }

        private void dataGridViewMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MarksForm_Load(object sender, EventArgs e)
        {
            SetupGrid();         
            SetupTopThreeGrid(); 
            LoadMarksToGrid();
            LoadTopThree();

            comboExam.DataSource = ExamController.GetAllExams();
            comboExam.DisplayMember = "ExamName";
            comboExam.ValueMember = "Id";

            comboStudent.DataSource = StudentController.GetStudentNames();
            comboStudent.DisplayMember = "FullName";
            comboStudent.ValueMember = "StudentId";
            /*var studentList = new List<object>();

            foreach (var s in StudentController.GetAllStudents())
            {
                var id = s.Item1.Id;
                var fullName = string.Concat(s.Item1.FirstName, " ", s.Item1.LastName);

                studentList.Add(new { Id = id, FullName = fullName });
            }*/

            // Loading Students
            //comboStudent.DataSource = StudentController.GetAllStudents(); 
            //comboStudent.DisplayMember = "FirstName"; 
            //comboStudent.ValueMember = "Id";

            comboSubject.DataSource = SubjectController.GetAllSubjects();
            comboSubject.DisplayMember = "SubjectName";
            comboSubject.ValueMember = "Id";
        }
    }
}
