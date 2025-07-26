namespace CarApp_Inheritance_vs_Composition_
{
    // A vehicle is not always a car.
    // A car is a vehicle. (Inherits its properties & methods)
    // An engine is not a vehicle.
    // Each vehicle contains an engine. (Composition)

    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.StartVehicle();

            myCar.Honk();
        }
    }

    // Parent class which the car class inherits from
    class Vehicle
    {
        private Engine engine = new Engine();
        public void Move() => Console.WriteLine("The vehicle is moving");

        public void StartVehicle()
        {
            engine.Start(); // Vehicle contains an Engine and uses it
            Console.WriteLine("Vehicle is ready to drive");
        }
    }

    // Subclass which inherits from Vehicle class
    class Car : Vehicle
    {
        public void Honk() => Console.WriteLine("The car is honking");
    }

    // Class used as a part of vehicle class -> composition, not inheritance.
    class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine started");
        }
    }

}
