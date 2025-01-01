using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace EmployeeManagementSystem
{
    public partial class MainForm : Form
    {
        // Database connection string
        private readonly string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
        private OracleConnection connection;

        public MainForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadInitialData();

            // Hide all user controls initially
            HideUserControls();
            addEmployee1.Show();
        }

        private void InitializeDatabase()
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                MessageBox.Show("Connected to database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInitialData()
        {
            // Set welcome message with default if no username is set
            greet_user.Text = "Welcome, User!";
        }

        private void HideUserControls()
        {
            addEmployee1.Hide();
            task1.Hide();
            project2.Hide();
            account2.Hide();
            taskAssignment1.Hide();
            gantt1.Hide();
        }

        private void addEmployee_btn_Click(object sender, EventArgs e)
        {
            HideUserControls();
            addEmployee1.Show();
        }


        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                Application.Exit();
            }
        }

        // Helper method for other forms to access the database connection
        public OracleConnection GetDatabaseConnection()
        {
            return connection;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void pro_btn_Click(object sender, EventArgs e)
        {
            HideUserControls();
            project2.Show();

        }

        private void Task_btn_Click(object sender, EventArgs e)
        {
            HideUserControls();
            task1.Show();

        }

        private void taskassignment_btn_Click(object sender, EventArgs e)
        {
            HideUserControls();
            taskAssignment1.Show();

        }

        private void account_btn_Click(object sender, EventArgs e)
        {
            HideUserControls();
            account2.Show();

        }

        private void gantt_btn_Click(object sender, EventArgs e)
        {
            HideUserControls();
            gantt1.Show();
        }
    }
}