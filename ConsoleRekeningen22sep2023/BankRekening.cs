namespace ConsoleRekeningen22sep2023
{
    /// <summary>
    /// Een klasse BankRekening die een Rekening is.
    /// </summary>
    internal class BankRekening : Rekening
    {
        /// <summary>
        /// De rente van een BankRekening is 5% wanneer het saldo hoger is dan 100 euro, zoniet is deze 0%.
        /// </summary>
        public override double BerekenRente()
        {
            double rente = 0;

            if (this.Saldo > 100)
            {
                rente = 0.05;
            }

            return rente * this.Saldo;
        }

        public override string ToString()
        {
            return "Bankrekening";
        }
    }
}