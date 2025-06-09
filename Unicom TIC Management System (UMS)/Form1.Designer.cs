namespace Unicom_TIC_Management_System__UMS_
{
    partial class Form1
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
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblusername.Location = new System.Drawing.Point(141, 119);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(117, 24);
            this.lblusername.TabIndex = 0;
            this.lblusername.Text = "USERNAME";
            this.lblusername.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblpassword.Location = new System.Drawing.Point(141, 182);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(118, 24);
            this.lblpassword.TabIndex = 1;
            this.lblpassword.Text = "PASSWORD";
            this.lblpassword.Click += new System.EventHandler(this.lblpassword_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(298, 119);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(344, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(298, 186);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(344, 20);
            this.txtpassword.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.lblusername);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button button1;
    }
}

