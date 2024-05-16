using System;

namespace DesignPatterns
{
    // Product Interface
    public interface Vehicle
    {
        public void PrintVehicle();
    }

    // Concrete Product class for TwoWheeler
    public class TwoWheeler : Vehicle
    {
        public void PrintVehicle()
        {
            Console.WriteLine("I am Two Wheeler.");
        }
    }

    // Concrete Product class for FourWheeler
    public class FourWheeler : Vehicle
    {
        public void PrintVehicle()
        {
            Console.WriteLine("I am Four Wheeler.");
        }
    }

    // Factory Interface (Creator Interface)
    public interface VehicleFactory
    {
        // Factory interface defining the factory method
        public Vehicle CreateVehicle();
    }

    // Concrete factory class for TwoWheeler 
    public class TwoWheelerFactory : VehicleFactory 
    {
        public Vehicle CreateVehicle()
        {
            return new TwoWheeler();
        }
    }

    // Conrete factory class for FourWheeler
    public class FourWheelerFactory : VehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new FourWheeler();
        }
    }

    // Client Class
    public class Client
    {
        private Vehicle? pVehicle;

        public Client(VehicleFactory factory)
        {
            pVehicle = factory.CreateVehicle();
        }

        public Vehicle GetVehicle()
        {
            return pVehicle;
        }
    }

    // Driver Class
    public class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory twoWheelerFactory = new TwoWheelerFactory();
            Client twoWheelerClient = new Client(twoWheelerFactory);
            Vehicle twoWheeler = twoWheelerClient.GetVehicle();
            twoWheeler.PrintVehicle();


            VehicleFactory fourWheelerFactory = new FourWheelerFactory();
            Client fourWheelerClient = new Client(fourWheelerFactory);
            Vehicle fourWheeler = fourWheelerClient.GetVehicle();
            fourWheeler.PrintVehicle();


            Console.ReadKey();
        }
    }
}
