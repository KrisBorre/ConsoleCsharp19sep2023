using ConsolePersoon28sep2023;

namespace ConsoleIntegrationInterpolation7oct2023
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

        public List<Person> DiveCrew { get; set; }

        public string Transport { get; set; }

        private List<MotionData> Pitch { get; set; }

        private InterpolationAbstractClass7oct2023 interpolationPitch;

        private List<MotionData> Roll { get; set; }

        private InterpolationAbstractClass7oct2023 interpolationRoll;

        private List<MotionData> Yaw { get; set; }

        private InterpolationAbstractClass7oct2023 interpolationYaw;

        private List<Engine.PowerData> Power { get; set; }

        public InterpolationAbstractClass7oct2023 InterpolationPower;

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

        private void ReadMotion()
        {
            Yaw = new List<MotionData>();
            Yaw.Add(new MotionData(0, 2));
            Yaw.Add(new MotionData(5, 1));
            Yaw.Add(new MotionData(10, 3));

            Roll = new List<MotionData>();
            Roll.Add(new MotionData(0, 2));
            Roll.Add(new MotionData(2, 1));
            Roll.Add(new MotionData(6, 3));
            Roll.Add(new MotionData(8, 3));
            Roll.Add(new MotionData(10, 1));

            Pitch = new List<MotionData>();
            Pitch.Add(new MotionData(0, 0));
            Pitch.Add(new MotionData(2, 1));
            Pitch.Add(new MotionData(3, 2));
            Pitch.Add(new MotionData(4, 1));
            Pitch.Add(new MotionData(7, 0.5));
            Pitch.Add(new MotionData(8, 3));
            Pitch.Add(new MotionData(10, 1));
        }

        private void InitializeMotion()
        {
            ReadMotion();
            double[] time = new double[Yaw.Count];
            double[] angle = new double[Yaw.Count];
            for (int i = 0; i < Yaw.Count; i++)
            {
                time[i] = Yaw[i].X;
                angle[i] = Yaw[i].Y;
            }
            this.interpolationYaw = new InterpolationSpline7oct2023(time, angle);
            time = new double[Roll.Count];
            angle = new double[Roll.Count];
            for (int i = 0; i < Roll.Count; i++)
            {
                time[i] = Roll[i].X;
                angle[i] = Roll[i].Y;
            }
            this.interpolationRoll = new InterpolationSpline7oct2023(time, angle);
            time = new double[Pitch.Count];
            angle = new double[Pitch.Count];
            for (int i = 0; i < Pitch.Count; i++)
            {
                time[i] = Pitch[i].X;
                angle[i] = Pitch[i].Y;
            }
            this.interpolationPitch = new InterpolationSpline7oct2023(time, angle);
        }

        private void CalculatePower()
        {
            InitializeMotion();
            Power = new List<Engine.PowerData>();
            const double timeInterval = 10;
            const int powerPoints = 1000;
            double[] time = new double[powerPoints];
            double[] power = new double[powerPoints];
            for (int i = 0; i < powerPoints; i++)
            {
                time[i] = (i * timeInterval) / powerPoints;
                power[i] = interpolationYaw.Interp(time[i]) + this.Engine.Gear[(int)time[i]] * Math.Pow(interpolationRoll.Interp(time[i]), 2) + Math.Pow(interpolationPitch.Interp(time[i]), 3);
                Power.Add(new Engine.PowerData(time[i], power[i]));
            }

            this.InterpolationPower = new InterpolationLinear7oct2023(time, power);
        }

        /// <summary>
        /// time mag maximaal 10 zijn. Minimum 0.
        /// </summary>
        public double GetSpeed(double time = 10)
        {
            CalculatePower();
            double speed = 0;

            PowerFunction powerFunction = new PowerFunction(this);

            IntegrationTrapezoidal7oct2023 integrationTrapezoidal2 = new IntegrationTrapezoidal7oct2023(powerFunction, 0.0, time);
            for (int j = 1; j <= 5; j++)
            {
                speed = integrationTrapezoidal2.Next();
            }
            return speed;
        }


        class MotionData
        {
            public double X;
            public double Y;

            public MotionData(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }

    class PowerFunction : IntegrandAbstractClass7oct2023
    {
        private Boat boat;

        public PowerFunction(Boat boat)
        {
            this.boat = boat;
        }

        public override double Function(double time)
        {
            return boat.InterpolationPower.Interp(time);
        }

    }

}

