using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Project : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        OracleConnection conn;

        public Project()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadProjects();

            // Add event handlers
            Add_btn.Click += Add_btn_Click;
            Update_btn.Click += Update_btn_Click;
            Delete_btn.Click += Delete_btn_Click;
            Clear_btn.Click += Clear_btn_Click;
            Project_dtg.CellClick += Project_dtg_CellClick;
        }

        private void InitializeDatabase()
        {
            
            conn = new OracleConnection(connectionString);
        }

        private void LoadProjects()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("SELECT * FROM PROJECTS ORDER BY PROJECTID", conn))
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    Project_dtg.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("PROC_INSERT_PROJECT", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Output parameter
                    OracleParameter projectIdParam = new OracleParameter("p_PROJECTID", OracleDbType.Int32);
                    projectIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(projectIdParam);

                    // Input parameters
                    cmd.Parameters.Add("p_PROJECTNAME", OracleDbType.Varchar2).Value = ProjectName_txt.Text;
                    cmd.Parameters.Add("p_STARTDATE", OracleDbType.Date).Value = StartDate_dtp.Value;
                    cmd.Parameters.Add("p_ENDDATE", OracleDbType.Date).Value = EndDate_dtp.Value;
                    cmd.Parameters.Add("p_STATUS", OracleDbType.Varchar2).Value = Status_cmb.SelectedItem.ToString();
                    cmd.Parameters.Add("p_PROJECTMANAGERID", OracleDbType.Int32).Value =
                        Convert.ToInt32(ProjectManagerID_txt.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Project added successfully!");
                    LoadProjects();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding project: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (OracleCommand cmd = new OracleCommand("PROC_UPDATE_PROJECT", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_PROJECTID", OracleDbType.Int32).Value =
                        Convert.ToInt32(ProjectID_txt.Text);
                    cmd.Parameters.Add("p_PROJECTNAME", OracleDbType.Varchar2).Value = ProjectName_txt.Text;
                    cmd.Parameters.Add("p_STARTDATE", OracleDbType.Date).Value = StartDate_dtp.Value;
                    cmd.Parameters.Add("p_ENDDATE", OracleDbType.Date).Value = EndDate_dtp.Value;
                    cmd.Parameters.Add("p_STATUS", OracleDbType.Varchar2).Value = Status_cmb.SelectedItem.ToString();
                    cmd.Parameters.Add("p_PROJECTMANAGERID", OracleDbType.Int32).Value =
                        Convert.ToInt32(ProjectManagerID_txt.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Project updated successfully!");
                    LoadProjects();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating project: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectID_txt.Text))
            {
                MessageBox.Show("Please select a project to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (OracleCommand cmd = new OracleCommand("BEGIN PROC_DELETE_PROJECT(:p_PROJECTID); END;", conn))
                    {
                        conn.Open();

                        // Add parameters
                        cmd.Parameters.Add(new OracleParameter("p_PROJECTID", OracleDbType.Int32)
                        {
                            Value = Convert.ToInt32(ProjectID_txt.Text)
                        });

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Project deleted successfully!");
                        LoadProjects();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting project: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }    

        private void Project_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Project_dtg.Rows[e.RowIndex];
                ProjectID_txt.Text = row.Cells["PROJECTID"].Value.ToString();
                ProjectName_txt.Text = row.Cells["PROJECTNAME"].Value.ToString();
                StartDate_dtp.Value = Convert.ToDateTime(row.Cells["STARTDATE"].Value);
                EndDate_dtp.Value = Convert.ToDateTime(row.Cells["ENDDATE"].Value);
                Status_cmb.SelectedItem = row.Cells["STATUS"].Value.ToString();
                ProjectManagerID_txt.Text = row.Cells["PROJECTMANAGERID"].Value.ToString();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            ProjectID_txt.Clear();
            ProjectName_txt.Clear();
            StartDate_dtp.Value = DateTime.Now;
            EndDate_dtp.Value = DateTime.Now;
            Status_cmb.SelectedIndex = -1;
            ProjectManagerID_txt.Clear();
        }

        private void Project_Load(object sender, EventArgs e)
        {
            ProjectID_txt.Enabled = false;
        }
    }
}