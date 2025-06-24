namespace Unicom_TIC_Management_System__UMS_.View
{
    partial class defaultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblTotalStaffs = new System.Windows.Forms.Label();
            this.lblTotalAdmins = new System.Windows.Forms.Label();
            this.lblTotalLecturers = new System.Windows.Forms.Label();
            this.lblTotalCourses = new System.Windows.Forms.Label();
            this.lblTotalSubjects = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "default dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.Location = new System.Drawing.Point(155, 65);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(237, 31);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "Total Students: 0";
            // 
            // lblTotalStaffs
            // 
            this.lblTotalStaffs.AutoSize = true;
            this.lblTotalStaffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStaffs.Location = new System.Drawing.Point(76, 124);
            this.lblTotalStaffs.Name = "lblTotalStaffs";
            this.lblTotalStaffs.Size = new System.Drawing.Size(198, 31);
            this.lblTotalStaffs.TabIndex = 2;
            this.lblTotalStaffs.Text = "Total Staffs: 0";
            this.lblTotalStaffs.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblTotalAdmins
            // 
            this.lblTotalAdmins.AutoSize = true;
            this.lblTotalAdmins.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAdmins.Location = new System.Drawing.Point(155, 183);
            this.lblTotalAdmins.Name = "lblTotalAdmins";
            this.lblTotalAdmins.Size = new System.Drawing.Size(217, 31);
            this.lblTotalAdmins.TabIndex = 3;
            this.lblTotalAdmins.Text = "Total Admins: 0";
            this.lblTotalAdmins.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblTotalLecturers
            // 
            this.lblTotalLecturers.AutoSize = true;
            this.lblTotalLecturers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLecturers.Location = new System.Drawing.Point(76, 240);
            this.lblTotalLecturers.Name = "lblTotalLecturers";
            this.lblTotalLecturers.Size = new System.Drawing.Size(234, 31);
            this.lblTotalLecturers.TabIndex = 4;
            this.lblTotalLecturers.Text = "Total Lectures: 0";
            // 
            // lblTotalCourses
            // 
            this.lblTotalCourses.AutoSize = true;
            this.lblTotalCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCourses.Location = new System.Drawing.Point(155, 301);
            this.lblTotalCourses.Name = "lblTotalCourses";
            this.lblTotalCourses.Size = new System.Drawing.Size(230, 31);
            this.lblTotalCourses.TabIndex = 5;
            this.lblTotalCourses.Text = "Total Courses: 0";
            // 
            // lblTotalSubjects
            // 
            this.lblTotalSubjects.AutoSize = true;
            this.lblTotalSubjects.Location = new System.Drawing.Point(91, 370);
            this.lblTotalSubjects.Name = "lblTotalSubjects";
            this.lblTotalSubjects.Size = new System.Drawing.Size(0, 13);
            this.lblTotalSubjects.TabIndex = 6;
            // 
            // defaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Unicom_TIC_Management_System__UMS_.Properties.Resources.OIP__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(696, 650);
            this.Controls.Add(this.lblTotalSubjects);
            this.Controls.Add(this.lblTotalCourses);
            this.Controls.Add(this.lblTotalLecturers);
            this.Controls.Add(this.lblTotalAdmins);
            this.Controls.Add(this.lblTotalStaffs);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "defaultForm";
            this.Text = "defaultForm";
            this.Load += new System.EventHandler(this.defaultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblTotalStaffs;
        private System.Windows.Forms.Label lblTotalAdmins;
        private System.Windows.Forms.Label lblTotalLecturers;
        private System.Windows.Forms.Label lblTotalCourses;
        private System.Windows.Forms.Label lblTotalSubjects;
    }
}