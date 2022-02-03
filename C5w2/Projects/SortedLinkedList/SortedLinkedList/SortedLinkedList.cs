using System;
using System.Text;
using System.Collections.Generic;

public class SortedLinkedList<T> : LinkedList<T> where T : IComparable
{
    public SortedLinkedList() : base() { }

    public void Add(T item)
    {
        if (item == null) return;

        // check if no items yet
        // and check if it should be in front
        if (First == null || First.Value.CompareTo(item) > 0)
        {
            AddFirst(item);
            return;
        }

        var currentNode = First;
        while (currentNode.Next != null &&
            currentNode.Next.Value.CompareTo(item) < 0)
        {
            currentNode = currentNode.Next;
        }

        AddAfter(currentNode, new LinkedListNode<T>(item));
    }

    public void Reposition(T item)
    {
        if (item == null) return;

        LinkedListNode<T> currentNode = First;
        if (currentNode == null) return;

        T current;
        LinkedListNode<T> previousNode;
        while (currentNode != null)
        {
            if (currentNode == First)
            {
                currentNode = currentNode.Next;
                continue;
            }

            current = currentNode.Value;
            previousNode = currentNode.Previous;
            if (current.Equals(item) && previousNode.Value.CompareTo(item) > 0)
            {
                AddBefore(previousNode, new LinkedListNode<T>(current));
                Remove(currentNode);
                currentNode = previousNode.Previous;
            }
            else
            {
                currentNode = currentNode.Next;
            }
        }
    }
}
