using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram20mar2024
{
    public partial class CustomItemMappingForm : Form
    {
        private PlotView plotView1;

        public CustomItemMappingForm()
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

            PlotModel plotModel = CustomItemMapping();
            Text = "OxyPlot CustomItemMapping";
            this.plotView1.Model = plotModel;
        }

        private static PlotModel CustomItemMapping()
        {
            var model = new PlotModel { Title = "Custom Item Mapping" };

            var s = new HistogramSeries { Mapping = obj => (HistogramItem)obj, TrackerFormatString = "{Description}" };
            s.Items.Add(new CustomHistogramItem(1, 2, 4, 4, "Item 1"));
            s.Items.Add(new CustomHistogramItem(2, 3, -4, 4, "Item 2"));
            s.Items.Add(new CustomHistogramItem(3, 4, 2, 2, "Item 3"));
            s.Items.Add(new CustomHistogramItem(4, 5, -2, 2, "Item 4"));
            model.Series.Add(s);

            return model;
        }

        private class CustomHistogramItem : HistogramItem
        {
            public CustomHistogramItem(double rangeStart, double rangeEnd, double area, int count, string description)
                : base(rangeStart, rangeEnd, area, count)
            {
                this.Description = description;
            }

            public string Description { get; }
        }
    }
}
