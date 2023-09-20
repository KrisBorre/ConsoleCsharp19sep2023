using ConsoleBankAccount20sep2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij de BankAccount console application!");

        BankAccount rekening1 = new BankAccount();
        rekening1.Naam = "Van Looy";
        rekening1.Rekeningnummer = "545488787";
        rekening1.PayInFunds(1000);
        Console.WriteLine($"Op de rekening van {rekening1.Naam} staat {rekening1.GetBalance()} euro.");

        BankAccount rekening2 = new BankAccount();
        rekening2.Naam = "Bernard";
        rekening2.Rekeningnummer = "332232314112";
        rekening2.PayInFunds(1500);
        Console.WriteLine($"Op de rekening van {rekening2.Naam} staat {rekening2.GetBalance()} euro.");

        Console.WriteLine($"Storting rekening {rekening2.Naam} naar rekening {rekening1.Naam}.");
        rekening1.PayInFunds(rekening2.WithdrawFunds(200));

        Console.WriteLine($"Op de rekening van {rekening1.Naam} staat {rekening1.GetBalance()} euro.");
        Console.WriteLine($"Op de rekening van {rekening2.Naam} staat {rekening2.GetBalance()} euro.");

        Console.WriteLine($"Poging van storting rekening {rekening2.Naam} naar rekening {rekening1.Naam}.");
        rekening1.PayInFunds(rekening2.WithdrawFunds(2000));

        Console.WriteLine($"Op de rekening van {rekening1.Naam} staat {rekening1.GetBalance()} euro.");
        Console.WriteLine($"Op de rekening van {rekening2.Naam} staat {rekening2.GetBalance()} euro.");

        Console.WriteLine($"Storting rekening {rekening1.Naam} naar rekening {rekening2.Naam}.");
        BankAccount.Transactie(100, rekening1, rekening2);

        Console.WriteLine($"Op de rekening van {rekening1.Naam} staat {rekening1.GetBalance()} euro.");
        Console.WriteLine($"Op de rekening van {rekening2.Naam} staat {rekening2.GetBalance()} euro.");

        rekening1.ChangeState(BankAccount.AccountState.Geblokkeerd);
        Console.WriteLine($"Poging tot storting rekening {rekening1.Naam} naar rekening {rekening2.Naam}.");
        BankAccount.Transactie(500, rekening1, rekening2);
        rekening1.ChangeState(BankAccount.AccountState.Geldig);

        Console.WriteLine($"Op de rekening van {rekening1.Naam} staat {rekening1.GetBalance()} euro.");
        Console.WriteLine($"Op de rekening van {rekening2.Naam} staat {rekening2.GetBalance()} euro.");

        Console.ReadLine();
    }
}