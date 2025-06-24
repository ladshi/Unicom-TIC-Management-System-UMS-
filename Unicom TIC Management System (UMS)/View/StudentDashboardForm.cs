using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class StudentDashboardForm : Form
    {
        private string username;
        private int studentId;

        public StudentDashboardForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxProfile_Enter(object sender, EventArgs e)
        {

        }
    }
}
