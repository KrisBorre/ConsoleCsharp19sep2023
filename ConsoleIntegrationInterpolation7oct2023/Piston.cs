namespace ConsoleIntegrationInterpolation7oct2023
{
    internal class Piston
    {
        private Engine engine;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string pistonType;

        public string PistonType
        {
            get { return pistonType; }
            set { pistonType = value; }
        }

        public Piston(Engine engine)
        {
            this.engine = engine;
        }
    }
}