using System;

namespace PriorityQueue
{
    /// <summary>
    /// A priority queue implementation using an unsorted array.
    /// </summary>
    public class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        // Underlying storage for priority items
        private readonly PriorityItem<T>[] storage;
        // Maximum number of elements allowed
        private readonly int capacity;
        // Index of the last inserted element
        private int tailIndex;

        /// <summary>
        /// Initialises a new instance with the specified capacity.
        /// </summary>
        /// <param name="size">Maximum number of items.</param>
        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        /// <summary>
        /// Adds an item with the given priority to the queue.
        /// </summary>
        public void Add(T item, int priority)
        {
            // Move tail forward
            tailIndex++;
            // Check for overflow
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }
            // Insert without ordering
            storage[tailIndex] = new PriorityItem<T>(item, priority);
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

            // Find the index of the max‐priority element
            int maxIndex = 0;
            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[maxIndex].Priority)
                {
                    maxIndex = i;
                }
            }
            return storage[maxIndex].Item;
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

            // Find the index of the max‐priority element
            int maxIndex = 0;
            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[maxIndex].Priority)
                {
                    maxIndex = i;
                }
            }

            // Replace removed slot with the last element
            storage[maxIndex] = storage[tailIndex];
            // Shrink the queue
            tailIndex--;
        }

        /// <summary>
        /// Determines whether the queue is empty.
        /// </summary>
        public bool IsEmpty()
        {
            return tailIndex < 0;
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
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }
    }
}
