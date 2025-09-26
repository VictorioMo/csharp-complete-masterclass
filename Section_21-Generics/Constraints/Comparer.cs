using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constraints
{
    internal class Comparer
    {
        // Generic method with type constraint
        public static bool AreEqual<T>(T a, T b) where T : class
        {
            return a == b; // if no overload for '==' is present,
                           // this returns true only if the memory adresses are the same. (same reference)
        }
    }
}
