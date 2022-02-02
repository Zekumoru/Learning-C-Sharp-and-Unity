/*  PreviousPathNode class
 *  
 *  Serves as the previous node from a node.
 *  Basically, it helps creating the path so we
 *  can backtrack.
 *  
 *  NOTE: This class was previously named
 *        PathNodeInfo but it was a bit
 *        ambiguous.
 */
namespace Graphs.PathFinding
{
    internal class PreviousPathNode<T>
    {
        public GraphNode<T> Previous { get; private set; }

        public PreviousPathNode(GraphNode<T> previous)
            => Previous = previous;
    }
}