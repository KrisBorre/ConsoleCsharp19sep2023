namespace LibraryIntegration13nov2023
{
    public abstract class IntegrationAbstractClass7oct2023
    {
        protected int n;

        // Limits of integration and current value of integral.
        protected double a, b;
        protected double? s = null;

        public abstract double Next();

        public override string ToString()
        {
            return "Integral solution";
        }
    }
}
