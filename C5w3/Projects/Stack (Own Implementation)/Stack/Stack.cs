using System;
using System.Collections.Generic;

namespace Stack
{
    internal class Stack<T>
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
}
