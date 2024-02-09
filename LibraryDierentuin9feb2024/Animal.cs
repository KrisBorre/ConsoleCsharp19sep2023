using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public abstract class Animal
    {
        public WeightInKilogram9feb2024 Weight { get; set; }

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

        public static WeightInKilogram9feb2024 GetAverageWeight(List<Animal> list)
        {
            WeightInKilogram9feb2024 average = new WeightInKilogram9feb2024(0);
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
