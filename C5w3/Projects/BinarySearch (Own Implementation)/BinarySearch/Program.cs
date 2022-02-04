using System;
using BinarySearch;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = BuildIntList();
            int index;

            index = BinarySearch<int>.GetIndexOf(45, list);
            Console.WriteLine(index); // must be -1

            index = BinarySearch<int>.GetIndexOf(33, list);
            Console.WriteLine(index); // must be 6
        }

        static List<int> BuildIntList()
        {
            var list = new List<int>();

            list.Add(3);    // 0
            list.Add(7);    // 1
            list.Add(15);   // 2
            list.Add(17);   // 3
            list.Add(20);   // 4
            list.Add(24);   // 5
            list.Add(33);   // 6
            list.Add(38);   // 7
            list.Add(42);   // 8
            list.Add(57);   // 9

            return list;
        }
    }
}