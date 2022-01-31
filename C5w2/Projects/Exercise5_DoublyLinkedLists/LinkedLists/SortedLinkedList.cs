using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    /// <summary>
    /// A sorted linked list
    /// </summary>
    class SortedLinkedList<T> : LinkedList<T> where T:IComparable
    {
        #region Constructors

        public SortedLinkedList() : base()
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds the given item to the list
        /// </summary>
        /// <param name="item">item to add</param>
        public override void Add(T item)
        {
            // adding to empty list
            if (head == null)
            {
                head = new LinkedListNode<T>(item, null, null);
            }
            else if (head.Value.CompareTo(item) > 0)
            {
                // adding before head
                head.Previous = new LinkedListNode<T>(item, null, head);
                head = head.Previous;
            }
            else
            {
                // find place to add new node
                LinkedListNode<T> currentNode = head;
                while (currentNode.Next != null &&
                    currentNode.Next.Value.CompareTo(item) < 0)
                {
                    currentNode = currentNode.Next;
                }

                // link in new node between previous node and current node
                LinkedListNode<T> newNode = new LinkedListNode<T>(item, currentNode, currentNode.Next);
                currentNode.Next = newNode;
                if (newNode.Next != null) newNode.Next.Previous = newNode;
            }
            count++;
        }

        #endregion
    }
}

