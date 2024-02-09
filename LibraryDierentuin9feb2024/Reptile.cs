using LibraryPhysicalUnits9feb2024;

namespace LibraryDierentuin9feb2024
{
    public class Reptile : Animal
    {
        public Reptile()
        {
            Weight = new WeightInKilogram9feb2024(20);
        }

        public int AantalSchubben { get; set; }

        protected void LegEieren()
        {
            Console.WriteLine("Eieren ...");
        }

        /// <summary>
        /// Voorzie in de klasse Animal een virtual methode ToonInfo die alle properties van de klasse op het scherm zet. 
        /// De overgeërfde klassen overriden deze methode door de extra properties ook te tonen (maar gebruik base.ToonInfo om zeker de parentklasse werking te bewaren).
        /// </summary>
        public override void ToonInfo()
        {
            base.ToonInfo();
            Console.WriteLine("Reptiel");
            Console.WriteLine("Aantal schubben:" + AantalSchubben);
        }

        public override void Speaks()
        {
            Console.WriteLine("ssssss");
        }

        public override string ToString()
        {
            return "Reptiel";
        }
    }
}
