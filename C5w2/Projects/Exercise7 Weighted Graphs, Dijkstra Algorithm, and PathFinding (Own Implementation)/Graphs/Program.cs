using System;
using System.Text;
using Graphs.PathFinding;
using Graphs.PathFinding.Dijkstra;
using Graphs.Testing;


/*  Graphs, Weighted Graphs, And Pathfinding
 *  
 *  I implemented the weighted graph pathfinding using graph edges
 *  so a lot in this solution's code has changed.
 *  
 *  Also, I am FULLY aware that I duplicated too much code.
 *  I was trying to make the weighted graph pathfinding work,
 *  I was already too deep with my implementation of graph edges
 *  hence I had to recreate the Graph class with a WeightedGraph
 *  class.
 *  
 *  There's a flaw with my design so even if I wanted to apply
 *  inheritance, I could not. Besides, I was only trying to complete
 *  this exercise hence I won't be optimizing/refactoring to that
 *  optimal solution.
 *  
 *  Cuz' RIP me, it's already been like, what? 7 hours of headaches.
 *  Though, I did learn a ton for sure.
 *  
 *  If you were to ask me what kind of solution I'm thinking so that
 *  I can apply inheritance and keep the DRY principle then I think
 *  it would be better to use the Weighted Graph Pathfinding version
 *  and refactor the unweighted one from there.
 *  
 *  There's that FindNeighbors method within the Graph classes that
 *  with the weighted graph pathfinding version, we don't need it all.
 *  
 *  Anyways, this is how I implemented the exercise 7 of course 5 week 2.
 *  Yours sincerely, Zekumoru. :D
 *  
 *  UPDATE: Well, I figured, since I already implemented here my own
 *          weighted graph implementation, I am going to re-implement
 *          Dijkstra algorithm from the Programming Assignment 2 here.
 *          
 *          It wasn't that difficult implementing it my graph edges,
 *          though, it wasn't that very easy either. Anyways, as
 *          always, I learned a ton here again. :D
 */
namespace Graphs
{
    internal class Program
    {
        static int start = 4;
        static int end = 1;

        static void Main(string[] args)
        {
            RunDijkstraAlgorithmTest();
            Console.WriteLine();

            //RunPathFindingTest();
            //Console.WriteLine();

            RunWeightedPathFindingTest();
        }

        static void RunDijkstraAlgorithmTest()
        {
            Console.WriteLine("Dijkstra Algorithm Search");

            var graph = BuildWeightedGraph(new UndirectedWeightedGraph<int>());
            var dijkstraPathFinder = new DijkstraGraphPathFinder<int>();

            var path = dijkstraPathFinder.Search(start, end, graph);
            Console.WriteLine(ConvertPathToString(path));
            Console.WriteLine("Path length: " + dijkstraPathFinder.PathLength);
        }

        static void RunWeightedPathFindingTest()
        {
            var graph = BuildWeightedGraph(new UndirectedWeightedGraph<int>());
            var pathFinder = new WeightedGraphPathFinder<int>();

            LinkedList<WeightedGraphEdge<int>> path;

            Console.WriteLine("Depth-First Search");
            path = pathFinder.Search(start, end, graph, SearchType.DepthFirst);
            Console.WriteLine(ConvertPathToString(path));
            Console.WriteLine("Path length: " + pathFinder.PathLength);
            Console.WriteLine();

            Console.WriteLine("Breadth-First Search");
            path = pathFinder.Search(start, end, graph, SearchType.BreadthFirst);
            Console.WriteLine("Path length: " + pathFinder.PathLength);
            Console.WriteLine(ConvertPathToString(path));
        }

        static void RunPathFindingTest()
        {
            var graph = BuildGraph(new UndirectedGraph<int>());
            var pathFinder = new GraphPathFinder<int>();

            LinkedList<GraphNode<int>> path;

            Console.WriteLine("Depth-First Search");
            path = pathFinder.Search(start, end, graph, SearchType.DepthFirst);
            Console.WriteLine(ConvertPathToString(path));
            Console.WriteLine();
            
            Console.WriteLine("Breadth-First Search");
            path = pathFinder.Search(start, end, graph, SearchType.BreadthFirst);
            Console.WriteLine(ConvertPathToString(path));
        }

        static string ConvertPathToString<T>(LinkedList<T> path)
        {
            if (path == null || path.Count == 0) return "There's no path";

            var builder = new StringBuilder();
            var currentNode = path.First;
            int count = 0;

            while (currentNode != null)
            {
                builder.Append(currentNode.Value);
                currentNode = currentNode.Next;
                count++;
                if (count != path.Count) builder.Append(" -> ");
            }

            return builder.ToString();
        }

        static string ConvertPathToString<T>(LinkedList<WeightedGraphEdge<T>> path)
        {
            // Syntax: {value} | {value} | ... | {value}
            if (path == null || path.Count == 0) return "There's no path";

            var builder = new StringBuilder();
            var currentNode = path.First;
            int count = 0;
            while (currentNode != null)
            {
                builder.Append(currentNode.Value);
                currentNode = currentNode.Next;
                count++;
                if (count != path.Count) builder.Append(" | ");
            }
            return builder.ToString();
        }

        static string ConvertPathToString<T>(LinkedList<GraphNode<T>> path)
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

        static WeightedGraph<int> BuildWeightedGraph(WeightedGraph<int> graph)
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

            graph.AddEdge(1, 5,   5*2);
            graph.AddEdge(4, 11,  11*2);
            graph.AddEdge(4, 42,  42*2);
            graph.AddEdge(5, 11,  511);
            graph.AddEdge(5, 12,  12*2);
            graph.AddEdge(5, 42,  542);
            graph.AddEdge(7, 10,  10*2);
            graph.AddEdge(7, 11,  11*2);
            graph.AddEdge(10, 11, 11*2);
            graph.AddEdge(11, 42, 42*2);
            graph.AddEdge(12, 42, 42*2);

            return graph;
        }
    }
}