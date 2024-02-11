// Source: Masoud Nazari (2016) on ResearchGate.net
// https://www.researchgate.net/publication/308901977_2d_Ising_model_simulation_code
// This code simulates 2d Ising model with any lattice size and can calculate the phase transition temperature 

// Dit programma heeft enkele minuten rekentijd nodig vooraleer het 2 grafieken toont.

// https://en.wikipedia.org/wiki/Ising_model

// Source: https://nl.wikipedia.org/wiki/Ising-model
// Het Ising-model is een theoretisch model uit de statistische mechanica dat een ferromagnetisch systeem modelleert.
// Zo'n systeem bestaat uit magnetische dipolen waarvan de spin ofwel opwaarts ofwel neerwaarts gericht is.
// In het model wordt dit voorgesteld door componenten die zich in twee discrete toestanden kunnen bevinden (+1 of -1).

// Het Ising-model werd bedacht door de fysicus Wilhelm Lenz.
// Aan Ernst Ising, een van zijn studenten, gaf hij de opdracht om te onderzoeken of een faseovergang mogelijk is in een eendimensionaal model.
// Dit bleek niet het geval. Als het model twee of meer dimensies bevat, kan wel een faseovergang optreden.

using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Series;

namespace WinFormsIsing2D11feb2024
{
    public partial class Form1 : Form
    {
        static Random r = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);
        //size of the lattice:
        static int L = 10;
        //array that used for storing configurations:
        static int[,] S;
        //number of the Monte Carlo steps:
        static int mcs = 10000;
        //number of the Monte Carlo steps:
        static int transient = 5000;
        static List<string> list = new List<string>();
        static double norm = 1.0 / (mcs * L * L);
        static int posx;
        static int posy;
        static int choose;
        static double Tc = 0;
        static double exactTc = Math.Round(2 / Math.Log(1 + Math.Sqrt(2)), 5);

        public Form1()
        {
            InitializeComponent();
            this.Text = "Ising Model 2D";

            //initiating variables and counters:
            double E = 0, E_avg = 0, etot = 0;
            double M = 0, M_avg = 0, mtot = 0;
            List<double> pM = new List<double>();
            List<double> pE = new List<double>();
            List<double> pT = new List<double>();

            Console.WriteLine("2d Ising model simulation:");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine("Please set parameters for simulation:\n");
            Console.Write("-Lattice size (for example: 10): ");
            //L = int.Parse(Console.ReadLine());
            L = 10;
            S = new int[L, L];
            Console.Write("-Number of the Monte Carlo steps (usually: 10000): ");
            //mcs = int.Parse(Console.ReadLine());
            mcs = 10000;
            Console.Write("-Number of transient steps (usually: 5000): ");
            //transient = int.Parse(Console.ReadLine());
            transient = 5000;
            Console.Write("-Temperature time steps (usually: 0.1): ");
            //double tts = double.Parse(Console.ReadLine());
            double tts = 0.1;
            //Console.Clear();
            Console.WriteLine("2d Ising model simulation:");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine("Temperature" + "\t" + "Magnetisation" + "\t" + "Energy");
            Console.WriteLine("________________________________________");

            //initialize lattice to starting configuration (all +1):
            initialize();

            //Temperature loop:
            for (double t = 1.0; t < 5.0; t += tts)
            {
                //transient phases:
                transient_results(t);

                //applying transient results to e and m:
                E = total("E");
                M = total("M");

                //initialize summation variables at each temperature step:
                etot = 0;
                mtot = 0;

                //Monte Carlo loop:
                for (int a = 1; a < mcs; a++)
                {
                    array_to_list();
                    //Metropolis loop:
                    for (int b = 1; b <= L * L; b++)
                    {
                        //choose random site and test filiping condition:
                        choose = choose_random_site("i", 0);
                        posx = choose_random_site("x", choose);
                        posy = choose_random_site("y", choose);
                        if (test_flip(posx, posy, t))
                        {
                            flip(posx, posy);
                            E += -2 * flip_energy(posx, posy);
                            M += 2 * S[posx, posy];
                        }
                        //remove choosed site to prevent repeating:
                        list.RemoveAt(choose);
                    }
                    etot += E / 2;
                    mtot += M;
                }
                //average observables:
                E_avg = etot * norm;
                M_avg = mtot * norm;

                //output data for ploting:
                pE.Add(E_avg);
                pM.Add(M_avg);
                pT.Add(t);
                if (Tc == 0)
                {
                    if (t > 1)
                    {
                        double ctc = Math.Abs(pM.ElementAt(pM.Count - 1)) - Math.Abs(pM.ElementAt(pM.Count - 2));
                        if (Math.Abs(ctc) > Math.Abs(pM.ElementAt(pM.Count - 2)) / 2.0)
                        {
                            Tc = pT.ElementAt(pT.Count - 2);
                        }
                    }
                }
                Console.WriteLine(t + "\t\t" + Math.Round(M_avg, 5) + "\t\t" + Math.Round(E_avg, 5));
            }

            //showing the exact and the simulated critical temperatures:
            Console.WriteLine("\n" + "     ---------------------------------------------------------------------");
            Console.WriteLine("     Exact critical temperature (according to Onsager's solution): " + exactTc);
            Console.WriteLine("     Simulated critical temperature                              : " + Tc);
            Console.WriteLine("     ---------------------------------------------------------------------" + "\n\n");

            ////plotting <M> and <E> versus T (GnuPlot is an open source class that you can download it freely and attach it to the program):
            //GnuPlot.Set("xlabel 'Temperature' font ',16'");
            //GnuPlot.Set("zeroaxis");
            ////<M>:
            //GnuPlot.Set("terminal wxt");
            //GnuPlot.HoldOn();
            //GnuPlot.Set("parametric");
            //GnuPlot.Plot("[0:1] 2.27, t with lines lc rgb 'gray' title 'exact critical temperature'");
            //GnuPlot.Plot("[0:1] " + Tc + ", t with lines lc rgb 'green' title 'simulated critical temperature'");
            //GnuPlot.Set("ylabel 'Magnetisation' font ',16'");
            //GnuPlot.Plot(pT.ToArray(), pM.ToArray(), "with points pt 7 ps 0.75 lc rgb 'blue' title '<M>'");

            var plotModel1 = new PlotModel { Title = "Magnetisation as a function of temperature" };
            var lineSeries1 = new LineSeries();
            lineSeries1.MarkerType = MarkerType.Circle;

            //Console.WriteLine("pT       " + "           " + "pM");
            for (int i = 0; i < pT.Count; i++)
            {
                //Console.WriteLine(pT[i].ToString() + "           " + pM[i].ToString());
                lineSeries1.Points.Add(new DataPoint(pT[i], pM[i]));
            }
            plotModel1.Series.Add(lineSeries1);
            plotModel1.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 2.27, Text = "exact critical temperature", Color = OxyColor.FromRgb(128, 128, 128) });
            plotModel1.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = Tc, Text = "simulated critical temperature", Color = OxyColor.FromRgb(0, 255, 0) });

            this.plotView1.Model = plotModel1;

            ////<E>:
            //GnuPlot.Set("terminal wxt 1");
            //GnuPlot.HoldOn();
            //GnuPlot.Set("parametric");
            //GnuPlot.Plot("[-2:0] 2.27, t with lines lc rgb 'gray' title 'exact critical temperature'");
            //GnuPlot.Plot("[-2:0] " + Tc + ", t with lines lc rgb 'green' title 'simulated critical temperature'");
            //GnuPlot.Set("ylabel 'Energy' font ',16'");
            //GnuPlot.Plot(pT.ToArray(), pE.ToArray(), "with points pt 7 ps 0.75 lc rgb 'red' title '<E>'");

            var plotModel2 = new PlotModel { Title = "Energy as a function of temperature" };
            var lineSeries2 = new LineSeries();
            lineSeries2.MarkerType = MarkerType.Circle;

            //Console.WriteLine("pT       " + "           " + "pE");
            for (int i = 0; i < pT.Count; i++)
            {
                //Console.WriteLine(pT[i].ToString() + "           " + pE[i].ToString());
                lineSeries2.Points.Add(new DataPoint(pT[i], pE[i]));
            }
            plotModel2.Series.Add(lineSeries2);
            plotModel2.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = 2.27, Text = "exact critical temperature", Color = OxyColor.FromRgb(128, 128, 128) });
            plotModel2.Annotations.Add(new LineAnnotation { Type = LineAnnotationType.Vertical, X = Tc, Text = "simulated critical temperature", Color = OxyColor.FromRgb(0, 255, 0) });

            this.plotView2.Model = plotModel2;

            /*
2d Ising model simulation:
--------------------------

Temperature     Magnetisation   Energy
________________________________________
1               0,9992          -2,00118
1,1             0,99847         -2,00258
1,2             0,9968          -2,00572
1,3             0,99484         -2,00937
1,4             0,99148         -2,01541
1,5             0,98604         -2,02486
1,6             0,98015         -2,0349
1,7             0,97011         -2,05074
1,8             0,95673         -2,07024
1,9             -0,93673                -1,85681
2               -0,91314                -1,34636
2,1             0,07134         -1,26908
2,2             0,27443         -1,44688
2,3             0,08618         -1,79482
2,4             -0,02505                -1,32305
2,5             -0,0838         -1,5687
2,6             0,01557         -0,47948
2,7             -0,00235                -1,84874
2,8             0,00559         -0,79564
2,9             0,01364         -0,8226
3               -0,01895                -0,66748
3,1             -0,01581                -0,4454
3,2             0,00544         -0,34277
3,3             -0,00071                -0,59963
3,4             0,00227         -0,43478
3,5             -0,005          -0,92914
3,6             -0,0007         -0,9416
3,7             0,00115         -0,35311
3,8             0,004           -0,48268
3,9             0,00218         -0,9719
4               0,00335         -0,02224
4,1             -0,00317                -0,57108
4,2             -0,00283                -0,33725
4,3             -0,00085                -0,34568
4,4             -0,00438                -0,53159
4,5             -0,00194                -0,23678
4,6             -0,00067                -0,72523
4,7             0,00071         -0,3114
4,8             -0,00015                -0,43519
4,9             -0,00188                -0,26094
5               -0,00136                -0,92552

   ---------------------------------------------------------------------
   Exact critical temperature (according to Onsager's solution): 2,26919
   Simulated critical temperature                              : 2
   ---------------------------------------------------------------------


pT                  pM
1           0,999198
1,1           0,99847
1,2           0,996802
1,3           0,994838
1,4           0,991484
1,5           0,986042
1,6           0,980152
1,7           0,97011
1,8           0,95673
1,9           -0,93673
2           -0,913142
2,1           0,071336
2,2           0,274428
2,3           0,086176
2,4           -0,025046
2,5           -0,083798
2,6           0,015572
2,7           -0,00235
2,8           0,005592
2,9           0,013644
3           -0,018946
3,1           -0,015812
3,2           0,005438
3,3           -0,000712
3,4           0,00227
3,5           -0,005002
3,6           -0,000702
3,7           0,001146
3,8           0,004004
3,9           0,002182
4           0,00335
4,1           -0,00317
4,2           -0,00283
4,3           -0,00085
4,4           -0,004378
4,5           -0,001936
4,6           -0,00067
4,7           0,000706
4,8           -0,000152
4,9           -0,001878
5           -0,001362

pT                  pE
1           -2,001178
1,1           -2,002578
1,2           -2,00572
1,3           -2,009374
1,4           -2,015406
1,5           -2,024864
1,6           -2,034898
1,7           -2,050738
1,8           -2,070236
1,9           -1,856814
2           -1,34636
2,1           -1,269084
2,2           -1,44688
2,3           -1,794816
2,4           -1,323054
2,5           -1,568698
2,6           -0,479478
2,7           -1,848744
2,8           -0,795638
2,9           -0,8226
3           -0,66748
3,1           -0,445396
3,2           -0,34277
3,3           -0,599634
3,4           -0,434776
3,5           -0,929142
3,6           -0,941604
3,7           -0,35311
3,8           -0,482682
3,9           -0,971896
4           -0,02224
4,1           -0,57108
4,2           -0,337246
4,3           -0,34568
4,4           -0,531592
4,5           -0,236782
4,6           -0,725234
4,7           -0,311402
4,8           -0,435194
4,9           -0,260938
5           -0,925524*/
        }

        private static void flip(int x, int y)
        {
            S[x, y] *= -1;
        }

        private static bool test_flip(int x, int y, double T)
        {
            double dE = -2.0 * flip_energy(x, y);
            if (dE <= 0)
            {
                return true;
            }
            else if (r.NextDouble() < Math.Exp(-dE / T))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int choose_random_site(string type, int c)
        {
            int v = 0;
            switch (type)
            {
                case "i":
                    v = r.Next(0, list.Count - 1);
                    break;

                case "x":
                    v = int.Parse(list.ElementAt(c).Substring(0, list.ElementAt(c).IndexOf(",")));
                    break;

                case "y":
                    v = int.Parse(list.ElementAt(c).Substring(list.ElementAt(c).IndexOf(",") + 1));
                    break;
            }
            return v;
        }

        private static void array_to_list()
        {
            for (int k = 0; k <= list.Count - 1; k++)
            {
                list.RemoveAt(k);
            }

            for (int i = 0; i <= L - 1; i++)
            {
                for (int j = 0; j <= L - 1; j++)
                {
                    list.Add(i + "," + j);
                }
            }
        }

        private static double total(string type)
        {
            double v = 0;
            switch (type)
            {
                case "E":
                    for (int x = 0; x <= L - 1; x++)
                    {
                        for (int y = 0; y <= L - 1; y++)
                        {
                            v += flip_energy(x, y);
                        }
                    }
                    break;

                case "M":
                    for (int x = 0; x <= L - 1; x++)
                    {
                        for (int y = 0; y <= L - 1; y++)
                        {
                            v += S[x, y];
                        }
                    }
                    break;
            }
            return v;
        }

        private static int flip_energy(int i, int j)
        {
            int up, down, left, right, e;
            if (i == 0)
                up = S[L - 1, j];
            else
                up = S[i - 1, j];
            if (i == L - 1)
                down = S[0, j];
            else
                down = S[i + 1, j];
            if (j == 0)
                left = S[i, L - 1];
            else
                left = S[i, j - 1];
            if (j == L - 1)
                right = S[i, 0];
            else
                right = S[i, j + 1];

            e = -1 * S[i, j] * (up + down + right + left);
            return e;
        }

        private static void transient_results(double T)
        {
            for (int a = 1; a <= transient; a++)
            {
                array_to_list();
                for (int b = 1; b <= L * L; b++)
                {
                    choose = choose_random_site("i", 0);
                    posx = choose_random_site("x", choose);
                    posy = choose_random_site("y", choose);
                    if (test_flip(posx, posy, T))
                    {
                        flip(posx, posy);
                    }
                    list.RemoveAt(choose);
                }
            }
        }

        private static void initialize()
        {
            for (int i = 0; i <= L - 1; i++)
            {
                for (int j = 0; j <= L - 1; j++)
                {
                    S[i, j] = 1;
                }
            }
        }
    }
}
