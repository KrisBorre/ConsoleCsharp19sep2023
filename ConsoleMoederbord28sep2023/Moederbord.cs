namespace ConsoleMoederbord28sep2023
{
    internal class Moederbord
    {
        public string Name { get; set; }

        public CPUSlot CPU { get; set; }
        public AGPSlot AGP { get; set; }
        public List<RAM> RAMemories = new List<RAM>();

        public ChipsetSlot Chipset { get; set; }

        public WirelessSlot Wireless { get; set; }

        public double WeightInPounds { get; set; }

        public bool TestMoederbord()
        {
            bool result = true;
            if (CPU == null) { Console.WriteLine($"{Name} CPU slot is empty."); result = false; }
            if (AGP == null) { Console.WriteLine($"{Name} AGP slot is empty."); result = false; }
            if (RAMemories.Count == 0) { Console.WriteLine($"{Name} RAM slots are empty."); result = false; }
            if (Chipset == null) { Console.WriteLine($"{Name} Chipset slot is empty."); result = false; }
            if (Wireless == null) { Console.WriteLine($"{Name} Wireless slot is empty."); result = false; }
            return result;
        }        
    }
}
