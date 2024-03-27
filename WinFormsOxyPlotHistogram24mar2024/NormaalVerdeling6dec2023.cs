namespace WinFormsOxyPlotHistogram24mar2024
{
    internal enum Method
    {
        BoxMuller,
        Leva1992
     };

    internal class NormaalVerdeling6dec2023
    {
        private Random14oct2023 verdeling;

        public NormaalVerdeling6dec2023(double gemiddelde = 0, double variantie = 1, ulong zaadje = 5)
        {
            verdeling = new NormaalVerdeling_Leva1992_14oct2023(gemiddelde, variantie, zaadje);
        }

        public NormaalVerdeling6dec2023(double gemiddelde = 0, double variantie = 1, ulong zaadje = 5, Method method = Method.Leva1992)
        {
            switch (method)
            {
                case Method.BoxMuller:
                    verdeling = new NormaalVerdeling_BoxMuller_14oct2023(gemiddelde, variantie, zaadje);
                    break;
                case Method.Leva1992:
                default:
                    verdeling = new NormaalVerdeling_Leva1992_14oct2023(gemiddelde, variantie, zaadje);
                    break;
            }
        }

        public double Afwijking()
        {
            return verdeling.Afwijking();
        }
    }
}
