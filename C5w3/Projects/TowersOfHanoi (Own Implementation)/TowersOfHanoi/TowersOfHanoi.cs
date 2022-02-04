using System;
using System.Collections.Generic;
using System.Text;

namespace TowersOfHanoi
{
    internal class TowersOfHanoi
    {
        public int Disc { get; set; }
        public List<Move> Moves { get; private set; }

        public TowersOfHanoi(int numOfDisc)
        {
            Moves = new List<Move>();
            if (numOfDisc > 0) Disc = numOfDisc;
            else Disc = 0;
        }

        public void Solve(int start, int end)
        {
            if (Disc < 1) return;
            if (start < 1 || start > 3 || end < 1 || end > 3) return;

            Hanoi(Disc, start, end);
        }

        void Hanoi(int disc, int start, int end)
        {
            if (disc == 1)
            {
                Moves.Add(new Move(disc, start, end));
                return;
            }

            int other = 6 - (start + end);
            Hanoi(disc - 1, start, other);

            Moves.Add(new Move(disc, start, end));

            Hanoi(disc - 1, other, end);
        }

        public override string ToString()
        {
            if (Disc == 0) return "Make sure the number of discs is not negative nor zero.";
            if (Moves.Count == 0) return "Did you put the correct start and end? \n"
                    + "Remember that: 1 <= start <= 3 and 1 <= end <= 3";

            var builder = new StringBuilder();
            foreach (var move in Moves) builder.AppendLine(move.ToString());
            return builder.ToString();
        }
    }
}
