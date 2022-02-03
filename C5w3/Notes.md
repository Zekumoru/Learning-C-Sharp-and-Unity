# Notes
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
