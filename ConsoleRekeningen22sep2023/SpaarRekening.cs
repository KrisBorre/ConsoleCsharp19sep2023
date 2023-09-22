namespace ConsoleRekeningen22sep2023
{
    /// <summary>
    /// Een klasse SpaarRekening die een Rekening is.
    /// </summary>
    internal class SpaarRekening : Rekening
    {
        /// <summary>
        /// De rente van een SpaarRekening bedraagt steeds 2%.
        /// </summary>
        /// <returns></returns>
        public override double BerekenRente()
        {
            double rente = 0.02;
            return rente * this.Saldo;
        }

        public override string ToString()
        {
            return "Spaarrekening";
        }
    }
}
