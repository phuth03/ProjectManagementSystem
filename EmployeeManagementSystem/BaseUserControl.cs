using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagementSystem
{
    public class BaseUserControl : UserControl
    {
        protected OracleConnection GetConnection()
        {
            if (ParentForm is MainForm mainForm)
            {
                return mainForm.GetDatabaseConnection();
            }
            return null;
        }

        protected void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
