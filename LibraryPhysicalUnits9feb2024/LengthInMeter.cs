namespace LibraryPhysicalUnits9feb2024
{
    public class LengthInMeter : ILength
    {
        private double m_LengthInMeter;
        private double m_PrecisionInMeter;

        public LengthInMeter(double lengthInMeter, double accuracyInMeter)
        {
            m_LengthInMeter = lengthInMeter;
            m_PrecisionInMeter = accuracyInMeter;
        }

        public double GetInMeter()
        {
            return m_LengthInMeter;
        }

        public double GetInKilometer()
        {
            return LengthCalculation.ConvertMeterIntoKilometer(m_LengthInMeter);
        }

        public double GetInCentimeter()
        {
            return LengthCalculation.ConvertMeterIntoCentimeter(m_LengthInMeter);
        }

        public double GetPrecisionInMeter()
        {
            return m_PrecisionInMeter;
        }

        public override string ToString()
        {
            return m_LengthInMeter + " m";
        }

        public LengthInMeter MultiplyBy(double factor)
        {
            var result = new LengthInMeter(this.m_LengthInMeter * factor, this.m_PrecisionInMeter * factor);
            return result;
        }

        public static LengthInMeter operator *(double factor, LengthInMeter b)
        {
            var result = new LengthInMeter(factor * b.GetInMeter(), factor * b.GetPrecisionInMeter());
            return result;
        }

        public static LengthInMeter operator *(LengthInMeter a, double factor)
        {
            var result = new LengthInMeter(a.GetInMeter() * factor, a.GetPrecisionInMeter() * factor);
            return result;
        }

        public LengthInMeter DivideBy(double factor)
        {
            var result = new LengthInMeter(this.m_LengthInMeter / factor, this.m_PrecisionInMeter / factor);
            return result;
        }

        //public static InvertedLengthInMeter operator /(double factor, LengthInMeter b)
        //{
        //    var result = new InvertedLengthInMeter(factor / b.GetInMeter(), factor / b.GetPrecisionInMeter());
        //    return result;
        //}

        public static LengthInMeter operator /(LengthInMeter a, double factor)
        {
            var result = new LengthInMeter(a.GetInMeter() / factor, a.GetPrecisionInMeter() / factor);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInMeter a, LengthInMeter b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInMeter a, LengthInCentimeter b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInCentimeter a, LengthInMeter b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInMeter a, LengthInKilometer b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static AreaInSquareMeter operator *(LengthInKilometer a, LengthInMeter b)
        {
            var result = AreaCalculation.Multiply(a, b);
            return result;
        }

        public static LengthInMeter operator +(LengthInMeter a, LengthInCentimeter b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }

        public static LengthInMeter operator +(LengthInCentimeter a, LengthInMeter b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }

        public static LengthInMeter operator +(LengthInMeter a, LengthInKilometer b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }

        public static LengthInMeter operator +(LengthInKilometer a, LengthInMeter b)
        {
            var result = LengthCalculation.Add(a, b);
            return result;
        }
    }
}
