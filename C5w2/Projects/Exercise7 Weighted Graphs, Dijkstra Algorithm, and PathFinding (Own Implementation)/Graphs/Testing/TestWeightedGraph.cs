using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Testing
{
    internal class TestWeightedGraph : Test
    {
        WeightedGraph<string> graph;

        public TestWeightedGraph(WeightedGraph<string> typeOfGraph)
        {
            graph = typeOfGraph;
            ClearGraph();
        }

        public override void EvaluateTests()
        {
            PrintLine("------------------------------------------");
            PrintLine("Testing Graph");

            TestAddingNodes();
            ClearGraph();
            PrintLine();

            TestRemovingNodes();
            ClearGraph();
            PrintLine();

            TestAddingEdges();
            ClearGraph();
            PrintLine();

            TestRemovingEdges();
            ClearGraph();
            PrintLine();

            TestRemovingAnEdge();
            ClearGraph();
            PrintLine();

            TestRemovingNodeWhichMustAffectEdges();
            ClearGraph();
            PrintLine();

            TestAddingMultipleEdgesOnSameNodes();
            ClearGraph();
            PrintLine();

            TestRemovingOnMultipleEdgesOfSameNodes();
            ClearGraph();
            PrintLine();

            TestFindEdgesWithOneNode();
            ClearGraph();
            PrintLine();
        }

        void TestAddingNodes()
        {
            PrintLine("Testing Adding Nodes");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");

            // Test if a node has been added
            Print("Test Case 1: ");
            if (graph.FindNode("John") != null) Passed();
            else Failed();

            // Test adding existing node
            Print("Test Case 2: ");
            if (!graph.AddNode("John")) Passed();
            else Failed();

            // Test adding null
            Print("Test Case 3: ");
            if (!graph.AddNode(null)) Passed();
            else Failed();
        }

        void TestRemovingNodes()
        {
            PrintLine("Testing Removing Nodes");

            // Test removing non-existent node
            Print("Test Case 1: ");
            if (!graph.RemoveNode("John")) Passed();
            else Failed();

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");

            // Test removing a node
            Print("Test Case 2: ");
            if (graph.RemoveNode("John")) Passed();
            else Failed();

            // Test removing the same node again
            Print("Test Case 3: ");
            if (!graph.RemoveNode("John")) Passed();
            else Failed();
        }

        void TestAddingEdges()
        {
            PrintLine("Testing Adding Edges");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luke");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test adding an edge with valid nodes
            graph.AddEdge("John", "Michael", 0);
            Print("Test Case 1: ");
            if (graph.FindEdges("John", "Michael").Count > 0) Passed();
            else Failed();

            // Test re-adding the same edge
            Print("Test Case 2: ");
            if (!graph.AddEdge("John", "Michael", 0)) Passed();
            else Failed();

            // Test adding an edge with an invalid node
            Print("Test Case 3: ");
            if (!graph.AddEdge("John", "Joe", 0)) Passed();
            else Failed();

            // Test adding an edge with invalid nodes
            Print("Test Case 4: ");
            if (!graph.AddEdge("Mark", "Ken", 0)) Passed();
            else Failed();
        }

        void TestRemovingEdges()
        {
            PrintLine("Testing Removing Edges");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test removing non-existent edge
            Print("Test Case 1: ");
            if (!graph.RemoveEdges("John", "Michael")) Passed();
            else Failed();

            // Test removing valid edge
            graph.AddEdge("Luis", "Peter", 0);
            Print("Test Case 2: ");
            if (graph.RemoveEdges("Luis", "Peter")) Passed();
            else Failed();

            // Test removing the same edge
            Print("Test Case 3: ");
            if (!graph.RemoveEdges("Luis", "Peter")) Passed();
            else Failed();

            // Test removing edge with invalid node
            Print("Test Case 4: ");
            if (!graph.RemoveEdges("Luis", "Zac")) Passed();
            else Failed();

            // Test removing edge with invalid nodes
            Print("Test Case 5: ");
            if (!graph.RemoveEdges("Apollos", "Xandra")) Passed();
            else Failed();

            // Test removing edge with null
            Print("Test Case 6: ");
            if (!graph.RemoveEdges("Michael", null)) Passed();
            else Failed();
        }

        void TestRemovingAnEdge()
        {
            PrintLine("Testing Removing An Edge");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test removing non-existent edge
            Print("Test Case 1: ");
            if (!graph.RemoveEdge("John", "Michael", 23)) Passed();
            else Failed();

            // Test removing valid edge
            Print("Test Case 2: ");
            graph.AddEdge("John", "Luis", 17);
            if (graph.RemoveEdge("John", "Luis", 17)) Passed();
            else Failed();

            // Test removing edge with valid nodes but unmatching weight
            Print("Test Case 3: ");
            graph.AddEdge("Matthew", "Peter", 5);
            if (!graph.RemoveEdge("Matthew", "Peter", 1)) Passed();
            else Failed();

            // Test removing an edge twice
            Print("Test Case 4: ");
            graph.RemoveEdge("Matthew", "Peter", 5);
            if (!graph.RemoveEdge("Matthew", "Peter", 5)) Passed();
            else Failed();

            // Test removing an edge with null
            Print("Test Case 5: ");
            graph.AddEdge("John", "Peter", 29);
            if (!graph.RemoveEdge(null, "Peter", 29)) Passed();
            else Failed();
        }

        void TestRemovingNodeWhichMustAffectEdges()
        {
            PrintLine("Testing Removing A Node Which Must Affect Edges");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test with FindEdge
            Print("Test Case 1: ");
            graph.AddEdge("John", "Michael", 27);
            graph.RemoveNode("John");
            if (graph.FindEdge("John", "Michael", 27) == null) Passed();
            else Failed();

            // Test with FindEdges
            Print("Test Case 2: ");
            graph.AddEdge("Luis", "Matthew", 19);
            graph.RemoveNode("Matthew");
            if (graph.FindEdges("Luis", "Matthew").Count == 0) Passed();
            else Failed();
        }

        void TestAddingMultipleEdgesOnSameNodes()
        {
            PrintLine("Testing Adding Multiple Edges On The Same Nodes");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test adding multiple edges
            Print("Test Case 1: ");
            graph.AddEdge("John", "Michael", 1);
            graph.AddEdge("John", "Michael", 2);
            graph.AddEdge("John", "Michael", 3);
            if (graph.FindEdges("John", "Michael").Count >= 3) Passed();
            else Failed();
        }

        void TestRemovingOnMultipleEdgesOfSameNodes()
        {
            PrintLine("Testing Removing On Multiple Edges Of Same Nodes");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test removing an edge
            Print("Test Case 1: ");
            graph.AddEdge("John", "Michael", 1);
            graph.AddEdge("John", "Michael", 2);
            graph.AddEdge("John", "Michael", 3);
            graph.RemoveEdge("John", "Michael", 1);
            if (graph.FindEdges("John", "Michael").Count >= 2) Passed();
            else Failed();

            // Test removing edges
            Print("Test Case 2: ");
            graph.RemoveEdges("John", "Michael");
            if (graph.FindEdges("John", "Michael").Count == 0) Passed();
            else Failed();
        }

        void TestFindEdgesWithOneNode()
        {
            PrintLine("Testing FindEdges With One Node");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            graph.AddEdge("John", "Michael", 2);
            graph.AddEdge("Peter", "John", 4);
            graph.AddEdge("Luis", "John", 6);
            graph.AddEdge("John", "Matthew", 8);

            // Test the count of edges
            Print("Test Case 1 (UndirectedGraph): ");
            if (graph.FindEdges("John").Count == 8) Passed();
            else Failed();

            // Test null
            Print("Test Case 2: ");
            string str = null;
            if (graph.FindEdges(str).Count == 0) Passed();
            else Failed();
        }

        void TestToString()
        {
            PrintLine("Testing ToString");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");

            graph.AddEdge("John", "Luis", 0);
            graph.AddEdge("Michael", "Luis", 0);

            PrintLine(graph.ToString() ?? "Graph is null");
        }

        void ClearGraph()
        {
            graph.Clear();
        }
    }
}
