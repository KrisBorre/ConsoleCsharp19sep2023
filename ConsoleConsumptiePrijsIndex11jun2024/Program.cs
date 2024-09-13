using System.Globalization;

namespace ConsoleConsumptiePrijsIndex11jun2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumptie Prijs Index by Gemini, and manually corrected.");

            string filePath = @"..\..\..\CPI_All_base_years.txt";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip the header row
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split('|');

                        // Extract the desired columns
                        DateTime date = DateTime.Parse($"{values[0]}-{values[1]}-01"); // Assuming the day is always 1

                        decimal consumptieprijsindex = decimal.Parse(values[2], CultureInfo.InvariantCulture);

                        // Process the data as needed
                        Console.WriteLine($"Date: {date:yyyy-MM-dd}");
                        Console.WriteLine($"Consumptieprijsindex: {consumptieprijsindex}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
        }
    }
}