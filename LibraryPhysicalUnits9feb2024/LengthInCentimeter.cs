namespace LibraryPhysicalUnits9feb2024
{
    public class LengthInCentimeter : ILength
    {
        private double m_LengthInCentimeter;
        private double m_PrecisionInCentimeter;

        public LengthInCentimeter(double lengthInCentimeter, double accuracyInCentimeter)
        {
            m_LengthInCentimeter = lengthInCentimeter;
            m_PrecisionInCentimeter = accuracyInCentimeter;
        }

        public double GetInCentimeter()
        {
            return m_LengthInCentimeter;
        }

        public double GetInKilometer()
        {
            return LengthCalculation.ConvertCentimeterIntoKilometer(m_LengthInCentimeter);
        }

        public double GetInMeter()
        {
            return LengthCalculation.ConvertCentimeterIntoMeter(m_LengthInCentimeter);
        }

        public double GetPrecisionInCentimeter()
        {
            return m_PrecisionInCentimeter;
        }

        public double GetPrecisionInMeter()
        {
            return LengthCalculation.ConvertCentimeterIntoMeter(m_PrecisionInCentimeter);
        }

        public override string ToString()
        {
            return m_LengthInCentimeter + " m";
        }



        public static LengthInMeter operator +(LengthInCentimeter a, LengthInCentimeter b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }

        public static LengthInMeter operator +(LengthInCentimeter a, LengthInKilometer b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }

        public static LengthInMeter operator +(LengthInKilometer a, LengthInCentimeter b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }
    }
}
