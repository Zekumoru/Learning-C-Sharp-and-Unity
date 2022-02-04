# Notes
## Content
[Stack](#stack)
  - [Implementation](#implementation)

[Queue](#queue)
  - [Queue Implementation](#queue-implementation)
  - [Priority Queue Implementation](#priority-queue-implementation)

[Recursion](#recursion)
  - [Factorial Example](#factorial-example)

[Tail Recursion](#tail-recursion)
  - [Factorial Example](#factorial-example-1)

[Binary Search](#binary-search)
  - [Recursive Solution](#recursive-solution)

[Towers Of Hanoi](#towers-of-hanoi)

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

## Recursion
Recursion just basically means calling a method by itself, in other words, calling the same method inside that method.

That, of course, introduces the problem that it will cause an infinite loop of calling the same method, hence, we have what we call **base cases** which helps the method to terminate calling itself if such cases have been met.

### Factorial Example
Let's take the factorial of a number as an example to use recursion. Of course, we can take the iterative approach:

```csharp
// Find the factorial of n
int Factorial(int n)
{
    int result = 1;
    for (int i = n; i >= 1; i--)
    {
        result *= i;
    }
    return result;
}
```

It is called **iterative** because we are not calling the same method within itself. So what a recursive solution looks like? Well, here:

```csharp
public static int Factorial(int n)
{
    if (n == 0) return 1;
    return Factorial(n - 1) * n;
}
```

Since we know that 0! is 1, hence, that is our base case to stop our recursive solution from looping infinitely.

However, this recursive solution poses a problem. Notice that our bit of code `Factorial(n - 1) * n` is reliant to the result of `Factorial`, in other words, before we can do the multiplication `*`, we **need** something to multiply it for and that's within `Factorial`, in which, must first loop until it meets the base case `if (n == 0) return 1`.

The problem is space complexity. We cannot like "garbage collect" (just an analogy, it isn't really like garbage collection but let's say that way for easier comprehension) the method until we reach the base case, meaning if we need 10 recursions, we will also need 10 method calls that are suspended waiting for the next reach the base case.

The solution to this problem is what we call **tail recursion**.

## Tail Recursion
It is the same as recursion, only difference is, you don't get these nasty many suspended method calls waiting the next ones to finish until it does its work, rather, with tail recursion, you only have one method at a time.

### Factorial Example
```csharp
int Factorial(int n, int accumulated = 1)
{
    if (n == 1) return accumulated;
    return Factorial(n - 1, accumulated * n);
}
```

Note the `accumulated` parameter, it is actually the result of our `Factorial` method.

Also, notice that we don't have that reliant thingy as we had before with the recursion solution. As a matter of fact, try and read the code for anything like _"I need to wait for this method"_, and you won't find one. That's the efficient way of writing recursions with tail recursions!

## Binary Search
Binary search is really efficient when it comes to finding the index of the value we want to search in a _sorted list_. Notice, **sorted list**. Binary search **does not** work with unsorted lists.

It's efficient because it takes `O(log n)` time to search for our value rather than looking at each which will give us `O(n)`.

### Recursive Solution
```csharp
static class BinarySearch<T> where T : IComparable
{
    public static int GetIndexOf(T searchValue, List<T> listToSearch)
        => Search(searchValue, listToSearch, 0, listToSearch.Count);

    static int Search(T searchValue, List<T> listToSearch, int lowerBound, int upperBound)
    {
        if (lowerBound > upperBound) return -1;

        int middleLocation = (lowerBound + upperBound) / 2;
        T middleValue = listToSearch[middleLocation];
        if (middleValue.Equals(searchValue)) return middleLocation;

        if (middleValue.CompareTo(searchValue) > 0)
            return Search(searchValue, listToSearch, lowerBound, middleLocation - 1);

        return Search(searchValue, listToSearch, middleLocation + 1, upperBound);
    }
}
```

Notice how I made the solution generic and also, I encapsulated the searching in a `BinarySearch<T>` class.

The basic idea behind binary search is you check whether the value you're looking for is in the middle, if it is, we're done, if not, we then go check if it either above the middle or below the middle. If our value is supposedly greater than the middle value, we then search the middle of the previous middle and the upper bound. And so on and so forth until we find the value.

Now, let's walkthrough the code:
- `GetIndexOf` is our public method which our users can use.
- `Search` is our recursive method
  - `if (lowerBound > upperBound) return -1` this is our base case when we didn't find the value in the list.
  - The bit of code below checks if whether we find our value or not, if we do, we return its position/location.

```csharp
int middleLocation = (lowerBound + upperBound) / 2;
T middleValue = listToSearch[middleLocation];
if (middleValue.Equals(searchValue)) return middleLocation;
```

  - The last bit of code, as seen below, checks whether we should look the middle above or below of our previous middle.

```csharp
if (middleValue.CompareTo(searchValue) > 0)
    return Search(searchValue, listToSearch, lowerBound, middleLocation - 1);
return Search(searchValue, listToSearch, middleLocation + 1, upperBound);
```

> Notice that I am not using if/else, rather, I am using what's called a [guard clause](https://en.wikipedia.org/wiki/Guard_(computer_science))

## Towers Of Hanoi
It's better to see what this tower about visually so check it out online and also check the rules of it. [Towers of Hanoi: A Complete Recursive Visualization](https://www.youtube.com/watch?v=rf6uf3jNjbo) video helped me understand the solution to this problem.

Also, I made like my own code version of the solution to the Towers Of Hanoi which I'll explain how it works (which of course, most of my explanation comes from the video).

Here's my solution code:

```csharp
class Move
{
    public int Disc { get; private set; }
    public int From { get; private set; }
    public int To { get; private set; }

    public Move(int disc, int from, int to)
    {
        Disc = disc;
        From = from;
        To = to;
    }
}

class TowersOfHanoi
{
    public int Disc { get; set; }
    public List<Move> Moves { get; private set; }

    public TowersOfHanoi(int numOfDisc)
    {
        Moves = new List<Move>();
        if (numOfDisc > 0) Disc = numOfDisc;
        else Disc = 0;
    }

    public void Solve(int start, int end)
    {
        if (Disc < 1) return;
        if (start < 1 || start > 3 || end < 1 || end > 3) return;

        Hanoi(Disc, start, end);
    }

    void Hanoi(int disc, int start, int end)
    {
        if (disc == 1)
        {
            Moves.Add(new Move(disc, start, end));
            return;
        }

        int other = 6 - (start + end);
        Hanoi(disc - 1, start, other);

        Moves.Add(new Move(disc, start, end));

        Hanoi(disc - 1, other, end);
    }
}
```

Basically the recursive solution was, using proof of induction thingy:
Let's say we start at the first peg and then we want to put everything to the third peg, or our end.

When *f(n)* where *n = 1*, or when we have only one disc, we put it from start to end, simple as that.

But what about when *n > 1*? How do we put the bottom disc or the nth disc to the end? Well, the first solution would be to put the (n-1) discs, or the *f(n-1)* discs, to the second peg, in other words, to be able to move the very bottom disc or the nth disc, we need to first get rid of the discs on top of it and put it to our *other* peg, or the free stick.

And then when the third peg is free, we put the nth disc, or *f(n)*, or the used-to-be bottom disc, to the end peg.

Now, we only need to put the (n-1) discs to the end peg.

Notice how we solved this with induction: start with a base case or *f(1)* then solve for *f(n-1)* and finally solve for *f(n)*.

Hence with the code, _if(disc == 1)_ is the base case. Inside the if block, we make a move, which is the _Moves.Add(new Move(disc, start, end))_ code.

And then, we need to get the reference to our free peg, which it turns out that, we can use the fact that we have three pegs and added to each other, that's 6 (or 1 + 2 + 3, or first peg, second peg, and third peg), using the number 6, we can use the other fact that whatever the start and end is, we will get the peg that is, let's say, the free peg.

Then we called _Hanoi(disc - 1, start, other)_ to move the (n-1) or the *f(n-1)* discs to the other/free peg.
Afterward, we can move our used-to-be-bottom disc, or the nth disc or the *f(n)*, to our destination/end peg.  That's the _Moves.Add(new Move(disc, start, end))_ bit of code does.

After that bit of code, we have the _Hanoi(disc - 1, other, end)_ statement which brings all our discs from the other/free peg on top of the nth disc which is now in the end/destination peg.

And that's the recursive solution for the Towers Of Hanoi game in a nutshell. Also, check the Projects folder in this week and play around with my solution if you want.
