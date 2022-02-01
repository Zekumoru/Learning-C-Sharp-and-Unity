using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal abstract class Graph<T>
    {
        // Fields
        protected List<GraphNode<T>> nodes;
        protected List<GraphEdge<T>> edges;

        // Constructor
        public Graph()
        {
            nodes = new List<GraphNode<T>>();
            edges = new List<GraphEdge<T>>();
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

        public IList<GraphEdge<T>> Edges
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
            GraphEdge<T> edge;
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

        public abstract bool AddEdge(T value1, T value2);
        public abstract bool RemoveEdge(T value1, T value2);

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
            foreach (GraphEdge<T> edge in edges)
            {
                if (edge.Tail == node) neighbors.Add(edge.Head);
            }

            return neighbors;
        }

        public GraphEdge<T> FindEdge(T value1, T value2)
        {
            if (FindNode(value1) == null || FindNode(value2) == null) return null;
            return FindEdgeProtected(value1, value2);
        }

        protected abstract GraphEdge<T> FindEdgeProtected(T value1, T value2);

        public override string? ToString()
        {
            if (nodes.Count == 0) return "Graph is empty!";

            // Syntax:
            // {Value: {node1}; Neighbors: [{node1}, {node2}, ..., {nodeN}]}, ...
            var nodesAndNeighbors = new Dictionary<GraphNode<T>, List<GraphNode<T>>>();

            foreach (GraphEdge<T> edge in edges)
            {
                if (!nodesAndNeighbors.ContainsKey(edge.Head))
                {
                    nodesAndNeighbors[edge.Head] = new List<GraphNode<T>>();
                }
                if (!nodesAndNeighbors.ContainsKey(edge.Tail))
                {
                    var neighborsList = new List<GraphNode<T>>();
                    neighborsList.Add(edge.Head);
                    nodesAndNeighbors[edge.Tail] = neighborsList;
                }
                else
                {
                    nodesAndNeighbors[edge.Tail].Add(edge.Head);
                }
            }

            int i, j;
            List<GraphNode<T>> neighbors;
            var builder = new StringBuilder();
            builder.Append("{");
            for (i = 0; i < nodes.Count; i++)
            {
                builder.Append("Value: ");
                builder.Append(nodes[i].ToString());

                builder.Append("; Neighbors: [");

                neighbors = nodesAndNeighbors[nodes[i]];
                for (j = 0; j < neighbors.Count; j++)
                {
                    builder.Append(neighbors[j].ToString());

                    if (j < neighbors.Count - 1) builder.Append(", ");
                }
                builder.Append("]");

                if (i < nodes.Count - 1) builder.Append("}, {");
                else  builder.Append("}");
            }

            return builder.ToString();
        }
    }
}
