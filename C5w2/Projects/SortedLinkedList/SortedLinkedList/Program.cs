using System;
using System.Text;

namespace SortedLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestAdding();
            Console.WriteLine();
            TestRepositioning();
        }

        static void Test()
        {
            Console.WriteLine("Testing something...");

            var list = new SortedLinkedList<int>();

            list.Add(1);

            var first = list.First;

            list.Add(2);
            list.Add(3);

            list.AddBefore(first, new LinkedListNode<int>(4));

            TestCase(1);
            if (LinkedListToString(list) == "4, 1, 2, 3") Passed();
            else Failed();

            TestCase(2);
            if (list.First() == 4) Passed();
            else Failed();
        }

        static void TestAdding()
        {
            Console.WriteLine("Testing adding");

            var list = new SortedLinkedList<int>();

            // Test adding
            TestCase(1);
            list.Add(1);
            if (list.First.Value == 1) Passed();
            else Failed();

            // Test adding greater
            TestCase(2);
            list.Add(4);
            if (list.First.Value == 1 && list.Contains(4)) Passed();
            else Failed();

            // Test adding lesser
            TestCase(3);
            list.Add(-5);
            if (list.First.Value == -5) Passed();
            else Failed();

            // Test current items
            TestCase(4);
            if (LinkedListToString(list) == "-5, 1, 4") Passed();
            else Failed();

            // Test add with sorting
            TestCase(5);
            list.Add(-2);
            list.Add(2);
            list.Add(-3);
            list.Add(7);
            if (LinkedListToString(list) == "-5, -3, -2, 1, 2, 4, 7") Passed();
            else Failed();

            // Test extensively
            TestCase(6);
            list.Add(56);
            list.Add(24);
            list.Add(1);
            list.Add(-152);
            list.Add(34);
            list.Add(34);
            list.Add(98);
            list.Add(34);
            list.Add(-55);
            if (LinkedListToString(list) == "-152, -55, -5, -3, -2, 1, 1, 2, 4, 7, 24, 34, 34, 34, 56, 98") Passed();
            else Failed();
        }

        static void TestRepositioning()
        {
            Console.WriteLine("Testing repositioning");

            var list = new SortedLinkedList<int>();

            // list: 5, 12, 7
            list.AddLast(5);
            list.AddLast(12);
            list.AddLast(7);

            // Test repositioning
            TestCase(1);
            list.Reposition(7);
            if (LinkedListToString(list) == "5, 7, 12") Passed();
            else Failed();

            // Test repositioning multiple
            TestCase(2);
            list.AddLast(3);
            list.AddLast(3);
            list.Reposition(3);
            if (LinkedListToString(list) == "3, 3, 5, 7, 12") Passed();
            else Failed();
        }

        static string LinkedListToString<T>(LinkedList<T> list)
        {
            // Syntax: {item}, {item}, ..., {item}
            var builder = new StringBuilder();
            var current = list.First;

            while (current != null)
            {
                builder.Append(current.Value);
                current = current.Next;
                if (current != null) builder.Append(", ");
            }

            return builder.ToString();
        }

        static void TestCase(int n) => Console.Write("Test Case " + n + ": ");
        static void Passed() => Console.WriteLine("Passed");
        static void Failed() => Console.WriteLine("Failed");
    }
}