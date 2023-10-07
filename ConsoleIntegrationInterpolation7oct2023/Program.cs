using ConsoleIntegrationInterpolation7oct2023;

Console.WriteLine("Integration and Interpolation numerical recipes");

Car car1 = new Car("Jaak", 44, Engine.FuelType.Diesel, "onbekend", Crankshaft.CrankType.Full, 6);
car1.Brand = "Seat";
car1.Accelerate();

Boat boat1 = new Boat(2, "Henk", 43, "AMD processor", 20, Engine.SensorType.MAP, Boat.ShipType.SuperYacht, Engine.FuelType.Petrol);

Console.WriteLine("Speed: " + boat1.GetSpeed());

boat1.Transport = "cargo";

Car car2 = new Car("Paul", 20, Engine.FuelType.Petrol, "20x", Crankshaft.CrankType.Full, 8);
car2.Brand = "Rolls Roys";
car2.Accelerate();

Console.ReadLine();
