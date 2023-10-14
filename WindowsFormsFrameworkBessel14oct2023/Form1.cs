using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsFrameworkBessel14oct2023
{
    public partial class Form1 : Form
    {
        private Chart chart2;

        public Form1()
        {
            InitializeComponent();

            // Add Reference -> Assemblies -> Framework -> System.Windows.Forms.DataVisualization -> check

            Text = "Bessel function";

            ChartArea chartArea2 = new ChartArea();
            Series series2 = new Series();
            chart2 = new Chart();
            chartArea2.Name = "ChartArea2";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Location = new Point(66, 35);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.Point;
            series2.Legend = "legend2";
            series2.Name = "series2";

            Bessel14oct2023_jy bessjy = new Bessel14oct2023_jy();

            const double minimum = -5;
            const double maximum = 15;
            const int AANTAL = 1000;
            for (int i = 1; i <= AANTAL; i++)
            {
                double x = (i / (double)AANTAL) * (maximum - minimum) + minimum;

                series2.Points.Add(new DataPoint(x, bessjy.j0(x)));
            }

            chart2.Dock = DockStyle.Fill;
            chart2.Series.Add(series2);
            chart2.Size = new Size(300, 300);
            chart2.TabIndex = 0;
            chart2.Text = "chart2";

            Controls.Add(chart2);
        }
    }
}
