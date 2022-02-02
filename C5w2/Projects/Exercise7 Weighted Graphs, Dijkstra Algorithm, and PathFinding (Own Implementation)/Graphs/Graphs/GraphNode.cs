using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class GraphNode<T>
    {
        public T Value { get; set; }
        public GraphNode(T value) => Value = value;
        public override string? ToString()
        {
            if (Value == null) return null;
            return Value.ToString();
        }
    }
}
