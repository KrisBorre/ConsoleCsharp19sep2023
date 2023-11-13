namespace LibraryIntegration13nov2023
{
    public class IntegrationTrapezoidal7oct2023 : IntegrationAbstractClass7oct2023
    {
        private IntegrandAbstractClass7oct2023 integrand;

        public IntegrationTrapezoidal7oct2023(IntegrandAbstractClass7oct2023 integrand, double a, double b)
        {
            this.integrand = integrand;
            this.a = a;
            this.b = b;
            n = 0;
        }

        public override double Next()
        {
            double x, tnm, sum, del;
            int it, j;
            n++;

            if (n == 1)
            {
                s = 0.5 * (b - a) * (integrand.Function(a) + integrand.Function(b));
            }
            else // n != 1
            {
                for (it = 1, j = 1; j < n - 1; j++)
                {
                    it <<= 1;
                }

                tnm = it;

                del = (b - a) / tnm;

                x = a + 0.5 * del;

                for (sum = 0.0, j = 0; j < it; j++, x += del)
                {
                    sum += integrand.Function(x);
                }

                s = 0.5 * (s + (b - a) * sum / tnm);
            }

            return (double)s;
        }

        public override string ToString()
        {
            string result;

            result = base.ToString() + " of " + integrand + " using the extended trapezoidal rule is ";

            if (s == null) result += "not calculated yet.";
            else result += s.ToString();

            return result;
        }

    }
}
