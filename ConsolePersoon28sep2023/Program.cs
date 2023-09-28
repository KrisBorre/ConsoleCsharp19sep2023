using ConsolePersoon28sep2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Van UML diagrammen naar code.");

        Person p1 = new Person("Karel", 4);
        Console.WriteLine(p1.Name);

        Person p2 = new Person("Jan", 5, 3);
        Console.WriteLine(p2.Name);

        Person p3 = new Person("Piet", age: 6, 4);
        Console.WriteLine(p3.Name);

        Person p4 = new Person(name: "Korneel", age: 7);
        Console.WriteLine(p4.Name);

        Person p5 = new Person(numberOfLegs: 1, age: 3, name: "Arnold");
        Console.WriteLine(p5.Name);

        Console.ReadLine();
    }
}