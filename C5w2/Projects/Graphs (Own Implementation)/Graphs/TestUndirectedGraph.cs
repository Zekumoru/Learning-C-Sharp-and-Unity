using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class TestUndirectedGraph : Test
    {
        Graph<string> graph;

        public TestUndirectedGraph()
        {
            graph = new UndirectedGraph<string>();

            EvaluateTests();
        }

        protected override void EvaluateTests()
        {
            PrintLine("------------------------------------------");
            PrintLine("Testing UndirectedGraph");

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
        }

        void TestAddingNodes()
        {
            PrintLine("Testing Adding Nodes");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");

            // Test if a node has been added
            Print("Test Case 1: ");
            if (graph.Find("John") != null) Passed();
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
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test adding an edge with valid nodes
            graph.AddEdge("John", "Michael");
            Print("Test Case 1: ");
            if (graph.Find("John").HasNeighbor(graph.Find("Michael"))) Passed();
            else Failed();

            // Test re-adding the same edge
            Print("Test Case 2: ");
            if (!graph.AddEdge("John", "Michael")) Passed();
            else Failed();

            // Test adding an edge with an invalid node
            Print("Test Case 3: ");
            if (!graph.AddEdge("John", "Joe")) Passed();
            else Failed();

            // Test adding an edge with invalid nodes
            Print("Test Case 4: ");
            if (!graph.AddEdge("Mark", "Ken")) Passed();
            else Failed();
        }

        void TestRemovingEdges()
        {
            PrintLine("Testing Removing Nodes");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");
            graph.AddNode("Peter");
            graph.AddNode("Matthew");

            // Test removing non-existent edge
            Print("Test Case 1: ");
            if (!graph.RemoveEdge("John", "Michael")) Passed();
            else Failed();

            // Test removing valid edge
            graph.AddEdge("Luis", "Peter");
            Print("Test Case 2: ");
            if (graph.RemoveEdge("Luis", "Peter")) Passed();
            else Failed();

            // Test removing the same edge
            Print("Test Case 2: ");
            if (!graph.RemoveEdge("Luis", "Peter")) Passed();
            else Failed();

            // Test removing edge with invalid node
            Print("Test Case 4: ");
            if (!graph.RemoveEdge("Luis", "Zac")) Passed();
            else Failed();

            // Test removing edge with invalid nodes
            Print("Test Case 5: ");
            if (!graph.RemoveEdge("Apollos", "Xandra")) Passed();
            else Failed();
        }

        void TestToString()
        {
            PrintLine("Testing ToString");

            graph.AddNode("John");
            graph.AddNode("Michael");
            graph.AddNode("Luis");

            graph.AddEdge("John", "Luis");
            graph.AddEdge("Michael", "Luis");

            PrintLine(graph.ToString()??"Graph is null");
        }

        void ClearGraph()
        {
            graph.ClearNodes();
        }
    }
}
