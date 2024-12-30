using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class TaskAssignment : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/xe;User Id=projectman;Password=Phu123;";
        private OracleConnection conn;
        private DataTable taskDataTable;
        private OracleDataAdapter taskAdapter;

        public TaskAssignment()
        {
            InitializeComponent();
            conn = new OracleConnection(connectionString);
            InitializeDataComponents();
            LoadTaskData();

            // Add event handler for cell click
            Task_dtg.CellClick += Task_dtg_CellClick;
        }

        private void InitializeDataComponents()
        {
            string query = "SELECT * FROM TASKASSIGNMENTS ORDER BY ASSIGNMENTID";
            taskAdapter = new OracleDataAdapter(query, conn);
            taskDataTable = new DataTable();

            // Configure the adapter with INSERT, UPDATE, and DELETE commands
            OracleCommandBuilder builder = new OracleCommandBuilder(taskAdapter);
            taskAdapter.InsertCommand = builder.GetInsertCommand();
            taskAdapter.UpdateCommand = builder.GetUpdateCommand();
            taskAdapter.DeleteCommand = builder.GetDeleteCommand();
        }

        private void LoadTaskData()
        {
            try
            {
                taskDataTable.Clear();
                taskAdapter.Fill(taskDataTable);
                Task_dtg.DataSource = taskDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void Task_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Task_dtg.Rows[e.RowIndex];
                AssignmentID_txt.Text = row.Cells["ASSIGNMENTID"].Value.ToString();
                TaskID_txt.Text = row.Cells["TASKID"].Value.ToString();
                EmployeeID_txt.Text = row.Cells["EMPLOYEEID"].Value.ToString();
                AssignedDate_txt.Value = Convert.ToDateTime(row.Cells["ASSIGNEDDATE"].Value);
                Status_txt.Text = row.Cells["STATUS"].Value.ToString();
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(AssignmentID_txt.Text) ||
                string.IsNullOrWhiteSpace(TaskID_txt.Text) ||
                string.IsNullOrWhiteSpace(EmployeeID_txt.Text) ||
                string.IsNullOrWhiteSpace(Status_txt.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    // Validate TaskID exists
                    cmd.CommandText = "SELECT COUNT(*) FROM TASKS WHERE TASKID = :taskid";
                    cmd.Parameters.Add(":taskid", OracleDbType.Varchar2).Value = TaskID_txt.Text;
                    int taskCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (taskCount == 0)
                    {
                        MessageBox.Show("Invalid Task ID!");
                        return false;
                    }

                    // Validate EmployeeID exists
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT COUNT(*) FROM EMPLOYEES WHERE EMPLOYEEID = :empid";
                    cmd.Parameters.Add(":empid", OracleDbType.Varchar2).Value = EmployeeID_txt.Text;
                    int empCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (empCount == 0)
                    {
                        MessageBox.Show("Invalid Employee ID!");
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Validation error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                DataRow newRow = taskDataTable.NewRow();
                newRow["ASSIGNMENTID"] = AssignmentID_txt.Text;
                newRow["TASKID"] = TaskID_txt.Text;
                newRow["EMPLOYEEID"] = EmployeeID_txt.Text;
                newRow["ASSIGNEDDATE"] = AssignedDate_txt.Value;
                newRow["STATUS"] = Status_txt.Text;

                taskDataTable.Rows.Add(newRow);
                taskAdapter.Update(taskDataTable);

                MessageBox.Show("Task assigned successfully!");
                LoadTaskData();
                ClearFields();
            }
            catch (Exception ex)
            {
                taskDataTable.RejectChanges();
                MessageBox.Show("Error adding task: " + ex.Message);
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                DataRow[] rows = taskDataTable.Select($"ASSIGNMENTID = '{AssignmentID_txt.Text}'");
                if (rows.Length > 0)
                {
                    rows[0]["TASKID"] = TaskID_txt.Text;
                    rows[0]["EMPLOYEEID"] = EmployeeID_txt.Text;
                    rows[0]["ASSIGNEDDATE"] = AssignedDate_txt.Value;
                    rows[0]["STATUS"] = Status_txt.Text;

                    taskAdapter.Update(taskDataTable);
                    MessageBox.Show("Task assignment updated successfully!");
                    LoadTaskData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                taskDataTable.RejectChanges();
                MessageBox.Show("Error updating task: " + ex.Message);
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AssignmentID_txt.Text))
            {
                MessageBox.Show("Please select a task assignment to delete.");
                return;
            }

            try
            {
                if (MessageBox.Show("Are you sure you want to delete this task assignment?",
                    "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataRow[] rows = taskDataTable.Select($"ASSIGNMENTID = '{AssignmentID_txt.Text}'");
                    if (rows.Length > 0)
                    {
                        rows[0].Delete();
                        taskAdapter.Update(taskDataTable);
                        MessageBox.Show("Task assignment deleted successfully!");
                        LoadTaskData();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                taskDataTable.RejectChanges();
                MessageBox.Show("Error deleting task: " + ex.Message);
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
            Status_txt.SelectedIndex = -1;
        }

        private void TaskAssignment_Load(object sender, EventArgs e)
        {
            LoadTaskData();

        }
    }
}

