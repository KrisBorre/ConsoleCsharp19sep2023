namespace ConsoleDierentuin25sep2023
{
    public class Mammal : Animal
    {
        public Mammal()
        {
            feeding = Feeding.Herbivore;
            Weight = 100;
        }

        public bool IsPrimaat;

        private void Zogen()
        {
            Console.WriteLine("Zogen ...");
        }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine("Zoogdier");
            Console.WriteLine("IsPrimaat: " + IsPrimaat);
            Zogen();
        }

        public override void Speaks()
        {
            Console.WriteLine("mmmmmmm");
        }

        public override string ToString()
        {
            return "Zoogdier";
        }
    }
}
