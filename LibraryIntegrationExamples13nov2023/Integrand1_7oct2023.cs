using LibraryIntegration13nov2023;

namespace LibraryIntegrationExamples13nov2023
{
    public class Integrand1_7oct2023 : IntegrandAbstractClass7oct2023
    {
        private double p;
        // https://www.whitman.edu/mathematics/calculus_late_online/section10.05.html
        // Integraal oplossing is 0.6438 ... als p = 0.5 en integraal is van 0 tot 1

        public Integrand1_7oct2023(double power = 0.5)
        {
            p = power;
        }

        public override double Function(double x)
        {
            return x * Math.Pow(1 + x, p);
        }

        public override string ToString()
        {
            return $"x * Math.Pow(1+x,{p:F1})";
        }
    }
}
