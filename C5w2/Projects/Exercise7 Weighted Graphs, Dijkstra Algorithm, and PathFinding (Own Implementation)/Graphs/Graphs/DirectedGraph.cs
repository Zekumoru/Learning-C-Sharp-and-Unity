using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class DirectedGraph<T> : Graph<T>
    {
        public DirectedGraph() : base() { }

        public override bool AddEdge(T tail, T head)
        {
            GraphNode<T> headNode = FindNode(head);
            GraphNode<T> tailNode = FindNode(tail);

            if (headNode == null || tailNode == null) return false;
            if (FindEdgeProtected(tail, head) != null) return false;

            edges.Add(new GraphEdge<T>(tailNode, headNode));
            return true;
        }

        public override bool RemoveEdge(T tail, T head)
        {
            GraphEdge<T> edgeToRemove = FindEdgeProtected(tail, head);
            if (edgeToRemove == null) return false;

            edges.Remove(edgeToRemove);
            return true;
        }

        protected override GraphEdge<T> FindEdgeProtected(T tail, T head)
        {
            if (head == null || tail == null) return null;
            foreach (GraphEdge<T> edge in edges)
            {
                if (head.Equals(edge.Head.Value) && tail.Equals(edge.Tail.Value)) return edge;
            }
            return null;
        }
    }
}
