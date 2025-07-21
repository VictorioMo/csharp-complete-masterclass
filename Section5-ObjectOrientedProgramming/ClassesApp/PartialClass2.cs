using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    public partial class PartialClass
    {
        public int Field1_2 { get; set; }

        public partial void DoSomething()
        {
            Console.WriteLine($"I did something for {this}");
        }
    }
}
