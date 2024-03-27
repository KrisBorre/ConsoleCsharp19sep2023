using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram17mar2024
{
    public partial class DisconnectedBinsForm : Form
    {
        private PlotView plotView1;

        public DisconnectedBinsForm()
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

            PlotModel plotModel = CreateDisconnectedBins();
            Text = "OxyPlot CreateDisconnectedBins";
            this.plotView1.Model = plotModel;
        }

        private static PlotModel CreateDisconnectedBins()
        {
            var model = new PlotModel { Title = "Disconnected Bins" };
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Representation" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x" });

            HistogramSeries chs = new HistogramSeries();
            chs.Items.AddRange(new[] { new HistogramItem(0, 0.5, 10, 7), new HistogramItem(0.75, 1.0, 10, 7) });
            chs.LabelFormatString = "{0:0.00}";
            chs.LabelPlacement = LabelPlacement.Middle;
            model.Series.Add(chs);

            return model;
        }
    }
}
