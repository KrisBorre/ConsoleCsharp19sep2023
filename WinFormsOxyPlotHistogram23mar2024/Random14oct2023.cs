namespace WinFormsOxyPlotHistogram23mar2024
{
    // Numerical Recipes in C++
    // Recommended generator.
    // The period of the generator is 10^{57}
    internal class Random14oct2023
    {
        ulong u, v, w; //Declares 64-bit integer

        public Random14oct2023(ulong j)
        {
            v = 4101842887655102017UL;
            w = 1;
            u = j ^ v; int64();
            v = u; int64();
            w = v; int64();
        }

        public ulong int64()
        {
            u = u * 2862933555777941757UL + 7046029254386353087UL;
            v ^= v >> 17; v ^= v << 31; v ^= v >> 8;
            w = 4294957665U * (w & 0xffffffff) + (w >> 32);
            ulong x = u ^ (u << 21); x ^= x >> 35; x ^= x << 4;
            return (x + v) ^ w;
        }

        public double doub() { return 5.42101086242752217E-20 * int64(); }
        public uint int32() { return (uint)int64(); }

        public virtual double Afwijking()
        {
            return doub();
        }

    }
}

