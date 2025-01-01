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
        private int scrollX = 0;
        private int scrollY = 0;
        private Panel mainPanel;
        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;
        private const int PADDING = 10;
        private Timer refreshTimer;
        public event EventHandler DataUpdated;
        public Gantt()
        {
            InitializeComponent();
            InitializeScrollbars();
            this.DoubleBuffered = true;
            this.Paint += Gantt_Paint;
            this.Resize += Gantt_Resize;
            InitializeRefreshTimer();

            LoadData();
        }
        private void InitializeRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 1000; // Check every second
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void InitializeScrollbars()
        {
            // Create and configure vertical scrollbar
            vScrollBar = new VScrollBar
            {
                Dock = DockStyle.Right,
                SmallChange = rowHeight,
                LargeChange = rowHeight * 5
            };
            vScrollBar.Scroll += VScrollBar_Scroll;

            // Create and configure horizontal scrollbar
            hScrollBar = new HScrollBar
            {
                Dock = DockStyle.Bottom,
                SmallChange = dayWidth,
                LargeChange = dayWidth * 5
            };
            hScrollBar.Scroll += HScrollBar_Scroll;

            // Create main panel for drawing
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false
            };
            mainPanel.Paint += Gantt_Paint;

            // Add controls to the form
            this.Controls.Add(mainPanel);
            this.Controls.Add(vScrollBar);
            this.Controls.Add(hScrollBar);
        }

        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollY = e.NewValue;
            mainPanel.Invalidate();
        }

        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollX = e.NewValue;
            mainPanel.Invalidate();
        }

        private void UpdateScrollBars()
        {
            if (taskData != null && taskData.Rows.Count > 0)
            {
                // Calculate total height needed
                int totalHeight = (taskData.Rows.Count * rowHeight) + PADDING * 2;
                vScrollBar.Maximum = Math.Max(0, totalHeight - mainPanel.Height);

                // Calculate total width needed
                int days = (endDate - startDate).Days;
                int totalWidth = (days * dayWidth) + 200 + PADDING * 2; // 200 for task names column
                hScrollBar.Maximum = Math.Max(0, totalWidth - mainPanel.Width);

                vScrollBar.Visible = vScrollBar.Maximum > 0;
                hScrollBar.Visible = hScrollBar.Maximum > 0;
            }
        }

        private void Gantt_Resize(object sender, EventArgs e)
        {
            UpdateScrollBars();
            mainPanel.Invalidate();
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
                            t.taskid,
                            t.taskname,
                            t.startdate,
                            t.enddate,
                            t.completionpercentage,
                            e.EMPLOYEENAME as assigned_to
                        FROM Tasks t
                        LEFT JOIN TaskAssignments ta ON t.taskid = ta.taskid
                        LEFT JOIN Employees e ON ta.employeeid = e.employeeid
                        WHERE t.startdate IS NOT NULL 
                        AND t.enddate IS NOT NULL
                        ORDER BY t.taskid", conn))
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

                            // Add buffer days for better visibility
                            startDate = startDate.AddDays(-5);
                            endDate = endDate.AddDays(5);
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
            UpdateScrollBars();
        }

        private void Gantt_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(-scrollX, -scrollY);

            // Draw fixed header
            g.ResetTransform();
            DrawHeader(g);
            g.TranslateTransform(-scrollX, -scrollY);

            // Draw time scale and grid
            DrawTimeScale(g, 200, PADDING);

            if (taskData != null && taskData.Rows.Count > 0)
            {
                int yPos = PADDING + 30; // Start below header

                foreach (DataRow row in taskData.Rows)
                {
                    // Draw task name and assigned person
                    string taskName = row["taskname"]?.ToString() ?? "Untitled Task";
                    string assignedTo = row["assigned_to"]?.ToString() ?? "Unassigned";

                    // Reset transform for fixed column
                    g.ResetTransform();
                    g.DrawString(taskName, this.Font, Brushes.Black, PADDING, yPos + 5);
                    g.DrawString(assignedTo, new Font(this.Font.FontFamily, 8), Brushes.Gray, PADDING, yPos + 20);

                    // Restore transform for scrollable content
                    g.TranslateTransform(-scrollX, -scrollY);

                    if (!row.IsNull("startdate") && !row.IsNull("enddate"))
                    {
                        DateTime taskStart = Convert.ToDateTime(row["startdate"]);
                        DateTime taskEnd = Convert.ToDateTime(row["enddate"]);
                        int completion = Convert.ToInt32(row["completionpercentage"] ?? 0);

                        DrawTaskBar(g, taskStart, taskEnd, completion, 200, yPos);
                    }

                    yPos += rowHeight;
                }
            }
        }

        private void DrawHeader(Graphics g)
        {
            Rectangle headerRect = new Rectangle(0, 0, mainPanel.Width, 30);
            g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), headerRect);
            g.DrawLine(Pens.LightGray, 0, 30, mainPanel.Width, 30);
        }

        private void DrawTimeScale(Graphics g, int xOffset, int yPos)
        {
            int days = (endDate - startDate).Days;
            DateTime currentDate = startDate;
            string currentMonth = "";

            // Draw month bars
            for (int i = 0; i <= days; i++)
            {
                int x = xOffset + (i * dayWidth);

                // Draw month label if it's a new month
                if (currentDate.ToString("MMM yyyy") != currentMonth)
                {
                    currentMonth = currentDate.ToString("MMM yyyy");
                    int monthWidth = 0;
                    DateTime monthEnd = currentDate.AddMonths(1).AddDays(-1);
                    if (monthEnd > endDate) monthEnd = endDate;
                    monthWidth = ((monthEnd - currentDate).Days + 1) * dayWidth;

                    // Draw month background
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)),
                        x, yPos, monthWidth, 20);
                    g.DrawString(currentMonth, this.Font, Brushes.Black, x + 5, yPos);
                }

                // Draw day lines and labels
                g.DrawLine(Pens.LightGray, x, yPos + 20, x, yPos + this.Height);

                // Draw day numbers
                if (i < days)
                {
                    g.DrawString(currentDate.Day.ToString(),
                        new Font(this.Font.FontFamily, 8),
                        Brushes.Gray, x + 2, yPos + 22);
                }

                currentDate = currentDate.AddDays(1);
            }
        }

        private void DrawTaskBar(Graphics g, DateTime start, DateTime end, int completion, int xOffset, int yPos)
        {
            int days = Math.Max(1, (end - start).Days);
            int xStart = xOffset + ((start - startDate).Days * dayWidth);
            int width = Math.Max(dayWidth, days * dayWidth);

            // Draw task background
            Rectangle taskRect = new Rectangle(xStart, yPos + 5, width, 20);
            g.FillRectangle(Brushes.LightBlue, taskRect);
            g.DrawRectangle(Pens.Blue, taskRect);

            // Draw completion percentage
            if (completion > 0)
            {
                int completionWidth = (width * completion) / 100;
                Rectangle completionRect = new Rectangle(xStart, yPos + 5, completionWidth, 20);
                g.FillRectangle(Brushes.Blue, completionRect);
            }

            // Draw percentage text
            string percentText = completion + "%";
            SizeF textSize = g.MeasureString(percentText, this.Font);
            float textX = xStart + (width - textSize.Width) / 2;
            float textY = yPos + 7;

            // Draw text with contrasting color
            g.DrawString(percentText, this.Font, Brushes.White,
                textX, textY);

            // Draw start and end dates
            g.DrawString(start.ToString("MM/dd"),
                new Font(this.Font.FontFamily, 7),
                Brushes.Gray, xStart, yPos + 26);
            g.DrawString(end.ToString("MM/dd"),
                new Font(this.Font.FontFamily, 7),
                Brushes.Gray, xStart + width - 30, yPos + 26);
        }
        private void Gantt_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        public void RefreshGantt()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            string connectionString = "Data Source=localhost:1521/XE;User Id=projectman;Password=Phu123;";
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(@"
                        SELECT 
                            t.taskid,
                            t.taskname,
                            t.startdate,
                            t.enddate,
                            t.completionpercentage,
                            e.EMPLOYEENAME as assigned_to
                        FROM Tasks t
                        LEFT JOIN TaskAssignments ta ON t.taskid = ta.taskid
                        LEFT JOIN Employees e ON ta.employeeid = e.employeeid
                        WHERE t.startdate IS NOT NULL 
                        AND t.enddate IS NOT NULL
                        ORDER BY t.taskid", conn))
                    {
                        DataTable newTaskData = new DataTable();
                        new OracleDataAdapter(cmd).Fill(newTaskData);

                        // Check if data has changed
                        if (!DataTablesAreEqual(taskData, newTaskData))
                        {
                            taskData = newTaskData;
                            UpdateDateRange();
                            UpdateScrollBars();
                            mainPanel.Invalidate();

                            // Raise event to notify subscribers of data update
                            DataUpdated?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error refreshing data: " + ex.Message);
                }
            }
        }

        private bool DataTablesAreEqual(DataTable dt1, DataTable dt2)
        {
            if (dt1 == null || dt2 == null) return dt1 == dt2;
            if (dt1.Rows.Count != dt2.Rows.Count) return false;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (!Equals(dt1.Rows[i][j], dt2.Rows[i][j]))
                        return false;
                }
            }
            return true;
        }

        private void UpdateDateRange()
        {
            if (taskData != null && taskData.Rows.Count > 0)
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

                // Add buffer days
                startDate = startDate.AddDays(-5);
                endDate = endDate.AddDays(5);
            }
            else
            {
                startDate = DateTime.Today;
                endDate = DateTime.Today.AddDays(30);
            }
        }

        // Override Dispose to clean up timer

    }
}