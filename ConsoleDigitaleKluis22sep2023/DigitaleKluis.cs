namespace ConsoleDigitaleKluis22sep2023
{
    internal class DigitaleKluis
    {
        /// <summary>
        /// Een private variabele die de toegangscode van de kluis bewaard als geheel getal
        /// </summary>
        private int code;

        /// <summary>
        /// Een overloaded constructor die als parameter een geheel getal toelaat. 
        /// Dit getal zal worden toegewezen aan de private variabele code.
        /// </summary>
        /// <param name="getal"></param>
        public DigitaleKluis(int getal)
        {
            CanShowCode = false;
            Code = getal;
            CodeLevel = getal / 1000;
        }

        private bool canShowCode;

        /// <summary>
        /// Een full property CanShowCode die kan ingesteld worden op true or false, om aan te geven of de code van buitenuit kan gezien worden.
        /// </summary>
        public bool CanShowCode
        {
            get { return canShowCode; }
            set { canShowCode = value; }
        }

        /// <summary>
        /// Een read-only property CodeLevel van type int. 
        /// Deze property zal het level van de code teruggeven. 
        /// Het level is eenvoudigweg de code gedeeld door 1000 als geheel getal (dus indien de code 500 is zal 0 worden teruggegeven, indien de code 2000 is wordt 2 teruggegeven, etc.)
        /// </summary>
        public int CodeLevel { get; private set; }


        /// <summary>
        /// Een fullproperty Code met private set. 
        /// De get van deze property zal -666 teruggeven, tenzij CanShowcode op true staat, in dit geval zal de effectieve code worden terug gegeven.
        /// </summary>
        public int Code
        {
            get
            {
                int result = -666;
                if (CanShowCode)
                {
                    result = code;
                }
                return result;
            }
            private set
            {
                code = value;
            }
        }


        /// <summary>
        /// Een methode TryCode die een geheel getal als parameter aanvaardt. 
        /// De methode geeft een true terug indien de code correct was, anders false. 
        /// Deze methode kan gebruikt worden om extern een code te testen, indien deze overeenkomt met de bewaarde code dan zal gemeld worden dat de code geldig is en wordt ook getoond hoeveel keer de gebruiker geprobeerd heeft. 
        /// Indien de gebruiker -666 meegaf dan meldt de methode dat de gebruiker een cheater is . 
        /// Indien de gebruiker een foute code meegaf dan meldt de methode dat dit een foute code was en wordt het aantal pogingen met 1 verhoogd.
        /// </summary>
        /// <param name="getal"></param>
        public bool TryCode(int getal)
        {
            bool result = false;
            aantalPogingen++;
            if (getal != -666)
            {
                if (getal == code)
                {
                    Console.WriteLine("Code is geldig.");
                    Console.WriteLine($"De gebruiker heeft {aantalPogingen} keer geprobeerd.");
                    result = true;
                    aantalPogingen = 0;
                }
                else
                {
                    Console.WriteLine("Foute code");
                }
            }
            else // getal == -666
            {
                Console.WriteLine("Je bent een cheater.");
            }
            return result;
        }

        private int aantalPogingen = 0;
    }
}

