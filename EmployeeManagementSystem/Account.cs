using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Account : UserControl
    {
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        OracleConnection conn;
        public Account()
        {
            InitializeComponent();
            LoadAccounts();

            // Wire up event handlers
            Add_btn.Click += Add_btn_Click;
            Update_btn.Click += Update_btn_Click;
            Delete_btn.Click += Delete_btn_Click;
            Clear_btn.Click += Clear_btn_Click;
            Acc_dtg.CellClick += Acc_dtg_CellClick;
        }

        private void LoadAccounts()
        {
            try
            {
                using ( conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ACCOUNTID, USERNAME, PASSWORDHASH, EMAIL, ROLE, EMPLOYEEID FROM ACCOUNTS", conn))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Acc_dtg.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_INSERT_ACCOUNT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        OracleParameter accountIdParam = new OracleParameter("p_ACCOUNTID", OracleDbType.Int32);
                        accountIdParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(accountIdParam);

                        // Input parameters
                        cmd.Parameters.Add("p_USERNAME", OracleDbType.Varchar2).Value = User_txt.Text;
                        cmd.Parameters.Add("p_PASSWORDHASH", OracleDbType.Varchar2).Value = Pass_txt.Text;
                        cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = Email_txt.Text;
                        cmd.Parameters.Add("p_ROLE", OracleDbType.Varchar2).Value = Roll_cmb.SelectedItem.ToString();
                        cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value = int.Parse(EmpID_txt.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccounts();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_UPDATE_ACCOUNT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_ACCOUNTID", OracleDbType.Int32).Value = int.Parse(Acc_id.Text);
                        cmd.Parameters.Add("p_USERNAME", OracleDbType.Varchar2).Value = User_txt.Text;
                        cmd.Parameters.Add("p_PASSWORDHASH", OracleDbType.Varchar2).Value = Pass_txt.Text;
                        cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = Email_txt.Text;
                        cmd.Parameters.Add("p_ROLE", OracleDbType.Varchar2).Value = Roll_cmb.SelectedItem.ToString();
                        cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value = int.Parse(EmpID_txt.Text);

                        OracleParameter successParam = new OracleParameter("p_SUCCESS", OracleDbType.Varchar2, 20);
                        successParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(successParam);

                        cmd.ExecuteNonQuery();

                        string result = successParam.Value.ToString();
                        if (result == "SUCCESS")
                        {
                            MessageBox.Show("Account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAccounts();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Account update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Acc_id.Text))
            {
                MessageBox.Show("Please select an account to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("PROC_DELETE_ACCOUNT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("p_ACCOUNTID", OracleDbType.Int32).Value = int.Parse(Acc_id.Text);

                        OracleParameter successParam = new OracleParameter("p_SUCCESS", OracleDbType.Varchar2, 20);
                        successParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(successParam);

                        cmd.ExecuteNonQuery();

                        string result = successParam.Value.ToString();
                        if (result == "SUCCESS")
                        {
                            MessageBox.Show("Account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAccounts();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Account deletion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            Acc_id.Clear();
            User_txt.Clear();
            Pass_txt.Clear();
            Email_txt.Clear();
            Roll_cmb.SelectedIndex = -1;
            EmpID_txt.Clear();
        }

        private void Acc_dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Acc_dtg.Rows[e.RowIndex];
                Acc_id.Text = row.Cells["ACCOUNTID"].Value.ToString();
                User_txt.Text = row.Cells["USERNAME"].Value.ToString();
                Pass_txt.Text = row.Cells["PASSWORDHASH"].Value.ToString();
                Email_txt.Text = row.Cells["EMAIL"].Value.ToString();
                Roll_cmb.SelectedItem = row.Cells["ROLE"].Value.ToString();
                EmpID_txt.Text = row.Cells["EMPLOYEEID"].Value.ToString();
                Pass_txt.Clear(); // For security, don't display the password
            }
        }

        private void Account_Load(object sender, EventArgs e)
        {
            Acc_id.Enabled = false;
        }
    }
}