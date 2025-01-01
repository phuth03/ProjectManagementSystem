using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace EmployeeManagementSystem
{
    public partial class Form1 : Form
    {
        // Database connection string
        private string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize form settings
            login_password.PasswordChar = '*';
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_username.Text.Trim();
            string password = login_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using ( conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ACCOUNTID, USERNAME, ROLE FROM ACCOUNTS WHERE USERNAME = :username AND PASSWORDHASH = :password", conn))
                    {
                        cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                        cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Login successful
                                int accountId = reader.GetInt32(0);
                                string role = reader.GetString(2);

                                // Store user information if needed
                                // You can create a static class to store current user info

                                // Show main form
                                MainForm mainForm = new MainForm();
                                this.Hide();
                                mainForm.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Register_lbl_Click(object sender, EventArgs e)
        {
            ShowRegisterForm();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            ShowRegisterForm();
        }

        private void ShowRegisterForm()
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
