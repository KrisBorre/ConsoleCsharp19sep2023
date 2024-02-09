namespace LibraryPhysicalUnits9feb2024
{
    public class WeightInPounds9feb2024 : IWeight7feb2024
    {
        private double m_WeightInPounds;
        private double m_PrecisionInPounds;

        public WeightInPounds9feb2024(double weightInPounds, double precisionInPounds = 0)
        {
            m_WeightInPounds = weightInPounds;
            m_PrecisionInPounds = precisionInPounds;
        }

        public double GetInPounds()
        {
            return m_WeightInPounds;
        }

        public double GetInKilogram()
        {
            return WeightCalculation7feb2024.ConvertPoundsIntoKilogram(m_WeightInPounds);
        }

        public double GetInTon()
        {
            return WeightCalculation7feb2024.ConvertPoundsIntoTon(m_WeightInPounds);
        }

        public double GetPrecisionInPounds()
        {
            return m_PrecisionInPounds;
        }

        public double GetPrecisionInKilogram()
        {
            return WeightCalculation7feb2024.ConvertPoundsIntoKilogram(m_PrecisionInPounds);
        }

        public IWeight7feb2024 MultiplyBy(double factor)
        {
            var result = new WeightInPounds9feb2024(this.m_WeightInPounds * factor);
            return result;
        }

        public static WeightInPounds9feb2024 operator *(double factor, WeightInPounds9feb2024 b)
        {
            var result = new WeightInPounds9feb2024(factor * b.GetInPounds());
            return result;
        }

        public static WeightInPounds9feb2024 operator *(WeightInPounds9feb2024 a, double factor)
        {
            var result = new WeightInPounds9feb2024(a.GetInPounds() * factor);
            return result;
        }

        public override string ToString()
        {
            return m_WeightInPounds + " lbs";
        }

        public WeightInPounds9feb2024 DivideBy(double factor)
        {
            var result = new WeightInPounds9feb2024(this.m_WeightInPounds / factor, this.m_PrecisionInPounds / factor);
            return result;
        }

        public static WeightInPounds9feb2024 operator /(WeightInPounds9feb2024 a, double factor)
        {
            var result = new WeightInPounds9feb2024(a.GetInPounds() / factor);
            return result;
        }
    }
}
