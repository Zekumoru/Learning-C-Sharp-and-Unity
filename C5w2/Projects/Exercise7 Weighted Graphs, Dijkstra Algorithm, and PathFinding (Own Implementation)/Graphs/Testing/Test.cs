using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Testing
{
    internal abstract class Test
    {
        public abstract void EvaluateTests();
        protected void Print(string str) => Console.Write(str);
        protected void PrintLine() => Console.WriteLine();
        protected void PrintLine(string str) => Console.WriteLine(str);
        protected void Passed() => Console.WriteLine("Passed");
        protected void Failed() => Console.WriteLine("Failed");
    }
}
