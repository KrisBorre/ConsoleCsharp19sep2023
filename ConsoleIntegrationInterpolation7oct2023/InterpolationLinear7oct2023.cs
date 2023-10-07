namespace ConsoleIntegrationInterpolation7oct2023
{
    internal class InterpolationLinear7oct2023 : InterpolationAbstractClass7oct2023
    {
        public InterpolationLinear7oct2023(double[] xv, double[] yv) : base(xv, yv, 2)
        { }

        protected override double RawInterp(int j, double x)
        {
            if (xx[j] == xx[j + 1]) return yy[j];
            else return yy[j] + ((x - xx[j]) / (xx[j + 1] - xx[j])) * (yy[j + 1] - yy[j]);
        }
    }
}