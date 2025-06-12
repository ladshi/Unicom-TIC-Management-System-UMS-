using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Unicom_TIC_Management_System__UMS_.View
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            // Add a root node
            treeAdmin.Nodes.Add("Students");
            treeAdmin.Nodes.Add("Lectures");
            treeAdmin.Nodes.Add("Staff");
            treeAdmin.Nodes.Add("Courses");
            treeAdmin.Nodes.Add("TimeTables");
            treeAdmin.Nodes.Add("Subject");
           

            // Add a child node to the first root node
            treeAdmin.Nodes[0].Nodes.Add("Add/Edit Students");

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
