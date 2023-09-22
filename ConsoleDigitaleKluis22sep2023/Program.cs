using ConsoleDigitaleKluis22sep2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij de digitale kluis!");

        {
            DigitaleKluis k1 = new DigitaleKluis(500);
            Console.WriteLine("k1.CodeLevel = " + k1.CodeLevel); // 0
            Console.WriteLine("k1.Code = " + k1.Code);
            k1.CanShowCode = true;
            Console.WriteLine("k1.Code = " + k1.Code);
        }


        Console.WriteLine("\nDruk op de enter toets om verder te gaan.");
        Console.ReadLine();

        {
            DigitaleKluis k2 = new DigitaleKluis(2000);
            Console.WriteLine("k2.CodeLevel = " + k2.CodeLevel); // 2
            Console.WriteLine("k2.Code = " + k2.Code);
            k2.CanShowCode = true;
            Console.WriteLine("k2.Code = " + k2.Code);
        }


        Console.WriteLine("\nDruk op de enter toets om verder te gaan.");
        Console.ReadLine();


        {
            DigitaleKluis k3 = new DigitaleKluis(2000);
            Console.WriteLine("k3.CodeLevel = " + k3.CodeLevel); // 2
            Console.WriteLine("k3.Code = " + k3.Code);
            Console.WriteLine(k3.TryCode(1234));
            Console.WriteLine(k3.TryCode(2000));
            Console.WriteLine(k3.TryCode(5632));
            Console.WriteLine(k3.TryCode(9985));
            Console.WriteLine(k3.TryCode(2000));
            Console.WriteLine(k3.TryCode(-666));

            k3.CanShowCode = true;
            Console.WriteLine("k3.Code = " + k3.Code);
        }

        Console.WriteLine("\nDruk op de enter toets om verder te gaan.");
        Console.ReadLine();

        {
            DigitaleKluis k4 = new DigitaleKluis(6578);
            Console.WriteLine(k4.TryCode(6578));
            Console.WriteLine(k4.TryCode(6578));
            Console.WriteLine(k4.TryCode(6578));
            Console.WriteLine(k4.TryCode(9985));
            Console.WriteLine(k4.TryCode(2000));
            Console.WriteLine(k4.Code);
            Console.WriteLine(k4.TryCode(6578));
        }

        Console.WriteLine("\nDruk op de enter toets om verder te gaan.");
        Console.ReadLine();


        {
            DigitaleKluis k5 = new DigitaleKluis(123456);
            k5.CanShowCode = false;
            Console.WriteLine(k5.TryCode(123456));
        }

        Console.ReadLine();
    }
}