using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Testing
{
    internal class TestGraphEdge : Test
    {
        GraphNode<string> matthewNode;
        GraphNode<string> lukeNode;
        GraphNode<string> johnNode;

        public TestGraphEdge()
        {
            matthewNode = new GraphNode<string>("Matthew");
            lukeNode = new GraphNode<string>("Luke");
            johnNode = new GraphNode<string>("John");
        }

        public override void EvaluateTests()
        {
            PrintLine("------------------------------------------");
            PrintLine("Testing GraphEdge");

            TestCreatingEdge();
            PrintLine();

            TestNullNodes();
            PrintLine();

            TestSettingNodes();
            PrintLine();

            TestContainsMethod();
            PrintLine();
        }

        void TestCreatingEdge()
        {
            PrintLine("Testing Creating Edge");

            Print("Test Case 1: ");
            var edge1 = new GraphEdge<string>(matthewNode, lukeNode);
            if (edge1.ToString() == "Matthew -> Luke") Passed();
            else Failed();

            Print("Test Case 2: ");
            var edge2 = new GraphEdge<string>(matthewNode, johnNode);
            if (edge2.ToString() == "Matthew -> John") Passed();
            else Failed();

            Print("Test Case 3: ");
            var edge3 = new GraphEdge<string>(lukeNode, johnNode);
            if (edge3.ToString() == "Luke -> John") Passed();
            else Failed();
        }

        void TestNullNodes()
        {
            PrintLine("Testing Null Nodes");

            Print("Test Case 1: ");
            var edge1 = new GraphEdge<string>(matthewNode, null);
            if (edge1.ToString() == "Matthew -> ") Passed();
            else Failed();

            Print("Test Case 2: ");
            var edge2 = new GraphEdge<string>(null, null);
            if (edge2.ToString() == " -> ") Passed();
            else Failed();

            Print("Test Case 3: ");
            var edge3 = new GraphEdge<string>(null, lukeNode);
            if (edge3.ToString() == " -> Luke") Passed();
            else Failed();
        }

        void TestSettingNodes()
        {
            PrintLine("Testing Setting Nodes");

            Print("Test Case 1: ");
            var edge1 = new GraphEdge<string>(matthewNode, lukeNode);
            edge1.Tail = johnNode;
            if (edge1.ToString() == "John -> Luke") Passed();
            else Failed();

            Print("Test Case 2: ");
            var edge2 = new GraphEdge<string>(matthewNode, lukeNode);
            edge2.Head = johnNode;
            if (edge2.ToString() == "Matthew -> John") Passed();
            else Failed();

            Print("Test Case 3: ");
            var edge3 = new GraphEdge<string>(matthewNode, lukeNode);
            edge3.Tail = johnNode;
            edge3.Head = johnNode;
            if (edge3.ToString() == "John -> John") Passed();
            else Failed();
        }

        void TestContainsMethod()
        {
            PrintLine("Testing Contains Method");

            Print("Test Case 1: ");
            var edge1 = new GraphEdge<string>(matthewNode, lukeNode);
            if (edge1.Contains(matthewNode)) Passed();
            else Failed();

            Print("Test Case 2: ");
            if (!edge1.Contains(johnNode)) Passed();
            else Failed();

            Print("Test Case 3: ");
            if (!edge1.Contains(null)) Passed();
            else Failed();
        }
    }
}
