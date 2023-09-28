namespace ConsolePersoon28sep2023
{
    internal class Head
    {
        private bool hasHair;

        public bool HasHair
        {
            get { return hasHair; }
            set { hasHair = value; }
        }

        private double size;

        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public void Speak()
        {
            Console.WriteLine("talking ....");
        }
    }
}
