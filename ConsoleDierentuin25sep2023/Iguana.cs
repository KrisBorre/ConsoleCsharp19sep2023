namespace ConsoleDierentuin25sep2023
{
    public class Iguana : Reptile
    {
        public Iguana()
        {
            Weight = 10;
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
