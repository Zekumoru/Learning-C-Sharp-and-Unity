using System;

namespace Factorial
{
    internal class Program
    {
        /*  There's a method called Solve which basically does the Tail Recursive search
         *  since that's much more efficient in terms of space complexity, I made it as
         *  the default solve recursion algorithm.
         */
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial.RecursiveSolve(10));
        }
    }
}