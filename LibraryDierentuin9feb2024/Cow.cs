using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public class Cow : Mammal
    {
        public Cow()
        {
            Weight = new WeightInKilogram9feb2024(500);
        }

        public void Melken()
        {
            Console.WriteLine("Melken ...");
            base.ToonInfo();
            feeding = Feeding.Omnivore;
            base.Eet();
        }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Melken();
        }

        public override void Speaks()
        {
            Console.WriteLine("boe boe boe");
        }

        public override string ToString()
        {
            return "Koe";
        }
    }
}
