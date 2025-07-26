using System.Collections;
using System.Transactions;
using Newtonsoft.Json.Serialization;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        //Create new node.
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only tail will be affected.
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        } 
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_tail == _head)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the tail will be affected.
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect the second to last node from the last node.
            _tail = _tail.Prev; // Update the tail to point to the second to last node.
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        //Check if list is empty;
        if (_head is null)
        {
            Console.WriteLine("The list is empty.");
        }
        else
        {
            //Set a variable pointing to the head of the list to begin iteration.    
            var current = _head;
            //Iterate through the list until the inserted value matches the data in the current node, and designate it as the current node.
            while (current.Next is not null)
            {
                if (current.Data == value)
                {
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            
            //Check if current node is the tail of the list, if so verify its value matches before removing using RemoveTail method.
            if (current.Next == null)
            {
                if (current.Data == value)
                {
                    RemoveTail();
                }
                else
                {
                }
            }
            //Check if current node is the head of the list, if so remove using RemoveHead method.
            else if (current.Prev == null)
            {
                RemoveHead();
            }
            else
            {
                //Set the Prev value for the node immmediately following the node to be removed to point to the node before the node to be removed.
                current.Next.Prev = current.Prev;
                //Set the Next value for the node immmediately before the node to be removed to point to the node after the node to be removed.
                current.Prev.Next = current.Next;
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {

        var current = _head;
        while (current is not null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
                current = current.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        // TODO Problem 5
        var current = _tail; //Start inumeration at the tail since this is the reverse iteration.
        while (current is not null)
        {
            yield return current.Data; // // Provide (yield) each item to the user
            current = current.Prev; //Go backward through the list, since this is the reverse iteration.
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}