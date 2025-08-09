using System.Diagnostics;
using System.Formats.Asn1;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            //Do nothing, only values less than or greater than will be added.
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left != null)
            {
                return Left.Contains(value);
            }
            else
            {
                return false;
            }
        }
        else if (value > Data)
        {
            if (Right != null)
            {
                return Right.Contains(value);
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }        
    }

    public int GetHeight(int? count = null)
    {
        if (count == null)
        {
            count = 1;
        }
        if (Left is null & Right is null)
        {
            Console.WriteLine((int)count);
            return (int)count;
        }
        else if (Left != null)
        {
            count++;
            return this.Left.GetHeight(count);
        }
        else if (Right != null)
        {
            count++;
            return this.Right.GetHeight(count);
        }
        else
        {
            return 0;
        }        
    }
}