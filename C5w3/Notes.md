# Notes
## Content
[Stack](#stack)
  - [Implementation](#implementation)

[Queue](#queue)
  - [Queue Implementation](#queue-implementation)
  - [Priority Queue Implementation](#priority-queue-implementation)

## Stack
A stack is a **Last-In First-Out**, or **LIFO**, data structure which supports three main operations: **Push**, **Pop**, and **Peek**.

With a stack, we don't care about the items below the top item, hence, we could say we're always working with the top of the stack and if that top gets pushed down by a new item then we'll work with that new item. This is why we don't care about the items below.

A bit of note, this made me appreciate more about data structure since with the depth-first search algorithm, I don't need to think about the whole list but rather the top. Go check the _Depth-First With Stack_ folder about it, it's also the exercise from this week.

### Implementation
It's pretty straight-forward to implement. We only need some sort of list to contain our items and create the main three methods: Push, Pop, and Peek.

```csharp
class Stack<T>
{
    List<T> stack;

    public Stack() => stack = new List<T>();

    public int Count => stack.Count;

    public void Push(T item) => stack.Add(item);

    public T Pop()
    {
        if (Count == 0) throw new InvalidOperationException("Cannot pop from an empty stack!");
        T item = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (Count == 0) throw new InvalidOperationException("Cannot peek from an empty stack!");
        return stack[stack.Count - 1];
    }
}
```

## Queue
There are actually two types of queue: a normal **queue** and a **priority queue**. And both supports the 3 main functionalities: **enqueuing**, **dequeuing**, and **peeking** the first element (**NOT** the last item added, this is not a stack).

A queue can be likened to a waiting line in real life, where the people in the front gets their turn first than the people in the back.

Same idea from the stack data structure here: We don't care about the content of the queue other than its first element or the very last item added. Hence, a queue is a **First-In First-Out** or **FIFO** data structure.

A queue is helpful on implementing a breadth-first search algorithm. Also, its relative: Priority queue is helpful on Dijkstra algorithm.

> `Stack` and `Queue` are both available on the `System.Collections.Generic` namespace. But, priority queues, however, are not. If you need a priority queue, you make one!

### Queue Implementation
It's pretty straight-forward to implement this one too.

```csharp
class Queue<T>
{
    List<T> queue;

    public Queue() => queue = new List<T>();

    public int Count => queue.Count;

    public void Enqueue(T item) => queue.Add(item);

    public T Dequeue()
    {
        if (Count == 0) throw new InvalidOperationException("Cannot dequeue from an empty queue!");
        T item;
        item = queue[0];
        queue.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (Count == 0) throw new InvalidOperationException("Cannot peek at an empty queue!");
        return queue[0];
    }
}
```

### Priority Queue Implementation
It's the same as the queue implementation, only difference is enqueuing because we have to make sure it's added in the right order.

```csharp
class PriorityQueue<T> where T : IComparable
{
    List<T> queue;

    public PriorityQueue() => queue = new List<T>();

    public int Count => queue.Count;

    public void Enqueue(T item)
    {
        int insertLocation;
        for (insertLocation = 0; insertLocation < Count
            && queue[insertLocation].CompareTo(item) < 0;
            insertLocation++);
        queue.Insert(insertLocation, item);
    }

    public T Dequeue()
    {
        if (Count == 0) throw new InvalidOperationException("Cannot dequeue from an empty queue!");
        T item = queue[0];
        queue.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (Count == 0) throw new InvalidOperationException("Cannot peek from an empty queue!");
        return queue[0];
    }
}
```
