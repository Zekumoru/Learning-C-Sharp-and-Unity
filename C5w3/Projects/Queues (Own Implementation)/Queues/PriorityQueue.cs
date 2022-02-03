using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    internal class PriorityQueue<T> where T : IComparable
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
}
