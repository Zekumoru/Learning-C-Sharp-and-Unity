using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class WeightedGraphEdge<T>
    {
        // Properties
        public GraphNode<T> Head { get; set; }
        public GraphNode<T> Tail { get; set; }
        public int Distance { get; set; }

        // Constructor
        public WeightedGraphEdge(GraphNode<T> tail, GraphNode<T> head, int weight)
        {
            Head = head;
            Tail = tail;
            Distance = weight;
        }

        // Methods
        public bool Contains(GraphNode<T> node)
        {
            return Head.Equals(node) || Tail.Equals(node);
        }

        public override string? ToString()
        {
            // Syntax:
            // {Tail} -> {Head} ({Weight})
            return Tail + " -> " + Head + " (" + Distance + ")";
        }
    }
}
