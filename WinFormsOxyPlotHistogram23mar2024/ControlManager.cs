using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram23mar2024
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

            HistogramSeries chs = new HistogramSeries();
            var binningOptions = new BinningOptions(BinningOutlierMode.CountOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.ExcludeExtremeValues);
            var binBreaks = HistogramHelpers.CreateUniformBins(start: -std * 4, end: std * 4, binCount: 75);
            chs.Items.AddRange(HistogramHelpers.Collect(SampleNormal(mean, std, n), binBreaks, binningOptions));
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

        private IEnumerable<double> SampleNormal(double mean, double std, int count)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                yield return SampleNormal(rnd, mean, std);
            }
        }

        private double SampleNormal(Random rnd, double mean, double std)
        {
            ulong zaadje = (ulong)rnd.NextInt64();

            Method method = Method.BoxMuller;

            NormaalVerdeling6dec2023 gasdev = new NormaalVerdeling6dec2023(gemiddelde: mean, variantie: std, zaadje: zaadje, method: method);

            return gasdev.Afwijking();
        }

    }
}
