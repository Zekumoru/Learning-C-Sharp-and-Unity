
namespace Queues
{
    internal static class Test
    {
        public static void Run()
        {
            Console.WriteLine("TESTING QUEUE");
            Console.WriteLine();

            TestConstructor();
            TestEnqueue();
            TestDequeue();
            TestPeek();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("TESTING PRIORITY QUEUE");
            Console.WriteLine();

            TestPriorityConstructor();
            TestPriorityEnqueue();
            TestPriorityDequeue();
            TestPriorityPeek();
        }

        static void TestConstructor()
        {
            Console.WriteLine("Testing Constructor");

            var queue = new Queue<string>();

            TestCase(1);
            if (queue.Count == 0) Passed();
            else Failed();

            Console.WriteLine();
        }

        static void TestPriorityConstructor()
        {
            Console.WriteLine("Testing Constructor");

            var queue = new PriorityQueue<string>();

            TestCase(1);
            if (queue.Count == 0) Passed();
            else Failed();

            Console.WriteLine();
        }

        static void TestEnqueue()
        {
            Console.WriteLine("Testing Enqueue");

            var queue = new Queue<string>();

            TestCase(1);
            queue.Enqueue("Bob");
            queue.Enqueue("Carl");
            if (queue.Count == 2) Passed();
            else Failed();

            Console.WriteLine();
        }

        static void TestPriorityEnqueue()
        {
            Console.WriteLine("Testing Enqueue");

            var queue = new PriorityQueue<string>();

            TestCase(1);
            queue.Enqueue("Bob");
            queue.Enqueue("Carl");
            queue.Enqueue("Alex");
            if (queue.Count == 3 && queue.Peek() == "Alex") Passed();
            else Failed();

            Console.WriteLine();
        }

        static void TestDequeue()
        {
            Console.WriteLine("Testing Dequeue");

            string dequeued;
            var queue = new Queue<string>();

            TestCase(1);
            queue.Enqueue("Bob");
            queue.Enqueue("Carl");
            dequeued = queue.Dequeue();
            if (queue.Count == 1 && dequeued == "Bob") Passed();
            else Failed();

            TestCase(2);
            dequeued = queue.Dequeue();
            if (queue.Count == 0 && dequeued == "Carl") Passed();
            else Failed();

            TestCase(3);
            try
            {
                dequeued = queue.Dequeue();
                Failed();
            }
            catch (InvalidOperationException e)
            {
                Passed();
            }

            Console.WriteLine();
        }

        static void TestPriorityDequeue()
        {
            Console.WriteLine("Testing Dequeue");

            string dequeued;
            var queue = new PriorityQueue<string>();

            TestCase(1);
            queue.Enqueue("Bob");
            queue.Enqueue("Alex");
            queue.Enqueue("Carl");
            dequeued = queue.Dequeue();
            if (queue.Count == 2 && dequeued == "Alex") Passed();
            else Failed();

            TestCase(2);
            queue.Enqueue("Annie");
            dequeued = queue.Dequeue();
            if (dequeued == "Annie") Passed();
            else Failed();

            TestCase(3);
            queue.Enqueue("Zekumoru");
            dequeued = queue.Dequeue();
            if (dequeued == "Bob") Passed();
            else Failed();

            TestCase(4);
            try
            {
                dequeued = queue.Dequeue();
                dequeued = queue.Dequeue();
                dequeued = queue.Dequeue();
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

            var queue = new Queue<string>();

            TestCase(1);
            queue.Enqueue("Bob");
            queue.Enqueue("Carl");
            if (queue.Count == 2 && queue.Peek() == "Bob") Passed();
            else Failed();

            TestCase(2);
            queue.Dequeue();
            if (queue.Peek() == "Carl") Passed();
            else Failed();

            TestCase(3);
            queue.Dequeue();
            try
            {
                string peeked = queue.Dequeue();
                Failed();
            }
            catch (InvalidOperationException e)
            {
                Passed();
            }

            Console.WriteLine();
        }

        static void TestPriorityPeek()
        {
            Console.WriteLine("Testing Peek");

            var queue = new PriorityQueue<string>();

            TestCase(1);
            queue.Enqueue("Zekumoru");
            queue.Enqueue("Annie");
            if (queue.Peek() == "Annie" && queue.Count == 2) Passed();
            else Failed();

            TestCase(2);
            queue.Dequeue();
            if (queue.Peek() == "Zekumoru") Passed();
            else Failed();

            TestCase(3);
            queue.Dequeue();
            try
            {
                string peeked = queue.Dequeue();
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
