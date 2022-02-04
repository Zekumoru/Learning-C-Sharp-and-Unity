using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoi
{
    internal class Move
    {
        public int Disc { get; private set; }
        public int From { get; private set; }
        public int To { get; private set; }

        public Move(int disc, int from, int to)
        {
            Disc = disc;
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"Moved disc {Disc} from peg {From} to peg {To}";
        }
    }
}
