using System;
using System.Collections.Generic;

// Абстрактний клас для транспортного засобу
public abstract class Vehicle
{
    public double Speed { get; set; }
    public int Capacity { get; set; }

    public Vehicle(double speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public abstract void Move();
}

// Клас для людини
public class Human : Vehicle
{
    public Human(double speed) : base(speed, 1) { }

    public override void Move()
    {
        Console.WriteLine($"The human is moving at {Speed} km/h.");
    }
}

// Клас для автомобіля
public class Car : Vehicle
{
    public Car(double speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine($"The car is moving at {Speed} km/h with a capacity of {Capacity} people.");
    }
}

// Клас для автобуса
public class Bus : Vehicle
{
    public Bus(double speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine($"The bus is moving at {Speed} km/h with a capacity of {Capacity} people.");
    }
}

// Клас для потяга
public class Train : Vehicle
{
    public Train(double speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine($"The train is moving at {Speed} km/h with a capacity of {Capacity} people.");
    }
}

// Клас для транспортної мережі
public class TransportNetwork
{
    public List<Vehicle> Vehicles { get; set; }

    public TransportNetwork()
    {
        Vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void ControlMovement()
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.Move();
        }
    }
}

// Клас для маршруту
public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string startPoint, string endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public void CalculateOptimalRoute(Vehicle vehicle)
    {
        Console.WriteLine($"Calculating optimal route for {vehicle.GetType().Name} from {StartPoint} to {EndPoint}.");
    }
}

// Тестування та взаємодія з користувачем
public class Program
{
    public static void Main()
    {
        TransportNetwork network = new TransportNetwork();

        // Введення даних для створення транспортних засобів
        Console.WriteLine("Enter the number of vehicles to add:");
        int numberOfVehicles = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfVehicles; i++)
        {
            Console.WriteLine("Choose vehicle type (1 for Car, 2 for Bus, 3 for Train, 4 for Human):");
            int vehicleType = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter speed (in km/h):");
            double speed = double.Parse(Console.ReadLine());

            if (vehicleType == 1) // Car
            {
                Console.WriteLine("Enter capacity:");
                int capacity = int.Parse(Console.ReadLine());
                network.AddVehicle(new Car(speed, capacity));
            }
            else if (vehicleType == 2) // Bus
            {
                Console.WriteLine("Enter capacity:");
                int capacity = int.Parse(Console.ReadLine());
                network.AddVehicle(new Bus(speed, capacity));
            }
            else if (vehicleType == 3) // Train
            {
                Console.WriteLine("Enter capacity:");
                int capacity = int.Parse(Console.ReadLine());
                network.AddVehicle(new Train(speed, capacity));
            }
            else if (vehicleType == 4) // Human
            {
                network.AddVehicle(new Human(speed));
            }
            else
            {
                Console.WriteLine("Invalid vehicle type. Skipping.");
            }
        }

        // Контроль руху транспортних засобів
        network.ControlMovement();

        // Введення даних для маршруту
        Console.WriteLine("Enter start point for the route:");
        string startPoint = Console.ReadLine();
        Console.WriteLine("Enter end point for the route:");
        string endPoint = Console.ReadLine();

        Route route = new Route(startPoint, endPoint);

        foreach (var vehicle in network.Vehicles)
        {
            route.CalculateOptimalRoute(vehicle);
        }
    }
}
