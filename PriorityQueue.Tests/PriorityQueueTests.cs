using NUnit.Framework;
using System.Collections;

namespace PriorityQueue.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        private const int Capacity = 5;


        public class QueueWrapper
        {
            public readonly PriorityQueue<int> Queue;
            private readonly string _name;

            public QueueWrapper(PriorityQueue<int> queue, string name)
            {
                Queue = queue;
                _name = name;
            }

            public override string ToString() => _name;
        }


        private static IEnumerable GetQueues()
        {
            yield return new QueueWrapper(new SortedArrayPriorityQueue<int>(Capacity), "SortedArrayTests");
            yield return new QueueWrapper(new UnsortedArrayPriorityQueue<int>(Capacity), "UnsortedArrayTests");
            yield return new QueueWrapper(new UnsortedLinkedPriorityQueue<int>(Capacity), "UnsortedLinkedTests");
            yield return new QueueWrapper(new SortedLinkedPriorityQueue<int>(Capacity), "SortedLinkedTests");
            yield return new QueueWrapper(new HeapPriorityQueue<int>(Capacity), "HeapTests");
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void AddMultipleItems_MixedPriorities_ShouldReturnItemsInDescendingPriority(QueueWrapper wrapper)
        {
            var queue = wrapper.Queue;
            // Arrange
            queue.Add(1, 1);
            queue.Add(2, 3);
            queue.Add(3, 2);

            // Act & Assert
            Assert.That(queue.Head(), Is.EqualTo(2), "Expected highest priority (3) first");
            queue.Remove();
            Assert.That(queue.Head(), Is.EqualTo(3), "Expected next highest (2)");
            queue.Remove();
            Assert.That(queue.Head(), Is.EqualTo(1), "Expected remaining item (1)");
            queue.Remove();
            Assert.That(queue.IsEmpty(), Is.True, "Queue should be empty after removals");
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void SingleItem_AddThenRemove_ShouldEmptyQueue(QueueWrapper wrapper)
        {
            var queue = wrapper.Queue;
            // Arrange
            queue.Add(1, 1);

            // Act
            var head = queue.Head();
            queue.Remove();

            // Assert
            Assert.That(head, Is.EqualTo(1), "Head should return the single item");
            Assert.That(queue.IsEmpty(), Is.True, "Queue should be empty after removing the only item");
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void IsEmpty_WhenNewQueue_ShouldReturnTrue(QueueWrapper wrapper)
        {
            var queue = wrapper.Queue;
            // Act & Assert
            Assert.That(queue.IsEmpty(), Is.True, "New queue should report empty");
        }

        [Test, TestCaseSource(nameof(GetQueues))]
        public void Add_WhenQueueIsFull_ShouldThrowQueueOverflowException(QueueWrapper wrapper)
        {
            var queue = wrapper.Queue;
            // Arrange
            for (int i = 0; i < Capacity; i++)
            {
                queue.Add(i, i);
            }

            // Act & Assert
            Assert.Throws<QueueOverflowException>(
                () => queue.Add(1, 1),
                "Adding beyond capacity should throw overflow");
        }

    }
}
