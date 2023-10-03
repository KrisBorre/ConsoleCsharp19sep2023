namespace ConsoleEngine3oct2023
{
    internal class Propeller
    {
        public enum ForceType { ThrustBending, CentrifugalTwisting, TorqueBending, Vibratory }

        public List<ForceType> Forces { get; set; }

        public enum RotatingType { Counter, Contra }

        public RotatingType Rotating { get; set; }

        public double AdvanceRatio { get; set; }

        public Boat Boat { get; set; }
    }
}
