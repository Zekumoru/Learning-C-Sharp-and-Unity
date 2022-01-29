using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    /// <summary>
    /// Exercise 1 solution
    /// </summary>
    class Program
    {
        static Random random = new Random();

        /// <summary>
        /// Tests LastIndexOf and AllIndexesOf methods
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // build test dynamic array
            UnorderedIntDynamicArray array = new UnorderedIntDynamicArray();

            // test LastIndexOf with one item in dynamic array
            array.Add(24);
            Console.WriteLine(array.LastIndexOf(24));

            // test LastIndexOf with multiple items in the dynamic array
            array.Add(GenerateRandomIntRange(0, 100));
            array.Add(57);
            array.Add(GenerateRandomIntRange(0, 100));
            array.Add(GenerateRandomIntRange(0, 100));
            array.Add(57);
            array.Add(GenerateRandomIntRange(0, 100));
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.LastIndexOf(57));

            // test LastIndexOf with item not in dynamic array
            Console.WriteLine(array.LastIndexOf(123));

            // test AllIndexesOf with one item in dynamic array
            Console.WriteLine(array.AllIndexesOf(24));

            // test AllIndexesOf with multiple items in dynamic array
            Console.WriteLine(array.AllIndexesOf(57));

            // test AllIndexesOf with item not in dynamic array
            Console.WriteLine(array.AllIndexesOf(123));

            Console.WriteLine();
        }

        static int GenerateRandomIntRange(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
