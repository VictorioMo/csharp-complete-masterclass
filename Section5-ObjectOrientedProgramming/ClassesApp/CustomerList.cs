using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    internal class CustomerList
    {
        private Customer[] _customers;

        internal Customer[] Customers { get => _customers; set => _customers = value; }

        public Customer this[int index] => Customers[index];
    }
}
