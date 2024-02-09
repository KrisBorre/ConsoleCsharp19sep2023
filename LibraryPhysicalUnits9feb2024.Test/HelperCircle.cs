namespace LibraryPhysicalUnits9feb2024.Test
{
    internal class HelperCircle
    {
        public static AreaInSquareMeter Square(LengthInMeter x)
        {
            return x * x;
        }

        public static LengthInMeter CalculateRadius(LengthInMeter diameter)
        {
            return diameter / 2;
        }

        // https://en.wikipedia.org/wiki/Circumference
        public static LengthInMeter CalculateCircumference(LengthInMeter diameter)
        {
            return 2 * Math.PI * CalculateRadius(diameter);
        }

        // https://en.wikipedia.org/wiki/Circle
        public static AreaInSquareMeter CalculateArea(LengthInMeter diameter)
        {
            return Math.PI * Square(CalculateRadius(diameter));
        }
    }
}
