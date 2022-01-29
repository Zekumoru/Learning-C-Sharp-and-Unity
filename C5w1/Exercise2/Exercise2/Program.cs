using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    /// <summary>
    /// Exercise 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Uses ordered generic dynamic array
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            OrderedDynamicArray<Rectangle> array = new OrderedDynamicArray<Rectangle>();
            array.Add(new Rectangle(1, 2));
            array.Add(new Rectangle(5, 6));
            array.Add(new Rectangle(3, 2));
            array.Print();
        }
    }
}
