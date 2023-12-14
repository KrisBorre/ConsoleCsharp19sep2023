using System;
using System.Windows.Forms;

namespace WindowsFormsFrameworkBessel14oct2023
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static double sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        public static double abs(double x)
        {
            return Math.Abs(x);
        }

        public static double cos(double x)
        {
            return Math.Cos(x);
        }

        public static double sin(double x)
        {
            return Math.Sin(x);
        }

        public static double log(double x)
        {
            return Math.Log(x);
        }
    }
}
