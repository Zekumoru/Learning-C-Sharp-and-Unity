using System;

namespace ImplementingLinkedList
{
    public class SortedLinkedList<T> : ImplementingLinkedList.LinkedList<T> where T : IComparable
    {
        public SortedLinkedList() : base() { }

        public override void Add(T item)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<T>(item, null);
            }
            else if (Head.Value.CompareTo(item) >= 0)
            {
                Head = new LinkedListNode<T>(item, Head);
            }
            else
            {
                LinkedListNode<T> previous = Head;
                LinkedListNode<T> current = Head.Next;
                while (current != null
                    && current.Value.CompareTo(item) < 0)
                {
                    previous = current;
                    current = current.Next;
                }
                previous.Next = new LinkedListNode<T>(item, current);
            }
            Count++;
        }
    }
}
