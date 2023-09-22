namespace ConsoleRekeningen22sep2023
{
    /// <summary>
    /// Abstracte klasse Rekening: deze bevat een methode VoegGeldToe en HaalGeldAf.
    /// </summary>
    internal abstract class Rekening
    {
        public void VoegGeldToe(double geld)
        {
            saldo += geld;
        }

        public void HaalGeldAf(double geld)
        {
            saldo -= geld;
        }

        /// <summary>
        /// in euro
        /// </summary>
        private double saldo;

        /// <summary>
        /// Het saldo van de rekening wordt in een private variabele bijgehouden (en via de voorgaande methoden aangepast) die enkel via een read-only property kan uitgelezen worden. 
        /// </summary>
        public double Saldo
        {
            get { return saldo; }
        }

        /// <summary>
        /// Voorts is er een abstracte methode BerekenRente de rente als double teruggeeft.
        /// </summary>
        /// <returns></returns>
        public abstract double BerekenRente();

    }
}
