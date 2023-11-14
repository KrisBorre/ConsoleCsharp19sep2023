using LibraryIntegration13nov2023;

namespace LibraryFunctionExamples13nov2023
{
    public class Sinus7oct2023 : IntegrandAbstractClass7oct2023
    {
        public override double Function(double x)
        {
            return Math.Sin(x);
        }

        public override string ToString()
        {
            return "sin(x)";
        }
    }
}
