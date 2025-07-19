using System.Net;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Create a list using the length value to receive each increment.
        var list = new double[length];
        //create a variable that will increase and be used to add each incremented value to the list.
        double current = 0;
        //impliment a for loop where i = 0, until i = the variable length, incremented by one (++i) to 
        //add each incremented value of the number to the list.
        for (int i = 0; i <= length; i++)
        {
            current += number;
            list[i] = (current);
            //Console.WriteLine(current);
        }
        return list; // returns generated list.
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Create new empty list with a length equal to the input list.
        List<int> newList = new List<int>(data.Count);

        //create a variable equal to the length of the data list.
        int dataLength = data.Count;

        //Caluculate the index value of the rotation based upon the data list length.
        //values starting at the calcutalated value until the end of the list are the start of the new list.
        //values starting at the beginning of the data list until the index value caluculated are the end of the new list.
        if (amount > dataLength)
        {
            amount = (amount % dataLength);
        }

        //Create new list of end numbers.
        List<int> endList = data.GetRange(0, amount);
        //Create a new list for the starting numbers.
        List<int> startList = data.GetRange(amount, dataLength - amount);
        //Add the start list to the empty new List.
        newList.AddRange(startList);
        //Add the end list to the end of the new list.
        newList.AddRange(endList);
        //Print the resulting list.
        Console.WriteLine(newList);
    }
}


