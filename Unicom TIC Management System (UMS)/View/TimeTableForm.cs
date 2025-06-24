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
using Unicom_TIC_Management_System__UMS_.Services;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class TimeTableForm : Form
    {
        private TimeTableController controller = new TimeTableController();
        private int selectedTimetableId = -1;
        public TimeTableForm()
        {

            InitializeComponent();
            LoadSubjects();
            LoadLecturers();
            LoadRooms();
            LoadTimetablesToGrid();
        }

        private void LoadSubjects()
        {
            var subjects = SubjectService.GetAllSubjects();
            combosubject.DataSource = subjects;
            combosubject.DisplayMember = "SubjectName";
            combosubject.ValueMember = "Id";
            combosubject.SelectedIndex = -1;
        }

        private void LoadLecturers()
        {
            var lecturers = LectureService.GetAllLecturers();
            var lecturerDisplayList = lecturers.Select(l => new
            {
                UserId = l.UserId,
                FullName = $"{l.FirstName} {l.LastName}"
            }).ToList();

            combolecture.DataSource = lecturerDisplayList;
            combolecture.DisplayMember = "FullName";
            combolecture.ValueMember = "UserId";
            combolecture.SelectedIndex = -1;
        }

        private void LoadRooms()
        {
            var rooms = RoomallocationService.GetAllRooms();
            comboroom.DataSource = rooms;
            comboroom.DisplayMember = "RoomName";
            comboroom.ValueMember = "Id";
            comboroom.SelectedIndex = -1;
        }



        private void TimeTableForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var t = new Timetable
            {

                Day = DTpic.Value.ToString(),

                StartTime = textstarttime.Text,
                EndTime = Textendtime.Text,
                SubjectId = Convert.ToInt32(combosubject.SelectedValue),
                LectureId = Convert.ToInt32(combolecture.SelectedValue),
                TimeSlot = texttimeslot.Text,
                RoomId = Convert.ToInt32(comboroom.SelectedValue)
            };

            controller.AddTimetable(t);
            LoadTimetablesToGrid();
            ClearInputs();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId != -1)
            {
                var t = new Timetable
                {
                    Id = selectedTimetableId,

                    Day = DTpic.Value.ToString(),

                    StartTime = textstarttime.Text,
                    EndTime = Textendtime.Text,
                    SubjectId = Convert.ToInt32(combosubject.SelectedValue),
                    LectureId = Convert.ToInt32(combolecture.SelectedValue),
                    TimeSlot = texttimeslot.Text,
                    RoomId = Convert.ToInt32(comboroom.SelectedValue)
                };

                controller.UpdateTimetable(t);
                LoadTimetablesToGrid();
                ClearInputs();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId != -1)
            {
                controller.DeleteTimetable(selectedTimetableId);
                LoadTimetablesToGrid();
                ClearInputs();
            }
        }

        private void dataGridViewTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedTimetableId = Convert.ToInt32(dataGridViewTimetable.Rows[e.RowIndex].Cells[0].Value);

                DTpic.Value = Convert.ToDateTime(dataGridViewTimetable.Rows[e.RowIndex].Cells[1].Value);

                textstarttime.Text = dataGridViewTimetable.Rows[e.RowIndex].Cells[2].Value.ToString();
                Textendtime.Text = dataGridViewTimetable.Rows[e.RowIndex].Cells[3].Value.ToString();
                combosubject.SelectedValue = dataGridViewTimetable.Rows[e.RowIndex].Cells[4].Value;
                combolecture.SelectedValue = dataGridViewTimetable.Rows[e.RowIndex].Cells[5].Value;
                texttimeslot.Text = dataGridViewTimetable.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboroom.SelectedValue = dataGridViewTimetable.Rows[e.RowIndex].Cells[7].Value;
            }
        }

            private void LoadTimetablesToGrid()
            {
            dataGridViewTimetable.Columns.Clear();
            dataGridViewTimetable.Columns.Add("Id", "ID");
            dataGridViewTimetable.Columns.Add("Day", "Day");
            dataGridViewTimetable.Columns.Add("StartTime", "Start Time");
            dataGridViewTimetable.Columns.Add("EndTime", "End Time");

            dataGridViewTimetable.Columns.Add("SubjectId", "Subject ID");
            dataGridViewTimetable.Columns["SubjectId"].Visible = false;

            dataGridViewTimetable.Columns.Add("LectureId", "Lecturer ID");
            dataGridViewTimetable.Columns["LectureId"].Visible = false;

            dataGridViewTimetable.Columns.Add("RoomId", "Room ID");
            dataGridViewTimetable.Columns["RoomId"].Visible = false;

            dataGridViewTimetable.Columns.Add("SubjectName", "Subject");
            dataGridViewTimetable.Columns.Add("LecturerName", "Lecturer");
            dataGridViewTimetable.Columns.Add("TimeSlot", "Time Slot");
            dataGridViewTimetable.Columns.Add("RoomName", "Room");

            dataGridViewTimetable.Rows.Clear();

            foreach (var t in controller.GetAllTimetables())
            {
                string subjectName = SubjectController.GetSubjectNameById(t.SubjectId);
                string lecturerName = LectureController.GetLecturerNameById(t.LectureId);
                string roomName = RoomController.GetRoomNameById(t.RoomId);

                dataGridViewTimetable.Rows.Add(
                       t.Id,
                       t.Day,
                       t.StartTime,
                       t.EndTime,
                       t.SubjectId,          // invisible ids 
                       t.LectureId,          
                       t.RoomId,            
                       subjectName,          
                       lecturerName,         
                       t.TimeSlot,
                       roomName             
                   );
            }
        }

            private void ClearInputs()
            {
                selectedTimetableId = -1;

                DTpic.Value = DateTime.Today; ;

                textstarttime.Clear();
                Textendtime.Clear();
                texttimeslot.Clear();
                combosubject.SelectedIndex = -1;
                combolecture.SelectedIndex = -1;
                comboroom.SelectedIndex = -1;
            }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}

 