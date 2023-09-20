namespace ConsoleBankAccount20sep2023
{
    internal class BankAccount
    {
        public enum AccountState
        {
            Geldig, Geblokkeerd
        }

        private AccountState accountState = AccountState.Geldig;

        private string naam;

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        private int bedrag;

        protected int Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }

        private string rekeningnummer;

        public string Rekeningnummer
        {
            get { return rekeningnummer; }
            set { rekeningnummer = value; }
        }

        /// <summary>
        /// WithdrawFunds: bepaald bedrag wordt van rekening verwijderd.
        /// Pas de WithdrawFunds methode aan zodat als returntype het bedrag (int) wordt teruggegeven.
        /// Indien het gevraagde bedrag meer dan de balance is dan geef je al het geld terug dat nog op de rekening staat en toon je in de console dat niet al het geld kon worden gegeven.
        /// </summary>
        public int WithdrawFunds(int bepaaldBedrag)
        {
            int withdrawnAmount = 0;
            if (bepaaldBedrag > Bedrag)
            {
                Console.WriteLine("Excuses, Er staat onvoldoende op de rekening.");
                Console.WriteLine($"Er staat slechts {GetBalance()} op de rekening.");
                Console.WriteLine("Niet al het geld kon worden gegeven.");
                withdrawnAmount = Bedrag;
                Bedrag = 0;
            }
            else
            {
                Bedrag -= bepaaldBedrag;
                withdrawnAmount = bepaaldBedrag;
            }
            return withdrawnAmount;
        }


        /// <summary>
        /// PayInFunds: bepaald bedrag (als parameter) wordt op de rekening gezet.
        /// </summary>
        public void PayInFunds(int bepaaldBedrag)
        {
            Bedrag += bepaaldBedrag;
        }

        /// <summary>
        /// GetBalance: het totale bedrag op de rekening wordt teruggegeven.
        /// </summary>
        public int GetBalance()
        {
            return Bedrag;
        }

        public void ChangeState(AccountState state)
        {
            accountState = state;
        }

        public static void Transactie(int bedrag, BankAccount from, BankAccount to)
        {
            if (from.accountState == AccountState.Geldig && to.accountState == AccountState.Geldig)
            {
                to.PayInFunds(from.WithdrawFunds(bedrag));
            }
            else
            {
                Console.WriteLine("Error: Een rekening is geblokkeerd.");
            }
        }
    }
}
