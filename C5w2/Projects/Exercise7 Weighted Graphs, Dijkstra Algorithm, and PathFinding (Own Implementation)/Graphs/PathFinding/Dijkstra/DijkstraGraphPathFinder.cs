using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.Utils;

namespace Graphs.PathFinding.Dijkstra
{
    internal class DijkstraGraphPathFinder<T>
    {
        public float PathLength { get; private set; }

        public DijkstraGraphPathFinder() => PathLength = float.MaxValue;

        public LinkedList<WeightedGraphEdge<T>> Search(T start, T end, WeightedGraph<T> graph)
        {
            var searchList = new SortedLinkedList<SearchNode<T>>();
            var searchNodes = new Dictionary<GraphNode<T>, SearchNode<T>>();
            /*  searchNodes serves to find the search nodes of the neighbors of graph node
             *  and also, it serves to keep track of already searched nodes
             */

            GraphNode<T> startNode = graph.FindNode(start);
            GraphNode<T> endNode = graph.FindNode(end);

            // Initialize the list and the dictionary
            SearchNode<T> searchNode;
            foreach (var node in graph.Nodes)
            {
                searchNode = new SearchNode<T>(node);

                if (node == startNode) searchNode.Distance = 0f;

                searchList.Add(searchNode);
                searchNodes.Add(node, searchNode);
            }

            // Begin search here
            while (searchList.Count > 0)
            {
                SearchNode<T> currentSearchNode = searchList.First.Value;
                searchList.RemoveFirst();

                GraphNode<T> currentGraphNode = currentSearchNode.GraphNode;
                searchNodes.Remove(currentGraphNode);

                if (currentGraphNode == endNode)
                {
                    if (currentSearchNode.Distance == float.MaxValue) return new LinkedList<WeightedGraphEdge<T>>();
                    return BuildPath(currentSearchNode);
                }

                foreach (var edge in graph.FindEdges(currentGraphNode))
                {
                    // check if neighbor (edge.Head) is still in search list
                    if (searchNodes.ContainsKey(edge.Head))
                    {
                        float distance = currentSearchNode.Distance + edge.Distance;

                        var neighborSearchNode = searchNodes[edge.Head];
                        if (distance < neighborSearchNode.Distance)
                        {
                            neighborSearchNode.Distance = distance;
                            neighborSearchNode.Previous = currentSearchNode;
                            neighborSearchNode.GraphEdge = edge;
                            searchList.Reposition(neighborSearchNode);
                        }
                    }
                }
            }

            return new LinkedList<WeightedGraphEdge<T>>();
        }

        private LinkedList<WeightedGraphEdge<T>> BuildPath(SearchNode<T> endNode)
        {
            // note that endNode.Distance contains the total length of the path
            PathLength = endNode.Distance;

            var path = new LinkedList<WeightedGraphEdge<T>>();
            path.AddFirst(endNode.GraphEdge);

            var previous = endNode.Previous;
            while (previous.GraphEdge != null)
            {
                path.AddFirst(previous.GraphEdge);
                previous = previous.Previous;
            }

            return path;
        }
    }
}
