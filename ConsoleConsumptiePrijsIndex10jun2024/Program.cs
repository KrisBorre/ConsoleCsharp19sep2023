namespace ConsoleConsumptiePrijsIndex10jun2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumptie Prijs Index by ChatGPT");

            // Path to the data file
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

                    // Add the data to the list
                    dataRows.Add(new DataRow(date, cpiIndex, withoutEnergyIndex, withoutPetroleumIndex, inflation, healthIndex));
                }
            }

            // Print the extracted data
            foreach (var row in dataRows)
            {
                Console.WriteLine($"Date: {row.Date}, CPI: {row.CpiIndex}, Without Energy: {row.WithoutEnergyIndex}, Without Petroleum: {row.WithoutPetroleumIndex}, Inflation: {row.Inflation}, Health Index: {row.HealthIndex}");
            }
        }
    }

    // DataRow class to store each row's data
    class DataRow
    {
        public string Date { get; set; }
        public string CpiIndex { get; set; }
        public string WithoutEnergyIndex { get; set; }
        public string WithoutPetroleumIndex { get; set; }
        public string Inflation { get; set; }
        public string HealthIndex { get; set; }

        public DataRow(string date, string cpiIndex, string withoutEnergyIndex, string withoutPetroleumIndex, string inflation, string healthIndex)
        {
            Date = date;
            CpiIndex = cpiIndex;
            WithoutEnergyIndex = withoutEnergyIndex;
            WithoutPetroleumIndex = withoutPetroleumIndex;
            Inflation = inflation;
            HealthIndex = healthIndex;
        }
    }
}
