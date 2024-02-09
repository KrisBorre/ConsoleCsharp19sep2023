using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public class Snake : Reptile
    {
        public Snake()
        {
            Weight = new WeightInKilogram9feb2024(3);
            feeding = Feeding.Carnivore;
            BeweegVoort();
        }

        public double Lengte;

        public override void ToonInfo()
        {
            IsGevangen = true;
            base.Eet();
            base.ToonInfo();
            Console.WriteLine("Lengte: " + Lengte);
        }

        public void Bijt()
        {
            ((Animal)this).ToonInfo();
            Console.WriteLine("Gebeten om te weten.");
            IsGevangen = false;
        }

        public override void Speaks()
        {
            Console.WriteLine("ssssssssssssssss");
        }

        public override string ToString()
        {
            return "Slang";
        }
    }
}
