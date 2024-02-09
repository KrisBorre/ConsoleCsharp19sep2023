using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public class Dog : Mammal
    {
        public Dog()
        {
            Weight = new WeightInKilogram9feb2024(25);
        }

        public string Beschrijving { get; set; }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine("Beschrijving: " + Beschrijving);
            feeding = Feeding.Omnivore;
        }

        public override void Speaks()
        {
            Console.WriteLine("waf");
        }

        public override string ToString()
        {
            return "Hond";
        }
    }
}
