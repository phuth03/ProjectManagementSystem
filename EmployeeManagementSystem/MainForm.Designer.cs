
namespace EmployeeManagementSystem
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.greet_user = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.taskAssignment1 = new EmployeeManagementSystem.TaskAssignment();
            this.project2 = new EmployeeManagementSystem.Project();
            this.account2 = new EmployeeManagementSystem.Account();
            this.task1 = new EmployeeManagementSystem.Task();
            this.addEmployee1 = new EmployeeManagementSystem.AddEmployee();
            this.gantt1 = new EmployeeManagementSystem.Gantt();
            this.logout_btn = new System.Windows.Forms.Button();
            this.pro_btn = new System.Windows.Forms.Button();
            this.Gantt_btn = new System.Windows.Forms.Button();
            this.account_btn = new System.Windows.Forms.Button();
            this.taskassignment_btn = new System.Windows.Forms.Button();
            this.Task_btn = new System.Windows.Forms.Button();
            this.addEmployee_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 43);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Management System";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(1439, 10);
            this.exit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(20, 21);
            this.exit.TabIndex = 0;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.pro_btn);
            this.panel2.Controls.Add(this.Gantt_btn);
            this.panel2.Controls.Add(this.account_btn);
            this.panel2.Controls.Add(this.taskassignment_btn);
            this.panel2.Controls.Add(this.Task_btn);
            this.panel2.Controls.Add(this.addEmployee_btn);
            this.panel2.Controls.Add(this.greet_user);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 695);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(71, 649);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sign Out";
            // 
            // greet_user
            // 
            this.greet_user.AutoSize = true;
            this.greet_user.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greet_user.ForeColor = System.Drawing.Color.White;
            this.greet_user.Location = new System.Drawing.Point(65, 146);
            this.greet_user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.greet_user.Name = "greet_user";
            this.greet_user.Size = new System.Drawing.Size(144, 24);
            this.greet_user.TabIndex = 1;
            this.greet_user.Text = "Welcome, User";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.taskAssignment1);
            this.panel3.Controls.Add(this.project2);
            this.panel3.Controls.Add(this.account2);
            this.panel3.Controls.Add(this.task1);
            this.panel3.Controls.Add(this.addEmployee1);
            this.panel3.Controls.Add(this.gantt1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(300, 43);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1167, 695);
            this.panel3.TabIndex = 2;
            // 
            // taskAssignment1
            // 
            this.taskAssignment1.Location = new System.Drawing.Point(-3, 0);
            this.taskAssignment1.Name = "taskAssignment1";
            this.taskAssignment1.Size = new System.Drawing.Size(1167, 695);
            this.taskAssignment1.TabIndex = 7;
            // 
            // project2
            // 
            this.project2.Location = new System.Drawing.Point(0, 0);
            this.project2.Name = "project2";
            this.project2.Size = new System.Drawing.Size(1167, 695);
            this.project2.TabIndex = 5;
            // 
            // account2
            // 
            this.account2.Location = new System.Drawing.Point(0, 0);
            this.account2.Name = "account2";
            this.account2.Size = new System.Drawing.Size(1167, 695);
            this.account2.TabIndex = 4;
            // 
            // task1
            // 
            this.task1.Location = new System.Drawing.Point(0, -4);
            this.task1.Margin = new System.Windows.Forms.Padding(4);
            this.task1.Name = "task1";
            this.task1.Size = new System.Drawing.Size(1167, 695);
            this.task1.TabIndex = 3;
            // 
            // addEmployee1
            // 
            this.addEmployee1.Location = new System.Drawing.Point(0, 0);
            this.addEmployee1.Margin = new System.Windows.Forms.Padding(5);
            this.addEmployee1.Name = "addEmployee1";
            this.addEmployee1.Size = new System.Drawing.Size(1167, 695);
            this.addEmployee1.TabIndex = 1;
            // 
            // gantt1
            // 
            this.gantt1.Location = new System.Drawing.Point(0, 0);
            this.gantt1.Name = "gantt1";
            this.gantt1.Size = new System.Drawing.Size(1167, 695);
            this.gantt1.TabIndex = 6;
            // 
            // logout_btn
            // 
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatAppearance.BorderSize = 0;
            this.logout_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_logout_rounded_up_filled_25px;
            this.logout_btn.Location = new System.Drawing.Point(15, 636);
            this.logout_btn.Margin = new System.Windows.Forms.Padding(4);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(47, 43);
            this.logout_btn.TabIndex = 5;
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // pro_btn
            // 
            this.pro_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.pro_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pro_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.pro_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.pro_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.pro_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pro_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pro_btn.ForeColor = System.Drawing.Color.White;
            this.pro_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_project_30;
            this.pro_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pro_btn.Location = new System.Drawing.Point(14, 266);
            this.pro_btn.Margin = new System.Windows.Forms.Padding(4);
            this.pro_btn.Name = "pro_btn";
            this.pro_btn.Size = new System.Drawing.Size(267, 49);
            this.pro_btn.TabIndex = 4;
            this.pro_btn.Text = "Project";
            this.pro_btn.UseVisualStyleBackColor = false;
            this.pro_btn.Click += new System.EventHandler(this.pro_btn_Click);
            // 
            // Gantt_btn
            // 
            this.Gantt_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Gantt_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Gantt_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Gantt_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Gantt_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Gantt_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gantt_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gantt_btn.ForeColor = System.Drawing.Color.White;
            this.Gantt_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_gantt_chart_32;
            this.Gantt_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gantt_btn.Location = new System.Drawing.Point(15, 569);
            this.Gantt_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Gantt_btn.Name = "Gantt_btn";
            this.Gantt_btn.Size = new System.Drawing.Size(267, 49);
            this.Gantt_btn.TabIndex = 4;
            this.Gantt_btn.Text = "Gantt Chart";
            this.Gantt_btn.UseVisualStyleBackColor = false;
            this.Gantt_btn.Click += new System.EventHandler(this.gantt_btn_Click);
            // 
            // account_btn
            // 
            this.account_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.account_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.account_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.account_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.account_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.account_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.account_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_btn.ForeColor = System.Drawing.Color.White;
            this.account_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_account_30;
            this.account_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.account_btn.Location = new System.Drawing.Point(15, 499);
            this.account_btn.Margin = new System.Windows.Forms.Padding(4);
            this.account_btn.Name = "account_btn";
            this.account_btn.Size = new System.Drawing.Size(267, 49);
            this.account_btn.TabIndex = 4;
            this.account_btn.Text = "Account";
            this.account_btn.UseVisualStyleBackColor = false;
            this.account_btn.Click += new System.EventHandler(this.account_btn_Click);
            // 
            // taskassignment_btn
            // 
            this.taskassignment_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.taskassignment_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskassignment_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.taskassignment_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.taskassignment_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.taskassignment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskassignment_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskassignment_btn.ForeColor = System.Drawing.Color.White;
            this.taskassignment_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_task_30;
            this.taskassignment_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.taskassignment_btn.Location = new System.Drawing.Point(14, 420);
            this.taskassignment_btn.Margin = new System.Windows.Forms.Padding(4);
            this.taskassignment_btn.Name = "taskassignment_btn";
            this.taskassignment_btn.Size = new System.Drawing.Size(267, 49);
            this.taskassignment_btn.TabIndex = 4;
            this.taskassignment_btn.Text = "Task Assingment";
            this.taskassignment_btn.UseVisualStyleBackColor = false;
            this.taskassignment_btn.Click += new System.EventHandler(this.taskassignment_btn_Click);
            // 
            // Task_btn
            // 
            this.Task_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Task_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Task_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Task_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Task_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Task_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Task_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Task_btn.ForeColor = System.Drawing.Color.White;
            this.Task_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_task_30;
            this.Task_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Task_btn.Location = new System.Drawing.Point(14, 342);
            this.Task_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Task_btn.Name = "Task_btn";
            this.Task_btn.Size = new System.Drawing.Size(267, 49);
            this.Task_btn.TabIndex = 4;
            this.Task_btn.Text = "Task";
            this.Task_btn.UseVisualStyleBackColor = false;
            this.Task_btn.Click += new System.EventHandler(this.Task_btn_Click);
            // 
            // addEmployee_btn
            // 
            this.addEmployee_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addEmployee_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addEmployee_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addEmployee_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addEmployee_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addEmployee_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEmployee_btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmployee_btn.ForeColor = System.Drawing.Color.White;
            this.addEmployee_btn.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_employee_card_30px;
            this.addEmployee_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addEmployee_btn.Location = new System.Drawing.Point(14, 189);
            this.addEmployee_btn.Margin = new System.Windows.Forms.Padding(4);
            this.addEmployee_btn.Name = "addEmployee_btn";
            this.addEmployee_btn.Size = new System.Drawing.Size(267, 49);
            this.addEmployee_btn.TabIndex = 3;
            this.addEmployee_btn.Text = "ADD EMPLOYEE";
            this.addEmployee_btn.UseVisualStyleBackColor = false;
            this.addEmployee_btn.Click += new System.EventHandler(this.addEmployee_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_employee_card_100px;
            this.pictureBox1.Location = new System.Drawing.Point(75, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 123);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 738);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label greet_user;
        private System.Windows.Forms.Button Task_btn;
        private System.Windows.Forms.Button addEmployee_btn;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private Task salary1;
        private AddEmployee addEmployee1;
        private Project project1;
        private Account account1;   
        private System.Windows.Forms.Button pro_btn;
        private System.Windows.Forms.Button taskassignment_btn;
        private System.Windows.Forms.Button account_btn;
        private Project project2;
        private Account account2;
        private Task task1;
        private System.Windows.Forms.Button Gantt_btn;
        private Gantt gantt1;
        private TaskAssignment taskAssignment1;
    }
}