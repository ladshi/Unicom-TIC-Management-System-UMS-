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
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Exam exam = new Exam
            {
                ExamName = textexamname.Text.Trim(),
                ExamDate = Examdatetimepicker.Value.ToString("yyyy-MM-dd")
            };

            ExamController.AddExam(exam);
            LoadExamData();
            ClearInputs();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedExamId != -1)
            {
                Exam exam = new Exam
                {
                    Id = selectedExamId,
                    ExamName = textexamname.Text.Trim(),
                    ExamDate = Examdatetimepicker.Value.ToString("yyyy-MM-dd")
                };

                ExamController.UpdateExam(exam);
                LoadExamData();
                ClearInputs();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId != -1)
            {
                ExamController.DeleteExam(selectedExamId);
                LoadExamData();
                ClearInputs();
            }
        }

        private void LoadExamData()
        {
            dataGridViewexam.Rows.Clear();
            foreach (var exam in ExamController.GetAllExams())
            {
                dataGridViewexam.Rows.Add(exam.Id, exam.ExamName, exam.ExamDate);
            }
        }

        private void dataGridViewExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewexam.Rows[e.RowIndex];
                selectedExamId = Convert.ToInt32(row.Cells[0].Value);
                textexamname.Text = row.Cells[1].Value.ToString();
                Examdatetimepicker.Value = DateTime.Parse(row.Cells[2].Value.ToString());
            }
        }

        private void ClearInputs()
        {
            textexamname.Clear();
            Examdatetimepicker.Value = DateTime.Today;
            selectedExamId = -1;
        }

    }
}
