using ConsolePersoon28sep2023;

namespace ConsoleEngine3oct2023
{
    internal class Boat
    {
        public enum ShipType
        {
            Yacht, Motorboat, Sail, Container, RollOnRollOff, SuperYacht
        }

        public ShipType BoatType { get; set; }

        public Person Captain { get; set; }

        public List<Person> Crew { get; set; }

        public List<Person> Passengers { get; set; }

        public string Transport { get; set; }

        public Engine Engine { get; set; }

        public Propeller[] propellers;

        public Boat Tender { get; set; }

        public Boat(int numberOfPropellers, string captianName, int captianAge, string engineControlUnit, double engineDisplacement, Engine.SensorType sensor = Engine.SensorType.MAF, ShipType shipType = ShipType.SuperYacht, Engine.FuelType fuel = Engine.FuelType.Diesel)
        {
            propellers = new Propeller[numberOfPropellers];
            for (int i = 0; i < numberOfPropellers; i++)
            {
                Propeller p = new Propeller();
                p.Boat = this;
                propellers[i] = p;
            }
            this.Engine = new Engine(engineDisplacement, crank: Crankshaft.CrankType.Half);
            this.Engine.Boat = this;
            this.Engine.EngineControlUnit = engineControlUnit;
            this.Engine.Fuel = fuel;
            this.Engine.Sensor = sensor;
            this.Captain = new Person(captianName, captianAge);
            this.BoatType = shipType;
        }
    }
}
