namespace ConsoleDierentuin25sep2023
{
    public class Dog : Mammal
    {
        public Dog()
        {
            Weight = 25;
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
