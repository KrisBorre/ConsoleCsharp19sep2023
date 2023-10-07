namespace ConsoleIntegrationInterpolation7oct2023
{
    internal abstract class InterpolationAbstractClass7oct2023
    {
        private bool cor;
        protected int n, mm, jsav, dj;
        protected double[] xx;
        protected double[] yy;

        public InterpolationAbstractClass7oct2023(double[] x, double[] y, int m)
        {
            n = x.Length;
            mm = m;
            jsav = 0;
            cor = false;
            xx = x;
            yy = y;
            dj = Math.Max(1, (int)Math.Pow((double)n, 0.25));
        }

        public double Interp(double x)
        {
            int jlo = cor ? Hunt(x) : Locate(x);
            return RawInterp(jlo, x);
        }

        protected abstract double RawInterp(int jlo, double x);


        private int Locate(double x)
        {
            int ju, jm, jl;
            if (n < 2 || mm < 2 || mm > n) Console.WriteLine("Locate size error");
            bool ascnd = (xx[n - 1] >= xx[0]);
            jl = 0;
            ju = n - 1;
            while (ju - jl > 1)
            {
                jm = (ju + jl) >> 1;
                if (x >= xx[jm] == ascnd)
                    jl = jm;
                else
                    ju = jm;
            }
            cor = Math.Abs(jl - jsav) > dj ? false : true;
            jsav = jl;
            int result = Math.Max(0, Math.Min(n - mm, jl - ((mm - 2) >> 1)));
            return result;
        }

        private int Hunt(double x)
        {
            int jl = jsav, jm, ju, inc = 1;
            if (n < 2 || mm < 2 || mm > n) Console.WriteLine("Hunt size error");
            bool ascnd = (xx[n - 1] >= xx[0]);
            if (jl < 0 || jl > n - 1)
            {
                jl = 0;
                ju = n - 1;
            }
            else
            {
                if (x >= xx[jl] == ascnd)
                {
                    for (; ; )
                    {
                        ju = jl + inc;
                        if (ju >= n - 1) { ju = n - 1; break; }
                        else if (x < xx[ju] == ascnd) break;
                        else
                        {
                            jl = ju;
                            inc += inc;
                        }
                    }
                }
                else
                {
                    ju = jl;
                    for (; ; )
                    {
                        jl = jl - inc;
                        if (jl <= 0) { jl = 0; break; }
                        else if (x >= xx[jl] == ascnd) break;
                        else
                        {
                            ju = jl;
                            inc += inc;
                        }
                    }
                }
            }
            while (ju - jl > 1)
            {
                jm = (ju + jl) >> 1;
                if (x >= xx[jm] == ascnd)
                    jl = jm;
                else
                    ju = jm;
            }
            cor = Math.Abs(jl - jsav) > dj ? false : true;
            jsav = jl;
            int result = Math.Max(0, Math.Min(n - mm, jl - ((mm - 2) >> 1)));
            return result;
        }


    }
}
