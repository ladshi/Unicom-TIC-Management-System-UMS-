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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();

            if (userController.IsUserTableEmpty())
            {
                //  First-time setting up
                MessageBox.Show("First time admin setting up.Please add Main admin!", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AdminForm adminForm = new AdminForm(firstTime: true); 
                adminForm.Show();
                
            }
            else
            {
                // ✅ Users exist, show login
                Login loginForm = new Login();
                loginForm.Show();
            }
            this.Hide();
        }

        private void Welcomenote_Click(object sender, EventArgs e)
        {

        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
