using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal abstract class WeightedGraph<T>
    {

        public void printEdges()
        {
            foreach (WeightedGraphEdge<T> edge in edges)
            {
                Console.WriteLine(edge);
            }
        }
        // Fields
        protected List<GraphNode<T>> nodes;
        protected List<WeightedGraphEdge<T>> edges;

        // Constructor
        public WeightedGraph()
        {
            nodes = new List<GraphNode<T>>();
            edges = new List<WeightedGraphEdge<T>>();
        }

        // Properties
        public int NodeCount
        {
            get { return nodes.Count; }
        }

        public int EdgeCount
        {
            get { return edges.Count; }
        }

        public IList<GraphNode<T>> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }

        public IList<WeightedGraphEdge<T>> Edges
        {
            get { return edges.AsReadOnly(); }
        }

        // Methods
        public bool AddNode(T value)
        {
            if (value == null) return false;
            if (FindNode(value) != null) return false;
            nodes.Add(new GraphNode<T>(value));
            return true;
        }

        public bool RemoveNode(T value)
        {
            GraphNode<T> toRemoveNode = FindNode(value);
            if (toRemoveNode == null) return false;

            nodes.Remove(toRemoveNode);
            WeightedGraphEdge<T> edge;
            for (int i = edges.Count - 1; i >= 0; i--)
            {
                edge = edges[i];
                if (edge.Contains(toRemoveNode))
                {
                    edges.RemoveAt(i);
                }
            }
            return true;
        }

        public abstract bool AddEdge(T value1, T value2, int weight);
        public abstract bool RemoveEdge(T value1, T value2, int weight);

        public abstract bool RemoveEdges(T value1, T value2);

        public bool RemoveEdge(WeightedGraphEdge<T> edge)
        {
            return edges.Remove(edge);
        }

        public void Clear()
        {
            nodes.Clear();
            edges.Clear();
        }

        public GraphNode<T> FindNode(T value)
        {
            if (value == null) return null;
            foreach (GraphNode<T> node in nodes)
            {
                if (value.Equals(node.Value)) return node;
            }
            return null;
        }

        public List<GraphNode<T>> FindNeighbors(GraphNode<T> node)
        {
            if (!nodes.Contains(node)) return null;

            var neighbors = new List<GraphNode<T>>();
            foreach (WeightedGraphEdge<T> edge in edges)
            {
                if (edge.Tail == node) neighbors.Add(edge.Head);
            }

            return neighbors;
        }

        public abstract WeightedGraphEdge<T> FindEdge(T value1, T value2, int weight);

        protected abstract WeightedGraphEdge<T> FindEdge(GraphNode<T> node1, GraphNode<T> node2, int weight);

        public abstract List<WeightedGraphEdge<T>> FindEdges(T value1, T value2);

        protected abstract List<WeightedGraphEdge<T>> FindEdges(GraphNode<T> node1, GraphNode<T> node2);

        public List<WeightedGraphEdge<T>> FindEdges(T value)
        {
            var node = FindNode(value);
            if (node == null) return new List<WeightedGraphEdge<T>>();
            return FindEdges(node);
        }

        public List<WeightedGraphEdge<T>> FindEdges(GraphNode<T> node)
        {
            var edgesFound = new List<WeightedGraphEdge<T>>();
            foreach (WeightedGraphEdge<T> edge in edges)
            {
                if (edge.Tail == node || edge.Head == node) edgesFound.Add(edge);
            }
            return edgesFound;
        }

        public override string? ToString()
        {
            if (nodes.Count == 0) return "Graph is empty!";

            var builder = new StringBuilder();

            foreach (WeightedGraphEdge<T> edge in edges)
            {
                builder.AppendLine(edge.ToString());
            }

            return builder.ToString();
        }
    }
}
