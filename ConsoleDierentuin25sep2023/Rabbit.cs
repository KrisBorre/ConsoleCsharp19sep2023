namespace ConsoleDierentuin25sep2023
{
    public class Rabbit : Mammal
    {
        public Rabbit()
        {
            Weight = 1;
        }

        public int AantalOren { get; set; }

        public void Hup()
        {
            Console.WriteLine("Hup Hup Hup");
            this.ToonInfo();
            BeweegVoort();
        }

        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine("AantalOren: " + AantalOren);
        }

        public void Ontsnapt()
        {
            IsGevangen = false;
        }

        public override void Speaks()
        {
            Console.WriteLine("hup hop hip");
        }

        public override string ToString()
        {
            return "Konijn";
        }
    }
}
