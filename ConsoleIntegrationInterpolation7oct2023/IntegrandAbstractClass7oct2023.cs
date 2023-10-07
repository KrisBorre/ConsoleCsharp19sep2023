namespace ConsoleIntegrationInterpolation7oct2023
{
    abstract class IntegrandAbstractClass7oct2023
    {
        public abstract double Function(double x);
    }

    class Square7oct2023 : IntegrandAbstractClass7oct2023
    {
        public override double Function(double x)
        {
            return x * x;
        }

        public override string ToString()
        {
            return "x^2";
        }
    }

    class ConstantTimesPower7oct2023 : IntegrandAbstractClass7oct2023
    {
        private double c, p;

        public ConstantTimesPower7oct2023(double constant = 4.0, double power = 0.5)
        {
            this.c = constant;
            this.p = power;
        }

        public override double Function(double x)
        {
            return c * Math.Pow(x, p);
        }

        public override string ToString()
        {
            return $"{c} x^{p:F2}";
        }
    }

    class Sinus7oct2023 : IntegrandAbstractClass7oct2023
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

    class Integrand1_7oct2023 : IntegrandAbstractClass7oct2023
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

    class Integrand2_7oct2023 : IntegrandAbstractClass7oct2023
    {
        private double p1, p2;
        // https://www.whitman.edu/mathematics/calculus_late_online/section10.05.html
        // Als power1 = 0.5 en power2 = 4 dan is de integraal van 0 tot 1 gelijk aan 1.089 ...

        public Integrand2_7oct2023(double power1 = 0.5, double power2 = 4)
        {
            p1 = power1;
            p2 = power2;
        }

        public override double Function(double x)
        {
            return Math.Pow(Math.Pow(x, p2) + 1, p1);
        }

        public override string ToString()
        {
            return $"Math.Pow(Math.Pow(x, {p2}) + 1, {p1})";
        }
    }
}
