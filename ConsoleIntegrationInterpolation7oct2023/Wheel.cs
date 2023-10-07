namespace ConsoleIntegrationInterpolation7oct2023
{
    internal class Wheel
    {
        public enum TireType { SyntheticRubber, NaturalRubber }

        public TireType Tire { get; set; }

        public int Number { get; set; }

        public string LoadSensitivity { get; set; }

        public int WorkLoad { get; set; }

        public enum WearType { None, Some, Damaged }

        public WearType Wear { get; set; }

        public Car Car { get; set; }

        public Wheel(Car car, int number, TireType tireType = TireType.SyntheticRubber)
        {
            this.Car = car;
            this.Number = number;
            this.Tire = tireType;
            this.Wear = WearType.None;
            this.WorkLoad = 0;
            this.LoadSensitivity = "Normal sensitivity";
        }
    }
}
