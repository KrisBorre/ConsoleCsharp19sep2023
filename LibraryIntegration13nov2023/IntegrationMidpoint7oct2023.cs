namespace LibraryIntegration13nov2023
{
    public class IntegrationMidpoint7oct2023 : IntegrationAbstractClass7oct2023
    {
        public IntegrationMidpoint7oct2023(IntegrandAbstractClass7oct2023 integrand, double a, double b) : base(integrand, a, b)
        { }

        public override double Next()
        {
            int it, j;
            double x, tnm, sum, del, ddel;
            n++;

            if (n == 1)
            {
                solution = (b - a) * integrand.Function(0.5 * (a + b));
            }
            else // n != 1
            {
                for (it = 1, j = 1; j < n - 1; j++)
                {
                    it *= 3;
                }

                tnm = it;
                del = (b - a) / (3.0 * tnm);
                ddel = del + del;
                x = a + 0.5 * del;
                sum = 0.0;

                for (j = 0; j < it; j++)
                {
                    sum += integrand.Function(x);
                    x += ddel;
                    sum += integrand.Function(x);
                    x += del;
                }

                solution = (solution + (b - a) * sum / tnm) / 3.0;
            }

            return (double)solution;
        }

        public override string ToString()
        {
            string result;

            result = base.ToString() + " of " + integrand + " using the extended midpoint rule is ";

            if (solution == null) result += "not calculated yet.";
            else result += solution.ToString();

            return result;
        }

    }

}
