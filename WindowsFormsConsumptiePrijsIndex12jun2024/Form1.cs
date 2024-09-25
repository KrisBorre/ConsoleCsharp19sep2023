using OxyPlot.WindowsForms;

// See also SolutionCsharp13dec2023 -> WinFormsConsumptiePrijsIndex20dec2023

namespace WindowsFormsConsumptiePrijsIndex12jun2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string filePath = @"..\..\..\CPI_All_base_years.txt";

            // Create a list to store the data
            List<DataRow> dataRows = new List<DataRow>();

            // Read the file line by line
            foreach (var line in File.ReadLines(filePath))
            {
                // Split the line by the '|' delimiter
                var columns = line.Split('|');

                // Ensure there are enough columns in the data
                if (columns.Length >= 9)
                {
                    // Parse the relevant columns
                    string date = $"{columns[0]}-{columns[1]}";  // Combining year and month to get the date
                    string cpiIndex = columns[2] == "." ? null : columns[2]; // Consumptieprijsindex (CPI)
                    string withoutEnergyIndex = columns[3] == "." ? null : columns[3]; // Index zonder energetische producten
                    string withoutPetroleumIndex = columns[4] == "." ? null : columns[4]; // Index zonder petroleum producten
                    string inflation = columns[6] == "." ? null : columns[6]; // Inflatie
                    string healthIndex = columns[7] == "." ? null : columns[7]; // Gezondheidsindex

                    string basisJaar = columns[9];
                    // Add the data to the list
                    dataRows.Add(new DataRow(date, cpiIndex, withoutEnergyIndex, withoutPetroleumIndex, inflation, healthIndex, basisJaar));
                }
            }

            this.Text = "Consumptie Prijs Index";

            //var plotModel = InflationGraph.CreatePlotModel(dataRows);
            var plotModel = InflationGraph.CreateInflationPlot(dataRows);

            this.plotView1 = new PlotView { Model = plotModel };
        }
    }
}
