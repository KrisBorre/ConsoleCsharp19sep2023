namespace LibraryInterpolation13nov2023
{
    public class InterpolationPoly7oct2023 : InterpolationAbstractClass7oct2023
    {
        public double dy;

        public InterpolationPoly7oct2023(double[] xv, double[] yv, int m) : base(xv, yv, m)
        {
            dy = 0;
        }

        protected override double RawInterp(int jl, double x)
        {
            int i, m, ns = 0;
            double y, den, dif, dift, ho, hp, w;


            double[] xa = new double[xx.Length - jl];
            Array.Copy(xx, jl, xa, 0, xx.Length - jl);
            double[] ya = new double[yy.Length - jl];
            Array.Copy(yy, jl, ya, 0, yy.Length - jl);

            double[] c = new double[mm];
            double[] d = new double[mm];

            dif = Math.Abs(x - xa[0]);
            for (i = 0; i < mm; i++)
            {
                if ((dift = Math.Abs(x - xa[i])) < dif)
                {
                    ns = i;
                    dif = dift;
                }
                c[i] = ya[i];
                d[i] = ya[i];
            }
            y = ya[ns--];
            for (m = 1; m < mm; m++)
            {
                for (i = 0; i < mm - m; i++)
                {
                    ho = xa[i] - x;
                    hp = xa[i + m] - x;
                    w = c[i + 1] - d[i];
                    if ((den = ho - hp) == 0.0) Console.WriteLine("InterpolationPoly7oct2023::RawInterp error");
                    den = w / den;
                    d[i] = hp * den;
                    c[i] = ho * den;
                }
                y += (dy = (2 * (ns + 1) < (mm - m) ? c[ns + 1] : d[ns--]));
            }
            return y;
        }
    }
}

