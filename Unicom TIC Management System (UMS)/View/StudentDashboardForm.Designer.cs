namespace Unicom_TIC_Management_System__UMS_.View
{
    partial class StudentDashboardForm
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
            this.groupBoxProfile = new System.Windows.Forms.GroupBox();
            this.textContact = new System.Windows.Forms.TextBox();
            this.textGuardian = new System.Windows.Forms.TextBox();
            this.textCourse = new System.Windows.Forms.TextBox();
            this.textGender = new System.Windows.Forms.TextBox();
            this.textDOB = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelContact = new System.Windows.Forms.Label();
            this.labelGuardian = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelDOB = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridViewTimeTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewMarks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxProfile
            // 
            this.groupBoxProfile.Controls.Add(this.textContact);
            this.groupBoxProfile.Controls.Add(this.textGuardian);
            this.groupBoxProfile.Controls.Add(this.textCourse);
            this.groupBoxProfile.Controls.Add(this.textGender);
            this.groupBoxProfile.Controls.Add(this.textDOB);
            this.groupBoxProfile.Controls.Add(this.textName);
            this.groupBoxProfile.Controls.Add(this.labelContact);
            this.groupBoxProfile.Controls.Add(this.labelGuardian);
            this.groupBoxProfile.Controls.Add(this.labelCourse);
            this.groupBoxProfile.Controls.Add(this.labelGender);
            this.groupBoxProfile.Controls.Add(this.labelDOB);
            this.groupBoxProfile.Controls.Add(this.labelName);
            this.groupBoxProfile.Location = new System.Drawing.Point(59, 53);
            this.groupBoxProfile.Name = "groupBoxProfile";
            this.groupBoxProfile.Size = new System.Drawing.Size(350, 180);
            this.groupBoxProfile.TabIndex = 0;
            this.groupBoxProfile.TabStop = false;
            this.groupBoxProfile.Text = "My Profile";
            this.groupBoxProfile.Enter += new System.EventHandler(this.groupBoxProfile_Enter);
            // 
            // textContact
            // 
            this.textContact.Location = new System.Drawing.Point(87, 148);
            this.textContact.Name = "textContact";
            this.textContact.Size = new System.Drawing.Size(226, 20);
            this.textContact.TabIndex = 11;
            // 
            // textGuardian
            // 
            this.textGuardian.Location = new System.Drawing.Point(87, 121);
            this.textGuardian.Name = "textGuardian";
            this.textGuardian.Size = new System.Drawing.Size(226, 20);
            this.textGuardian.TabIndex = 10;
            // 
            // textCourse
            // 
            this.textCourse.Location = new System.Drawing.Point(87, 96);
            this.textCourse.Name = "textCourse";
            this.textCourse.Size = new System.Drawing.Size(226, 20);
            this.textCourse.TabIndex = 9;
            // 
            // textGender
            // 
            this.textGender.Location = new System.Drawing.Point(87, 70);
            this.textGender.Name = "textGender";
            this.textGender.Size = new System.Drawing.Size(226, 20);
            this.textGender.TabIndex = 8;
            // 
            // textDOB
            // 
            this.textDOB.Location = new System.Drawing.Point(87, 48);
            this.textDOB.Name = "textDOB";
            this.textDOB.Size = new System.Drawing.Size(226, 20);
            this.textDOB.TabIndex = 7;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(87, 23);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(226, 20);
            this.textName.TabIndex = 6;
            // 
            // labelContact
            // 
            this.labelContact.AutoSize = true;
            this.labelContact.Location = new System.Drawing.Point(22, 151);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(44, 13);
            this.labelContact.TabIndex = 5;
            this.labelContact.Text = "Contact";
            // 
            // labelGuardian
            // 
            this.labelGuardian.AutoSize = true;
            this.labelGuardian.Location = new System.Drawing.Point(22, 124);
            this.labelGuardian.Name = "labelGuardian";
            this.labelGuardian.Size = new System.Drawing.Size(50, 13);
            this.labelGuardian.TabIndex = 4;
            this.labelGuardian.Text = "Guardian";
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Location = new System.Drawing.Point(24, 99);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(40, 13);
            this.labelCourse.TabIndex = 3;
            this.labelCourse.Text = "Course";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(22, 73);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(42, 13);
            this.labelGender.TabIndex = 2;
            this.labelGender.Text = "Gender";
            // 
            // labelDOB
            // 
            this.labelDOB.AutoSize = true;
            this.labelDOB.Location = new System.Drawing.Point(22, 51);
            this.labelDOB.Name = "labelDOB";
            this.labelDOB.Size = new System.Drawing.Size(30, 13);
            this.labelDOB.TabIndex = 1;
            this.labelDOB.Text = "DOB";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(22, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // dataGridViewTimeTable
            // 
            this.dataGridViewTimeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimeTable.Location = new System.Drawing.Point(59, 431);
            this.dataGridViewTimeTable.Name = "dataGridViewTimeTable";
            this.dataGridViewTimeTable.Size = new System.Drawing.Size(578, 150);
            this.dataGridViewTimeTable.TabIndex = 1;
            // 
            // dataGridViewMarks
            // 
            this.dataGridViewMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMarks.Location = new System.Drawing.Point(59, 286);
            this.dataGridViewMarks.Name = "dataGridViewMarks";
            this.dataGridViewMarks.Size = new System.Drawing.Size(350, 90);
            this.dataGridViewMarks.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "My Marks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time Table";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "STUDENTS DASHBOARD";
            // 
            // StudentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 611);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxProfile);
            this.Controls.Add(this.dataGridViewMarks);
            this.Controls.Add(this.dataGridViewTimeTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentDashboardForm";
            this.Text = "Studentpanel";
            this.Load += new System.EventHandler(this.StudentDashboardForm_Load);
            this.groupBoxProfile.ResumeLayout(false);
            this.groupBoxProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProfile;
        private System.Windows.Forms.TextBox textContact;
        private System.Windows.Forms.TextBox textGuardian;
        private System.Windows.Forms.TextBox textCourse;
        private System.Windows.Forms.TextBox textGender;
        private System.Windows.Forms.TextBox textDOB;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Label labelGuardian;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelDOB;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridViewTimeTable;
        private System.Windows.Forms.DataGridView dataGridViewMarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}