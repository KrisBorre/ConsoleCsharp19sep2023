namespace ConsoleIntegrationInterpolation7oct2023
{
    internal class Crankshaft
    {
        public enum CrankType
        {
            Full, Half
        }

        public double Displacement { get; set; }

        public string Injection { get; set; }

        private CrankType crank;

        public CrankType Crank
        {
            get { return crank; }
            set { crank = value; }
        }


        private bool isRotating;

        public bool IsRotating
        {
            get { return isRotating; }
            set { isRotating = value; }
        }

        private Engine engine;

        public Crankshaft(Engine engine)
        {
            this.engine = engine;
        }

    }
}
