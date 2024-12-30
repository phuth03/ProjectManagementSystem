using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Task : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        private OracleConnection conn;
        private OracleDataAdapter adapter;
        private DataTable taskTable;

        public Task()
        {
            InitializeComponent();
            conn = new OracleConnection(connectionString);
            InitializeDataComponents();
            LoadTaskData();

            // Add event handlers
            Add_btn.Click += Add_btn_Click;
            Update_btn.Click += Update_btn_Click;
            Delete_btn.Click += Delete_btn_Click;
            Clear_btn.Click += Clear_btn_Click;
            Task_dtg.CellClick += Task_dtg_CellClick;
        }

        private void InitializeDataComponents()
        {
            try
            {
                string sql = "SELECT * FROM Tasks ORDER BY TaskID";
                adapter = new OracleDataAdapter(sql, conn);

                // Add insert command
                adapter.InsertCommand = new OracleCommand(
                    @"INSERT INTO Tasks (TaskID, TaskName, TaskDescription, ProjectID, AssigneeID, Status, 
                       StartDate, EndDate, CompletionPercentage) 
                      VALUES (:taskId, :taskName, :taskDescription, :projectId, :assigneeID, :status, 
                       :startDate, :endDate, :completionPercentage)", conn);

                adapter.InsertCommand.Parameters.Add(":taskId", OracleDbType.Varchar2, 20, "TaskID");
                adapter.InsertCommand.Parameters.Add(":taskName", OracleDbType.Varchar2, 100, "TaskName");
                adapter.InsertCommand.Parameters.Add(":taskDescription", OracleDbType.Varchar2, 500, "TaskDescription");
                adapter.InsertCommand.Parameters.Add(":projectId", OracleDbType.Varchar2, 20, "ProjectID");
                adapter.InsertCommand.Parameters.Add(":assigneeID", OracleDbType.Varchar2, 20, "AssigneeID");
                adapter.InsertCommand.Parameters.Add(":Status", OracleDbType.Varchar2, 20, "Status");
                adapter.InsertCommand.Parameters.Add(":startDate", OracleDbType.Date, 0, "StartDate");
                adapter.InsertCommand.Parameters.Add(":endDate", OracleDbType.Date, 0, "EndDate");
                adapter.InsertCommand.Parameters.Add(":completionPercentage", OracleDbType.Varchar2, 20, "CompletionPercentage");


                // Add update command
                adapter.UpdateCommand = new OracleCommand(
                    @"UPDATE Tasks SET 
                      TaskName = :taskName,
                      TaskDescription = :taskDescription,
                      ProjectID = :projectId,
                      AssigneeID = :assigneeID,
                      Status = :status,
                      StartDate = :startDate,
                      EndDate = :endDate,
                      CompletionPercentage = :completionPercentage
                      WHERE TaskID = :taskId", conn);

                adapter.UpdateCommand.Parameters.Add(":taskName", OracleDbType.Varchar2, 100, "TaskName");
                adapter.UpdateCommand.Parameters.Add(":taskDescription", OracleDbType.Varchar2, 500, "TaskDescription");
                adapter.UpdateCommand.Parameters.Add(":projectId", OracleDbType.Varchar2, 20, "ProjectID");
                adapter.UpdateCommand.Parameters.Add(":assigneeID", OracleDbType.Varchar2, 20, "AssigneeID");
                adapter.UpdateCommand.Parameters.Add(":status", OracleDbType.Varchar2, 20, "Status");
                adapter.UpdateCommand.Parameters.Add(":startDate", OracleDbType.Date, 0, "StartDate");
                adapter.UpdateCommand.Parameters.Add(":endDate", OracleDbType.Date, 0, "EndDate");
                adapter.UpdateCommand.Parameters.Add(":taskId", OracleDbType.Varchar2, 20, "TaskID");
                adapter.UpdateCommand.Parameters.Add(":completionPercentage", OracleDbType.Varchar2, 20, "CompletionPercentage");


                // Add delete command
                adapter.DeleteCommand = new OracleCommand(
                    "DELETE FROM Tasks WHERE TaskID = :taskId", conn);
                adapter.DeleteCommand.Parameters.Add(":taskId", OracleDbType.Varchar2, 20, "TaskID");

                taskTable = new DataTable();
                adapter.Fill(taskTable);
                Task_dtg.DataSource = taskTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing data components: " + ex.Message);
            }
        }

        private void LoadTaskData()
        {
            try
            {
                taskTable.Clear();
                adapter.Fill(taskTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading task data: " + ex.Message);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    conn.Open(); // Open the connection
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Add Task
                            DataRow newRow = taskTable.NewRow();
                            newRow["TaskID"] = TaskID_txt.Text;
                            newRow["TaskName"] = TaskName_txt.Text;
                            newRow["TaskDescription"] = TaskDescription_txt.Text;
                            newRow["ProjectID"] = ProjectID_txt.Text;
                            newRow["AssigneeID"] = AssigneeID_txt.Text;
                            newRow["Status"] = TaskStatus_cmb.SelectedItem.ToString();
                            newRow["StartDate"] = StartDate_dtp.Value;
                            newRow["EndDate"] = EndDate_dtp.Value;
                            newRow["CompletionPercentage"] = CP_txt.Text;


                            taskTable.Rows.Add(newRow);
                            adapter.Update(taskTable);

                            // 2. Add TaskAssignment
                            using (OracleCommand cmd = new OracleCommand(@"
                        INSERT INTO TaskAssignments (
                            TaskID,
                            AssignmentID
                        ) VALUES (
                            :taskID,
                            :assignmentID
                        )", conn))
                            {
                                cmd.Parameters.Add(":taskID", OracleDbType.Varchar2).Value = TaskID_txt.Text;
                                cmd.Parameters.Add(":assignmentID", OracleDbType.Varchar2).Value = AssigneeID_txt.Text;

                                cmd.Transaction = transaction;
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Task added and assigned successfully!");
                            ClearFields();
                            LoadTaskData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error in transaction: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close(); // Ensure the connection is closed
            }
        }


        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    conn.Open();
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Update the task in the Tasks table
                            DataRow[] rows = taskTable.Select($"TaskID = '{TaskID_txt.Text}'");
                            if (rows.Length > 0)
                            {
                                DataRow row = rows[0];
                                row["TaskID"] = TaskID_txt.Text;
                                row["TaskName"] = TaskName_txt.Text;
                                row["TaskDescription"] = TaskDescription_txt.Text;
                                row["ProjectID"] = ProjectID_txt.Text;
                                row["AssigneeID"] = AssigneeID_txt.Text;
                                row["Status"] = TaskStatus_cmb.SelectedItem.ToString();
                                row["StartDate"] = StartDate_dtp.Value;
                                row["EndDate"] = EndDate_dtp.Value;
                                row["CompletionPercentage"] = CP_txt.Text;


                                adapter.Update(taskTable);
                            }

                            // 2. Update the TaskAssignments table
                            using (OracleCommand updateAssignmentCmd = new OracleCommand(
                                "UPDATE TaskAssignments SET AssignmentID = :assignmentID WHERE TaskID = :taskId", conn))
                            {
                                updateAssignmentCmd.Parameters.Add(":assignmentID", OracleDbType.Varchar2).Value = AssigneeID_txt.Text;
                                updateAssignmentCmd.Parameters.Add(":taskId", OracleDbType.Varchar2).Value = TaskID_txt.Text;

                                updateAssignmentCmd.Transaction = transaction;
                                updateAssignmentCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Task and its assignment updated successfully!");
                            ClearFields();
                            LoadTaskData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error in transaction: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close(); // Ensure the connection is closed
            }
        }


        private void Delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TaskID_txt.Text))
                {
                    MessageBox.Show("Please select a task to delete.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Delete from TaskAssignments table
                            using (OracleCommand deleteAssignmentCmd = new OracleCommand(
                                "DELETE FROM TaskAssignments WHERE TaskID = :taskId", conn))
                            {
                                deleteAssignmentCmd.Parameters.Add(":taskId", OracleDbType.Varchar2).Value = TaskID_txt.Text;
                                deleteAssignmentCmd.Transaction = transaction;
                                deleteAssignmentCmd.ExecuteNonQuery();
                            }

                            // 2. Delete from Tasks table
                            DataRow[] rows = taskTable.Select($"TaskID = '{TaskID_txt.Text}'");
                            if (rows.Length > 0)
                            {
                                rows[0].Delete();
                                adapter.Update(taskTable);
                            }

                            transaction.Commit();
                            MessageBox.Show("Task and its assignments deleted successfully!");
                            ClearFields();
                            LoadTaskData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error in transaction: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting task: " + ex.Message);
            }
        }


        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Task_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Task_dtg.Rows[e.RowIndex];
                TaskID_txt.Text = row.Cells["TaskID"].Value.ToString();
                TaskName_txt.Text = row.Cells["TaskName"].Value.ToString();
                TaskDescription_txt.Text = row.Cells["TaskDescription"].Value.ToString();
                ProjectID_txt.Text = row.Cells["ProjectID"].Value.ToString();
                AssigneeID_txt.Text = row.Cells["AssigneeID"].Value.ToString();
                TaskStatus_cmb.SelectedItem = row.Cells["Status"].Value.ToString();
                StartDate_dtp.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);
                EndDate_dtp.Value = Convert.ToDateTime(row.Cells["EndDate"].Value);
                CP_txt.Text = row.Cells["CompletionPercentage"].Value.ToString();

            }
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TaskID_txt.Text) ||
                string.IsNullOrWhiteSpace(TaskName_txt.Text) ||
                string.IsNullOrWhiteSpace(ProjectID_txt.Text) ||
                string.IsNullOrWhiteSpace(AssigneeID_txt.Text) ||
                TaskStatus_cmb.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            if (EndDate_dtp.Value < StartDate_dtp.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.");
                return false;
            }

            return true;
        }
    }
}
