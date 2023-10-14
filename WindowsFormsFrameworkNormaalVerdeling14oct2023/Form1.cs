using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsFrameworkNormaalVerdeling14oct2023
{
    public partial class Form1 : Form
    {
        private Random14oct2023 gasdev;

        private Chart chart2;

        public Form1()
        {
            InitializeComponent();

            Text = "Normaal verdeling";

            ChartArea chartArea2 = new ChartArea();
            chart2 = new Chart();
            chartArea2.Name = "ChartArea2";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Location = new Point(0, 40);
            chart2.Name = "chart2";           

            chart2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            chart2.Size = new Size(ClientSize.Width - chart2.Location.X, ClientSize.Height - chart2.Location.Y);
            chart2.TabIndex = 0;
            chart2.Text = "chart2";

            Controls.Add(chart2);

            comboBox1.Items.AddRange(new object[] {
            "Normaal Verdeling Box Muller",
            "Normaal Verdeling Leva 1992"});

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Series series2 = new Series();
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.RangeColumn;
            series2.Legend = "legend2";
            series2.Name = "series2";

            double variantie_breed = 10.0;
            const int NPTS = 2000; // Aantal punten in histogram.
            const int N = 30; // 20; // N is het aantal histogrambalken.
            const int NOVER2 = N / 2;
            ulong zaadje = (ulong)(5);
            if (gasdev != null) { zaadje = gasdev.int64(); }

            double x6;
            int[] dist = new int[N + 1];

            if (comboBox1.SelectedIndex == 0)
            {
                gasdev = new NormaalVerdeling_BoxMuller_14oct2023(0.0, variantie_breed, zaadje);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                gasdev = new NormaalVerdeling_Leva1992_14oct2023(0.0, variantie_breed, zaadje);
            }

            for (int j = 0; j <= N; j++) dist[j] = 0;

            for (int i = 0; i < NPTS; i++)
            {
                x6 = 0.025 * N * gasdev.Afwijking();
                int j = (int)(x6 > 0 ? x6 + 0.5 : x6 - 0.5);
                if ((j >= -NOVER2) && (j <= NOVER2)) ++dist[j + NOVER2];
            }

            for (int j = 0; j <= N; j++)
            {
                series2.Points.Add(new DataPoint(j + 1, dist[j]));
            }

            chart2.Series.Clear();
            chart2.Series.Add(series2);
        }
    }
}
