using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphEdge<T>
    {
        // Properties
        public GraphNode<T> Head { get; set; }
        public GraphNode<T> Tail { get; set; }

        // Constructor
        public GraphEdge(GraphNode<T> tail, GraphNode<T> head)
        {
            Head = head;
            Tail = tail;
        }

        // Methods
        public bool Contains(GraphNode<T> node)
        {
            return Head.Equals(node) || Tail.Equals(node);
        }

        public override string? ToString()
        {
            // Syntax:
            // {Tail} -> {Head}
            return Tail + " -> " + Head;
        }
    }
}
