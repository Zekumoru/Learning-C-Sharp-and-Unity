using System;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        List<int> list = new List<int>();

        #region Problem 1 and 2

        // create integer list
        list = new List<int>();

        // populate list with numbers 1 to 10 (both inclusive)
        for (int i = 1; list.Count() < 10; i++)
        {
            list.Add(i);
        }

        // remove even numbers from the list
        for (int i = list.Count() - 1; i >= 0; i--)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }

        // print list
        foreach (int number in list)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();

        #endregion

        #region Problem 3

        // create a new list and populate with
        // numbers 1 to 5 inclusive
        list = new List<int>();
        for (int i = 1; list.Count() < 5; i++)
        {
            list.Add(i);
        }

        // remove values 1, 2, and 3 (NOT indexes) from the list 
        for (int i = 0; i < list.Count(); i++) // bad forward loop
        //for (int i = list.Count() - 1; i >= 0; i--)
        {
            if (list[i] == 1 || list[i] == 2 || list[i] == 3)
            {
                list.RemoveAt(i);
            }
        }

        // print list
        foreach(int number in list)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();

        #endregion
    }
}