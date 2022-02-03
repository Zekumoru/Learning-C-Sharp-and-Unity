using System;
using System.Collections.Generic;

namespace Queues
{
    internal class Queue<T>
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
}
