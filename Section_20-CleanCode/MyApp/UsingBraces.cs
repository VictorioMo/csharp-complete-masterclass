using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class UsingBraces
    {
        /* Always use braces */
        // Even if you have a situation like this:

        public void DoSomething(string action)
        {
            if (action == "sleep")
                Console.WriteLine("Sleeping.");

            // Technically this code works, but it lacks visibility, so use braces always! { }

            if (action == "Walk")
            {
                Console.WriteLine("Walking.");
            }
        }
    }
}
