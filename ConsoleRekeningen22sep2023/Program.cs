using ConsoleRekeningen22sep2023;

internal class Program
{
    private static void Main(string[] args)
    {
        string welkom = "Give me the money!";
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        for (int i = 0; i < 3; i++) builder.Append(welkom.ToUpper()).Append(' ');
        Console.WriteLine(builder);

        {
            Rekening rekening1 = new BankRekening();
            Console.WriteLine($"{rekening1.Saldo} euro op een {rekening1} geeft {rekening1.BerekenRente()} euro rente.");
            rekening1.VoegGeldToe(100);
            Console.WriteLine($"{rekening1.Saldo} euro op een {rekening1} geeft {rekening1.BerekenRente()} euro rente.");
            for (int i = 0; i < 3; i++)
            {
                rekening1.VoegGeldToe(1000);
                Console.WriteLine($"{rekening1.Saldo} euro op een {rekening1} geeft {rekening1.BerekenRente()} euro rente.");
            }

            rekening1.HaalGeldAf(650);
            Console.WriteLine($"{rekening1.Saldo} euro op een {rekening1} geeft {rekening1.BerekenRente()} euro rente.");
        }

        {
            Rekening rekening2 = new BankRekening();
            rekening2.HaalGeldAf(100);
            Console.WriteLine($"{rekening2.Saldo} euro op een {rekening2} geeft {rekening2.BerekenRente()} euro rente.");

            for (int i = 0; i < 3; i++)
            {
                rekening2.VoegGeldToe(1000);
                Console.WriteLine($"{rekening2.Saldo} euro op een {rekening2} geeft {rekening2.BerekenRente()} euro rente.");
            }

            rekening2.HaalGeldAf(650);
            Console.WriteLine($"{rekening2.Saldo} euro op een {rekening2} geeft {rekening2.BerekenRente()} euro rente.");
        }


        {
            Rekening rekening3 = new SpaarRekening();
            Console.WriteLine($"{rekening3.Saldo} euro op een {rekening3} geeft {rekening3.BerekenRente()} euro rente.");
            rekening3.VoegGeldToe(100);
            Console.WriteLine($"{rekening3.Saldo} euro op een {rekening3} geeft {rekening3.BerekenRente()} euro rente.");

            for (int i = 0; i < 3; i++)
            {
                rekening3.VoegGeldToe(1000);
                Console.WriteLine($"{rekening3.Saldo} euro op een {rekening3} geeft {rekening3.BerekenRente()} euro rente.");
            }

            rekening3.HaalGeldAf(650);
            Console.WriteLine($"{rekening3.Saldo} euro op een {rekening3} geeft {rekening3.BerekenRente()} euro rente.");
        }

        {
            Rekening rekening4 = new SpaarRekening();
            rekening4.HaalGeldAf(100);
            Console.WriteLine($"{rekening4.Saldo} euro op een {rekening4} geeft {rekening4.BerekenRente()} euro rente.");

            for (int i = 0; i < 3; i++)
            {
                rekening4.VoegGeldToe(1000);
                Console.WriteLine($"{rekening4.Saldo} euro op een {rekening4} geeft {rekening4.BerekenRente()} euro rente.");
            }

            rekening4.HaalGeldAf(650);
            Console.WriteLine($"{rekening4.Saldo} euro op een {rekening4} geeft {rekening4.BerekenRente()} euro rente.");
        }


        {
            Rekening rekening5 = new ProRekening();
            Console.WriteLine($"{rekening5.Saldo} euro op een {rekening5} geeft {rekening5.BerekenRente()} euro rente.");
            rekening5.VoegGeldToe(100);
            Console.WriteLine($"{rekening5.Saldo} euro op een {rekening5} geeft {rekening5.BerekenRente()} euro rente.");

            for (int i = 0; i < 3; i++)
            {
                rekening5.VoegGeldToe(1000);
                Console.WriteLine($"{rekening5.Saldo} euro op een {rekening5} geeft {rekening5.BerekenRente()} euro rente.");
            }

            rekening5.HaalGeldAf(650);
            Console.WriteLine($"{rekening5.Saldo} euro op een {rekening5} geeft {rekening5.BerekenRente()} euro rente.");
        }

        {
            Rekening rekening6 = new ProRekening();
            rekening6.HaalGeldAf(100);
            Console.WriteLine($"{rekening6.Saldo} euro op een {rekening6} geeft {rekening6.BerekenRente()} euro rente.");

            for (int i = 0; i < 3; i++)
            {
                rekening6.VoegGeldToe(1000);
                Console.WriteLine($"{rekening6.Saldo} euro op een {rekening6} geeft {rekening6.BerekenRente()} euro rente.");
            }

            rekening6.HaalGeldAf(650);
            Console.WriteLine($"{rekening6.Saldo} euro op een {rekening6} geeft {rekening6.BerekenRente()} euro rente.");
        }

        Console.ReadLine();

        //GIVE ME THE MONEY! GIVE ME THE MONEY! GIVE ME THE MONEY!
        //0 euro op een Bankrekening geeft 0 euro rente.
        //100 euro op een Bankrekening geeft 0 euro rente.
        //1100 euro op een Bankrekening geeft 55 euro rente.
        //2100 euro op een Bankrekening geeft 105 euro rente.
        //3100 euro op een Bankrekening geeft 155 euro rente.
        //2450 euro op een Bankrekening geeft 122,5 euro rente.
        //-100 euro op een Bankrekening geeft -0 euro rente.
        //900 euro op een Bankrekening geeft 45 euro rente.
        //1900 euro op een Bankrekening geeft 95 euro rente.
        //2900 euro op een Bankrekening geeft 145 euro rente.
        //2250 euro op een Bankrekening geeft 112,5 euro rente.
        //0 euro op een Spaarrekening geeft 0 euro rente.
        //100 euro op een Spaarrekening geeft 2 euro rente.
        //1100 euro op een Spaarrekening geeft 22 euro rente.
        //2100 euro op een Spaarrekening geeft 42 euro rente.
        //3100 euro op een Spaarrekening geeft 62 euro rente.
        //2450 euro op een Spaarrekening geeft 49 euro rente.
        //-100 euro op een Spaarrekening geeft -2 euro rente.
        //900 euro op een Spaarrekening geeft 18 euro rente.
        //1900 euro op een Spaarrekening geeft 38 euro rente.
        //2900 euro op een Spaarrekening geeft 58 euro rente.
        //2250 euro op een Spaarrekening geeft 45 euro rente.
        //0 euro op een PRO rekening geeft 0 euro rente.
        //100 euro op een PRO rekening geeft 2 euro rente.
        //1100 euro op een PRO rekening geeft 32 euro rente.
        //2100 euro op een PRO rekening geeft 62 euro rente.
        //3100 euro op een PRO rekening geeft 92 euro rente.
        //2450 euro op een PRO rekening geeft 69 euro rente.
        //-100 euro op een PRO rekening geeft -2 euro rente.
        //900 euro op een PRO rekening geeft 18 euro rente.
        //1900 euro op een PRO rekening geeft 48 euro rente.
        //2900 euro op een PRO rekening geeft 78 euro rente.
        //2250 euro op een PRO rekening geeft 65 euro rente.
    }
}