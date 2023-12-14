namespace LibraryIntegration13nov2023
{
    public abstract class IntegrationAbstractClass7oct2023
    {
        protected IntegrandAbstractClass7oct2023 integrand;

        // Limits of integration and current value of integral.
        protected double a, b;

        protected int n;

        public IntegrationAbstractClass7oct2023(IntegrandAbstractClass7oct2023 integrand, double a, double b)
        {
            this.integrand = integrand;
            this.a = a;
            this.b = b;
            this.n = 0;
        }

        protected double? solution = null;

        public abstract double Next();

        public override string ToString()
        {
            return "Integral solution";
        }
    }
}
