namespace LibraryInterpolation13nov2023
{
    public class InterpolationSpline7oct2023 : InterpolationAbstractClass7oct2023
    {
        private double[] y2;

        public InterpolationSpline7oct2023(double[] xv, double[] yv, double yp1 = 1.0E+99, double ypn = 1.0E+99) : base(xv, yv, 2)
        {
            y2 = new double[xv.Length];
            Sety2(xv, yv, yp1, ypn);
        }

        private void Sety2(double[] xv, double[] yv, double yp1, double ypn)
        {
            int i, k;
            double p, qn, sig, un;
            double[] u = new double[n - 1];
            if (yp1 > 0.99E99)
            {
                y2[0] = u[0] = 0.0;
            }
            else
            {
                y2[0] = -0.5;
                u[0] = (3.0 / (xv[1] - xv[0])) * ((yv[1] - yv[0]) / (xv[1] - xv[0]) - yp1);
            }
            for (i = 1; i < n - 1; i++)
            {
                sig = (xv[i] - xv[i - 1]) / (xv[i + 1] - xv[i - 1]);
                p = sig * y2[i - 1] + 2.0;
                y2[i] = (sig - 1.0) / p;
                u[i] = (yv[i + 1] - yv[i]) / (xv[i + 1] - xv[i]) - (yv[i] - yv[i - 1]) / (xv[i] - xv[i - 1]);
                u[i] = (6.0 * u[i] / (xv[i + 1] - xv[i - 1]) - sig * u[i - 1]) / p;
            }
            if (ypn > 0.99E99)
            {
                qn = un = 0.0;
            }
            else
            {
                qn = 0.5;
                un = (3.0 / (xv[n - 1] - xv[n - 2])) * (ypn - (yv[n - 1] - yv[n - 2]) / (xv[n - 1] - xv[n - 2]));
            }
            y2[n - 1] = (un - qn * u[n - 2]) / (qn * y2[n - 2] + 1.0);
            for (k = n - 2; k >= 0; k--)
            {
                y2[k] = y2[k] * y2[k + 1] + u[k];
            }
        }

        protected override double RawInterp(int jl, double x)
        {
            int klo = jl, khi = jl + 1;
            double y, h, b, a;
            h = xx[khi] - xx[klo];
            if (h == 0.0) Console.WriteLine("Bad input to routine InterpolationSpline7oct2023::RawInterp");
            a = (xx[khi] - x) / h;
            b = (x - xx[klo]) / h;
            y = a * yy[klo] + b * yy[khi] + ((a * a * a - a) * y2[klo] + (b * b * b - b) * y2[khi]) * (h * h) / 6.0;
            return y;
        }
    }
}

