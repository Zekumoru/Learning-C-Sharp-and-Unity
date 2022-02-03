using System;

namespace Stack
{
    internal static class Test
    {
        public static void Run()
        {
            TestConstructor();
            TestPush();
            TestPop();
            TestPeek();
        }

        static void TestConstructor()
        {
            Console.WriteLine("Testing Constructor");

            var stack = new Stack<string>();

            TestCase(1);
            if (stack.Count == 0) Passed();
            else Failed();

            Console.WriteLine();
        }

        static void TestPush()
        {
            Console.WriteLine("Testing Push");

            var stack = new Stack<string>();

            TestCase(1);
            stack.Push("Bob");
            stack.Push("Carl");
            if (stack.Count == 2) Passed();
            else Failed();

            Console.WriteLine();
        }

        static void TestPop()
        {
            Console.WriteLine("Testing Pop");

            string popped;
            var stack = new Stack<string>();

            TestCase(1);
            stack.Push("Bob");
            stack.Push("Carl");
            popped = stack.Pop();
            if (stack.Count == 1 && popped == "Carl") Passed();
            else Failed();

            TestCase(2);
            popped = stack.Pop();
            if (stack.Count == 0 && popped == "Bob") Passed();
            else Failed();

            TestCase(3);
            try
            {
                popped = stack.Pop();
                Failed();
            }
            catch (InvalidOperationException e)
            {
                Passed();
            }

            Console.WriteLine();
        }

        static void TestPeek()
        {
            Console.WriteLine("Testing Peek");

            string peeked;
            var stack = new Stack<string>();

            TestCase(1);
            stack.Push("Bob");
            stack.Push("Carl");
            peeked = stack.Peek();
            if (stack.Count == 2 && peeked == "Carl") Passed();
            else Failed();

            TestCase(2);
            stack.Pop();
            peeked = stack.Peek();
            if (peeked == "Bob") Passed();
            else Failed();

            TestCase(3);
            stack.Pop();
            try
            {
                peeked = stack.Pop();
                Failed();
            }
            catch (InvalidOperationException e)
            {
                Passed();
            }

            Console.WriteLine();
        }

        static void TestCase(int n) => Console.Write("Test Case " + n + ": ");

        static void Passed() => Console.WriteLine("Passed");

        static void Failed() => Console.WriteLine("Failed");
    }
}
