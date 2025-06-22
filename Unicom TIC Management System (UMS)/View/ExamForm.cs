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
    public partial class ExamForm : Form
    {
        int selectedExamId = -1;

        public ExamForm()
        {
            InitializeComponent();
            LoadExamData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string examName = textexamname.Text.Trim();
            string examDate = Examdatetimepicker.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(examName))
            {
                MessageBox.Show("Exam name is required.");
                return;
            }

            Exam exam = new Exam
            {
                ExamName = examName,
                ExamDate = examDate
            };

            ExamController.AddExam(exam);
            LoadExamData();
            ClearInputs();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }

            string examName = textexamname.Text.Trim();
            string examDate = Examdatetimepicker.Value.ToString("yyyy-MM-dd");

            // Validation
            if (string.IsNullOrWhiteSpace(examName))
            {
                MessageBox.Show("Exam name is required.");
                return;
            }

            Exam exam = new Exam
            {
                Id = selectedExamId,
                ExamName = examName,
                ExamDate = examDate
            };

            ExamController.UpdateExam(exam);
            LoadExamData();
            ClearInputs();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId != -1)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this exam details?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                     );

                if (result == DialogResult.Yes)
                {
                    ExamController.DeleteExam(selectedExamId);
                    LoadExamData();
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Please select an exm to delete.");
            }
        }

        private void LoadExamData()
        {
            dataGridViewexam.Columns.Clear();
            dataGridViewexam.Columns.Add("Id", "Exam ID");
            dataGridViewexam.Columns.Add("ExamName", "Exam Name");
            dataGridViewexam.Columns.Add("ExamDate", "Exam Date");

            dataGridViewexam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewexam.Rows.Clear();
            foreach (var exam in ExamController.GetAllExams())
            {
                dataGridViewexam.Rows.Add(exam.Id, exam.ExamName, exam.ExamDate);
            }
            selectedExamId = -1;
        }

        private void ClearInputs()
        {
            textexamname.Clear();
            Examdatetimepicker.Value = DateTime.Today;
            selectedExamId = -1;
        }

        private void dataGridViewexam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewexam.Rows[e.RowIndex];
                selectedExamId = Convert.ToInt32(row.Cells[0].Value);
                textexamname.Text = row.Cells[1].Value.ToString();
                Examdatetimepicker.Value = DateTime.Parse(row.Cells[2].Value.ToString());
            }
        }
    }
}
