using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Testing
{
    internal class TestGraphNode : Test
    {
        public override void EvaluateTests()
        {
            PrintLine("------------------------------------------");
            PrintLine("Testing GraphNode");

            TestCreatingNode();
            PrintLine();

            TestSettingNode();
            PrintLine();
        }

        void TestCreatingNode()
        {
            PrintLine("Testing Node Creation");

            Print("Test Case 1: ");
            var node = new GraphNode<string>("Hello");
            if (node.Value.Equals("Hello")) Passed();
            else Failed();
        }

        void TestSettingNode()
        {
            PrintLine("Testing Node Setting");

            Print("Test Case 1: ");
            var node = new GraphNode<string>("Hello");
            node.Value = "World";
            if (node.Value.Equals("World")) Passed();
            else Failed();
        }
    }
}
