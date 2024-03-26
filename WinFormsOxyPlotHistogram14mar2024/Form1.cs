using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WinFormsOxyPlotHistogram14mar2024
{
    public partial class Form1 : Form
    {
        private PlotView plotView1;

        public Form1()
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

            PlotModel plotModel = HistogramLabelPlacement();
            PlotModel reversedPlotModel = ReverseYAxis(plotModel);
            Text = "OxyPlot HistogramLabelPlacement ReverseYAxis";
            this.plotView1.Model = reversedPlotModel;
        }

        /// <summary>
        /// Reverses the Y Axis of a PlotModel. The given PlotModel is mutated and returned for convenience.
        /// </summary>
        /// <param name="model">The PlotModel.</param>
        /// <returns>The PlotModel with reversed Y Axis.</returns>
        public static PlotModel ReverseYAxis(PlotModel model)
        {
            if (!string.IsNullOrEmpty(model.Title))
            {
                model.Title += " (reversed Y Axis)";
            }

            var foundYAxis = false;
            foreach (var axis in model.Axes)
            {
                switch (axis.Position)
                {
                    case AxisPosition.Left:
                        axis.StartPosition = 1 - axis.StartPosition;
                        axis.EndPosition = 1 - axis.EndPosition;
                        foundYAxis = true;
                        break;
                    case AxisPosition.Bottom:
                    case AxisPosition.Right:
                    case AxisPosition.Top:
                    case AxisPosition.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (!foundYAxis)
            {
                model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, StartPosition = 1, EndPosition = 0 });
            }

            return model;
        }

        public static PlotModel HistogramLabelPlacement()
        {
            var model = new PlotModel { Title = "Label Placement" };

            var s1 = new HistogramSeries { LabelPlacement = LabelPlacement.Base, LabelFormatString = "Base", StrokeThickness = 1, LabelMargin = 5 };
            var s2 = new HistogramSeries { LabelPlacement = LabelPlacement.Inside, LabelFormatString = "Inside", StrokeThickness = 1, LabelMargin = 5 };
            var s3 = new HistogramSeries { LabelPlacement = LabelPlacement.Middle, LabelFormatString = "Middle", StrokeThickness = 1, LabelMargin = 5 };
            var s4 = new HistogramSeries { LabelPlacement = LabelPlacement.Outside, LabelFormatString = "Outside", StrokeThickness = 1, LabelMargin = 5 };

            s1.Items.Add(new HistogramItem(1, 2, 4, 4));
            s1.Items.Add(new HistogramItem(2, 3, -4, 4));
            s2.Items.Add(new HistogramItem(3, 4, 2, 2));
            s2.Items.Add(new HistogramItem(4, 5, -2, 2));
            s3.Items.Add(new HistogramItem(5, 6, 3, 3));
            s3.Items.Add(new HistogramItem(6, 7, -3, 3));
            s4.Items.Add(new HistogramItem(7, 8, 1, 1));
            s4.Items.Add(new HistogramItem(8, 9, -1, -1));

            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Series.Add(s3);
            model.Series.Add(s4);

            return model;
        }
    }
}
