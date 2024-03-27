using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram19mar2024
{
    public partial class IndividualBinColorsForm : Form
    {
        private PlotView plotView1;

        public IndividualBinColorsForm()
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

            PlotModel plotModel = CreateIndividualBinColors();
            Text = "OxyPlot CreateIndividualBinColors";
            this.plotView1.Model = plotModel;
        }

        private static PlotModel CreateIndividualBinColors(double mean = 1, int n = 10000)
        {
            var model = new PlotModel { Title = "Individual Bin Colors", Subtitle = "Minimum is Red, Maximum is Green" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Frequency" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Observation" });

            Random rnd = new Random(1);

            HistogramSeries chs = new HistogramSeries() { FillColor = OxyColors.Gray, RenderInLegend = true, Title = "Measurements" };

            var binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var binBreaks = HistogramHelpers.CreateUniformBins(0, 10, 20);
            var bins = HistogramHelpers.Collect(SampleUniform(rnd, 0, 10, 1000), binBreaks, binningOptions).OrderBy(b => b.Count).ToArray();
            bins.First().Color = OxyColors.Red;
            bins.Last().Color = OxyColors.Green;
            chs.Items.AddRange(bins);
            chs.StrokeThickness = 1;
            model.Series.Add(chs);

            return model;
        }

        private static IEnumerable<double> SampleUniform(Random rnd, double min, double max, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return rnd.NextDouble() * (max - min) + min;
            }
        }
    }
}
