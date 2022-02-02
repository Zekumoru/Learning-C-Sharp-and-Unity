using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.PathFinding
{
    internal class WeightedGraphPathFinder<T>
    {
        public float PathLength { get; private set; }

        public WeightedGraphPathFinder() => PathLength = float.MaxValue;

        public LinkedList<WeightedGraphEdge<T>> Search(T start, T finish, WeightedGraph<T> graph, SearchType searchType)
        {
            // make sure both the vertices exist
            if (graph.FindNode(start) == null || graph.FindNode(finish) == null) return new LinkedList<WeightedGraphEdge<T>>();

            var startNode = graph.FindNode(start);
            var searchList = new LinkedList<GraphNode<T>>();
            var pathNodes = new Dictionary<GraphNode<T>, WeightedGraphEdge<T>>();

            pathNodes.Add(startNode, new WeightedGraphEdge<T>(null, startNode, 0));
            searchList.AddFirst(startNode);

            // if the start and finish are the same
            if (start.Equals(finish)) return ConvertToLinkedListPath(startNode, pathNodes);
            
            while (searchList.Count > 0)
            {
                GraphNode<T> currentNode = searchList.First.Value;
                searchList.RemoveFirst();

                foreach (var edge in graph.FindEdges(currentNode))
                {
                    // check if self
                    if (pathNodes.ContainsKey(edge.Head)) continue;

                    // check if finish found
                    if (edge.Head.Value.Equals(finish))
                    {
                        pathNodes.Add(edge.Head, edge);
                        return ConvertToLinkedListPath(edge.Head, pathNodes);
                    }

                    pathNodes.Add(edge.Head, edge);

                    if (searchType == SearchType.DepthFirst)
                    {
                        searchList.AddFirst(edge.Head);
                    }
                    else if (searchType == SearchType.BreadthFirst)
                    {
                        searchList.AddLast(edge.Head);
                    }
                }
            }

            return new LinkedList<WeightedGraphEdge<T>>();
        }

        private LinkedList<WeightedGraphEdge<T>> ConvertToLinkedListPath(GraphNode<T> endNode, Dictionary<GraphNode<T>, WeightedGraphEdge<T>> pathNodes)
        {
            var path = new LinkedList<WeightedGraphEdge<T>>();
            path.AddFirst(pathNodes[endNode]);

            PathLength = 0;

            // this is for when start == finish
            if (pathNodes[endNode].Tail == null) return path;

            GraphNode<T> currentNode = endNode;
            while ((currentNode = pathNodes[currentNode].Tail) != null)
            {
                var edge = pathNodes[currentNode];
                PathLength += edge.Distance;
                if (edge.Tail != null) path.AddFirst(edge);
            }

            return path;
        }
    }
}
