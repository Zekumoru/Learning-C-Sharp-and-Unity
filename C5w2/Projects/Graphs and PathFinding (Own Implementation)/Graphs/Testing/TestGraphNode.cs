using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class TestGraphNode : Test
    {
        GraphNode<string> node1;
        GraphNode<string> node2;
        GraphNode<string> node3;

        public TestGraphNode()
        {
            node1 = new GraphNode<string>("John");
            node2 = new GraphNode<string>("Michael");
            node3 = new GraphNode<string>("Luke");

            EvaluateTests();
        }

        protected override void EvaluateTests()
        {
            PrintLine("------------------------------------------");
            PrintLine("Testing GraphNode");

            TestAddingNeighbors();
            ClearNeighbors();
            PrintLine();

            TestRemovingNeighbors();
            ClearNeighbors();
            PrintLine();
        }

        void TestAddingNeighbors()
        {
            PrintLine("Testing Adding Neighbors");

            // Test adding neighbors
            Print("Test Case 1: ");
            node1.AddNeighbor(node2);
            node1.AddNeighbor(node3);
            if (node1.HasNeighbor(node2) && node1.HasNeighbor(node3)) Passed();
            else Failed();

            // Test neighbors count
            Print("Test Case 2: ");
            node1.AddNeighbor(node2);
            node1.AddNeighbor(node3);
            if (node1.NeighborsCount <= 2) Passed();
            else Failed();

            // Test HasNeighbor
            Print("Test Case 3: ");
            if (!node2.HasNeighbor(node1) && !node2.HasNeighbor(node3) &&
                !node3.HasNeighbor(node1) && !node3.HasNeighbor(node2)) Passed();
            else Failed();
        }

        void TestRemovingNeighbors()
        {
            PrintLine("Testing Removing Neighbors");

            // Remove an existing neighbor
            Print("Test Case 1: ");
            node1.AddNeighbor(node2);
            node1.AddNeighbor(node3);
            node2.AddNeighbor(node1);
            node1.RemoveNeighbor(node2);
            if (!node1.HasNeighbor(node2) && node2.HasNeighbor(node1)) Passed();
            else Failed();

            // Remove non-existing neighbor
            Print("Test Case 2: ");
            if (!node1.RemoveNeighbor(node2)) Passed();
            else Failed();

            // Remove from an empty neighbor list
            Print("Test Case 3: ");
            if (!node3.RemoveNeighbor(node2)) Passed();
            else Failed();
        }

        void ClearNeighbors()
        {
            node1.ClearNeighbors();
            node2.ClearNeighbors();
            node3.ClearNeighbors();
        }
    }
}
