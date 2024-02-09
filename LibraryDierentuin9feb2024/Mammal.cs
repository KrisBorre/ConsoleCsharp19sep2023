using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public class Mammal : Animal
    {
        public Mammal()
        {
            feeding = Feeding.Herbivore;
            Weight = new WeightInKilogram9feb2024(100);
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
