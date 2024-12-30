using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Account : UserControl
    {
        // Database connection string
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        private OracleConnection conn;

        public Account()
        {
            InitializeComponent();
            conn = new OracleConnection(connectionString);
            LoadAccountData();

            // Add event handlers
            Add_btn.Click += new EventHandler(AddAccount);
            Update_btn.Click += new EventHandler(UpdateAccount);
            Delete_btn.Click += new EventHandler(DeleteAccount);
            Clear_btn.Click += new EventHandler(ClearFields);
            Acc_dtg.CellClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        // Load account data into DataGridView
        private void LoadAccountData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Accounts";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Acc_dtg.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading account data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Add new account
        private void AddAccount(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs())
                {
                    conn.Open();
                    string query = @"INSERT INTO Accounts 
                           (accountid, username, email, passwordhash, role, employeeid) 
                           VALUES 
                           (:accountid, :username, :email, :passwordhash, :role, :employeeid)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("accountid", Acc_id.Text);
                    cmd.Parameters.Add("username", User_txt.Text);
                    cmd.Parameters.Add("email", Email_txt.Text);
                    cmd.Parameters.Add("passwordhash", Pass_txt.Text);
                    cmd.Parameters.Add("role", Roll_cmb.Text);
                    cmd.Parameters.Add("employeeid", EmpID_txt.Text);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Account added successfully!");
                        ClearFields(sender, e);
                        RefreshDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Update existing account
        private void UpdateAccount(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs())
                {
                    conn.Open();
                    string query = @"UPDATE Accounts 
                           SET username = :username,
                               email = :email,
                               passwordhash = :passwordhash,
                               role = :role,
                               employeeid = :employeeid
                           WHERE accountid = :accountid";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("username", User_txt.Text);
                    cmd.Parameters.Add("email", Email_txt.Text);
                    cmd.Parameters.Add("passwordhash", Pass_txt.Text);
                    cmd.Parameters.Add("role", Roll_cmb.Text);
                    cmd.Parameters.Add("employeeid", EmpID_txt.Text);
                    cmd.Parameters.Add("accountid", Acc_id.Text);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Account updated successfully!");
                        RefreshDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating account: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Delete account
        private void DeleteAccount(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this account?", "Confirmation",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    string query = "DELETE FROM Accounts WHERE accountid = :accountid";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("accountid", Acc_id.Text);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Account deleted successfully!");
                        ClearFields(sender, e);
                        RefreshDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting account: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // New method to refresh DataGridView
        private void RefreshDataGridView()
        {
            if (Acc_dtg.InvokeRequired)
            {
                Acc_dtg.Invoke(new Action(RefreshDataGridView));
                return;
            }

            try
            {
                using (OracleConnection newConn = new OracleConnection(connectionString))
                {
                    newConn.Open();
                    string query = "SELECT * FROM Accounts";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, newConn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    Acc_dtg.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message);
            }
        }

        // Clear input fields
        private void ClearFields(object sender, EventArgs e)
        {
            Acc_id.Clear();
            User_txt.Clear();
            Email_txt.Clear();
            Pass_txt.Clear();
            EmpID_txt.Clear();
            Roll_cmb.SelectedIndex = -1;
        }

        // Handle DataGridView cell click
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Acc_dtg.Rows[e.RowIndex];
                Acc_id.Text = row.Cells["accountid"].Value.ToString();
                User_txt.Text = row.Cells["username"].Value.ToString();
                Email_txt.Text = row.Cells["email"].Value.ToString();
                Pass_txt.Text = row.Cells["passwordhash"].Value.ToString();
                Roll_cmb.Text = row.Cells["role"].Value.ToString();
                EmpID_txt.Text = row.Cells["employeeid"].Value.ToString();
            }
        }

        // Validate input fields
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(Acc_id.Text) ||
                string.IsNullOrWhiteSpace(User_txt.Text) ||
                string.IsNullOrWhiteSpace(Email_txt.Text) ||
                string.IsNullOrWhiteSpace(Pass_txt.Text) ||
                string.IsNullOrWhiteSpace(EmpID_txt.Text) ||
                string.IsNullOrWhiteSpace(Roll_cmb.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
            return true;
        }
    }
}
