using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    class Customer
    {
        private static int nextID = 0;

        // Read-only instance filed initialized from the constructor
        private readonly int _id;

        // Backing field for write-only property
        private string _password;

        // Write only property
        public string Password
        {
            set
            {
                _password = value;
            }
        }

        // Read-only property
        public int ID { get => _id; }

        // Properties
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ContactNumber { get; set; }

        // Default Constructor
        public Customer()
        {
            _id = nextID++;
            Name = "Unspecified";
            Adress = "Unknown";
            ContactNumber = "None";
        }

        // Custom Constructors
        // Optional parameters
        public Customer(string name, string adress = "Unknown", string contactNumber = "NA")
        {
            _id = nextID++;
            Name = name;
            Adress = adress;
            ContactNumber = contactNumber;
        }

        // Method with default assigned value (optional parameter)
        public void SetDetails(string name, string adress, string contactNumber = "NA")
        {
            Name = name;
            Adress = adress;
            ContactNumber = contactNumber;
        }

        public void GetDetails()
        {
            Console.WriteLine($"ID = {_id}, Name = {Name}, Adress = {Adress}, Contact: {ContactNumber}.");
        }
    }
}
