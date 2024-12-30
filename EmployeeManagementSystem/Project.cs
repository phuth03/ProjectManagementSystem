using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Project : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        private OracleConnection conn;
        private OracleDataAdapter adapter;
        private DataTable projectTable;

        public Project()
        {
            InitializeComponent();
            conn = new OracleConnection(connectionString);
            InitializeDataComponents();
            LoadProjectData();

            // Add event handlers
            Add_btn.Click += Add_btn_Click;
            Update_btn.Click += Update_btn_Click;
            Delete_btn.Click += Delete_btn_Click;
            Clear_btn.Click += Clear_btn_Click;
            Project_dtg.CellClick += Project_dtg_CellClick;
        }

        private void InitializeDataComponents()
        {
            try
            {
                string sql = "SELECT * FROM Projects ORDER BY ProjectID";
                adapter = new OracleDataAdapter(sql, conn);

                // Add insert command
                adapter.InsertCommand = new OracleCommand(
                    @"INSERT INTO Projects (ProjectID, ProjectName, ProjectManagerID, Status, StartDate, EndDate) 
                      VALUES (:projectId, :projectName, :managerId, :status, :startDate, :endDate)", conn);

                adapter.InsertCommand.Parameters.Add(":projectId", OracleDbType.Varchar2, 20, "ProjectID");
                adapter.InsertCommand.Parameters.Add(":projectName", OracleDbType.Varchar2, 100, "ProjectName");
                adapter.InsertCommand.Parameters.Add(":managerId", OracleDbType.Varchar2, 20, "ProjectManagerID");
                adapter.InsertCommand.Parameters.Add(":status", OracleDbType.Varchar2, 20, "Status");
                adapter.InsertCommand.Parameters.Add(":startDate", OracleDbType.Date, 0, "StartDate");
                adapter.InsertCommand.Parameters.Add(":endDate", OracleDbType.Date, 0, "EndDate");

                // Add update command
                adapter.UpdateCommand = new OracleCommand(
                    @"UPDATE Projects SET 
                      ProjectName = :projectName, 
                      ProjectManagerID = :managerId, 
                      Status = :status, 
                      StartDate = :startDate, 
                      EndDate = :endDate 
                      WHERE ProjectID = :projectId", conn);

                adapter.UpdateCommand.Parameters.Add(":projectName", OracleDbType.Varchar2, 100, "ProjectName");
                adapter.UpdateCommand.Parameters.Add(":managerId", OracleDbType.Varchar2, 20, "ProjectManagerID");
                adapter.UpdateCommand.Parameters.Add(":status", OracleDbType.Varchar2, 20, "Status");
                adapter.UpdateCommand.Parameters.Add(":startDate", OracleDbType.Date, 0, "StartDate");
                adapter.UpdateCommand.Parameters.Add(":endDate", OracleDbType.Date, 0, "EndDate");
                adapter.UpdateCommand.Parameters.Add(":projectId", OracleDbType.Varchar2, 20, "ProjectID");

                // Add delete command
                adapter.DeleteCommand = new OracleCommand(
                    "DELETE FROM Projects WHERE ProjectID = :projectId", conn);
                adapter.DeleteCommand.Parameters.Add(":projectId", OracleDbType.Varchar2, 20, "ProjectID");

                projectTable = new DataTable();
                adapter.Fill(projectTable);
                Project_dtg.DataSource = projectTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing data components: " + ex.Message);
            }
        }

        private void LoadProjectData()
        {
            try
            {
                projectTable.Clear();
                adapter.Fill(projectTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading project data: " + ex.Message);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    DataRow newRow = projectTable.NewRow();
                    newRow["ProjectID"] = ProjectID_txt.Text;
                    newRow["ProjectName"] = ProjectName_txt.Text;
                    newRow["ProjectManagerID"] = ProjectManagerID_txt.Text;
                    newRow["Status"] = Status_cmb.SelectedItem.ToString();
                    newRow["StartDate"] = StartDate_dtp.Value;
                    newRow["EndDate"] = EndDate_dtp.Value;

                    projectTable.Rows.Add(newRow);
                    adapter.Update(projectTable);

                    MessageBox.Show("Project added successfully!");
                    ClearFields();
                    LoadProjectData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding project: " + ex.Message);
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    DataRow[] rows = projectTable.Select($"ProjectID = '{ProjectID_txt.Text}'");
                    if (rows.Length > 0)
                    {
                        DataRow row = rows[0];
                        row["ProjectName"] = ProjectName_txt.Text;
                        row["ProjectManagerID"] = ProjectManagerID_txt.Text;
                        row["Status"] = Status_cmb.SelectedItem.ToString();
                        row["StartDate"] = StartDate_dtp.Value;
                        row["EndDate"] = EndDate_dtp.Value;

                        adapter.Update(projectTable);

                        MessageBox.Show("Project updated successfully!");
                        ClearFields();
                        LoadProjectData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating project: " + ex.Message);
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProjectID_txt.Text))
                {
                    MessageBox.Show("Please select a project to delete.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataRow[] rows = projectTable.Select($"ProjectID = '{ProjectID_txt.Text}'");
                    if (rows.Length > 0)
                    {
                        rows[0].Delete();
                        adapter.Update(projectTable);

                        MessageBox.Show("Project deleted successfully!");
                        ClearFields();
                        LoadProjectData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting project: " + ex.Message);
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Project_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Project_dtg.Rows[e.RowIndex];
                ProjectID_txt.Text = row.Cells["ProjectID"].Value.ToString();
                ProjectName_txt.Text = row.Cells["ProjectName"].Value.ToString();
                ProjectManagerID_txt.Text = row.Cells["ProjectManagerID"].Value.ToString();
                Status_cmb.SelectedItem = row.Cells["Status"].Value.ToString();
                StartDate_dtp.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);
                EndDate_dtp.Value = Convert.ToDateTime(row.Cells["EndDate"].Value);
            }
        }

        private void ClearFields()
        {
            ProjectID_txt.Clear();
            ProjectName_txt.Clear();
            ProjectManagerID_txt.Clear();
            Status_cmb.SelectedIndex = -1;
            StartDate_dtp.Value = DateTime.Now;
            EndDate_dtp.Value = DateTime.Now;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(ProjectID_txt.Text) ||
                string.IsNullOrWhiteSpace(ProjectName_txt.Text) ||
                string.IsNullOrWhiteSpace(ProjectManagerID_txt.Text) ||
                Status_cmb.SelectedIndex == -1)
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