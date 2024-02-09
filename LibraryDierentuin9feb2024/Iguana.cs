using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public class Iguana : Reptile
    {
        public Iguana()
        {
            Weight = new WeightInKilogram9feb2024(10);
        }

        public void Spring()
        {
            LegEieren();
            Console.WriteLine("Springen ...");
        }

        public override void ToonInfo()
        {
            Spring();
            base.ToonInfo();
        }

        public override void Speaks()
        {
            Console.WriteLine(".............");
        }

        public override string ToString()
        {
            return "Iguana";
        }
    }
}
