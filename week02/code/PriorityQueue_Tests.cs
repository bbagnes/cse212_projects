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
    // Scenario: Add three values with associated priorities to a queue, then verify they are removed in the order of their priority(highest to least).
    // Expected Result: The queue should be dequeued in the following order: Joseph, David, Scott.
    // Defect(s) Found: 
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        List<string> expectedDequeueOrder = ["Joseph", "David", "Scott"];
        List<string> dequeueOrder = [];

        priorityQueue.Enqueue("David", 12);
        priorityQueue.Enqueue("Scott", 8);
        priorityQueue.Enqueue("Joseph", 15);
        priorityQueue.Enqueue("Kevin", 7);

        for (int i = 0; i >= 2; i++)
        {
            var value = priorityQueue.Dequeue();
            dequeueOrder.Add(value);
            Assert.AreEqual(value, expectedDequeueOrder[i]);
        }    
    }

    // [TestMethod]
    // // Scenario: 
    // // Expected Result: 
    // // Defect(s) Found: 
    // public void TestPriorityQueue_3()
    // {
    //     var priorityQueue = new PriorityQueue();
    //     Assert.Fail("Implement the test case and then remove this.");
    // }
}