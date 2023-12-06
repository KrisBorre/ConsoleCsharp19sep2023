namespace LibraryInterpolation13nov2023
{
    public enum Method
    {
        Linear,
        Poly,
        Rat,
        Spline
    };

    public class NumericalInterpolator6dec2023
    {
        private InterpolationAbstractClass7oct2023 interpolationAbstractClass7oct2023;

        public double? dy { get; private set; }

        public NumericalInterpolator6dec2023(double[] x, double[] y, Method method = Method.Linear, int m = 2)
        {
            switch (method)
            {
                case Method.Linear:
                    interpolationAbstractClass7oct2023 = new InterpolationLinear7oct2023(x, y);
                    break;
                case Method.Poly:
                    interpolationAbstractClass7oct2023 = new InterpolationPoly7oct2023(x, y, m);
                    break;
                case Method.Rat:
                    interpolationAbstractClass7oct2023 = new InterpolationRat7oct2023(x, y, m);
                    break;
                case Method.Spline:
                    interpolationAbstractClass7oct2023 = new InterpolationSpline7oct2023(x, y);
                    break;
                default:
                    interpolationAbstractClass7oct2023 = new InterpolationLinear7oct2023(x, y);
                    break;
            }
        }

        public double Interpolate(double x)
        {
            double result = interpolationAbstractClass7oct2023.Interp(x);
            if (interpolationAbstractClass7oct2023 is InterpolationPoly7oct2023)
            {
                dy = (interpolationAbstractClass7oct2023 as InterpolationPoly7oct2023)?.dy;
            }
            else if (interpolationAbstractClass7oct2023 is InterpolationRat7oct2023)
            {
                dy = (interpolationAbstractClass7oct2023 as InterpolationRat7oct2023)?.dy;
            }
            return result;
        }
    }
}
