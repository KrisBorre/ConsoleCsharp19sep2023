using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsFrameworkConsumptiePrijsIndex14oct2023
{
    public partial class Form1 : Form
    {
        private Chart chart2;

        public Form1()
        {
            InitializeComponent();

            // Drag and drop Combobox from Toolbox on Form

            Text = "Consumptie Prijs Index";

            ChartArea chartArea2 = new ChartArea();
            chart2 = new Chart();
            chartArea2.Name = "ChartArea2";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Location = new Point(0, 40);
            chart2.Name = "chart2";

            // jaar maand Consumptieprijsindex 
            // jaar maand Index_zonder_energetische_producten 
            // jaar maand Index_zonder_petroleum_producten 
            // jaar maand inflatie 
            // jaar maand gezondheidsindex 

            comboBox1.Items.AddRange(new string[] {
            "Consumptieprijsindex",
            "Index zonder energetische producten",
            "Index zonder petroleum producten",
            "Inflatie",
            "Gezondheidsindex"});
            comboBox1.SelectedIndex = 0;

            chart2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            chart2.Size = new Size(ClientSize.Width - chart2.Location.X, ClientSize.Height - chart2.Location.Y);
            chart2.TabIndex = 0;
            chart2.Text = "chart2";

            Controls.Add(chart2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Series series2 = new Series();
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.RangeColumn;
            series2.Legend = "legend2";
            series2.Name = "series2";

            StreamReader streamReader = new StreamReader(@"..\..\CPI_All_base_years.txt");

            const char delimiter = '|';

            string header = streamReader.ReadLine();
            string[] headerValues = header.Split(delimiter);

            foreach (string s in headerValues)
            {
                Console.Write(s + "\t");
            }
            Console.WriteLine();

            List<ConsumptieRecord> lijst = new List<ConsumptieRecord>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] values = line.Split(delimiter);

                if (values.Length != 10) Console.WriteLine("Vervelende record!");

                ConsumptieRecord record = new ConsumptieRecord();
                int j = 0;
                record.StringJaar = values[j++];
                record.StringMaand = values[j++];
                record.StringConsumptieprijsindex = values[j++];
                record.Index_zonder_energetische_producten = values[j++];
                record.Index_zonder_petroleum_producten = values[j++];
                record.StringWeging = values[j++];
                record.Inflatie = values[j++];
                record.Gezondheidsindex = values[j++];
                record.Afgevlakte_gezondheidsindex = values[j++];
                record.StringBasisjaar = values[j++];

                lijst.Add(record);
            }

            streamReader.Close();
            streamReader.Dispose();

            string strBasisjaar = "2004"; // "1953"; //"2004";
            int startJaar = 1920;

            if (comboBox1.SelectedIndex == 0)
            {
                // jaar maand Consumptieprijsindex (alle data)
                foreach (ConsumptieRecord record in lijst)
                {
                    if (record.StringBasisjaar == strBasisjaar && record.Jaar >= startJaar)
                    {
                        series2.Points.Add(new DataPoint(record.Jaar + record.Maand / 12.0, record.Consumptieprijsindex));
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // jaar maand Index_zonder_energetische_producten (vanaf 2006)
                foreach (ConsumptieRecord record in lijst)
                {
                    if (record.StringBasisjaar == strBasisjaar && record.Jaar >= Math.Max(2006, startJaar) && record.Index_zonder_energetische_producten != ".")
                    {
                        series2.Points.Add(new DataPoint(record.Jaar + record.Maand / 12.0, record.Index_zonder_energetische_producten));
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // jaar maand Index_zonder_petroleum_producten (vanaf 1997)
                foreach (ConsumptieRecord record in lijst)
                {
                    if (record.StringBasisjaar == strBasisjaar && record.Jaar >= Math.Max(1997, startJaar) && record.Index_zonder_petroleum_producten != ".")
                    {
                        series2.Points.Add(new DataPoint(record.Jaar + record.Maand / 12.0, record.Index_zonder_petroleum_producten));
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                // jaar maand inflatie (alle data)
                foreach (ConsumptieRecord record in lijst)
                {
                    if (record.StringBasisjaar == strBasisjaar && record.Jaar >= startJaar && record.Inflatie != ".")
                    {
                        series2.Points.Add(new DataPoint(record.Jaar + record.Maand / 12.0, record.Inflatie));
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                // jaar maand gezondheidsindex (vanaf 1994)
                foreach (ConsumptieRecord record in lijst)
                {
                    if (record.StringBasisjaar == strBasisjaar && record.Jaar >= Math.Max(1994, startJaar) && record.Gezondheidsindex != ".")
                    {
                        series2.Points.Add(new DataPoint(record.Jaar + record.Maand / 12.0, record.Gezondheidsindex));
                    }
                }
            }

            chart2.Series.Clear();
            chart2.Series.Add(series2);
        }
    }
}
