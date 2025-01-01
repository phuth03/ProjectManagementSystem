using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EmployeeManagementSystem
{
    public partial class TaskAssignment : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";

        public TaskAssignment()
        {
            InitializeComponent();
        }

        private void TaskAssignment_Load(object sender, EventArgs e)
        {
            LoadTaskAssignments();
            Status_txt.SelectedIndex = 0; // Set default status to "Pending"
            AssignmentID_txt.Enabled = false;   
        }

        private void LoadTaskAssignments()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(
                        "SELECT a.ASSIGNMENTID, a.TASKID, a.EMPLOYEEID, " +
                        "TO_CHAR(a.ASSIGNEDDATE, 'MM/DD/YYYY') as ASSIGNEDDATE, a.STATUS " +
                        "FROM TASKASSIGNMENTS a ORDER BY a.ASSIGNMENTID", conn))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Task_dtg.DataSource = dt;
                        Task_dtg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task assignments: " + ex.Message);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_INSERT_TASKASSIGNMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Get next sequence value
                        OracleCommand seqCmd = new OracleCommand(
                            "SELECT SEQ_TASKASSIGNMENTID.NEXTVAL FROM DUAL", conn);
                        int assignmentId = Convert.ToInt32(seqCmd.ExecuteScalar());

                        // Set parameters
                        cmd.Parameters.Add("p_ASSIGNMENTID", OracleDbType.Int32).Value = assignmentId;
                        cmd.Parameters.Add("p_TASKID", OracleDbType.Int32).Value =
                            Convert.ToInt32(TaskID_txt.Text);
                        cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value =
                            Convert.ToInt32(EmployeeID_txt.Text);
                        cmd.Parameters.Add("p_ASSIGNEDDATE", OracleDbType.Date).Value =
                            AssignedDate_txt.Value;
                        cmd.Parameters.Add("p_STATUS", OracleDbType.Varchar2).Value =
                            Status_txt;
                        cmd.Parameters.Add("p_RESULT", OracleDbType.Varchar2, 200).Direction =
                            ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        string result = cmd.Parameters["p_RESULT"].Value.ToString();
                        if (result == "SUCCESS")
                        {
                            MessageBox.Show("Task assignment added successfully!");
                            LoadTaskAssignments();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Error: " + result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task assignment: " + ex.Message);
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_UPDATE_TASKASSIGNMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_ASSIGNMENTID", OracleDbType.Int32).Value =
                            Convert.ToInt32(AssignmentID_txt.Text);
                        cmd.Parameters.Add("p_TASKID", OracleDbType.Int32).Value =
                            Convert.ToInt32(TaskID_txt.Text);
                        cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value =
                            Convert.ToInt32(EmployeeID_txt.Text);
                        cmd.Parameters.Add("p_ASSIGNEDDATE", OracleDbType.Date).Value =
                            AssignedDate_txt.Value;  
                        cmd.Parameters.Add("p_STATUS", OracleDbType.Varchar2).Value =
                            Status_txt.SelectedItem.ToString();

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task assignment updated successfully!");
                        LoadTaskAssignments();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task assignment: " + ex.Message);
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this task assignment?",
                "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        conn.Open();
                        using (OracleCommand cmd = new OracleCommand("PROC_DELETE_TASKASSIGNMENT", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("p_ASSIGNMENTID", OracleDbType.Int32).Value =
                                Convert.ToInt32(AssignmentID_txt.Text);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Task assignment deleted successfully!");
                            LoadTaskAssignments();
                            ClearFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting task assignment: " + ex.Message);
                }
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            AssignmentID_txt.Clear();
            TaskID_txt.Clear();
            EmployeeID_txt.Clear();
            AssignedDate_txt.Value = DateTime.Now;
            Status_txt.SelectedIndex = 0;
        }

        private void Task_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Task_dtg.Rows[e.RowIndex];
                AssignmentID_txt.Text = row.Cells["ASSIGNMENTID"].Value.ToString();
                TaskID_txt.Text = row.Cells["TASKID"].Value.ToString();
                EmployeeID_txt.Text = row.Cells["EMPLOYEEID"].Value.ToString();
                AssignedDate_txt.Value = DateTime.Parse(row.Cells["ASSIGNEDDATE"].Value.ToString());
                Status_txt.Text = row.Cells["STATUS"].Value.ToString();
            }
        }
    }
}
