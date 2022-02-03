using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sorted linked list
/// </summary>
public class SortedLinkedList<T> : LinkedList<T> where T:IComparable
{
    #region Constructor

    public SortedLinkedList() : base()
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given item to the list
    /// </summary>
    /// <param name="item">item to add to list</param>
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

    /// <summary>
    /// Repositions the given item in the list by moving it
    /// forward in the list until it's in the correct
    /// position. This is necessary to keep the list sorted
    /// when the value of the item changes
    /// </summary>
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

    #endregion
}
