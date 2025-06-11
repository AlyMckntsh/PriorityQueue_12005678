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
            // Advance lastIndex and check for overflow
            lastIndex++;
            if (lastIndex >= capacity)
            {
                lastIndex--;
                throw new QueueOverflowException();
            }

            // Insert new element at the end
            heap[lastIndex] = new PriorityItem<T>(item, priority);

            // Bubble up to maintain max-heap property
            int current = lastIndex;
            while (current > 0)
            {
                int parent = (current - 1) / 2;
                if (heap[current].Priority <= heap[parent].Priority)
                {
                    break;
                }
                // Swap current with parent
                var temp = heap[current];
                heap[current] = heap[parent];
                heap[parent] = temp;
                current = parent;
            }
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
            // Root of the heap always holds the max-priority item
            return heap[0].Item;
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

            // Move last element to root and shrink the heap
            heap[0] = heap[lastIndex];
            lastIndex--;

            // Heapify down to restore max-heap property
            int current = 0;
            while (true)
            {
                int left = 2 * current + 1;
                int right = 2 * current + 2;
                int largest = current;

                if (left <= lastIndex && heap[left].Priority > heap[largest].Priority)
                {
                    largest = left;
                }
                if (right <= lastIndex && heap[right].Priority > heap[largest].Priority)
                {
                    largest = right;
                }
                if (largest == current)
                {
                    break;
                }
                // Swap current with largest child
                var temp = heap[current];
                heap[current] = heap[largest];
                heap[largest] = temp;
                current = largest;
            }
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
