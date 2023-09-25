namespace ConsoleDierentuin25sep2023
{
    public abstract class Animal
    {
        public double Weight { get; set; }

        public enum Feeding
        {
            Herbivore, Omnivore, Cannibalism, Carnivore
        }

        bool isGevangen = false;

        public Feeding feeding;

        public bool IsGevangen
        {
            get { return isGevangen; }
            set { isGevangen = value; }
        }

        public void BeweegVoort()
        {
            Console.WriteLine("Bewegen ...");
        }

        public void Eet()
        {
            Console.WriteLine("Eten...");
        }

        /// <summary>
        /// Voorzie in de klasse Animal een virtual methode ToonInfo die alle properties van de klasse op het scherm zet. 
        /// De overgeërfde klassen overriden deze methode door de extra properties ook te tonen (maar gebruik base.ToonInfo om zeker de parentklasse werking te bewaren).
        /// </summary>
        public virtual void ToonInfo()
        {
            Console.WriteLine("Dier");
            Console.WriteLine(feeding);
            Console.WriteLine("is Gevangen:" + IsGevangen);
        }

        public abstract void Speaks();

        public static double GetAverageWeight(List<Animal> list)
        {
            double average = 0;
            if (list != null && list.Count > 0)
            {
                foreach (Animal animal in list)
                {
                    average += animal.Weight;
                }
                average /= list.Count;
            }
            return average;
        }

    }
}
