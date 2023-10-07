namespace ConsoleIntegrationInterpolation7oct2023
{
    internal class Engine
    {
        public class PowerData
        {
            public double Time;
            public double Power;

            public PowerData(double time, double power)
            {
                Time = time;
                Power = power;
            }
        }

        public enum FuelType
        {
            Diesel, Petrol
        }

        public enum SensorType
        {
            MAP, MAF
        }

        public string EngineControlUnit { get; set; }

        public FuelType Fuel { get; set; }

        public SensorType Sensor { get; set; }

        private Crankshaft crankshaft;
        private Piston[] pistons;

        public Car Car;
        public Boat Boat;

        public double[] Gear;

        public Engine(double displacement, string injection = "open", Crankshaft.CrankType crank = Crankshaft.CrankType.Full, int numberOfPistons = 4)
        {
            crankshaft = new Crankshaft(this);
            crankshaft.Displacement = displacement;
            crankshaft.Injection = injection;
            crankshaft.IsRotating = true;
            crankshaft.Crank = crank;

            pistons = new Piston[numberOfPistons];
            for (int i = 0; i < numberOfPistons; i++)
            {
                pistons[i] = new Piston(this);
                pistons[i].Name = $"Piston{i}";
                pistons[i].PistonType = "Rod";
            }

            Gear = new double[10];
            for (int i = 0; i < Gear.Length; i++)
            {
                Gear[i] = i;
            }

        }

    }
}

