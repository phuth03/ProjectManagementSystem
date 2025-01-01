using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Task : UserControl
    {
        private readonly string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";

        public Task()
        {
            InitializeComponent();
            LoadData();

            // Wire up event handlers
            Add_btn.Click += Add_btn_Click;
            Update_btn.Click += Update_btn_Click;
            Delete_btn.Click += Delete_btn_Click;
            Clear_btn.Click += Clear_btn_Click;
            Task_dtg.CellClick += Task_dtg_CellClick;
        }

        private void LoadData()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT * FROM TASKS ORDER BY TASKID", conn))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Task_dtg.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TaskName_txt.Text) ||
                    string.IsNullOrWhiteSpace(ProjectID_txt.Text))
                {
                    MessageBox.Show("Please fill in all required fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_INSERT_TASK", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameters
                        cmd.Parameters.Add("p_TASKID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                        // Input parameters
                        cmd.Parameters.Add("p_TASKNAME", OracleDbType.Varchar2).Value = TaskName_txt.Text;
                        cmd.Parameters.Add("p_TASKDESCRIPTION", OracleDbType.Varchar2).Value =
                            string.IsNullOrWhiteSpace(TaskDescription_txt.Text) ? DBNull.Value : (object)TaskDescription_txt.Text;
                        cmd.Parameters.Add("p_PROJECTID", OracleDbType.Int32).Value = Convert.ToInt32(ProjectID_txt.Text);
                        cmd.Parameters.Add("p_ASSIGNEEID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("p_STATUS", OracleDbType.Varchar2).Value =
                            string.IsNullOrWhiteSpace(TaskStatus_cmb.Text) ? "Not Started" : TaskStatus_cmb.Text;
                        cmd.Parameters.Add("p_STARTDATE", OracleDbType.Date).Value = StartDate_dtp.Value;
                        cmd.Parameters.Add("p_ENDDATE", OracleDbType.Date).Value = EndDate_dtp.Value;
                        cmd.Parameters.Add("p_COMPLETIONPERCENTAGE", OracleDbType.Int32).Value =
                            string.IsNullOrWhiteSpace(CP_txt.Text) ? 0 : Convert.ToInt32(CP_txt.Text);

                        try
                        {
                            cmd.ExecuteNonQuery();

                            // Convert OracleDecimal to Int32 for OUT parameters
                            int newTaskId = ((Oracle.ManagedDataAccess.Types.OracleDecimal)cmd.Parameters["p_TASKID"].Value).ToInt32();
                            int newAssignmentId = ((Oracle.ManagedDataAccess.Types.OracleDecimal)cmd.Parameters["p_ASSIGNEEID"].Value).ToInt32();

                            MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadData();
                        }
                        catch (OracleException ex)
                        {
                            if (ex.Number == 20001) // Our custom error from the trigger
                            {
                                MessageBox.Show("This employee already has 3 tasks assigned. Cannot assign more tasks.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                throw; // Re-throw other Oracle exceptions
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Project ID, Assignee ID and Completion Percentage",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskID_txt.Text))
            {
                MessageBox.Show("Please select a task to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_UPDATE_TASK", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_TASKID", OracleDbType.Int32).Value = Convert.ToInt32(TaskID_txt.Text);
                        cmd.Parameters.Add("p_TASKNAME", OracleDbType.Varchar2).Value = TaskName_txt.Text;
                        cmd.Parameters.Add("p_TASKDESCRIPTION", OracleDbType.Varchar2).Value = TaskDescription_txt.Text;
                        cmd.Parameters.Add("p_PROJECTID", OracleDbType.Int32).Value = Convert.ToInt32(ProjectID_txt.Text);
                        cmd.Parameters.Add("p_ASSIGNEEID", OracleDbType.Int32).Value = Convert.ToInt32(AssigneeID_txt.Text);
                        cmd.Parameters.Add("p_STATUS", OracleDbType.Varchar2).Value = TaskStatus_cmb.Text;
                        cmd.Parameters.Add("p_STARTDATE", OracleDbType.Date).Value = StartDate_dtp.Value;
                        cmd.Parameters.Add("p_ENDDATE", OracleDbType.Date).Value = EndDate_dtp.Value;
                        cmd.Parameters.Add("p_COMPLETIONPERCENTAGE", OracleDbType.Int32).Value = Convert.ToInt32(CP_txt.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskID_txt.Text))
            {
                MessageBox.Show("Please select a task to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        conn.Open();
                        using (OracleCommand cmd = new OracleCommand("PROC_DELETE_TASK", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("p_TASKID", OracleDbType.Int32).Value = Convert.ToInt32(TaskID_txt.Text);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Task_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Task_dtg.Rows[e.RowIndex];

                TaskID_txt.Text = row.Cells["TASKID"].Value.ToString();
                TaskName_txt.Text = row.Cells["TASKNAME"].Value.ToString();
                TaskDescription_txt.Text = row.Cells["TASKDESCRIPTION"].Value.ToString();
                ProjectID_txt.Text = row.Cells["PROJECTID"].Value.ToString();
                AssigneeID_txt.Text = row.Cells["ASSIGNEEID"].Value.ToString();
                TaskStatus_cmb.Text = row.Cells["STATUS"].Value.ToString();
                StartDate_dtp.Value = Convert.ToDateTime(row.Cells["STARTDATE"].Value);
                EndDate_dtp.Value = Convert.ToDateTime(row.Cells["ENDDATE"].Value);
                CP_txt.Text = row.Cells["COMPLETIONPERCENTAGE"].Value.ToString();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            TaskID_txt.Clear();
            TaskName_txt.Clear();
            TaskDescription_txt.Clear();
            ProjectID_txt.Clear();
            AssigneeID_txt.Clear();
            TaskStatus_cmb.SelectedIndex = -1;
            StartDate_dtp.Value = DateTime.Now;
            EndDate_dtp.Value = DateTime.Now;
            CP_txt.Clear();
        }

        private void Task_Load(object sender, EventArgs e)
        {
            TaskID_txt.Enabled = false;
            AssigneeID_txt.Enabled= false;
        }
    }
}