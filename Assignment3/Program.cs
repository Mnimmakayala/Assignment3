using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        //TODO [2]: Make the DisplayInfo method overridable and implement it
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Company Name: {Make}, Model Number: {Model}, Year Made: {Year}");
        }

        public abstract int NumWheels(); // Abstract method
    }

    //TODO [3]: Make the Car class inherit from the Vehicle class
    public class Car : Vehicle
    {
        // Constructor calling base class constructor
        public Car(string make, string model, int year) : base(make, model, year)
        {

        }

        //TODO [4]: Override and implement the NumWheels method
        public override int NumWheels()
        {
            // Total number of car wheels are four
            return 4;
        }

        //TODO [5]: Override and implement the DisplayInfo method
        public override void DisplayInfo()
        {
            Console.WriteLine($"Car - Make: {Make}, Model: {Model}, Year: {Year}");
        }
    }

    //TODO [6]: Make the MotorCycle class inherit from the Vehicle class
    public class MotorCycle : Vehicle
    {
        // Constructor
        public MotorCycle(string make, string model, int year) : base(make, model, year)
        {

        }

        //TODO [8]: Override and implement the NumWheels method
        public override int NumWheels()
        {
            return 2; // Motorcycles typically have 2 wheels
        }

        //TODO [9]: Override and implement the DisplayInfo method
        public override void DisplayInfo()
        {
            Console.WriteLine($"Motorcycle - Make: {Make}, Model: {Model}, Year: {Year}");
        }
    }

    public class Garage
    {
        private List<Vehicle> vehicles;

        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }

        public Garage()
        {
            vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            //TODO [10]: Implement logic here
            if (vehicles.Count < Capacity)
            {
                vehicles.Add(vehicle);
                Console.WriteLine($"Added {vehicle.Make} {vehicle.Model} to the garage.");
            }
            else
            {
                Console.WriteLine("No parking spot available.");
            }
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            //TODO [11]: Implement logic here
            if (vehicles.Contains(vehicle))
            {
                vehicles.Remove(vehicle);
                Console.WriteLine($"Removed {vehicle.Make} {vehicle.Model} from the garage.");
            }
            else
            {
                Console.WriteLine($"{vehicle.Make} {vehicle.Model} is not in the garage.");
            }
        }

        public void DisplayParkedVehicles()
        {
            //TODO [12]: Implement logic here
            Console.WriteLine($"Vehicles parked in {Name}:");
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
            }
        }

        public bool isThereAnySpotAvailable()
        {
            //TODO [13]: Implement logic here
            return vehicles.Count < Capacity;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO [14] Creating instances of Vehicle
            Vehicle v1 = new Car("Toyota", "HMD243", 2023);
            Vehicle v2 = new MotorCycle("Honda", "NR4989", 2022);
            Vehicle v3 = new Car("Elantra", "WEN2435", 2024);

            //TODO [15] Creating an instance of Garage, set the garage name, address and capacity
            Garage garage = new Garage();
            garage.Name = "Top Garage";
            garage.Address = "459 Lester Street";
            garage.Capacity = 3;

            //TODO [16]: Implement logic to interact with these objects.
            garage.AddVehicle(v1);
            garage.AddVehicle(v2);
            garage.DisplayParkedVehicles();

            Console.WriteLine(); 

            garage.AddVehicle(v3);
            garage.DisplayParkedVehicles();

            Console.WriteLine();

            garage.RemoveVehicle(v2);
            garage.DisplayParkedVehicles();
        }
    }
}
