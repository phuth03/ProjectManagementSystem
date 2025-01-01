using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace EmployeeManagementSystem
{
    public partial class RegisterForm : Form
    {
        OracleConnection conn;

        public RegisterForm()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
            conn = new OracleConnection(connectionString);
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(signup_username.Text) || string.IsNullOrEmpty(signup_password.Text))
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();

                // Check if username exists
                using (OracleCommand checkCmd = new OracleCommand("SELECT COUNT(*) FROM ACCOUNTS WHERE USERNAME = :username", conn))
                {
                    checkCmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = signup_username.Text;
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Insert new account
                using (OracleCommand cmd = new OracleCommand("PROC_INSERT_ACCOUNT", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Output parameter for ACCOUNTID
                    OracleParameter accountIdParam = new OracleParameter("p_ACCOUNTID", OracleDbType.Int32);
                    accountIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(accountIdParam);

                    // Input parameters
                    cmd.Parameters.Add("p_USERNAME", OracleDbType.Varchar2).Value = signup_username.Text;
                    cmd.Parameters.Add("p_PASSWORDHASH", OracleDbType.Varchar2).Value = signup_password.Text;
                    cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = Email_txt.Text;
                    cmd.Parameters.Add("p_ROLE", OracleDbType.Varchar2).Value = "Employee";
                    cmd.Parameters.Add("p_EMPLOYEEID", OracleDbType.Int32).Value = EmpID_txt.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open Form1
                    Form1 mainForm = new Form1();
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void signup_loginBtn_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Any initialization code if needed
        }

        private void Login_lbl_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }
    }
}