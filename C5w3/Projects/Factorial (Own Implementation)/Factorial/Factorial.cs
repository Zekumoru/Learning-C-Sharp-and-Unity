using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    internal static class Factorial
    {
        public static int Solve(int n)
        {
            return TailRecursiveSolve(n);
        }

        public static int RecursiveSolve(int n)
        {
            if (n == 0) return 1;
            return RecursiveSolve(n - 1) * n;
        }

        public static int TailRecursiveSolve(int n, int accumulated = 1)
        {
            if (n == 1) return accumulated;
            return TailRecursiveSolve(n - 1, accumulated * n);
        }
    }
}
