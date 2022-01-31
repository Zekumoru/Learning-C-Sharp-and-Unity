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

        // Constructor
        public Graph()
        {
            nodes = new List<GraphNode<T>>();
        }

        // Properties
        public int Count
        {
            get { return nodes.Count; }
        }

        public IList<GraphNode<T>> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }

        // Methods
        public bool AddNode(T value)
        {
            if (value == null) return false;
            if (Find(value) != null) return false;
            nodes.Add(new GraphNode<T>(value));
            return true;
        }

        public bool RemoveNode(T value)
        {
            GraphNode<T> toRemoveNode = Find(value);
            if (toRemoveNode == null) return false;

            nodes.Remove(toRemoveNode);
            foreach (GraphNode<T> node in nodes)
            {
                node.RemoveNeighbor(toRemoveNode);
            }
            return true;
        }

        public abstract bool AddEdge(T value1, T value2);
        public abstract bool RemoveEdge(T value1, T value2);

        public void ClearNodes()
        {
            foreach (GraphNode<T> node in nodes)
            {
                node.ClearNeighbors();
            }
            nodes.Clear();
        }

        public GraphNode<T> Find(T value)
        {
            if (value == null) return null;
            foreach (GraphNode<T> node in nodes)
            {
                if (value.Equals(node.Value)) return node;
            }
            return null;
        }

        public override string? ToString()
        {
            if (nodes.Count == 0) return "Graph is empty!";

            // Syntax:
            // {node1}, {node2}, ..., {node3}
            // '{}' included
            StringBuilder builder = new StringBuilder();
            
            int i;
            builder.Append("{");
            for (i = 0; i < nodes.Count - 1; i++)
            {
                builder.Append(nodes[i].ToString());
                builder.Append("}, {");
            }
            builder.Append(nodes[i].ToString());
            builder.Append("}");

            return builder.ToString();
        }
    }
}
