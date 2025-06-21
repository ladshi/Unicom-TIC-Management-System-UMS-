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

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class TimeTableForm : Form
    {
        private TimeTableController controller = new TimeTableController();
        private int selectedTimetableId = -1;
        public TimeTableForm()
        {

            InitializeComponent();
            LoadTimetablesToGrid();
        }

        private void TimeTableForm_Load(object sender, EventArgs e)
        {

        }
    }
}
