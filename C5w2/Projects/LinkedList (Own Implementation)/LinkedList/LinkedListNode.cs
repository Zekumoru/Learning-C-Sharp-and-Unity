using System;

namespace ImplementingLinkedList
{
    public class LinkedListNode<T>
    {
        public T Value { set; get; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value, LinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
