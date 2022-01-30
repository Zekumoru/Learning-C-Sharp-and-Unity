using System;

namespace ImplementingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImplementingLinkedList.LinkedList<int> list = new ImplementingLinkedList.SortedLinkedList<int>();
            list.Add(2);
            list.Add(3);
            list.Add(7);
            list.Add(6);
            list.Add(1);
            list.Add(9);
            PrintList(list);

            list.Remove(3);
            PrintList(list);

            list.Remove(2);
            PrintList(list);

            list.Clear();
            PrintList(list);
        }

        static void PrintList<T>(ImplementingLinkedList.LinkedList<T> list)
        {
            Console.WriteLine("Values: " + list);
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine();
        }
    }
}