using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphNode<T>
    {
        // Fields
        public T Value { get; set; }
        List<GraphNode<T>> neighbors;

        // Constructor
        public GraphNode(T value)
        {
            Value = value;
            neighbors = new List<GraphNode<T>>();
        }

        public int NeighborsCount
        {
            get { return neighbors.Count; }
        }

        public IList<GraphNode<T>> Neighbors
        {
            get { return neighbors.AsReadOnly(); }
        }

        // Methods
        public bool AddNeighbor(GraphNode<T> neighbor)
        {
            if (HasNeighbor(neighbor)) return false;
            neighbors.Add(neighbor);
            return true;
        }

        public bool RemoveNeighbor(GraphNode<T> neighbor) => neighbors.Remove(neighbor);
        public bool HasNeighbor(GraphNode<T> neighbor) => neighbors.Contains(neighbor);
        public void ClearNeighbors() => neighbors.Clear();

        public override string? ToString()
        {
            // Syntax:
            // Value: {value}; Neighbors: {val1, val2, ..., valN}
            // where 'val' are the neighbors' values
            StringBuilder builder = new StringBuilder();
            builder.Append("Value: ");
            builder.Append((Value == null)? "[Value Not Set]" : Value.ToString());
            builder.Append("; Neighbors: ");
            if (neighbors.Count == 0)
            {
                builder.Append("[No Neighbors]");
            }
            else
            {
                int i;
                for (i = 0; i < neighbors.Count - 1; i++)
                {
                    builder.Append(neighbors[i].Value);
                    builder.Append(", ");
                }
                builder.Append(neighbors[i].Value);
            }
            return builder.ToString();
        }
    }
}
