using ConsoleMoederbord28sep2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij het Moederbord!");

        Moederbord Z390E_GAMING = new Moederbord();
        Z390E_GAMING.Name = "Z390E GAMING";
        Z390E_GAMING.AGP = new AGPSlot("GeForceRTX2080");
        Z390E_GAMING.CPU = new CPUSlot("IntelCorei9_9900K");

        Z390E_GAMING.Chipset = new ChipsetSlot("Intel Z390 Chipset");

        Z390E_GAMING.RAMemories.Add(new RAM("64 GB DDR4 4266+ MHz"));
        Z390E_GAMING.RAMemories.Add(new RAM("64 GB DDR4 4266+ MHz"));

        Z390E_GAMING.Wireless = new WirelessSlot("2x2 MU-MIMO 802.11ac");

        Z390E_GAMING.Name = "90MB0YF0-M0EAY1";
        Z390E_GAMING.WeightInPounds = 1;

        if (Z390E_GAMING.TestMoederbord())
        {
            Console.WriteLine($"Het moederbord {Z390E_GAMING.Name} is volledig.");
        }

        Moederbord ASUS = new Moederbord();
        ASUS.Name = "ASUS Z170I PRO GAMING";   
        if (!ASUS.TestMoederbord())
        {
            Console.WriteLine($"Het moederbord {ASUS.Name} is onvolledig.");
        }

        Console.ReadLine();
    }
}