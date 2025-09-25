using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroGenerics
{
    // Class is not generic
    internal class Logger
    {
        // But still can have generic methods
        public void Log<T>(T message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}
