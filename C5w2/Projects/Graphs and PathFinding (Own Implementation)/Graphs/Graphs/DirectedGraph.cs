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
            GraphNode<T> tailNode = Find(tail);
            GraphNode<T> headNode = Find(head);
            
            // one or both nodes do not exist
            if (tailNode == null || headNode == null) return false;

            // edge already exists
            if (tailNode.Neighbors.Contains(headNode)) return false;

            // connect edge
            tailNode.AddNeighbor(headNode);
            return true;
        }

        public override bool RemoveEdge(T tail, T head)
        {
            GraphNode<T> tailNode = Find(tail);
            GraphNode<T> headNode = Find(head);

            // one or both nodes do not exist
            if (tailNode == null || headNode == null) return false;

            // edge does not exist
            if (!tailNode.Neighbors.Contains(headNode)) return false;

            // remove edge
            tailNode.RemoveNeighbor(headNode);
            return true;
        }
    }
}
