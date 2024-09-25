using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Globalization;

// See also SolutionCsharp13dec2023 -> WinFormsConsumptiePrijsIndex20dec2023

// DeepSeek Coder 7B Instruct, strongly adapted code to make it work.
namespace WindowsFormsConsumptiePrijsIndex13jun2024
{
    public partial class Form1 : Form
    {
        private List<DataRow> dataRows = new List<DataRow>();

        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreatePlotModel();
        }

        private void LoadData()
        {
            string path = @"..\..\..\CPI_All_base_years.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split('|');
                    string date = columns[0] + "|" + columns[1];
                    string inflationStr = columns[6]; // Assuming the inflation index is in the 7th column
                    string basisJaar = columns[9]; // 10th column

                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";

                    if (basisJaar == "2013")
                    {
                        if (double.TryParse(inflationStr.TrimEnd('%'), provider, out double inflationValue))
                        {
                            // Convert percentage to a fraction (0.01 for 1%, 0.02 for 2%, etc.)
                            inflationValue /= 100.0;
                            dataRows.Add(new DataRow { Date = date, Inflation = inflationValue });
                        }
                    }
                }
            }
        }

        private void CreatePlotModel()
        {
            // Create a line series for the inflation data
            LineSeries lineSeries = new LineSeries();
            foreach (var row in dataRows)
            {
                string[] dateParts = row.Date.Split('|');

                if (dateParts.Length == 2 && int.TryParse(dateParts[0], out int year) && int.TryParse(dateParts[1], out int month))
                {
                    DateTime date = new DateTime(year, month, 1);  // Assuming day is 1
                    Console.WriteLine("Parsed date: " + date.ToString("yyyy-MM-dd"));
                    lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), row.Inflation));
                }
                else
                {
                    Console.WriteLine("Failed to parse date");
                }
            }

            // Create a plot model
            PlotModel plotModel = new PlotModel { Title = "Inflation Over Time" };
            plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            plotModel.Series.Add(lineSeries);

            // Assign the plot model to the oxyplot control
            oxyPlotControl.Model = plotModel;
        }
    }

    public class DataRow
    {
        public string Date { get; set; }
        public double Inflation { get; set; }
    }
}