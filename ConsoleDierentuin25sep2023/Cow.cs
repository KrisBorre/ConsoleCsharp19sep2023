namespace ConsoleDierentuin25sep2023
{
    public class Cow : Mammal
    {
        public Cow()
        {
            Weight = 500;
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
