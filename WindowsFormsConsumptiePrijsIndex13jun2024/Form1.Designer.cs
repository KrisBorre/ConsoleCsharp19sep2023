namespace WindowsFormsConsumptiePrijsIndex13jun2024
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            oxyPlotControl = new OxyPlot.WindowsForms.PlotView();
            SuspendLayout();
            // 
            // oxyPlotControl
            // 
            oxyPlotControl.Location = new Point(12, 12);
            oxyPlotControl.Name = "oxyPlotControl";
            oxyPlotControl.PanCursor = Cursors.Hand;
            oxyPlotControl.Size = new Size(699, 375);
            oxyPlotControl.TabIndex = 0;
            oxyPlotControl.Text = "plotView1";
            oxyPlotControl.ZoomHorizontalCursor = Cursors.SizeWE;
            oxyPlotControl.ZoomRectangleCursor = Cursors.SizeNWSE;
            oxyPlotControl.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 399);
            Controls.Add(oxyPlotControl);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView oxyPlotControl;
    }
}
