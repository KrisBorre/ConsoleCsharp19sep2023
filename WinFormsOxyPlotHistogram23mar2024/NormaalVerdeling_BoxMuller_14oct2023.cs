namespace WinFormsOxyPlotHistogram23mar2024
{
    internal class NormaalVerdeling_BoxMuller_14oct2023 : Random14oct2023
    {
        private double mu, sig;
        private double storedval;

        public NormaalVerdeling_BoxMuller_14oct2023(double gemiddelde = 0, double variantie = 1, ulong zaadje = 5) : base(zaadje)
        {
            mu = gemiddelde;
            sig = variantie;
            storedval = 0.0;
        }

        public override double Afwijking()
        {
            double result;
            double v1, v2, rsq, fac;

            if (storedval == 0.0)
            {
                do
                {
                    v1 = 2.0 * doub() - 1.0;
                    v2 = 2.0 * doub() - 1.0;
                    rsq = v1 * v1 + v2 * v2;
                } while (rsq >= 1.0 || rsq == 0.0);

                fac = Math.Sqrt(-2.0 * Math.Log(rsq) / rsq);
                storedval = v1 * fac;
                result = mu + sig * v2 * fac;
            }
            else
            {
                fac = storedval;
                storedval = 0.0;
                result = mu + sig * fac;
            }

            return result;
        }

    }
}
