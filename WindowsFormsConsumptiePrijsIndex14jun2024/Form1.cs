using OxyPlot;
using OxyPlot.Series;
using System.Data;

// See also SolutionCsharp13dec2023 -> WinFormsConsumptiePrijsIndex20dec2023

// OpenChat 3.5, does not work
namespace WindowsFormsConsumptiePrijsIndex14jun2024
{
    public partial class Form1 : Form
    {
        private DataTable dataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
            DataTable dataTable = ReadDataFile(@"..\..\..\CPI_All_base_years.txt");

            foreach (DataColumn column in dataTable.Columns)
            {
                string temp = column.ColumnName;
                Console.WriteLine(temp);
            }

            // Filter rows with NM_BASE_YR equal to 2013
            var filteredRows = dataTable.AsEnumerable().Where(row => row.Field<int>(9) == 2013); // does not work

            // Create the OxyPlot chart
            LineSeries lineSeries = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                Color = OxyColors.Blue
            };

            foreach (var row in filteredRows)
            {
                if (double.TryParse(row["Date"].ToString(), out double date) && double.TryParse(row["MS_CPI_INFL"].ToString(), out double inflation))
                {
                    lineSeries.Points.Add(new DataPoint(date, inflation));
                }
            }

            // Set up the PlotModel and add the LineSeries
            var plotModel = new PlotModel { Title = "Inflation Over Time" };
            plotModel.Series.Add(lineSeries);

            // Create a PlotView control
            OxyPlot.WindowsForms.PlotView plotView = new OxyPlot.WindowsForms.PlotView
            {
                Dock = DockStyle.Fill,
                Model = plotModel
            };

            // Add the PlotView to the form
            Controls.Add(plotView);
        }

        private DataTable ReadDataFile(string filePath)
        {
            DataTable dataTable = new DataTable();

            string[] lines = File.ReadAllLines(filePath);

            // Add columns to the DataTable
            for (int i = 0; i < lines[0].Split('|').Length - 1; i++)
            {
                dataTable.Columns.Add($"Column{i + 1}", typeof(string));
            }

            foreach (string line in lines)
            {
                string[] columns = line.Split('|');

                DataRow row = dataTable.NewRow();

                for (int i = 0; i < columns.Length - 1; i++)
                {
                    row[i] = columns[i];
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
