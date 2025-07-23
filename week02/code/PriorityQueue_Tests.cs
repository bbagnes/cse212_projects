using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create an empty queue and verify an exception is thrown when attempting to dequeue it.
    // Expected Result: Triggers an InvalidOperationException: "The queue is empty." to be generated.
    // Defect(s) Found: None, test passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Add three values with associated priorities to a queue, then verify they are removed in the order of their priority(highest to lowest).
    // Expected Result: The queue should be dequeued in the following order: Joseph, David, Scott, Kevin, Brad.
    // Defect(s) Found: Priority is being used, but priorityItem is not being removed upon dequeue. 
    // Also, index to order priority of items started at 1, not 0; and index should have run until <= _queue.Count - 1, not < _queue.Count - 1.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        List<string> expectedDequeueOrder = ["Joseph", "David", "Scott", "Kevin"];
        List<string> dequeueOrder = [];

        priorityQueue.Enqueue("Brad", 5);
        priorityQueue.Enqueue("David", 12);
        priorityQueue.Enqueue("Scott", 8);
        priorityQueue.Enqueue("Joseph", 15);
        priorityQueue.Enqueue("Kevin", 7);
        
        int i = 0;

        while (i <= 3)
        {
            //Debug.WriteLine(priorityQueue);
            var value = priorityQueue.Dequeue();
            dequeueOrder.Add(value);                        
            Assert.AreEqual(expectedDequeueOrder[i],dequeueOrder[i]);
            i++;
        }

         
    }

    [TestMethod]
    // Scenario: Add a group of values with two or more sharing the same priority value, verify equal priority get removed in order of queue.
    // Expected Result: The queue should be dequeued in the following order: Joseph, David, Scott, Kevin, Brad, Ben.
    // Defect(s) Found: Function removed the last item with an equally high priority, not the first. Removed = to prevent reassignment of index.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        List<string> expectedDequeueOrder = ["Joseph", "David", "Scott", "Kevin", "Brad", "Ben"];
        List<string> dequeueOrder = [];

        priorityQueue.Enqueue("Brad", 7);
        priorityQueue.Enqueue("David", 12);
        priorityQueue.Enqueue("Scott", 12);
        priorityQueue.Enqueue("Joseph", 15);
        priorityQueue.Enqueue("Kevin", 12);
        priorityQueue.Enqueue("Daniel", 5);
        priorityQueue.Enqueue("Ben", 7);
        
        
        int i = 0;

        while (i <= 5)
        {
            //Debug.WriteLine(priorityQueue);
            var value = priorityQueue.Dequeue();
            dequeueOrder.Add(value);                        
            Assert.AreEqual(expectedDequeueOrder[i],dequeueOrder[i]);
            i++;
        }

    }
}