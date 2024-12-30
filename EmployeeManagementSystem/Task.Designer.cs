
namespace EmployeeManagementSystem
{
    partial class Task
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TaskStatus_cmb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.Add_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ProjectID_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskName_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskID_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Task_dtg = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TaskDescription_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EndDate_dtp = new System.Windows.Forms.DateTimePicker();
            this.StartDate_dtp = new System.Windows.Forms.DateTimePicker();
            this.AssigneeID_txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CP_txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Task_dtg)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskStatus_cmb
            // 
            this.TaskStatus_cmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskStatus_cmb.FormattingEnabled = true;
            this.TaskStatus_cmb.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Completed",
            "On Hold"});
            this.TaskStatus_cmb.Location = new System.Drawing.Point(519, 134);
            this.TaskStatus_cmb.Margin = new System.Windows.Forms.Padding(4);
            this.TaskStatus_cmb.Name = "TaskStatus_cmb";
            this.TaskStatus_cmb.Size = new System.Drawing.Size(225, 26);
            this.TaskStatus_cmb.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(455, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Status:";
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Clear_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Clear_btn.FlatAppearance.BorderSize = 0;
            this.Clear_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Clear_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Clear_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.ForeColor = System.Drawing.Color.White;
            this.Clear_btn.Location = new System.Drawing.Point(788, 201);
            this.Clear_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(151, 46);
            this.Clear_btn.TabIndex = 17;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = false;
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Delete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_btn.FlatAppearance.BorderSize = 0;
            this.Delete_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Delete_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Delete_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.ForeColor = System.Drawing.Color.White;
            this.Delete_btn.Location = new System.Drawing.Point(615, 201);
            this.Delete_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(151, 46);
            this.Delete_btn.TabIndex = 16;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = false;
            // 
            // Update_btn
            // 
            this.Update_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Update_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Update_btn.FlatAppearance.BorderSize = 0;
            this.Update_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Update_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Update_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Update_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_btn.ForeColor = System.Drawing.Color.White;
            this.Update_btn.Location = new System.Drawing.Point(416, 201);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(151, 46);
            this.Update_btn.TabIndex = 15;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = false;
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Add_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add_btn.FlatAppearance.BorderSize = 0;
            this.Add_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Add_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Add_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_btn.ForeColor = System.Drawing.Color.White;
            this.Add_btn.Location = new System.Drawing.Point(243, 201);
            this.Add_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(151, 46);
            this.Add_btn.TabIndex = 14;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(421, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Assignee ID:";
            // 
            // ProjectID_txt
            // 
            this.ProjectID_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectID_txt.Location = new System.Drawing.Point(519, 43);
            this.ProjectID_txt.Margin = new System.Windows.Forms.Padding(4);
            this.ProjectID_txt.Name = "ProjectID_txt";
            this.ProjectID_txt.Size = new System.Drawing.Size(201, 24);
            this.ProjectID_txt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(430, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Project ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Task description:";
            // 
            // TaskName_txt
            // 
            this.TaskName_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskName_txt.Location = new System.Drawing.Point(167, 92);
            this.TaskName_txt.Margin = new System.Windows.Forms.Padding(4);
            this.TaskName_txt.Name = "TaskName_txt";
            this.TaskName_txt.Size = new System.Drawing.Size(225, 24);
            this.TaskName_txt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Task Name:";
            // 
            // TaskID_txt
            // 
            this.TaskID_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskID_txt.Location = new System.Drawing.Point(167, 43);
            this.TaskID_txt.Margin = new System.Windows.Forms.Padding(4);
            this.TaskID_txt.Name = "TaskID_txt";
            this.TaskID_txt.Size = new System.Drawing.Size(225, 24);
            this.TaskID_txt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Task ID:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Location = new System.Drawing.Point(0, 368);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1119, 278);
            this.panel4.TabIndex = 1;
            // 
            // Task_dtg
            // 
            this.Task_dtg.AllowUserToAddRows = false;
            this.Task_dtg.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Task_dtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Task_dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Task_dtg.EnableHeadersVisualStyles = false;
            this.Task_dtg.Location = new System.Drawing.Point(29, 73);
            this.Task_dtg.Margin = new System.Windows.Forms.Padding(4);
            this.Task_dtg.Name = "Task_dtg";
            this.Task_dtg.ReadOnly = true;
            this.Task_dtg.RowHeadersVisible = false;
            this.Task_dtg.RowHeadersWidth = 51;
            this.Task_dtg.Size = new System.Drawing.Size(1064, 238);
            this.Task_dtg.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task\'s Data";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 368);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 278);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.CP_txt);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.TaskDescription_txt);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.EndDate_dtp);
            this.panel3.Controls.Add(this.StartDate_dtp);
            this.panel3.Controls.Add(this.AssigneeID_txt);
            this.panel3.Controls.Add(this.TaskStatus_cmb);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.Clear_btn);
            this.panel3.Controls.Add(this.Delete_btn);
            this.panel3.Controls.Add(this.Update_btn);
            this.panel3.Controls.Add(this.Add_btn);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.ProjectID_txt);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.TaskName_txt);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TaskID_txt);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(24, 399);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 264);
            this.panel3.TabIndex = 4;
            // 
            // TaskDescription_txt
            // 
            this.TaskDescription_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskDescription_txt.Location = new System.Drawing.Point(167, 140);
            this.TaskDescription_txt.Margin = new System.Windows.Forms.Padding(4);
            this.TaskDescription_txt.Name = "TaskDescription_txt";
            this.TaskDescription_txt.Size = new System.Drawing.Size(225, 24);
            this.TaskDescription_txt.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(785, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "End Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(785, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Start Date:";
            // 
            // EndDate_dtp
            // 
            this.EndDate_dtp.Location = new System.Drawing.Point(901, 94);
            this.EndDate_dtp.Name = "EndDate_dtp";
            this.EndDate_dtp.Size = new System.Drawing.Size(200, 22);
            this.EndDate_dtp.TabIndex = 22;
            // 
            // StartDate_dtp
            // 
            this.StartDate_dtp.Location = new System.Drawing.Point(901, 44);
            this.StartDate_dtp.Name = "StartDate_dtp";
            this.StartDate_dtp.Size = new System.Drawing.Size(200, 22);
            this.StartDate_dtp.TabIndex = 21;
            // 
            // AssigneeID_txt
            // 
            this.AssigneeID_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssigneeID_txt.Location = new System.Drawing.Point(519, 86);
            this.AssigneeID_txt.Margin = new System.Windows.Forms.Padding(4);
            this.AssigneeID_txt.Name = "AssigneeID_txt";
            this.AssigneeID_txt.Size = new System.Drawing.Size(201, 24);
            this.AssigneeID_txt.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Task_dtg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(24, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 343);
            this.panel1.TabIndex = 3;
            // 
            // CP_txt
            // 
            this.CP_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CP_txt.Location = new System.Drawing.Point(927, 137);
            this.CP_txt.Margin = new System.Windows.Forms.Padding(4);
            this.CP_txt.Name = "CP_txt";
            this.CP_txt.Size = new System.Drawing.Size(175, 24);
            this.CP_txt.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(752, 137);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "Completion Percentage:";
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Task";
            this.Size = new System.Drawing.Size(1167, 695);
            ((System.ComponentModel.ISupportInitialize)(this.Task_dtg)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TaskStatus_cmb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ProjectID_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TaskName_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TaskID_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView Task_dtg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox AssigneeID_txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker EndDate_dtp;
        private System.Windows.Forms.DateTimePicker StartDate_dtp;
        private System.Windows.Forms.TextBox TaskDescription_txt;
        private System.Windows.Forms.TextBox CP_txt;
        private System.Windows.Forms.Label label10;
    }
}
