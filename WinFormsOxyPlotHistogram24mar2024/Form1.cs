using System.Diagnostics;
using System.Reflection;

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

            // loop through the assemblies that this app references 
            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                var a = Assembly.Load(new AssemblyName(r.FullName));

                // declare a variable to count the number of methods
                int methodCount = 0;

                // loop through all the types in the assembly 
                foreach (var t in a.DefinedTypes)
                {
                    // add up the counts of methods 
                    methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                Debug.WriteLine($"{a.DefinedTypes.Count():N0} types with {methodCount:N0} methods in {r.Name} assembly.");
            }

            // 0 types with 0 methods in System.Runtime assembly.
            // 57 types with 553 methods in System.Collections assembly.
            // 1 697 types with 70 339 methods in System.Windows.Forms assembly.
            // 9 types with 454 methods in OxyPlot.WindowsForms assembly.
            // 418 types with 11 941 methods in OxyPlot assembly.
            // 33 types with 281 methods in System.ComponentModel.Primitives assembly.
            // 21 types with 455 methods in System.Drawing.Primitives assembly.
            // 112 types with 1 190 methods in System.Linq assembly.
            // 1 372 types with 12 534 methods in System.Windows.Forms.Primitives assembly.
        }
    }
}
