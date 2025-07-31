using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    internal class Rectangle
    {
        // const needs to be assigned during compile time
        public const int NumberOfCorners = 4;

        // readonly can be either initialized during compile time or via constructor
        public readonly string Color;

        public double Width { get; set; }
        public double Height { get; set; }

        public double Area { get => Width * Height; }

        public Rectangle(string color)
        {
            Color = color;
        }
    }
}
