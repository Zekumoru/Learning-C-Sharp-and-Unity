using System;

namespace TowersOfHanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of discs: ");

            int numOfDiscs;
            while (!int.TryParse(Console.ReadLine(), out numOfDiscs))
            {
                Console.Write("Invalid input! Enter number of discs again: ");
            }

            var hanoi = new TowersOfHanoi(numOfDiscs);
            hanoi.Solve(1, 3);
            Console.WriteLine(hanoi);
            Console.WriteLine("Total moves count: " + hanoi.Moves.Count);
        }
    }
}