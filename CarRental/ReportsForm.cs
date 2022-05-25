using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarRental
{
    public partial class ReportsForm : Form
    {
        private Queue<Color> colors = new Queue<Color>();

        private SeriesChartType chartType = SeriesChartType.Column;
        private bool showLegend = true;
        private bool showLabels = true;
        private bool showColors = true;
        private bool show3D = false;
        private int rotation = 30;
        private int perspective = 0;
        private DateTime fromDate;
        private DateTime toDate;

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ResetColors()
        {
            colors.Clear();
            colors.Enqueue(Color.FromArgb(65, 140, 240));
            colors.Enqueue(Color.FromArgb(252, 180, 65));
            colors.Enqueue(Color.FromArgb(224, 64, 10));
            colors.Enqueue(Color.FromArgb(5, 100, 146));
            colors.Enqueue(Color.FromArgb(191, 191, 191));
            colors.Enqueue(Color.FromArgb(26, 59, 105));
            colors.Enqueue(Color.FromArgb(255, 227, 130));
            colors.Enqueue(Color.FromArgb(18, 156, 221));
            colors.Enqueue(Color.FromArgb(202, 107, 75));
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            if (Location.IsEmpty)
                CenterToParent();   // при первом создании форма центрируется
            var dates = GetRange();
            fromDate = dates.Item1;
            toDate = dates.Item2;
            UpdateView();
        }

        private void ReportsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Environment.UserInteractive)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private Tuple<DateTime, DateTime> GetRange()
        {
            var query = "SELECT Min([RentalDate]), Max([RentalDate])FROM [Rental]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        return new Tuple<DateTime, DateTime>(reader.GetDateTime(0).Date, reader.GetDateTime(1).Date.AddDays(1).AddMilliseconds(-1));
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
            return new Tuple<DateTime, DateTime>(DateTime.Now.Date, DateTime.Now.Date.AddDays(1).AddMilliseconds(-1));
        }

        private int lastSelected = 0;

        private void UpdateView()
        {
            if (tabControl1.SelectedIndex > 5)
            {
                flowLayoutPanel1.Visible = false;
                PrepareToExport(lastSelected);
                return;
            }
            flowLayoutPanel1.Visible = true;
            ((TabPage)chart1.Parent).Controls.Clear();
            var tpage = tabControl1.Controls.Cast<TabPage>().FirstOrDefault(item => item.Name == $"tabPage{tabControl1.SelectedIndex + 1}");
            if (tpage != null)
                tpage.Controls.Add(chart1);
            var values = new List<double>();
            var names = new List<string>();
            string legend = "";
            string title = "";
            lastSelected = tabControl1.SelectedIndex;
            CalculateResults(lastSelected, values, names, ref legend, ref title);
            chart1.Titles[0].Text = title;
            FillChart(values.ToArray(), names.ToArray(), legend);
        }

        private void CalculateResults(int index, List<double> values, List<string> names, ref string legend, ref string title)
        {
            string query = "";
            switch (index)
            {
                case 0:
                    title = "Популярность машин по маркам";
                    query = @"SELECT [Brands].[Name], Count([Rental].[Id])
FROM [Brands] INNER JOIN ([Autopark] INNER JOIN [Rental] ON [Autopark].[Id] = [Rental].[CarId]) ON [Brands].[Id] = [Autopark].[BrandId]
WHERE [Rental].[RentalDate] > @FromDate And [Rental].[RentalDate] < @ToDate
GROUP BY [Brands].[Name]";
                    legend = "Марки авто";
                    break;
                case 1:
                    title = "Текущая активность сотрудников";
                    query = @"SELECT [Employees].[LastName], Count([Rental].[Id])
FROM [Employees] INNER JOIN [Rental] ON [Employees].[Id] = [Rental].[EmployeeId]
WHERE [Rental].[RentalDate] > @FromDate And [Rental].[RentalDate] < @ToDate
GROUP BY [Employees].[LastName]";
                    legend = "Сотрудники";
                    break;
                case 2:
                    title = "Текущая активность клиентов";
                    query = @"SELECT [Clients].[LastName], Count([Rental].[Id])
FROM [Clients] INNER JOIN [Rental] ON [Clients].[Id] = [Rental].[ClientId]
WHERE [Rental].[RentalDate] > @FromDate AND [Rental].[RentalDate] < @ToDate 
GROUP BY [Clients].[LastName]";
                    legend = "Клиенты";
                    break;
                case 3:
                    title = "Количество выданных сейчас авто";
                    query = @"SELECT [Brands].[Name], Count([Rental].[Id]) 
FROM [Brands] INNER JOIN ([Autopark] INNER JOIN [Rental] ON [Autopark].[Id] = [Rental].[CarId]) ON [Brands].[Id] = [Autopark].[BrandId]
WHERE [Rental].[RentalDate] > @FromDate AND [Rental].[RentalDate] < @ToDate AND [Rental].[State]='выдан'
GROUP BY [Brands].[Name]";
                    legend = "Выдано авто";
                    break;
                case 4:
                    title = "Прибыль по маркам";
                    query = @"SELECT [Brands].[Name], Sum([Cost]*[Days]) 
FROM ([Brands] INNER JOIN [Autopark] ON [Brands].[Id] = [Autopark].[BrandId])
INNER JOIN [Rental] ON [Autopark].[Id] = [Rental].[CarId] WHERE (Rental.RentalDate > @FromDate AND Rental.RentalDate < @ToDate) 
GROUP BY [Brands].[Name]";
                    legend = "Марки авто (прибыль)";
                    break;
                case 5:
                    title = "Средняя длительность аренды по маркам";
                    query = @"SELECT [Brands].[Name], Avg([Rental].[Days]) 
FROM([Brands] INNER JOIN[Autopark] ON[Brands].[Id] = [Autopark].[BrandId])
INNER JOIN[Rental] ON[Autopark].[Id] = [Rental].[CarId] WHERE (Rental.RentalDate > @FromDate AND Rental.RentalDate < @ToDate) 
GROUP BY[Brands].[Name]";
                    legend = "Марки авто (аренда в среднем)";
                    break;
            }
            if (string.IsNullOrWhiteSpace(query)) return;
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@FromDate", $"{fromDate}");
                command.Parameters.AddWithValue("@ToDate", $"{toDate}");
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(0));
                        values.Add(Convert.ToDouble(reader.GetValue(1)));
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        private string lastTitle = null;

        private void PrepareToExport(int index)
        {
            var values = new List<double>();
            var names = new List<string>();
            string legend = "";
            string title = "";
            CalculateResults(index, values, names, ref legend, ref title);
            lastTitle = title;
            lvReport.Columns[0].Text = legend;
            lvReport.Items.Clear();
            for (var i = 0; i < names.Count; i++)
            {
                var lvi = new ListViewItem(names[i]);
                lvi.SubItems.Add($"{values[i]}");
                lvReport.Items.Add(lvi);
            }
        }

        private void FillChart(double[] values, string[] labels, string legend)
        {
            if (values.Length > 0)
                chart1.ChartAreas[0].AxisY.Maximum = values.Max() * 1.2;
            chart1.Series.Clear();
            Series series = chart1.Series.Add(legend);
            series.ChartType = chartType;
            if (chartType == SeriesChartType.Pie)
                series.CustomProperties = showLabels ? "PieLineColor=Black, PieLabelStyle=Outside" : "PieLabelStyle=Disabled";
            else
                series.IsValueShownAsLabel = showLabels;
            series.LabelBackColor = Color.LightYellow;
            series.LabelBorderColor = Color.Black;
            chart1.Legends[0].CustomItems.Clear();
            ResetColors();
            Color color = Color.Red;
            for (var i = 0; i < values.Length; i++)
            {
                var point = series.Points.Add(values[i]);
                point.AxisLabel = $"{values[i]} {labels[i]}";
                if (showColors)
                {
                    color = colors.Dequeue();
                    colors.Enqueue(color);
                }
                point.Color = color;
                if (chartType == SeriesChartType.Column)
                    chart1.Legends[0].CustomItems.Add(color, point.AxisLabel);
            }
            foreach (var leg in chart1.Legends)
            {
                leg.Enabled = showLegend;
            }
            chart1.ChartAreas[0].Area3DStyle.Enable3D = show3D;
            chart1.ChartAreas[0].Area3DStyle.Rotation = rotation;
            chart1.ChartAreas[0].Area3DStyle.Perspective = perspective;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        /// <summary>
        /// Настройка вида диаграммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTuning_Click(object sender, EventArgs e)
        {
            var frm = new ReportTuningForm();
            frm.dtpFromDate.Value = fromDate;
            frm.dtpToDate.Value = toDate;
            if (chartType == SeriesChartType.Column)
                frm.rbColumn.Checked = true;
            else
                frm.rbPie.Checked = true;
            frm.cbLegend.Checked = showLegend;
            frm.cbLabels.Checked = showLabels;
            frm.cbColors.Checked = showColors;
            frm.cb3D.Checked = show3D;
            frm.nudTurn.Value = rotation;
            frm.nudVista.Value = perspective;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                fromDate = frm.dtpFromDate.Value.Date;
                toDate = frm.dtpToDate.Value.AddDays(1).Date.AddMilliseconds(-1);
                if (frm.rbColumn.Checked)
                    chartType = SeriesChartType.Column;
                else if (frm.rbPie.Checked)
                    chartType = SeriesChartType.Pie;
                showLegend = frm.cbLegend.Checked;
                showLabels = frm.cbLabels.Checked;
                showColors = frm.cbColors.Checked;
                show3D = frm.cb3D.Checked;
                rotation = (int)frm.nudTurn.Value;
                perspective = (int)frm.nudVista.Value;
                UpdateView();
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            lastSelected = ((RadioButton)sender).TabIndex;
            PrepareToExport(lastSelected);
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            foreach (var rb in panSelector.Controls.OfType<RadioButton>().OrderBy(item => item.Name))
            {
                if (rb.TabIndex == lastSelected)
                {
                    rb.Checked = true;
                    break;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var wait = new WaitForm();
            wait.Show();
            Cursor = Cursors.WaitCursor;
            dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var path = Application.StartupPath;
            var templateName = Path.Combine(path, "Reports", "Статистика.xltx");
            var outputName = Path.Combine(path, "Documents", $"{lastTitle ?? "Статистика"}.xlsx");
            if (File.Exists(outputName))
            {
                try
                {
                    File.Delete(outputName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Ошибка удаления предыдущей версии таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                var wb = xl.Workbooks.Open(templateName, 0, true);
                var sheet = wb.Sheets[1];
                var row = 2;
                sheet.Cells[1, 1] = lvReport.Columns[0].Text;
                sheet.Cells[1, 2] = lvReport.Columns[1].Text;
                foreach (var lvi in lvReport.Items.Cast<ListViewItem>())
                {
                    sheet.Cells[row, 1] = lvi.Text;
                    sheet.Cells[row, 2] = lvi.SubItems[1].Text;
                    row++;
                }
                sheet.Range("A1").Activate();
                wb.SaveAs(outputName);
                wb.Close();
            }
            finally
            {
                xl.Quit();
                Cursor = Cursors.Default;
                wait.Close();
            }
            MessageBox.Show(this, $"{lastTitle ?? "Отчет"} выгружен в папку Documents", "Документы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
