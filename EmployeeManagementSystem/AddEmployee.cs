using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagementSystem
{
    public partial class AddEmployee : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        private OracleConnection conn;

        public AddEmployee()
        {
            InitializeComponent();
            conn = new OracleConnection(connectionString);
            displayEmployeeData();
        }

        private void displayEmployeeData()
        {
            try
            {
                using (OracleConnection tempConn = new OracleConnection(connectionString))
                {
                    tempConn.Open();
                    string query = "SELECT EMPLOYEEID, EMPLOYEENAME, EMAIL, DEPARTMENT, JOBTITLE FROM EMPLOYEES ORDER BY EMPLOYEEID";
                    using (OracleCommand cmd = new OracleCommand(query, tempConn))
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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void addEmployee_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeID_txt.Text) ||
                string.IsNullOrEmpty(FullName_txt.Text) ||
                string.IsNullOrEmpty(Email_txt.Text) ||
                string.IsNullOrEmpty(JobTitile_txt.Text) ||
                string.IsNullOrEmpty(Department_txt.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OracleConnection tempConn = new OracleConnection(connectionString))
                {
                    tempConn.Open();
                    string query = @"INSERT INTO EMPLOYEES (EMPLOYEEID, EMPLOYEENAME, EMAIL, DEPARTMENT, JOBTITLE) 
                                   VALUES (:id, :name, :email, :department, :jobTitle)";

                    using (OracleCommand cmd = new OracleCommand(query, tempConn))
                    {
                        cmd.Parameters.Add(":id", OracleDbType.Int32).Value = int.Parse(EmployeeID_txt.Text);
                        cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = FullName_txt.Text;
                        cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = Email_txt.Text;
                        cmd.Parameters.Add(":department", OracleDbType.Varchar2).Value = Department_txt.Text;
                        cmd.Parameters.Add(":jobTitle", OracleDbType.Varchar2).Value = JobTitile_txt.Text;

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                            displayEmployeeData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addEmployee_updateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeID_txt.Text))
            {
                MessageBox.Show("Please select an employee to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OracleConnection tempConn = new OracleConnection(connectionString))
                {
                    tempConn.Open();
                    string query = @"UPDATE EMPLOYEES 
                                   SET EMPLOYEENAME = :name,
                                       EMAIL = :email,
                                       DEPARTMENT = :department,
                                       JOBTITLE = :jobTitle
                                   WHERE EMPLOYEEID = :id";

                    using (OracleCommand cmd = new OracleCommand(query, tempConn))
                    {
                        cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = FullName_txt.Text;
                        cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = Email_txt.Text;
                        cmd.Parameters.Add(":department", OracleDbType.Varchar2).Value = Department_txt.Text;
                        cmd.Parameters.Add(":jobTitle", OracleDbType.Varchar2).Value = JobTitile_txt.Text;
                        cmd.Parameters.Add(":id", OracleDbType.Int32).Value = int.Parse(EmployeeID_txt.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                            displayEmployeeData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addEmployee_deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmployeeID_txt.Text))
            {
                MessageBox.Show("Please select an employee to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (OracleConnection tempConn = new OracleConnection(connectionString))
                    {
                        tempConn.Open();
                        string query = "DELETE FROM EMPLOYEES WHERE EMPLOYEEID = :id";
                        using (OracleCommand cmd = new OracleCommand(query, tempConn))
                        {
                            cmd.Parameters.Add(":id", OracleDbType.Int32).Value = int.Parse(EmployeeID_txt.Text);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                                displayEmployeeData();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addEmployee_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            EmployeeID_txt.Clear();
            FullName_txt.Clear();
            Email_txt.Clear();
            Department_txt.Clear();
            JobTitile_txt.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Emp_dtg.Rows[e.RowIndex];
                EmployeeID_txt.Text = row.Cells[0].Value.ToString();
                FullName_txt.Text = row.Cells[1].Value.ToString();
                Email_txt.Text = row.Cells[2].Value.ToString();
                Department_txt.Text = row.Cells[3].Value.ToString();
                JobTitile_txt.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}