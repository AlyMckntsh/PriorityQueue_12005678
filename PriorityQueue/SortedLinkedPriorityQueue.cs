using System;

namespace PriorityQueue
{
    /// <summary>
    /// A priority queue implementation using a sorted linked list.
    /// </summary>
    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        /// <summary>
        /// Represents a node in the linked list.
        /// </summary>
        private class Node
        {
            public PriorityItem<T> Data;
            public Node Next;

            public Node(PriorityItem<T> data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        // Reference to the head of the sorted list (highest priority)
        private Node head;
        // Maximum number of elements allowed
        private readonly int capacity;
        // Current number of elements in the queue
        private int count;

        /// <summary>
        /// Initialises a new instance with the specified capacity.
        /// </summary>
        /// <param name="size">Maximum number of items.</param>
        public SortedLinkedPriorityQueue(int size)
        {
            head = null;
            capacity = size;
            count = 0;
        }

        /// <summary>
        /// Adds an item with the given priority to the queue.
        /// </summary>
        public void Add(T item, int priority)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves, but does not remove, the highest priority item.
        /// </summary>
        public T Head()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the highest priority item from the queue.
        /// </summary>
        public void Remove()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the queue is empty.
        /// </summary>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// Returns a string representation of the queue contents.
        /// </summary>
        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            Node current = head;
            bool first = true;
            while (current != null)
            {
                if (!first)
                {
                    result += ", ";
                }
                result += current.Data;
                first = false;
                current = current.Next;
            }
            result += "]";
            return result;
        }
    }
}
