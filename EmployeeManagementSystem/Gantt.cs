using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace EmployeeManagementSystem
{
    public partial class Gantt : UserControl
    {
        private DataTable taskData;
        private int rowHeight = 30;
        private int dayWidth = 30;
        private DateTime startDate;
        private DateTime endDate;

        public Gantt()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Gantt_Paint;
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(@"
                        SELECT 
                            taskid,
                            taskname,
                            startdate,
                            enddate,
                            NVL(completionpercentage, 0) as completionpercentage
                        FROM Tasks
                        WHERE startdate IS NOT NULL 
                        AND enddate IS NOT NULL
                        ORDER BY startdate", conn))
                    {
                        taskData = new DataTable();
                        new OracleDataAdapter(cmd).Fill(taskData);

                        if (taskData.Rows.Count > 0)
                        {
                            startDate = DateTime.MaxValue;
                            endDate = DateTime.MinValue;

                            foreach (DataRow row in taskData.Rows)
                            {
                                if (!row.IsNull("startdate") && !row.IsNull("enddate"))
                                {
                                    DateTime taskStart = Convert.ToDateTime(row["startdate"]);
                                    DateTime taskEnd = Convert.ToDateTime(row["enddate"]);

                                    if (taskStart < startDate) startDate = taskStart;
                                    if (taskEnd > endDate) endDate = taskEnd;
                                }
                            }

                            if (startDate == DateTime.MaxValue)
                            {
                                startDate = DateTime.Today;
                                endDate = DateTime.Today.AddDays(30);
                            }
                        }
                        else
                        {
                            startDate = DateTime.Today;
                            endDate = DateTime.Today.AddDays(30);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                    startDate = DateTime.Today;
                    endDate = DateTime.Today.AddDays(30);
                }
            }
        }

        private void Gantt_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int yPos = 10;

            DrawTimeScale(g, 200, 0);

            if (taskData != null && taskData.Rows.Count > 0)
            {
                foreach (DataRow row in taskData.Rows)
                {
                    string taskName = row["taskname"]?.ToString() ?? "Untitled Task";
                    g.DrawString(taskName, this.Font, Brushes.Black, 10, yPos + 5);

                    if (!row.IsNull("startdate") && !row.IsNull("enddate"))
                    {
                        DateTime taskStart = Convert.ToDateTime(row["startdate"]);
                        DateTime taskEnd = Convert.ToDateTime(row["enddate"]);

                        // Safely handle null or invalid completion percentage
                        int completion = 0;
                        if (!row.IsNull("completionpercentage"))
                        {
                            completion = Convert.ToInt32(row["completionpercentage"]);
                        }

                        DrawTaskBar(g, taskStart, taskEnd, completion, 200, yPos);
                    }

                    yPos += rowHeight;
                }
            }
        }

        private void DrawTimeScale(Graphics g, int xOffset, int yPos)
        {
            int days = Math.Max(1, (endDate - startDate).Days);
            DateTime currentDate = startDate;

            for (int i = 0; i <= days; i++)
            {
                int x = xOffset + (i * dayWidth);

                if (currentDate.Day == 1 || i == 0)
                {
                    g.DrawString(currentDate.ToString("MMM dd"),
                        this.Font, Brushes.Black, x, yPos);
                }

                g.DrawLine(Pens.LightGray, x, yPos + 20, x, this.Height);
                currentDate = currentDate.AddDays(1);
            }
        }

        private void DrawTaskBar(Graphics g, DateTime start, DateTime end,
            int completion, int xOffset, int yPos)
        {
            int days = Math.Max(1, (end - start).Days);
            int xStart = xOffset + ((start - startDate).Days * dayWidth);
            int width = Math.Max(dayWidth, days * dayWidth);

            Rectangle taskRect = new Rectangle(xStart, yPos + 5, width, 20);
            g.FillRectangle(Brushes.LightBlue, taskRect);
            g.DrawRectangle(Pens.Blue, taskRect);

            if (completion > 0)
            {
                int completionWidth = (width * completion) / 100;
                Rectangle completionRect = new Rectangle(
                    xStart, yPos + 5, completionWidth, 20);
                g.FillRectangle(Brushes.Blue, completionRect);
            }

            g.DrawString(completion + "%",
                this.Font, Brushes.White,
                xStart + 5, yPos + 7);
        }

        private void Gantt_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}