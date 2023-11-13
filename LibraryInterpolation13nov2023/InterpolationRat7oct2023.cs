namespace LibraryInterpolation13nov2023
{
    public class InterpolationRat7oct2023 : InterpolationAbstractClass7oct2023
    {
        public double dy;

        public InterpolationRat7oct2023(double[] xv, double[] yv, int m) : base(xv, yv, m)
        {
            dy = 0;
        }

        protected override double RawInterp(int jl, double x)
        {
            const double TINY = 1.0e-99;
            int m, i, ns = 0;
            double y, w, t, hh, h, dd;

            double[] xa = new double[xx.Length - jl];
            Array.Copy(xx, jl, xa, 0, xx.Length - jl);
            double[] ya = new double[yy.Length - jl];
            Array.Copy(yy, jl, ya, 0, yy.Length - jl);

            double[] c = new double[mm];
            double[] d = new double[mm];

            hh = Math.Abs(x - xa[0]);
            for (i = 0; i < mm; i++)
            {
                h = Math.Abs(x - xa[i]);
                if (h == 0.0)
                {
                    dy = 0.0;
                    return ya[i];
                }
                else if (h < hh)
                {
                    ns = i;
                    hh = h;
                }
                c[i] = ya[i];
                d[i] = ya[i] + TINY;
            }
            y = ya[ns--];
            for (m = 1; m < mm; m++)
            {
                for (i = 0; i < mm - m; i++)
                {
                    w = c[i + 1] - d[i];
                    h = xa[i + m] - x;
                    t = (xa[i] - x) * d[i] / h;
                    dd = t - c[i + 1];
                    if (dd == 0.0) Console.WriteLine("Error in InterpolationRat7oct2023::RawInterp");
                    dd = w / dd;
                    d[i] = c[i + 1] * dd;
                    c[i] = t * dd;
                }
                y += (dy = (2 * (ns + 1) < (mm - m) ? c[ns + 1] : d[ns--]));
            }
            return y;

        }
    }
}

