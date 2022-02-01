using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.PathFinding
{
    internal class GraphPathFinder<T>
    {
        public LinkedList<GraphNode<T>> Search(T start, T finish,
            Graph<T> graph, SearchType searchType)
        {
            // make sure both of the vertices exist
            if (graph.FindNode(start) == null || graph.FindNode(finish) == null) return null;

            var startNode = graph.FindNode(start);
            var searchList = new LinkedList<GraphNode<T>>();
            var pathNodes = new Dictionary<GraphNode<T>, PreviousPathNode<T>>();

            // if the start and target nodes/vertices are the same
            if (start.Equals(finish)) return ConvertToLinkedListPath(startNode, pathNodes);

            pathNodes.Add(startNode, new PreviousPathNode<T>(null));
            /*  pathNodes contains the path, so with this add,
            *  we have the startNode as the key to the previous
            *  node, in which case, there's no previous node
            *  since we're still starting out (duh)
            *  
            *  Hence, pathNodes' keys contain the previous node
            */

            searchList.AddFirst(startNode);
            /*  searchList contains the list of nodes to search,
            *  it is also what makes breadth-first and depth-first
            *  searches possible
            */

            while (searchList.Count > 0)
            {
                // get the first element in the searchList
                GraphNode<T> currentNode = searchList.First.Value;
                searchList.RemoveFirst();

                foreach (var neighbor in graph.FindNeighbors(currentNode))
                {
                    if (neighbor.Value.Equals(finish))
                    {
                        pathNodes.Add(neighbor, new PreviousPathNode<T>(currentNode));
                        return ConvertToLinkedListPath(neighbor, pathNodes);
                    }
                    if (pathNodes.ContainsKey(neighbor)) continue;

                    pathNodes.Add(neighbor, new PreviousPathNode<T>(currentNode));

                    if (searchType == SearchType.DepthFirst)
                    {
                        searchList.AddFirst(neighbor);
                    }
                    else if (searchType == SearchType.BreadthFirst)
                    {
                        searchList.AddLast(neighbor);
                    }
                }
            }

            return null;
        }

        LinkedList<GraphNode<T>> ConvertToLinkedListPath(GraphNode<T> endNode, 
            Dictionary<GraphNode<T>, PreviousPathNode<T>> pathNodes)
        {
            var path = new LinkedList<GraphNode<T>>();
            path.AddFirst(endNode);
            
            if (!pathNodes.ContainsKey(endNode)) return path;

            var previousNode = pathNodes[endNode].Previous;
            while (previousNode != null)
            {
                path.AddFirst(previousNode);
                previousNode = pathNodes[previousNode].Previous;
            }
            return path;
        }

        public string ConvertPathToString(LinkedList<GraphNode<T>> path)
        {
            if (path == null) return "No path found.";

            var pathString = new StringBuilder();
            var currentNode = path.First;
            int nodeCount = 0;
            while (currentNode != null)
            {
                nodeCount++;
                pathString.Append(currentNode.Value.Value);
                if (nodeCount < path.Count)
                {
                    pathString.Append(" -> ");
                }
                currentNode = currentNode.Next;
            }

            return pathString.ToString();
        }
    }
}
