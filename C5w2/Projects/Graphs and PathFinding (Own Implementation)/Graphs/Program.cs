using System;
using Graphs.PathFinding;

namespace Graphs
{
    internal class Program
    {
        static int start = 4;
        static int end = 1;

        static void Main(string[] args)
        {
            var graph = BuildGraph(new UndirectedGraph<int>());
            var pathFinder = new GraphPathFinder<int>();

            LinkedList<GraphNode<int>> path;

            Console.WriteLine("Depth-First Search");
            path = pathFinder.Search(start, end, graph, SearchType.DepthFirst);
            Console.WriteLine(pathFinder.ConvertPathToString(path));

            Console.WriteLine();
            Console.WriteLine("Breadth-First Search");
            path = pathFinder.Search(start, end, graph, SearchType.BreadthFirst);
            Console.WriteLine(pathFinder.ConvertPathToString(path));
        }

        static Graph<int> BuildGraph(Graph<int> graph)
        {
            graph.AddNode(1);
            graph.AddNode(4);
            graph.AddNode(5);
            graph.AddNode(7);
            graph.AddNode(10);
            graph.AddNode(11);
            graph.AddNode(12);
            graph.AddNode(42);
            graph.AddNode(88);

            graph.AddEdge(1, 5);
            graph.AddEdge(4, 11);
            graph.AddEdge(4, 42);
            graph.AddEdge(5, 11);
            graph.AddEdge(5, 12);
            graph.AddEdge(5, 42);
            graph.AddEdge(7, 10);
            graph.AddEdge(7, 11);
            graph.AddEdge(10, 11);
            graph.AddEdge(11, 42);
            graph.AddEdge(12, 42);

            return graph;
        }
    }
}