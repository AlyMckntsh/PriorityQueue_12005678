using System;

namespace PriorityQueue
{
    /// <summary>
    /// A priority queue implementation using a binary max-heap.
    /// </summary>
    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        // Underlying storage for the heap nodes
        private readonly PriorityItem<T>[] heap;
        // Maximum number of elements allowed
        private readonly int capacity;
        // Index of the last element in the heap
        private int lastIndex;

        /// <summary>
        /// Initialises a new instance with the specified capacity.
        /// </summary>
        /// <param name="size">Maximum number of items.</param>
        public HeapPriorityQueue(int size)
        {
            heap = new PriorityItem<T>[size];
            capacity = size;
            lastIndex = -1;
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
            return lastIndex < 0;
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
            for (int i = 0; i <= lastIndex; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += heap[i];
            }
            result += "]";
            return result;
        }
    }
}
