using System;

namespace ImplementingLinkedList
{
    public class UnsortedLinkedList<T> : ImplementingLinkedList.LinkedList<T>
    {
        public UnsortedLinkedList() : base() { }

        public override void Add(T item)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<T>(item, null);
            }
            else
            {
                Head = new LinkedListNode<T>(item, Head);
            }
            Count++;
        }
    }
}
