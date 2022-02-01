using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class UndirectedWeightedGraph<T> : WeightedGraph<T>
    {
        public UndirectedWeightedGraph() : base() { }

        public override bool AddEdge(T value1, T value2, int weight)
        {
            GraphNode<T> node1 = FindNode(value1);
            GraphNode<T> node2 = FindNode(value2);

            if (node1 == null || node2 == null) return false;
            var edgesFound = FindEdges(node1, node2);
            foreach (var edge in edgesFound)
            {
                if (edge.Weight == weight) return false;
            }

            edges.Add(new WeightedGraphEdge<T>(node1, node2, weight));
            edges.Add(new WeightedGraphEdge<T>(node2, node1, weight));
            return true;
        }

        public override bool RemoveEdge(T value1, T value2, int weight)
        {
            WeightedGraphEdge<T> edgeToRemove = FindEdge(value1, value2, weight);
            if (edgeToRemove == null) return false;
            edges.Remove(edgeToRemove);
            edges.Remove(FindEdge(value2, value1, weight));
            return true;
        }

        public override bool RemoveEdges(T value1, T value2)
        {
            List<WeightedGraphEdge<T>> edgesToRemove = FindEdges(value1, value2);
            if (edgesToRemove.Count == 0) return false;
            foreach (WeightedGraphEdge<T> edge in edgesToRemove)
            {
                edges.Remove(edge);
            }
            return true;
        }

        public override WeightedGraphEdge<T> FindEdge(T value1, T value2, int weight)
        {
            GraphNode<T> node1 = FindNode(value1);
            GraphNode<T> node2 = FindNode(value2);

            if (node1 == null || node2 == null) return null;
            return FindEdge(node1, node2, weight);
        }

        protected override WeightedGraphEdge<T> FindEdge(GraphNode<T> node1, GraphNode<T> node2, int weight)
        {
            foreach (WeightedGraphEdge<T> edge in edges)
            {
                if (edge.Head == node1 && edge.Tail == node2 && edge.Weight == weight) return edge;
                if (edge.Head == node2 && edge.Tail == node1 && edge.Weight == weight) return edge;
            }
            return null;
        }

        public override List<WeightedGraphEdge<T>> FindEdges(T value1, T value2)
        {
            GraphNode<T> node1 = FindNode(value1);
            GraphNode<T> node2 = FindNode(value2);

            if (node1 == null || node2 == null) return new List<WeightedGraphEdge<T>>();
            return FindEdges(node1, node2);
        }

        protected override List<WeightedGraphEdge<T>> FindEdges(GraphNode<T> node1, GraphNode<T> node2)
        {
            var edgesFound = new List<WeightedGraphEdge<T>>();
            foreach (WeightedGraphEdge<T> edge in edges)
            {
                if (edge.Head == node1 && edge.Tail == node2) edgesFound.Add(edge);
                else if (edge.Head == node2 && edge.Tail == node1) edgesFound.Add(edge);
            }
            return edgesFound;
        }
    }
}
