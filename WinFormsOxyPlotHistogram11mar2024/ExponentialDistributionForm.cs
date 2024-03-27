using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace WinFormsOxyPlotHistogram11mar2024
{
    public partial class ExponentialDistributionForm : Form
    {
        public ExponentialDistributionForm()
        {
            InitializeComponent();

            plotView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlotModel plotModel = CreateExponentialDistribution(true);
            Text = "OxyPlot CreateExponentialDistribution(true)";
            this.plotView1.Model = plotModel;
        }

        private static PlotModel CreateExponentialDistribution(bool logarithmicYAxis = false, double mean = 1, int n = 10000, double baseValue = 0)
        {
            var model = new PlotModel { Title = logarithmicYAxis ? "Exponential Distribution (logarithmic)" : "Exponential Distribution", Subtitle = "Uniformly distributed bins (" + n + " samples)" };
            model.Axes.Add(
                logarithmicYAxis ?
                    (Axis)new LogarithmicAxis { Position = AxisPosition.Left, Title = "Frequency" } :
                    new LinearAxis { Position = AxisPosition.Left, Title = "Frequency" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });

            Random rnd = new Random(1);

            HistogramSeries chs = new HistogramSeries();

            var binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var binBreaks = HistogramHelpers.CreateUniformBins(start: 0, end: 5, binCount: 15);
            chs.Items.AddRange(HistogramHelpers.Collect(SampleExps(rnd, mean, n), binBreaks, binningOptions));
            chs.StrokeThickness = 1;
            //chs.BaseValue = baseValue;
            //chs.NegativeFillColor = OxyColors.Red;
            model.Series.Add(chs);

            return model;
        }

        private static IEnumerable<double> SampleExps(Random rnd, double mean, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return SampleExp(rnd, mean);
            }
        }

        private static double SampleExp(Random rnd, double mean)
        {
            return Math.Log(1.0 - rnd.NextDouble()) / -mean;
        }
    }
}
