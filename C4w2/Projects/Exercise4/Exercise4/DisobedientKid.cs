using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class DisobedientKid : Kid
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Leave ME alone!!");
        }
    }
}
