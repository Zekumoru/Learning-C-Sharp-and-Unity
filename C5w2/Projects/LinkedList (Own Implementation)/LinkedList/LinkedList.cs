using System;
using System.Text;

namespace ImplementingLinkedList
{
    public abstract class LinkedList<T>
    {
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

        public bool Remove(T item)
        {
            if (Head == null) return false;
            if (Head.Value.Equals(item))
            {
                Head = Head.Next;
            }
            else
            {
                // the current variable here is the one that will
                // be removed if a match is found
                LinkedListNode<T> previous = Head;
                LinkedListNode<T> current = Head.Next;
                while (current != null &&
                    !current.Value.Equals(item))
                {
                    previous = current;
                    current = current.Next;
                }
                if (current == null) return false;

                previous.Next = current.Next;
            }

            Count--;
            return true;
        }

        public LinkedListNode<T> Find(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null && 
                !current.Value.Equals(item))
            {
                current = current.Next;
            }
            return current;
        }

        public void Clear()
        {
            if (Head == null) return;

            LinkedListNode<T> previous = Head;
            LinkedListNode<T> current = Head.Next;

            previous.Next = null;
            while (current != null)
            {
                previous = current;
                current = current.Next;
                previous.Next = null;
            }

            Head = null;
            Count = 0;
        }

        public override string? ToString()
        {
            if (Head == null) return "";

            StringBuilder builder = new StringBuilder();
            LinkedListNode<T> current = Head;

            while (current.Next != null)
            {
                builder.Append(current.Value.ToString());
                builder.Append(", ");
                current = current.Next;
            }
            builder.Append(current.Value.ToString());

            return builder.ToString();
        }
    }
}
