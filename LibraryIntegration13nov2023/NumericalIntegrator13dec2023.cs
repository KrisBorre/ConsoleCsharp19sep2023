namespace LibraryIntegration13nov2023
{
    public enum Method
    {
        Midpoint,
        Trapezoidal
    };

    public class NumericalIntegrator13dec2023
    {
        private IntegrationAbstractClass7oct2023 integrationAbstractClass7oct2023;

        public NumericalIntegrator13dec2023(IntegrandAbstractClass7oct2023 integrand, double a, double b, Method method = Method.Trapezoidal)
        {
            switch (method)
            {
                case Method.Midpoint:
                    this.integrationAbstractClass7oct2023 = new IntegrationMidpoint7oct2023(integrand, a, b);
                    break;
                case Method.Trapezoidal:
                    this.integrationAbstractClass7oct2023 = new IntegrationTrapezoidal7oct2023(integrand, a, b);
                    break;
                default:
                    this.integrationAbstractClass7oct2023 = new IntegrationTrapezoidal7oct2023(integrand, a, b);
                    break;
            }
        }

        public double Next()
        {
            double solution = this.integrationAbstractClass7oct2023.Next();
            return solution;
        }

        public override string ToString()
        {
            return this.integrationAbstractClass7oct2023.ToString();
        }
    }
}
