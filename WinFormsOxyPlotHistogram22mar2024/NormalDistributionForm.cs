namespace WinFormsOxyPlotHistogram22mar2024
{
    public partial class NormalDistributionForm : Form
    {
        public NormalDistributionForm()
        {
            InitializeComponent();

            this.Text = "OxyPlot CreateNormalDistribution";

            ControlManager controlManager = new ControlManager();

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
