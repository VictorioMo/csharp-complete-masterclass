using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    internal class Car
    {
        // Static field
        public static int NumberOfCars = 0;

        // Private field
        private string _brand = "";

        // Properties
        public string Brand 
        { 
            get
            {
                if (IsLuxury)
                {
                    return $"{_brand} - Luxury Edition";
                }
                else
                {
                    return _brand;
                }
            }
            set
            { 
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("No info was provided - couldn't assign a brand to the car.");
                    _brand = "DefaultValue";
                }
                else
                {
                    _brand = value;
                }
                
            }
        }
        // => lambda expression
        public string Model { get; set; }
        public bool IsLuxury { get; set; }

        public Car()
        {
            NumberOfCars++;
        }

        // Constructor
        public Car(string model, string brand, bool isLuxury)
        {
            NumberOfCars++;

            Model = model;
            Brand = brand;
            IsLuxury = isLuxury;
            Console.WriteLine($"A {Brand} of model {Model} has been created!");
        }

        // Methods
        public void Drive()
        {
            Console.WriteLine($"I'm a {Brand} {Model} and I'm now driving");
        }


    }
}
