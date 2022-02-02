using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class UndirectedGraph<T> : Graph<T>
    {
        public UndirectedGraph() : base() { }

        public override bool AddEdge(T value1, T value2)
        {
            GraphNode<T> node1 = FindNode(value1);
            GraphNode<T> node2 = FindNode(value2);

            if (node1 == null || node2 == null) return false;
            if (FindEdgeProtected(value1, value2) != null) return false;
            
            edges.Add(new GraphEdge<T>(node1, node2));
            edges.Add(new GraphEdge<T>(node2, node1));
            return true;
        }

        public override bool RemoveEdge(T value1, T value2)
        {
            GraphEdge<T> edge1 = FindEdgeProtected(value1, value2);
            if (edge1 == null) return false;

            edges.Remove(edge1);
            edges.Remove(FindEdgeProtected(value2, value1));
            return true;
        }

        protected override GraphEdge<T> FindEdgeProtected(T value1, T value2)
        {
            if (value2 == null || value1 == null) return null;
            foreach (GraphEdge<T> edge in edges)
            {
                if (value1.Equals(edge.Head.Value) && value2.Equals(edge.Tail.Value)) return edge;
                if (value2.Equals(edge.Head.Value) && value1.Equals(edge.Tail.Value)) return edge;
            }
            return null;
        }
    }
}
