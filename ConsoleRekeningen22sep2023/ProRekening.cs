namespace ConsoleRekeningen22sep2023
{
    /// <summary>
    /// Een klasse ProRekening die een SpaarRekening is.
    /// </summary>
    internal class ProRekening : SpaarRekening
    {
        /// <summary>
        /// De ProRekening hanteert de Rente-berekening van een SpaarRekening (base.BerekenRente) maar zal per 1000 euro saldo nog eens 10 euro verhogen.
        /// </summary>
        /// <returns></returns>
        public override double BerekenRente()
        {
            double resultaat = base.BerekenRente();

            int numberOf1000Euro = (int)(this.Saldo / 1000);
            double verhoging = numberOf1000Euro * 10;
            resultaat += verhoging;

            return resultaat;
        }

        public override string ToString()
        {
            return "PRO rekening";
        }
    }
}
