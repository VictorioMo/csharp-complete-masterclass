using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class VariableNaming
    {
        public void NamingOfVariables()
        {
            /* Clarity and Precision in Variable Naming */

            // bad examples
            int n = 100;
            string s = "John";

            // good examples
            int studentCount = 100;
            string studentName = "John";

            /* Naming convention cases */
            /*
             * PascalCase -> used for classes, methods/functions and properties
             * camelCase -> used for variables/parameters
             * _camelCase -> used for private fields
             * ALL_CAPS -> used for constants/defines
             */

        }
    }

    class CustomerService // PascalCase
    {
        private string _customerName; // _camelCase

        public const int MAX_CUSTOMERS = 100; // ALL_CAPS

        public int CustomerCount { get; set; } // PascalCase

        public CustomerService(string customerName)
        {
            _customerName = customerName;
        }

        public string GetCustomerName /* PascalCase */ 
            (int customerId /* camelCase */)
        {
            string name = "Larry Smith"; // camelCase
            return name;
        }

        /* Meaning through naming */

        // bad example
        public void Save() { } /* Although the idea is somewhat clear, still leaves you guessing */

        // good example
        public void SaveCustomer() { } /* More clear */
        public void SaveCustomerName() { }
    }
}
