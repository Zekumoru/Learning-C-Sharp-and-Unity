using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.PathFinding.Dijkstra
{
    internal class SearchNode<T> : IComparable
    {
        public GraphNode<T> GraphNode { get; private set; }
        public WeightedGraphEdge<T> GraphEdge { get; set; }
        public SearchNode<T> Previous { get; set; }
        public float Distance { get; set; }

        public SearchNode(GraphNode<T> node)
        {
            GraphNode = node;
            GraphEdge = null;
            Previous = null;
            Distance = float.MaxValue;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            SearchNode<T> other = obj as SearchNode<T>;

            if (other == null) throw new ArgumentException("Object is not a SearchNode");
            
            if (Distance < other.Distance) return -1;
            if (Distance > other.Distance) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"Node: {GraphNode.Value}; Previous: {Previous.GraphNode.Value} (Distance: {Distance})";
        }
    }
}
