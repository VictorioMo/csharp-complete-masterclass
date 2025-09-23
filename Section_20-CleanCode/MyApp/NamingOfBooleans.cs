using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class NamingOfBooleans
    {

    }

    partial class OrderProcessor
    {
        /* Always use has, is or other words which defines a state */

        private bool _hasErrors = false;
        private bool _isValid = true;

        public bool IsOrderPending { get; set; }

        /* Even the methods which return booleans 
         * should be named with the same idea in mind */
        public bool IsValid()
        {
            return _isValid;
        }
    }
}
