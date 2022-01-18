using System;
using System.IO;

internal class Program
{
    const string InputFileName = "test.txt";
    const string OutputFileName = "output.txt";

    static void Main(string[] args)
    {
        // variables
        StreamReader input = null;
        StreamWriter output = null;

        try
        {
            // open files
            input = File.OpenText(InputFileName);
            output = File.CreateText(OutputFileName);

            // read and output even-numbered row to output file
            string line;
            for (int row = 0; (line = input.ReadLine()) != null; row++)
            {
                if (row % 2 == 0)
                {
                    output.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            // print error message
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // close file if open
            if (input != null)
            {
                input.Close();
            }
            if (output != null)
            {
                output.Close();
            }
        }

        Console.WriteLine("output.txt created successfully!");
    }
}