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
    public partial class RoomAllocationForm : Form
    {
        private int selectedRoomId = -1;
        private RoomController roomController = new RoomController();

        public RoomAllocationForm()
        {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            comboroomtype.Items.Add("Lab");
            comboroomtype.Items.Add("Hall");
            comboroomtype.SelectedIndex = 0;

            LoadRoomData();
        }

        private void LoadRoomData()
        {
            ROOMgridview.Columns.Clear();
            ROOMgridview.Columns.Add("Id", "Room ID");
            ROOMgridview.Columns.Add("RoomName", "Room Name");
            ROOMgridview.Columns.Add("RoomType", "Room Type");

            ROOMgridview.Rows.Clear();
            List<RoomAllocation> roomList = roomController.GetAllRooms();

            foreach (var room in roomList)
            {
                ROOMgridview.Rows.Add(room.Id, room.RoomName, room.RoomType);
            }

            selectedRoomId = -1;
            Roomnametext.Clear();
            comboroomtype.SelectedIndex = 0;
        }

        private void ADDbutton_Click(object sender, EventArgs e)
        {
            RoomAllocation room = new RoomAllocation
            {
                RoomName = Roomnametext.Text.Trim(),
                RoomType = comboroomtype.SelectedItem.ToString()
            };

            RoomController.AddRoom(room);
            LoadRoomData();
        }

        private void ROOMgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRoomId = Convert.ToInt32(ROOMgridview.Rows[e.RowIndex].Cells[0].Value);
                Roomnametext.Text = ROOMgridview.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboroomtype.SelectedItem = ROOMgridview.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            if (selectedRoomId != -1)
            {
                RoomAllocation room = new RoomAllocation
                {
                    Id = selectedRoomId,
                    RoomName = Roomnametext.Text.Trim(),
                    RoomType = comboroomtype.SelectedItem.ToString()
                };

                RoomController.UpdateRoom(room);
                LoadRoomData();
            }
        }

        private void DELETEbutton_Click(object sender, EventArgs e)
        {
            if (selectedRoomId != -1)
            {
                RoomController.DeleteRoom(selectedRoomId);
                LoadRoomData();
            }
        }
    }
}
