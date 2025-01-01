using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagementSystem
{
    public partial class AddEmployee : UserControl
    {
        private readonly string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        private OracleConnection conn;

        public AddEmployee()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT * FROM EMPLOYEES ORDER BY EMPLOYEEID", conn))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Emp_dtg.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void addEmployee_addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FullName_txt.Text) ||
                    string.IsNullOrWhiteSpace(Email_txt.Text) ||
                    string.IsNullOrWhiteSpace(Department_txt.Text) ||
                    string.IsNullOrWhiteSpace(JobTitile_txt.Text))
                {
                    MessageBox.Show("Please fill in all fields", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_INSERT_EMPLOYEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        OracleParameter empIdParam = new OracleParameter("p_EMPLOYEEID", OracleDbType.Int32);
                        empIdParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(empIdParam);

                        // Input parameters
                        cmd.Parameters.Add("p_EMPLOYEENAME", OracleDbType.Varchar2).Value = FullName_txt.Text;
                        cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = Email_txt.Text;
                        cmd.Parameters.Add("p_DEPARTMENT", OracleDbType.Varchar2).Value = Department_txt.Text;
                        cmd.Parameters.Add("p_JOBTITLE", OracleDbType.Varchar2).Value = JobTitile_txt.Text;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Employee added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadEmployeeData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void addEmployee_updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmployeeID_txt.Text))
                {
                    MessageBox.Show("Please select an employee to update", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_UPDATE_EMPLOYEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value =
                            Convert.ToInt32(EmployeeID_txt.Text);
                        cmd.Parameters.Add("p_EMPLOYEENAME", OracleDbType.Varchar2).Value = FullName_txt.Text;
                        cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = Email_txt.Text;
                        cmd.Parameters.Add("p_DEPARTMENT", OracleDbType.Varchar2).Value = Department_txt.Text;
                        cmd.Parameters.Add("p_JOBTITLE", OracleDbType.Varchar2).Value = JobTitile_txt.Text;

                        OracleParameter successParam = new OracleParameter("p_SUCCESS", OracleDbType.Varchar2, 20);
                        successParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(successParam);

                        cmd.ExecuteNonQuery();

                        string result = successParam.Value.ToString();
                        if (result == "SUCCESS")
                        {
                            MessageBox.Show("Employee updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update employee", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void addEmployee_deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmployeeID_txt.Text))
                {
                    MessageBox.Show("Please select an employee to delete", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                using (conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_DELETE_EMPLOYEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value =
                            Convert.ToInt32(EmployeeID_txt.Text);

                        OracleParameter successParam = new OracleParameter("p_SUCCESS", OracleDbType.Varchar2, 20);
                        successParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(successParam);

                        cmd.ExecuteNonQuery();

                        string result = successParam.Value.ToString();
                        if (result == "SUCCESS")
                        {
                            MessageBox.Show("Employee deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            LoadEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete employee", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void addEmployee_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            EmployeeID_txt.Clear();
            FullName_txt.Clear();
            Email_txt.Clear();
            Department_txt.Clear();
            JobTitile_txt.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                EmployeeID_txt.Text = Emp_dtg.Rows[e.RowIndex].Cells["EMPLOYEEID"].Value.ToString();
                FullName_txt.Text = Emp_dtg.Rows[e.RowIndex].Cells["EMPLOYEENAME"].Value.ToString();
                Email_txt.Text = Emp_dtg.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
                Department_txt.Text = Emp_dtg.Rows[e.RowIndex].Cells["DEPARTMENT"].Value.ToString();
                JobTitile_txt.Text = Emp_dtg.Rows[e.RowIndex].Cells["JOBTITLE"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting employee: " + ex.Message, "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            EmployeeID_txt.Enabled = false;
        }
    }
}
