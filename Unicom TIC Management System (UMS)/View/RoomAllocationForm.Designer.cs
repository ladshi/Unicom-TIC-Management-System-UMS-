namespace Unicom_TIC_Management_System__UMS_.View
{
    partial class RoomAllocationForm
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
            this.ADDbutton = new System.Windows.Forms.Button();
            this.Updatebutton = new System.Windows.Forms.Button();
            this.DELETEbutton = new System.Windows.Forms.Button();
            this.ROOMgridview = new System.Windows.Forms.DataGridView();
            this.Roomnametext = new System.Windows.Forms.TextBox();
            this.comboroomtype = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ROOMgridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Rooms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ROOM NAME ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(124, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ROOM TYPE ";
            // 
            // ADDbutton
            // 
            this.ADDbutton.Location = new System.Drawing.Point(490, 159);
            this.ADDbutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ADDbutton.Name = "ADDbutton";
            this.ADDbutton.Size = new System.Drawing.Size(88, 23);
            this.ADDbutton.TabIndex = 5;
            this.ADDbutton.Text = "ADD";
            this.ADDbutton.UseVisualStyleBackColor = true;
            this.ADDbutton.Click += new System.EventHandler(this.ADDbutton_Click);
            // 
            // Updatebutton
            // 
            this.Updatebutton.Location = new System.Drawing.Point(382, 159);
            this.Updatebutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Updatebutton.Name = "Updatebutton";
            this.Updatebutton.Size = new System.Drawing.Size(88, 23);
            this.Updatebutton.TabIndex = 6;
            this.Updatebutton.Text = "UPDATE";
            this.Updatebutton.UseVisualStyleBackColor = true;
            this.Updatebutton.Click += new System.EventHandler(this.Updatebutton_Click);
            // 
            // DELETEbutton
            // 
            this.DELETEbutton.Location = new System.Drawing.Point(272, 159);
            this.DELETEbutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DELETEbutton.Name = "DELETEbutton";
            this.DELETEbutton.Size = new System.Drawing.Size(88, 23);
            this.DELETEbutton.TabIndex = 7;
            this.DELETEbutton.Text = "DELETE";
            this.DELETEbutton.UseVisualStyleBackColor = true;
            this.DELETEbutton.Click += new System.EventHandler(this.DELETEbutton_Click);
            // 
            // ROOMgridview
            // 
            this.ROOMgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ROOMgridview.Location = new System.Drawing.Point(123, 234);
            this.ROOMgridview.Name = "ROOMgridview";
            this.ROOMgridview.Size = new System.Drawing.Size(455, 233);
            this.ROOMgridview.TabIndex = 10;
            this.ROOMgridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ROOMgridview_CellClick);
            this.ROOMgridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ROOMgridview_CellContentClick);
            // 
            // Roomnametext
            // 
            this.Roomnametext.Location = new System.Drawing.Point(248, 75);
            this.Roomnametext.Name = "Roomnametext";
            this.Roomnametext.Size = new System.Drawing.Size(330, 20);
            this.Roomnametext.TabIndex = 13;
            // 
            // comboroomtype
            // 
            this.comboroomtype.FormattingEnabled = true;
            this.comboroomtype.Location = new System.Drawing.Point(248, 104);
            this.comboroomtype.Name = "comboroomtype";
            this.comboroomtype.Size = new System.Drawing.Size(330, 21);
            this.comboroomtype.TabIndex = 14;
            // 
            // RoomAllocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 691);
            this.Controls.Add(this.comboroomtype);
            this.Controls.Add(this.Roomnametext);
            this.Controls.Add(this.ROOMgridview);
            this.Controls.Add(this.DELETEbutton);
            this.Controls.Add(this.Updatebutton);
            this.Controls.Add(this.ADDbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RoomAllocationForm";
            this.Text = "RoomAllocation";
            this.Load += new System.EventHandler(this.RoomAllocationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ROOMgridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ADDbutton;
        private System.Windows.Forms.Button Updatebutton;
        private System.Windows.Forms.Button DELETEbutton;
        private System.Windows.Forms.DataGridView ROOMgridview;
        private System.Windows.Forms.TextBox Roomnametext;
        private System.Windows.Forms.ComboBox comboroomtype;
    }
}