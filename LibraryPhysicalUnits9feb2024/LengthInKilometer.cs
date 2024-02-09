namespace LibraryPhysicalUnits9feb2024
{
    public class LengthInKilometer : ILength
    {
        private double m_LengthInKilometer;
        private double m_PrecisionInKilometer;

        public LengthInKilometer(double lengthInKilometer, double accuracyInKilometer)
        {
            m_LengthInKilometer = lengthInKilometer;
            m_PrecisionInKilometer = accuracyInKilometer;
        }

        public double GetInKilometer()
        {
            return m_LengthInKilometer;
        }

        public double GetInMeter()
        {
            return LengthCalculation.ConvertKilometerIntoMeter(m_LengthInKilometer);
        }

        public double GetInCentimeter()
        {
            return LengthCalculation.ConvertKilometerIntoCentimeter(m_LengthInKilometer);
        }

        public double GetPrecisionInKilometer()
        {
            return m_PrecisionInKilometer;
        }

        public double GetPrecisionInMeter()
        {
            return LengthCalculation.ConvertKilometerIntoMeter(m_PrecisionInKilometer);
        }

        public override string ToString()
        {
            return m_LengthInKilometer + " km";
        }


    }
}
