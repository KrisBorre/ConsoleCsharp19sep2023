using ConsolePersoon28sep2023;

namespace ConsoleEngine3oct2023
{
    internal class Car
    {
        private Person driver;

        public Person Driver { get { return driver; } }

        private List<Person> passengers = new List<Person>();

        public List<Person> Passengers { get { return passengers; } }

        public double Velocity { get; private set; }

        public string Brand { get; set; }

        public List<Wheel> Wheels;

        public Engine Engine { get; set; }

        public Car(string driverName, int driverAge, Engine.FuelType fuelType, string injection, Crankshaft.CrankType crank, int numberOfPistons)
        {
            this.driver = new Person(driverName, driverAge);
            Wheels = new List<Wheel>();
            for (int i = 0; i < 4; i++)
            {
                Wheels.Add(new Wheel(this, i));
            }
            this.Engine = new Engine(0.0, injection, crank, numberOfPistons);
            this.Engine.Car = this;
            this.Engine.EngineControlUnit = "Intel Processor Core i5";
            this.Engine.Fuel = fuelType;
            this.Engine.Sensor = Engine.SensorType.MAP;
            Velocity = 0.0;
        }

        public void Accelerate()
        {
            this.Velocity += 1.0;
            Console.WriteLine("accelerating");
        }

        public void Decelerate()
        {
            this.Velocity -= 1.0;
            Console.WriteLine("decelerating");
        }

        public void Stop()
        {
            this.Velocity = 0;
            Console.WriteLine("stopped");
        }
    }
}
