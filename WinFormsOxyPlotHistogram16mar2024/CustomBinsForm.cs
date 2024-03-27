using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram16mar2024
{
    public partial class CustomBinsForm : Form
    {
        private PlotView plotView1;

        public CustomBinsForm()
        {
            InitializeComponent();

            plotView1 = new PlotView();
            plotView1.Location = new Point(12, 12);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(776, 426);
            plotView1.TabIndex = 0;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            plotView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Controls.Add(plotView1);

            PlotModel plotModel = CreateExponentialDistributionCustomBins();
            Text = "OxyPlot CreateExponentialDistributionCustomBins";
            this.plotView1.Model = plotModel;
        }

        private static PlotModel CreateExponentialDistributionCustomBins(double mean = 1, int n = 50000)
        {
            var model = new PlotModel { Title = "Exponential Distribution", Subtitle = "Custom bins (" + n + " samples)" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Frequency" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });

            Random rnd = new Random(1);

            HistogramSeries chs = new HistogramSeries();

            var binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            chs.Items.AddRange(HistogramHelpers.Collect(SampleExps(rnd, mean, n), new double[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.75, 1.0, 2.0, 3.0, 4.0, 5.0 }, binningOptions));
            chs.StrokeThickness = 1;
            chs.FillColor = OxyColors.Purple;
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
