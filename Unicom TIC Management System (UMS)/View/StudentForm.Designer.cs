namespace Unicom_TIC_Management_System__UMS_.View
{
    partial class StudentForm
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
            this.lblSname = new System.Windows.Forms.Label();
            this.textSDOB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSaddress = new System.Windows.Forms.TextBox();
            this.textSusername = new System.Windows.Forms.TextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.textSlastname = new System.Windows.Forms.TextBox();
            this.lblphoneno = new System.Windows.Forms.Label();
            this.textSPhoneNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.courseCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textSpassword = new System.Windows.Forms.TextBox();
            this.ButtonADD = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblgurdian = new System.Windows.Forms.Label();
            this.textGurname = new System.Windows.Forms.TextBox();
            this.lblGurPhone = new System.Windows.Forms.Label();
            this.textGurPhoNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSname
            // 
            this.lblSname.AutoSize = true;
            this.lblSname.Location = new System.Drawing.Point(71, 72);
            this.lblSname.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSname.Name = "lblSname";
            this.lblSname.Size = new System.Drawing.Size(90, 19);
            this.lblSname.TabIndex = 0;
            this.lblSname.Text = "First Name";
            // 
            // textSDOB
            // 
            this.textSDOB.Location = new System.Drawing.Point(76, 154);
            this.textSDOB.Name = "textSDOB";
            this.textSDOB.Size = new System.Drawing.Size(261, 27);
            this.textSDOB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gender";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(164, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 30;
            // 
            // textSaddress
            // 
            this.textSaddress.Location = new System.Drawing.Point(74, 273);
            this.textSaddress.Name = "textSaddress";
            this.textSaddress.Size = new System.Drawing.Size(558, 27);
            this.textSaddress.TabIndex = 7;
            this.textSaddress.TextChanged += new System.EventHandler(this.textSaddress_TextChanged);
            // 
            // textSusername
            // 
            this.textSusername.Location = new System.Drawing.Point(75, 330);
            this.textSusername.Name = "textSusername";
            this.textSusername.Size = new System.Drawing.Size(262, 27);
            this.textSusername.TabIndex = 9;
            this.textSusername.TextChanged += new System.EventHandler(this.textSusername_TextChanged);
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(367, 72);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(89, 19);
            this.lblLastname.TabIndex = 18;
            this.lblLastname.Text = "Last Name";
            // 
            // textSlastname
            // 
            this.textSlastname.Location = new System.Drawing.Point(371, 95);
            this.textSlastname.Name = "textSlastname";
            this.textSlastname.Size = new System.Drawing.Size(262, 27);
            this.textSlastname.TabIndex = 19;
            // 
            // lblphoneno
            // 
            this.lblphoneno.AutoSize = true;
            this.lblphoneno.Location = new System.Drawing.Point(367, 131);
            this.lblphoneno.Name = "lblphoneno";
            this.lblphoneno.Size = new System.Drawing.Size(125, 19);
            this.lblphoneno.TabIndex = 20;
            this.lblphoneno.Text = "Phone Number";
            // 
            // textSPhoneNo
            // 
            this.textSPhoneNo.Location = new System.Drawing.Point(372, 153);
            this.textSPhoneNo.Name = "textSPhoneNo";
            this.textSPhoneNo.Size = new System.Drawing.Size(262, 27);
            this.textSPhoneNo.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "Course";
            // 
            // courseCombo
            // 
            this.courseCombo.FormattingEnabled = true;
            this.courseCombo.Location = new System.Drawing.Point(371, 211);
            this.courseCombo.Name = "courseCombo";
            this.courseCombo.Size = new System.Drawing.Size(262, 27);
            this.courseCombo.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "Password";
            // 
            // textSpassword
            // 
            this.textSpassword.Location = new System.Drawing.Point(370, 330);
            this.textSpassword.Name = "textSpassword";
            this.textSpassword.Size = new System.Drawing.Size(262, 27);
            this.textSpassword.TabIndex = 25;
            // 
            // ButtonADD
            // 
            this.ButtonADD.Location = new System.Drawing.Point(575, 549);
            this.ButtonADD.Name = "ButtonADD";
            this.ButtonADD.Size = new System.Drawing.Size(75, 32);
            this.ButtonADD.TabIndex = 26;
            this.ButtonADD.Text = "ADD";
            this.ButtonADD.UseVisualStyleBackColor = true;
            this.ButtonADD.Click += new System.EventHandler(this.ButtonADD_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(469, 549);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(87, 32);
            this.buttonUpdate.TabIndex = 27;
            this.buttonUpdate.Text = "UPDATE";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(370, 551);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 30);
            this.buttonDelete.TabIndex = 28;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 27);
            this.textBox1.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 35;
            this.label5.Text = "Date of Birth";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 211);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 27);
            this.textBox2.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 37;
            this.label6.Text = "Address";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 19);
            this.label7.TabIndex = 38;
            this.label7.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 46);
            this.label1.TabIndex = 39;
            this.label1.Text = "Student\'s Details";
            // 
            // lblgurdian
            // 
            this.lblgurdian.AutoSize = true;
            this.lblgurdian.Location = new System.Drawing.Point(72, 423);
            this.lblgurdian.Name = "lblgurdian";
            this.lblgurdian.Size = new System.Drawing.Size(131, 19);
            this.lblgurdian.TabIndex = 40;
            this.lblgurdian.Text = "Gurdian\'s Name";
            this.lblgurdian.Click += new System.EventHandler(this.lblgurdian_Click);
            // 
            // textGurname
            // 
            this.textGurname.Location = new System.Drawing.Point(72, 445);
            this.textGurname.Name = "textGurname";
            this.textGurname.Size = new System.Drawing.Size(261, 27);
            this.textGurname.TabIndex = 41;
            this.textGurname.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // lblGurPhone
            // 
            this.lblGurPhone.AutoSize = true;
            this.lblGurPhone.Location = new System.Drawing.Point(374, 423);
            this.lblGurPhone.Name = "lblGurPhone";
            this.lblGurPhone.Size = new System.Drawing.Size(171, 19);
            this.lblGurPhone.TabIndex = 42;
            this.lblGurPhone.Text = "Gurdian\'s Contact No";
            this.lblGurPhone.Click += new System.EventHandler(this.lblGurPhone_Click);
            // 
            // textGurPhoNo
            // 
            this.textGurPhoNo.Location = new System.Drawing.Point(370, 445);
            this.textGurPhoNo.Name = "textGurPhoNo";
            this.textGurPhoNo.Size = new System.Drawing.Size(260, 27);
            this.textGurPhoNo.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 44;
            this.label8.Text = "Email ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(74, 392);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(554, 27);
            this.textBox3.TabIndex = 45;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 657);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textGurPhoNo);
            this.Controls.Add(this.lblGurPhone);
            this.Controls.Add(this.textGurname);
            this.Controls.Add(this.lblgurdian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.ButtonADD);
            this.Controls.Add(this.textSpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.courseCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textSPhoneNo);
            this.Controls.Add(this.lblphoneno);
            this.Controls.Add(this.textSlastname);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.textSusername);
            this.Controls.Add(this.textSaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textSDOB);
            this.Controls.Add(this.lblSname);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSname;
        private System.Windows.Forms.TextBox textSDOB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSaddress;
        private System.Windows.Forms.TextBox textSusername;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.TextBox textSlastname;
        private System.Windows.Forms.Label lblphoneno;
        private System.Windows.Forms.TextBox textSPhoneNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox courseCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textSpassword;
        private System.Windows.Forms.Button ButtonADD;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblgurdian;
        private System.Windows.Forms.TextBox textGurname;
        private System.Windows.Forms.Label lblGurPhone;
        private System.Windows.Forms.TextBox textGurPhoNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
    }
}