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
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null) return false;
            if (node1.HasNeighbor(node2)) return false;
            node1.AddNeighbor(node2);
            node2.AddNeighbor(node1);
            return true;
        }

        public override bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null) return false;
            if (!node1.HasNeighbor(node2)) return false;
            node1.RemoveNeighbor(node2);
            node2.RemoveNeighbor(node1);
            return true;
        }
    }
}
