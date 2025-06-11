using System;

namespace PriorityQueue
{
    /// <summary>
    /// A priority queue implementation using an unsorted linked list.
    /// </summary>
    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T>
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

        // Reference to the head of the list
        private Node head;
        // Maximum number of elements allowed
        private readonly int capacity;
        // Current number of elements in the queue
        private int count;

        /// <summary>
        /// Initialises a new instance with the specified capacity.
        /// </summary>
        /// <param name="size">Maximum number of items.</param>
        public UnsortedLinkedPriorityQueue(int size)
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
            // Check for overflow
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            // Prepend new node (unsorted insertion)
            head = new Node(new PriorityItem<T>(item, priority), head);
            count++;
        }

        /// <summary>
        /// Retrieves, but does not remove, the highest priority item.
        /// </summary>
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            // Traverse to find node with maximum priority
            Node current = head;
            Node maxNode = head;
            while (current != null)
            {
                if (current.Data.Priority > maxNode.Data.Priority)
                {
                    maxNode = current;
                }
                current = current.Next;
            }

            return maxNode.Data.Item;
        }

        /// <summary>
        /// Removes the highest priority item from the queue.
        /// </summary>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            // Find max-priority node and its predecessor
            Node current = head;
            Node maxNode = head;
            Node prevToMax = null;
            Node prev = null;

            while (current != null)
            {
                if (current.Data.Priority > maxNode.Data.Priority)
                {
                    maxNode = current;
                    prevToMax = prev;
                }
                prev = current;
                current = current.Next;
            }

            // Remove maxNode from list
            if (prevToMax == null)
            {
                // maxNode is head
                head = head.Next;
            }
            else
            {
                prevToMax.Next = maxNode.Next;
            }

            count--;
        }

        /// <summary>
        /// Determines whether the queue is empty.
        /// </summary>
        public bool IsEmpty() => count == 0;

        /// <summary>
        /// Returns a string representation of the queue contents.
        /// </summary>
        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            // Build comma-separated list of PriorityItem<T>.ToString()
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
