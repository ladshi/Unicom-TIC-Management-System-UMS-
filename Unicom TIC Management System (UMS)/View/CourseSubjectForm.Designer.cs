namespace Unicom_TIC_Management_System__UMS_.View
{
    partial class CourseSubjectForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.courseNameTextBox = new System.Windows.Forms.TextBox();
            this.subjectNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.courseDataGridView = new System.Windows.Forms.DataGridView();
            this.coursesearchbutton = new System.Windows.Forms.Button();
            this.courseAddButton = new System.Windows.Forms.Button();
            this.courseUpdatebutton = new System.Windows.Forms.Button();
            this.courseDeleteButton = new System.Windows.Forms.Button();
            this.Subjectaddbtn = new System.Windows.Forms.Button();
            this.subjectUpdateButton = new System.Windows.Forms.Button();
            this.subjectDeleteButton = new System.Windows.Forms.Button();
            this.subjectDataGridView = new System.Windows.Forms.DataGridView();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.CourseCombo = new System.Windows.Forms.Label();
            this.Subjectsearchbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.courseSubjectDataGridView = new System.Windows.Forms.DataGridView();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.courseSEARCH = new System.Windows.Forms.ComboBox();
            this.combosubject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseSubjectDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Courses & Subjects Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject Name";
            // 
            // courseNameTextBox
            // 
            this.courseNameTextBox.Location = new System.Drawing.Point(126, 56);
            this.courseNameTextBox.Name = "courseNameTextBox";
            this.courseNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.courseNameTextBox.TabIndex = 3;
            // 
            // subjectNameTextBox
            // 
            this.subjectNameTextBox.Location = new System.Drawing.Point(439, 89);
            this.subjectNameTextBox.Name = "subjectNameTextBox";
            this.subjectNameTextBox.Size = new System.Drawing.Size(216, 20);
            this.subjectNameTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Course List";
            // 
            // courseDataGridView
            // 
            this.courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGridView.Location = new System.Drawing.Point(55, 189);
            this.courseDataGridView.Name = "courseDataGridView";
            this.courseDataGridView.Size = new System.Drawing.Size(271, 231);
            this.courseDataGridView.TabIndex = 6;
            // 
            // coursesearchbutton
            // 
            this.coursesearchbutton.Location = new System.Drawing.Point(55, 434);
            this.coursesearchbutton.Name = "coursesearchbutton";
            this.coursesearchbutton.Size = new System.Drawing.Size(75, 23);
            this.coursesearchbutton.TabIndex = 7;
            this.coursesearchbutton.Text = "SEARCH";
            this.coursesearchbutton.UseVisualStyleBackColor = true;
            // 
            // courseAddButton
            // 
            this.courseAddButton.Location = new System.Drawing.Point(273, 87);
            this.courseAddButton.Name = "courseAddButton";
            this.courseAddButton.Size = new System.Drawing.Size(53, 23);
            this.courseAddButton.TabIndex = 9;
            this.courseAddButton.Text = "ADD";
            this.courseAddButton.UseVisualStyleBackColor = true;
            this.courseAddButton.Click += new System.EventHandler(this.courseAddButton_Click);
            // 
            // courseUpdatebutton
            // 
            this.courseUpdatebutton.Location = new System.Drawing.Point(198, 87);
            this.courseUpdatebutton.Name = "courseUpdatebutton";
            this.courseUpdatebutton.Size = new System.Drawing.Size(69, 23);
            this.courseUpdatebutton.TabIndex = 10;
            this.courseUpdatebutton.Text = "UPDATE";
            this.courseUpdatebutton.UseVisualStyleBackColor = true;
            // 
            // courseDeleteButton
            // 
            this.courseDeleteButton.Location = new System.Drawing.Point(134, 87);
            this.courseDeleteButton.Name = "courseDeleteButton";
            this.courseDeleteButton.Size = new System.Drawing.Size(58, 23);
            this.courseDeleteButton.TabIndex = 11;
            this.courseDeleteButton.Text = "DELETE";
            this.courseDeleteButton.UseVisualStyleBackColor = true;
            // 
            // Subjectaddbtn
            // 
            this.Subjectaddbtn.Location = new System.Drawing.Point(580, 125);
            this.Subjectaddbtn.Name = "Subjectaddbtn";
            this.Subjectaddbtn.Size = new System.Drawing.Size(75, 23);
            this.Subjectaddbtn.TabIndex = 12;
            this.Subjectaddbtn.Text = "ADD";
            this.Subjectaddbtn.UseVisualStyleBackColor = true;
            // 
            // subjectUpdateButton
            // 
            this.subjectUpdateButton.Location = new System.Drawing.Point(508, 125);
            this.subjectUpdateButton.Name = "subjectUpdateButton";
            this.subjectUpdateButton.Size = new System.Drawing.Size(66, 23);
            this.subjectUpdateButton.TabIndex = 13;
            this.subjectUpdateButton.Text = "UPDATE";
            this.subjectUpdateButton.UseVisualStyleBackColor = true;
            // 
            // subjectDeleteButton
            // 
            this.subjectDeleteButton.Location = new System.Drawing.Point(439, 125);
            this.subjectDeleteButton.Name = "subjectDeleteButton";
            this.subjectDeleteButton.Size = new System.Drawing.Size(63, 23);
            this.subjectDeleteButton.TabIndex = 14;
            this.subjectDeleteButton.Text = "DELETE";
            this.subjectDeleteButton.UseVisualStyleBackColor = true;
            // 
            // subjectDataGridView
            // 
            this.subjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectDataGridView.Location = new System.Drawing.Point(392, 189);
            this.subjectDataGridView.Name = "subjectDataGridView";
            this.subjectDataGridView.Size = new System.Drawing.Size(285, 225);
            this.subjectDataGridView.TabIndex = 15;
            // 
            // courseComboBox
            // 
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Location = new System.Drawing.Point(439, 55);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(216, 21);
            this.courseComboBox.TabIndex = 16;
            // 
            // CourseCombo
            // 
            this.CourseCombo.AutoSize = true;
            this.CourseCombo.Location = new System.Drawing.Point(362, 59);
            this.CourseCombo.Name = "CourseCombo";
            this.CourseCombo.Size = new System.Drawing.Size(71, 13);
            this.CourseCombo.TabIndex = 17;
            this.CourseCombo.Text = "Course Name";
            // 
            // Subjectsearchbutton
            // 
            this.Subjectsearchbutton.Location = new System.Drawing.Point(392, 434);
            this.Subjectsearchbutton.Name = "Subjectsearchbutton";
            this.Subjectsearchbutton.Size = new System.Drawing.Size(75, 23);
            this.Subjectsearchbutton.TabIndex = 18;
            this.Subjectsearchbutton.Text = "SEARCH";
            this.Subjectsearchbutton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Subject List";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Course and Subject List";
            // 
            // courseSubjectDataGridView
            // 
            this.courseSubjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseSubjectDataGridView.Location = new System.Drawing.Point(55, 488);
            this.courseSubjectDataGridView.Name = "courseSubjectDataGridView";
            this.courseSubjectDataGridView.Size = new System.Drawing.Size(622, 82);
            this.courseSubjectDataGridView.TabIndex = 22;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(198, 575);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 23;
            this.button9.Text = "SEARCH";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(284, 578);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(229, 20);
            this.textBox5.TabIndex = 24;
            // 
            // courseSEARCH
            // 
            this.courseSEARCH.FormattingEnabled = true;
            this.courseSEARCH.Location = new System.Drawing.Point(157, 434);
            this.courseSEARCH.Name = "courseSEARCH";
            this.courseSEARCH.Size = new System.Drawing.Size(169, 21);
            this.courseSEARCH.TabIndex = 25;
            // 
            // combosubject
            // 
            this.combosubject.FormattingEnabled = true;
            this.combosubject.Location = new System.Drawing.Point(486, 436);
            this.combosubject.Name = "combosubject";
            this.combosubject.Size = new System.Drawing.Size(191, 21);
            this.combosubject.TabIndex = 26;
            // 
            // CourseSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 607);
            this.Controls.Add(this.combosubject);
            this.Controls.Add(this.courseSEARCH);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.courseSubjectDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Subjectsearchbutton);
            this.Controls.Add(this.CourseCombo);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.subjectDataGridView);
            this.Controls.Add(this.subjectDeleteButton);
            this.Controls.Add(this.subjectUpdateButton);
            this.Controls.Add(this.Subjectaddbtn);
            this.Controls.Add(this.courseDeleteButton);
            this.Controls.Add(this.courseUpdatebutton);
            this.Controls.Add(this.courseAddButton);
            this.Controls.Add(this.coursesearchbutton);
            this.Controls.Add(this.courseDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subjectNameTextBox);
            this.Controls.Add(this.courseNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CourseSubjectForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CourseSubjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseSubjectDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.TextBox subjectNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView courseDataGridView;
        private System.Windows.Forms.Button coursesearchbutton;
        private System.Windows.Forms.Button courseAddButton;
        private System.Windows.Forms.Button courseUpdatebutton;
        private System.Windows.Forms.Button courseDeleteButton;
        private System.Windows.Forms.Button Subjectaddbtn;
        private System.Windows.Forms.Button subjectUpdateButton;
        private System.Windows.Forms.Button subjectDeleteButton;
        private System.Windows.Forms.DataGridView subjectDataGridView;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Label CourseCombo;
        private System.Windows.Forms.Button Subjectsearchbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView courseSubjectDataGridView;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox courseSEARCH;
        private System.Windows.Forms.ComboBox combosubject;
    }
}