namespace WinFormsOxyPlotHistogram24mar2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Normaal Verdeling";

            ControlManager controlManager = new ControlManager();

            foreach (Control control in controlManager.Controls)
            {
                this.Controls.Add(control);
            }
        }
    }
}
