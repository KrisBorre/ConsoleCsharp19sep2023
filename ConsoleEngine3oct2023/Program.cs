using ConsoleEngine3oct2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Van UML diagrammen naar code.");
        Console.WriteLine("Oefening met Engine, Car en Boat!");

        Car car1 = new Car("Tim", 44, Engine.FuelType.Diesel, "onbekend", Crankshaft.CrankType.Full, 6);
        car1.Brand = "Seat";
        car1.Accelerate();

        Boat boat1 = new Boat(2, "Will", 43, "AMD processor", 20, Engine.SensorType.MAP, Boat.ShipType.SuperYacht, Engine.FuelType.Petrol);
        boat1.Transport = "cargo";

        Car car2 = new Car("Dirk", 20, Engine.FuelType.Petrol, "20x", Crankshaft.CrankType.Full, 8);
        car2.Brand = "Rolls Roys";
        car2.Accelerate();

        Console.WriteLine("Einde.");
        Console.ReadLine();
    }
}