namespace LibraryPhysicalUnits9feb2024
{
    public class LengthCalculation
    {
        public static double ConvertCentimeterIntoKilometer(double length)
        {
            return length / 100000;
        }

        public static double ConvertKilometerIntoCentimeter(double length)
        {
            return length * 100000;
        }

        public static double ConvertMeterIntoKilometer(double length)
        {
            return length / 1000;
        }

        public static double ConvertKilometerIntoMeter(double length)
        {
            return length * 1000;
        }

        public static double ConvertMeterIntoCentimeter(double length)
        {
            return length * 100;
        }

        public static double ConvertCentimeterIntoMeter(double length)
        {
            return length / 100;
        }

        public static double ConvertMeterIntoFeet(double lengthInMeter)
        {
            return lengthInMeter / 0.3048;
        }

        public static double ConvertFeetIntoMeter(double lengthInFeet)
        {
            return lengthInFeet * 0.3048;
        }

        public static LengthInMeter Add(ILength length1, ILength length2)
        {
            double accuracy = Math.Sqrt(Math.Pow(length1.GetPrecisionInMeter(), 2) + Math.Pow(length2.GetPrecisionInMeter(), 2));
            return new LengthInMeter(length1.GetInMeter() + length2.GetInMeter(), accuracy);
        }
    }
}
