using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Globalization;

// See also SolutionCsharp13dec2023 -> WinFormsConsumptiePrijsIndex20dec2023

namespace WindowsFormsConsumptiePrijsIndex12jun2024
{
    internal class InflationGraph
    {
        /// <summary>
        /// By Gemini, but does not work.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PlotModel CreatePlotModel(List<DataRow> data)
        {
            var model = new PlotModel { Title = "Inflation Over Time" };

            // Create axes
            var xAxis = new DateTimeAxis { Title = "Date" };
            var yAxis = new LinearAxis { Title = "Inflation" };
            model.Axes.Add(xAxis);
            model.Axes.Add(yAxis);

            // Create line series
            var lineSeries = new LineSeries { Title = "Inflation" };

            int max_number_of_points = 5;
            int number_of_points = 0;
            foreach (var row in data)
            {
                if (row.BasisJaar == "2013")
                {
                    if (number_of_points < max_number_of_points)
                    {
                        DateTime date;
                        if (DateTime.TryParse(row.Date, out date))
                        {
                            double inflation;
                            if (row.Inflation != null && double.TryParse(row.Inflation.Replace("%", ""), CultureInfo.InvariantCulture, out inflation))
                            {
                                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(date), inflation));
                                number_of_points++;
                            }
                        }
                    }
                }
            }
            model.Series.Add(lineSeries);

            return model;
        }

        /// <summary>
        /// By ChatGPT, but does not work.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static PlotModel CreateInflationPlot(List<DataRow> data)
        {
            // Create a new PlotModel
            var plotModel = new PlotModel { Title = "Inflation Over Time" };

            // Create a LineSeries to represent the inflation data
            var lineSeries = new LineSeries
            {
                Title = "Inflation",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Red
            };

            int max_number_of_points = 5;
            int number_of_points = 0;
            // Add data points to the series
            foreach (var row in data)
            {
                if (row.BasisJaar == "2013")
                {
                    if (number_of_points < max_number_of_points)
                    {
                        if (row.Inflation != null && double.TryParse(row.Inflation.Replace("%", ""), CultureInfo.InvariantCulture, out double inflationValue))
                        {
                            lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.ParseExact(row.Date, "yyyy-M", null)), inflationValue));
                            number_of_points++;
                        }
                    }
                }
            }

            // Add the LineSeries to the PlotModel
            plotModel.Series.Add(lineSeries);

            // Set up X and Y axis
            plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                StringFormat = "yyyy-MM",
                Title = "Date"
            });
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Inflation (%)",
                MinimumPadding = 0.1,
                MaximumPadding = 0.1
            });

            return plotModel;
        }
    }
}
