using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram22mar2024
{
    internal class ControlManager
    {
        private List<Control> controls;

        public List<Control> Controls
        {
            get { return controls; }
        }

        private PlotView plotView1;

        public ControlManager()
        {
            this.controls = new List<Control>();

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

            PlotModel plotModel = CreateNormalDistribution();
            plotView1.Model = plotModel;
        }

        private PlotModel CreateNormalDistribution(double mean = 0, double std = 1, int n = 1000)
        {
            var model = new PlotModel { Title = $"Normal Distribution (μ={mean}, σ={std})", Subtitle = "95% of the distribution (" + n + " samples)" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Frequency" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });

            Random rnd = new Random();

            HistogramSeries chs = new HistogramSeries();
            var binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var binBreaks = HistogramHelpers.CreateUniformBins(start: -std * 4, end: std * 4, binCount: 75);
            chs.Items.AddRange(HistogramHelpers.Collect(SampleNormal(rnd, mean, std, n), binBreaks, binningOptions));
            chs.StrokeThickness = 1;

            double LimitHi = mean + 1.96 * std;
            double LimitLo = mean - 1.96 * std;
            OxyColor ColorHi = OxyColors.DarkRed;
            OxyColor ColorLo = OxyColors.DarkRed;

            chs.ColorMapping = (item) =>
            {
                if (item.RangeCenter > LimitHi)
                {
                    return ColorHi;
                }
                else if (item.RangeCenter < LimitLo)
                {
                    return ColorLo;
                }
                return chs.ActualFillColor;
            };

            model.Series.Add(chs);

            return model;
        }

        private IEnumerable<double> SampleNormal(Random rnd, double mean, double std, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return SampleNormal(rnd, mean, std);
            }
        }

        private double SampleNormal(Random rnd, double mean, double std)
        {
            // http://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
            var u1 = 1.0 - rnd.NextDouble();
            var u2 = rnd.NextDouble();
            return Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2) * std + mean;
        }

    }
}
