# Notes
## Content
[Linked List](#linked-list)
  - [Implementation](#implementation)
    - [LinkedListNode](#linkedlistnode)
    - [LinkedList](#linkedlist)
    - [UnsortedLinkedList](#unsortedlinkedlist)
    - [SortedLinkedList](#sortedlinkedlist)

[Graphs](#graphs)
  - [Implementation](#implementation-1)
    - [GraphNode](#graphnode)
    - [Graph](#graph)
    - [UndirectedGraph](#undirectedgraph)
    - [DirectedGraph](#directedgraph)

[Graph Pathfinding](#graph-pathfinding)
  - [Implementation](#implementation-2)
    - [Examples](#examples)
    - [SearchType](#searchtype)
    - [PreviousPathNode](#previouspathnode)
    - [GraphPathFinder](#graphpathfinder)
    - [Breadth-First Search And Depth-First Search](#breadth-first-search-and-depth-first-search)
    
## Linked List
The idea behind linked list is that rather than having a random access data structure like an array, we have nodes linked with each other using reference to the next node, which is called a **Singly Linked List**. If there is also a reference to the previous node then it is called a **Doubly Linked List**.

### Implementation
In this Implementation, we will be implementing a doubly linked list.

We need 2 classes: `LinkedList` which contains the list and `LinkedListNode` which contains the value and the references.

Actually, another two classes because it'd be better if we can have a sorted linked list and an unsorted linked list. The thing is, there's an improvement on adding to a linked list if it were unsorted, in fact, it's `O(1)`.\
Hence, the class `LinkedList` is abstract and we will have: `SortedLinkedList` and `UnsortedLinkedList`.

#### LinkedListNode
We only need to provide access to its value and its references to the next and previous node.

```csharp
class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode<T> Next { get; set; }
    public LinkedListNode<T> Previous { get; set; }

    public LinkedListNode(T value, LinkedListNode<T> previous, LinkedListNode<T> next)
    {
        Value = value;
        Previous = previous;
        Next = next;
    }
}
```

#### LinkedList
This is where the sorted and unsorted linked list will inherit from.

It contains the head of the list and also the count, we could have omitted a count variable but it would be efficient to cache it so we have `O(1)` getting the count rather than walking through the list which is `O(n)`.

For basic linked list, being able to get the _head_ and the _count_ is enough and the basic methods would be _adding_ a node, _removing_ a node, _clearing_ all nodes, and _finding_ an element.

```csharp
abstract class LinkedList<T>
{
    // Fields
    public int Count { get; set; }
    public LinkedListNode<T> Head { get; set; }

    // Constructor
    public LinkedList()
    {
        Count = 0;
        Head = null;
    }

    // Methods
    public abstract void Add(T item);

    public void Clear()
    {
        // unlink all nodes so they can be garbage collected
        if (head != null)
        {
            LinkedListNode<T> currentNode = head.Next;
            while (currentNode != null)
            {
                currentNode.Previous.Next = null;
                currentNode.Previous = null;
                currentNode = currentNode.Next;
            }
        }

        // reset head and count
        head = null;
        count = 0;
    }

    public bool Remove(T item)
    {
        // there are no nodes
        if (head == null) return false;

        // the item to remove is in the head node
        if (head.Value.Equals(item))
        {
            head = head.Next;
            if (head != null) head.Previous = null;
            count--;

            return true;
        }

        // find the item to remove
        LinkedListNode<T> currentNode = head;
        while (currentNode.Next != null &&
            !currentNode.Next.Value.Equals(item))
        {
            currentNode = currentNode.Next;
        }

        // check if it didn't find the item to remove
        if (currentNode.Next == null) return false;

        // unlink the node which contains the item to remove and
        // set the link of its previous and next nodes
        // and reduce count (obviously)
        LinkedListNode<T> toRemoveNode = currentNode.Next;
        currentNode.Next = toRemoveNode.Next;
        if (toRemoveNode.Next != null) toRemoveNode.Next.Previous = currentNode;
        count--;

        return true;
    }

    public  LinkedListNode<T> Find(T item)
    {
        LinkedListNode<T> currentNode = head;
        while (currentNode != null &&
            !currentNode.Value.Equals(item))
        {
            currentNode = currentNode.Next;
        }
        return currentNode;
    }
}
```

Notice that the `Add` method is abstract because this is where sorted and unsorted linked list differ. With sorted, adding is `O(n)` because it has to check where to put the item so in the worst case it might walk through all the nodes in the list.

#### UnsortedLinkedList
```csharp
class UnsortedLinkedList<T> : LinkedList<T>
{
    public UnsortedLinkedList() : base() {}

    public override void Add(T item)
    {
        // adding to empty list
        if (head == null)
        {
            head = new LinkedListNode<T>(item, null, null);
        }
        else
        {
            // add to front of list
            head.Previous = new LinkedListNode<T>(item, null, head);
            head = head.Previous;
        }
        count++;
    }
}
```

Notice that we're adding in the front of the list like exchanging the previous head with the new head which holds the new item.

Also, since we have a doubly linked list, it's possible to add in the end of the list, same procedure with a little bit of tweak of logic.

#### SortedLinkedList
```csharp
class SortedLinkedList<T> : LinkedList<T>
{
    public SortedLinkedList() : base() {}

    public override void Add(T item)
    {
        // adding to empty list
        if (head == null)
        {
            head = new LinkedListNode<T>(item, null, null);
        }
        else if (head.Value.CompareTo(item) > 0)
        {
            // if it so happens that the new node deserves to be in front
            head.Previous = new LinkedListNode<T>(item, null, head);
            head = head.Previous;
        }
        else
        {
            // find place to add the new node
            LinkedListNode<T> currentNode = head;
            while (currentNode.Next != null &&
                currentNode.Next.Value.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next;
            }

            // link the new node between previous node and current node
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, currentNode, currentNode.Next);
            currentNode.Next = newNode;
            if (newNode.Next != null) newNode.Next.Previous = newNode;
        }
        count++;
    }
}
```

## Graphs
Graphs, let's say, is a tiny little bit similar to a linked list but its nodes, instead of having like one or two references, i.e., next and previous, we have nodes which can have from 0 references to how many nodes there are, meaning it can have a reference to itself if we so desire.

We call these references, **edges**. And with a graph, we call nodes as **vertices**. Also the nodes pointed by the references are called **neighbors**.

Graphs are useful for like, e.g., finding a path for our NPC which wants to go from some world location to another.

There are two types of graphs: **directed graph** and **undirected graph**. Basically this means that with undirected graph, two nodes that are linked with each other know about each other, in other words, they're neighbors with each other, whereas, with directed graph, we can have a node linked to another node but this another node is not linked to that node hence "directed", needless to say, it's still possible for them to be neighbors with each other.

There's also this concept of _weighted_ with graphs. When we say **unweighted**, there's no cost going from a node to another, but with a **weighted** graph, there's a cost, for example, maybe the length of the edge to traverse, hence, with a weighted graph, it is possible to have two nodes connected by multiple edges because edges have now cost so there might be an edge, for example, that costs 5 meters, then another 7 meters, etc.

### Implementation
The graph that will be implemented here is unweighted.

We will be needing 4 classes (same like the linked list), and they are: `GraphNode`, `Graph`, `DirectedGraph`, and `UndirectedGraph`.

Since it's the same as the linked list implementation above, I ain't explaining what each are, other than the fact that the `Graph` class is abstract.

#### GraphNode
```csharp
class GraphNode<T>
{
    // Fields
    public T Value { get; set; }
    List<GraphNode<T>> neighbors;

    // Constructor
    public GraphNode(T value)
    {
        Value = value;
        neighbors = new List<GraphNode<T>>();
    }

    public int NeighborsCount
    {
        get { return neighbors.Count; }
    }

    public IList<GraphNode<T>> Neighbors
    {
        get { return neighbors.AsReadOnly(); }
    }

    // Methods
    public bool AddNeighbor(GraphNode<T> neighbor)
    {
        if (HasNeighbor(neighbor)) return false;
        neighbors.Add(neighbor);
        return true;
    }

    public bool RemoveNeighbor(GraphNode<T> neighbor) => neighbors.Remove(neighbor);
    public bool HasNeighbor(GraphNode<T> neighbor) => neighbors.Contains(neighbor);
    public void ClearNeighbors() => neighbors.Clear();
}
```

Notice the `Neighbors` property, it returns an `IList` rather than the actual list itself, this is so that the contents/elements of the list cannot be changed because they're just neighbors, they don't need to be changed through a node if it is not them.

#### Graph
```csharp
abstract class Graph<T>
{
    // Fields
    protected List<GraphNode<T>> nodes;

    // Constructor
    public Graph()
    {
        nodes = new List<GraphNode<T>>();
    }

    // Properties
    public int Count
    {
        get { return nodes.Count; }
    }

    public IList<GraphNode<T>> Nodes
    {
        get { return nodes.AsReadOnly(); }
    }

    // Methods
    public abstract bool AddEdge(T value1, T value2);
    public abstract bool RemoveEdge(T value1, T value2);

    public bool AddNode(T value)
    {
        if (value == null) return false;
        if (Find(value) != null) return false;
        nodes.Add(new GraphNode<T>(value));
        return true;
    }

    public bool RemoveNode(T value)
    {
        GraphNode<T> toRemoveNode = Find(value);
        if (toRemoveNode == null) return false;

        nodes.Remove(toRemoveNode);
        foreach (GraphNode<T> node in nodes)
        {
            node.RemoveNeighbor(toRemoveNode);
        }
        return true;
    }

    public void ClearNodes()
    {
        foreach (GraphNode<T> node in nodes)
        {
            node.ClearNeighbors();
        }
        nodes.Clear();
    }

    public GraphNode<T> Find(T value)
    {
        if (value == null) return null;
        foreach (GraphNode<T> node in nodes)
        {
            if (value.Equals(node.Value)) return node;
        }
        return null;
    }
}
```

Notice that _adding_ and _removing_ an edge methods are abstract since the only difference between a directed and undirected is how they are connected through an edge.

#### UndirectedGraph
```csharp
class UndirectedGraph<T> : Graph<T>
{
    public UndirectedGraph() : base() { }

    public override bool AddEdge(T value1, T value2)
    {
        GraphNode<T> node1 = Find(value1);
        GraphNode<T> node2 = Find(value2);
        if (node1 == null || node2 == null) return false;
        if (node1.HasNeighbor(node2)) return false;
        node1.AddNeighbor(node2);
        node2.AddNeighbor(node1);
        return true;
    }

    public override bool RemoveEdge(T value1, T value2)
    {
        GraphNode<T> node1 = Find(value1);
        GraphNode<T> node2 = Find(value2);
        if (node1 == null || node2 == null) return false;
        if (!node1.HasNeighbor(node2)) return false;
        node1.RemoveNeighbor(node2);
        node2.RemoveNeighbor(node1);
        return true;
    }
}
```

Notice the `node1.AddNeighbor(node2)` and `node2.AddNeighbor(node1)` in the `Add` method, also the `node1.RemoveNeighbor(node2)` and `node2.RemoveNeighbor(node1)`, these are the bits which make this an undirected graph.

#### DirectedGraph
```csharp
class DirectedGraph<T> : Graph<T>
{
    public DirectedGraph() : base() { }

    public override bool AddEdge(T tail, T head)
    {
        GraphNode<T> tailNode = Find(tail);
        GraphNode<T> headNode = Find(head);

        // one or both nodes do not exist
        if (tailNode == null || headNode == null) return false;

        // edge already exists
        if (tailNode.Neighbors.Contains(headNode)) return false;

        // connect edge
        tailNode.AddNeighbor(headNode);
        return true;
    }

    public override bool RemoveEdge(T tail, T head)
    {
        GraphNode<T> tailNode = Find(tail);
        GraphNode<T> headNode = Find(head);

        // one or both nodes do not exist
        if (tailNode == null || headNode == null) return false;

        // edge does not exist
        if (!tailNode.Neighbors.Contains(headNode)) return false;

        // remove edge
        tailNode.RemoveNeighbor(headNode);
        return true;
    }
}
```

Notice that now, we are adding and removing only one node, instead of 2 like in the undirected graph.

## Graph Pathfinding
Graph pathfinding or searching is finding the path from one node, the **start** node, to another node, the **target** or **end** node. This doesn't simply mean finding the reference to the target node but rather, how to get there like what are the nodes we must traverse to get there.

### Implementation
The instructor taught about the **breadth-first search** and the **depth-first search** algorithm.

We need 2 classes: `GraphPathFinder` and `PreviousPathNode`. And also an enumeration `SearchType` class to be able to pick which algorithm we want, either the breadth-first or the depth-first.

#### Examples
```
             4
         /       \
      42    ---   11
    /    \      /    \
   12  -  5    7     10
          |
          1    
```

It's shown as a tree for convenience, also, let's say we start at the node `4`.

What Breadth-First Search does is that it will go row by row to find/search, so for example, it'll go:
```
    4
 -> 42 -> 11
 -> 12 -> 5  -> 7 -> 10
 -> 1
```

What Depth-First Search does is that it will go deeper to each node to find/search, so for example, it'll go:
```
    4
 -> 42 -> 12
 -> 5  -> 1
 -> 11 -> 7
 -> 10
```

The examples above are visualization of how they are supposed to work and does not mean the actual implementation will traverse the same.

Honestly, there are videos and pictures in the web for better visualization of how these algorithms work so go check those out.

#### SearchType
```csharp
enum SearchType
{
    BreadthFirst,
    DepthFirst
}
```

#### PreviousPathNode
```csharp
class PreviousPathNode<T>
{
    public GraphNode<T> Previous { get; private set; }
    public PreviousPathNode(GraphNode<T> previous)
        => Previous = previous;
}
```

Serves to "save" the previous node from a node.\
Basically, it helps creating the path so we can backtrack, in other words, re-trace the path.

This class was previously named `PathNodeInfo` but it was a bit ambiguous (at least for me).

#### GraphPathFinder
```csharp
class GraphPathFinder<T>
{
    public LinkedList<GraphNode<T>> Search(T start, T finish, Graph<T> graph, SearchType searchType)
    {
        // make sure both of the vertices exist
        if (graph.Find(start) == null || graph.Find(finish) == null) return null;

        var startNode = graph.Find(start);
        var searchList = new LinkedList<GraphNode<T>>();
        var pathNodes = new Dictionary<GraphNode<T>, PreviousPathNode<T>>();

        // if the start and target nodes/vertices are the same
        if (start.Equals(finish)) return ConvertToLinkedListPath(startNode, pathNodes);

        pathNodes.Add(startNode, new PreviousPathNode<T>(null));
        searchList.AddFirst(startNode);

        while (searchList.Count > 0)
        {
            // get the first element in the searchList
            GraphNode<T> currentNode = searchList.First.Value;
            searchList.RemoveFirst();

            Console.WriteLine("Current Node: " + currentNode.Value);

            foreach (var neighbor in currentNode.Neighbors)
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
```

There are two important variables to take note of here: the `searchList` and `pathNodes` variables in the `Search` method.

`pathNodes` is a dictionary which its keys contain the previous nodes, in other words, we can use this dictionary to be able to trace back the path. We did not make this to be the return value because if we did, there's no way for us to know which way to start hence the `endNode` parameter in the `ConvertToLinkedListPath` method. So why a dictionary and not straight up use linked list? Because, the **crucial fact** to remember here is that this dictionary **WILL** contain all the nodes as keys to the nodes before it. **IT IS NOT** the path, rather, a list/dictionary of nodes about the nodes before them.

`searchList` contains the list of nodes to search, it is also what makes breadth-first and depth-first possible to like coexist in a single algorithm just changing how they are added to this search list.

#### Breadth-First Search And Depth-First Search
As I stated above, just really above this, what makes it possible to have a single algorithm perform both breadth-first and depth-first is the search linked list.

So how does it work? Well, let's grab the visual from the example earlier:
```
             4
         /       \
      42    ---   11
    /    \      /    \
   12  -  5    7     10
          |
          1    
```

Say we want to path find from `4` to `1`.

This is what the algorithm will do:
- First, start with `4` (duh), is it `1`? No.

> This is the bit of code that does this: `if (start.Equals(finish)) return ConvertToLinkedListPath(startNode, pathNodes);`

- Now, save `4` to our search list. **[4]** <- These brackets will denote what's in the search list
- Take the first node in the search list, which is `4`. **[]**
- Check this node's neighbors:
  - Is `42` our target `1`? Nope. Add this to search list. **[42]**
  - Is `11` our target `1`? Nope. Add this to search list. Now, depending on the algorithm, if we were breadth-first, we'll append this `11` to the search list or if we were depth-first, we'll prepend this to the search list. Let's go with depth-first for now, hence: **[11, 42]**
- Take the first node in the search list, which is `11`. **[42]**
- Check this node's neighbors:
  - Ignore `4` since it's already been evaluated

  > This is where this bit of code `if (pathNodes.ContainsKey(neighbor)) continue;` comes in.

  - Ignore `42`
  - Is `7` our target `1`? Nope. Add this to search list. **[7, 42]** (Remember this is depth-first hence we prepend)
  - Is `10` our target `1`? Nope. Add this to search list. **[10, 7, 42]**
- Take the first node in the search list, which is `10`. **[7, 42]**
- Check this node's neighbors:
  - Ignore `11`
- Take the first node in the search list, which is `7`. **[42]**
- Check this node's neighbors:
  - Ignore `11`
- Take the first node in the search list, which is `42`. **[]**
- Check this node's neighbors:
  - Ignore `4`
  - Ignore `11`
  - Is `12` our target `1`? Nope. Add this to search list. **[12]**
  - Is `5` our target `1`? Nope. Add this to search list. **[5, 12]**
- Take the first node in the search list, which is `5`. **[12]**
- Check this node's neighbors:
  - Ignore `42`
  - Ignore `12`
  - Is `1` our target `1`? Yes! Now we've finished searching.

```
           4
       /       \
    42    ---   11
  /    \      /    \
 12  -  5    7     10
        |
        1    
```

Now if we were using breadth-first then let's go back when we had `4` and now we append the nodes in the search list.
- Take the first node in the search list, which is `4`. **[]**
- Check this node's neighbors:
  - Is `42` our target `1`? Nope. Add this to search list. **[42]**
  - Is `11` our target `1`? Nope. Add this to search list. **[42, 11]** (Notice here that now we are appending `11`.)
- Take the first node in the search list, which is `42`. **[11]**
- Check this node's neighbor:
  - Ignore `4`
  - Is `12` our target `1`? Nope. Add this to search list. **[11, 12]**
  - Is `5` our target `1`? Nope. Add this to search list. **[11, 12, 5]**
  - Ignore `11`
- Take the first node in the search list, which is `11`. **[12, 5]**
- Check this node's neighbor:
  - Ignore `4`
  - Ignore `42`
  - Is `7` our target `1`? Nope. Add this to search list. **[12, 5, 7]**
  - Is `10` our target `1`? Nope. Add this to search list. **[12, 5, 7, 10]**
- Take the first node in the search list, which is `12`. **[5, 7, 10]**
  - Ignore `42`
  - Ignore `5`
- Take the first node in the search list, which is `5`. **[7, 10]**
  - Ignore `42`
  - Ignore `12`
  - Is `1` our target `1`? Yes! Now we've finished searching.

The important thing to note with these examples is how breadth-first and depth-first affect the search linked list. Also, this example **DOES NOT** reflect how the compiler will actually perform the algorithm, rather, how it might look like.
