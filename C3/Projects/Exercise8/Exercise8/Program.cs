using System;

/// <summary>
/// Asks the user for the month and day of birth
/// Then outputs it and a reminder (which is the
/// day before the birth day)
/// 
/// Invalid input and error checking are not
/// implemented
/// 
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        // variable
        int day;
        string month;

        Console.Write("Write the month of your birth: ");
        month = Console.ReadLine();

        Console.Write("Write the day of your birth: ");
        day = int.Parse(Console.ReadLine());

        Console.WriteLine("So your birthday is " + month + " " + day);
        Console.WriteLine("You'll receive a reminder on " + month + " " + (day - 1));
    }
}