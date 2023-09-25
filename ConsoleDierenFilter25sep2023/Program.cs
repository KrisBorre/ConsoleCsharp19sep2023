using ConsoleDierentuin25sep2023;
using ConsoleDierenFilter25sep2023;

internal class Program
{
    static void ToonDieren(List<Animal> lijst)
    {
        for (int i = 1; i <= lijst.Count; i++)
        {
            Console.WriteLine(i + ":  " + lijst[i - 1]);
        }
    }

    static void InvoerDieren(List<Animal> lijst)
    {
        List<Animal> dieren = new List<Animal>();
        dieren.Add(new Cow());
        dieren.Add(new Dog());
        dieren.Add(new Iguana());
        dieren.Add(new Mammal());
        dieren.Add(new Rabbit());
        dieren.Add(new Reptile());
        dieren.Add(new Snake());
        dieren.Add(new Pig());

        ToonDieren(dieren);

        while (true)
        {
            Console.WriteLine("Kies de dieren dat je wil toevoegen: (q is stop)");
            string strNummer = Console.ReadLine();

            if (strNummer == "q" || strNummer == "stop" || strNummer == "exit") break;

            if (int.TryParse(strNummer, out int keuze) && keuze >= 1 && keuze <= dieren.Count)
            {
                Animal dier = dieren[keuze - 1];
                lijst.Add(dier);
                Console.WriteLine(dier + " toegevoegd.");
            }
        }
    }

    static void VerwijderDier(List<Animal> lijst)
    {
        Console.WriteLine("Het hoeveelste dier wil je weg uit de lijst: ");
        ToonDieren(lijst);
        string strNummer = Console.ReadLine();
        if (int.TryParse(strNummer, out int keuze) && (keuze >= 1 && keuze <= lijst.Count))
        {
            lijst.RemoveAt(keuze - 1);
            Console.WriteLine("Verwijderd.");
        }
        Console.WriteLine("Nieuwe lijst: ");
        ToonDieren(lijst);
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom in de zoo van Antwerpen met filter!");

        List<Animal> lijst = new List<Animal>();
        InvoerDieren(lijst);

        bool stop = false;
        while (!stop)
        {
            Console.WriteLine("\na is verwijderen. b is gewicht gemiddelde. c is praten. d is opnieuw beginnen. q is stop.");
            string input = Console.ReadLine();
            switch (input)
            {
                case "stop":
                case "exit":
                case "q":
                    stop = true;
                    break;
                case "a":
                    VerwijderDier(lijst);
                    break;
                case "b":
                    Console.WriteLine("Gewicht gemiddelde is " + Animal.GetAverageWeight(lijst));
                    break;
                case "c":
                    foreach (Animal animal in lijst)
                    {
                        if (animal is Cow || animal is Snake || animal is Pig)
                        {
                            animal.Speaks();
                        }
                    }
                    break;
                case "d":
                    lijst.Clear();
                    InvoerDieren(lijst);
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine("\nDruk op de enter toets om te stoppen.");
        Console.ReadLine();
    }
}