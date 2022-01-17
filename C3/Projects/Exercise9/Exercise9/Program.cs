using System;

/// <summary>
/// Input: <pyramid slot number>,
///         <block letter>,
///         <whether or not the block should be lit>
///         
/// Example: 15,M,true
///     
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        int nextPos = 0;
        string token;
        string input;

        int pyramidSlotNumber;
        char blockLetter;
        bool shouldBeLit;

        // Get input from user
        Console.WriteLine("Syntax: <slot number>,<block letter>,<to be lit or not>");
        Console.Write("Enter: ");
        input = Console.ReadLine() ?? String.Empty;
        Console.WriteLine();

        // Extract data from input
        token = ExtractCommaData(input, nextPos);
        nextPos += token.Length + 1;
        pyramidSlotNumber = int.Parse(token);

        token = ExtractCommaData(input, nextPos);
        nextPos += token.Length + 1;
        blockLetter = char.Parse(token);

        token = ExtractCommaData(input, nextPos);
        shouldBeLit = bool.Parse(token);

        // output:
        Console.WriteLine("Slot number: " + pyramidSlotNumber);
        Console.WriteLine("Block letter: " + blockLetter);
        Console.WriteLine("Lit trigger: " + shouldBeLit);
    }

    static string ExtractCommaData(string input, int startPos)
    {
        int commaPos = input.IndexOf(",", startPos);
        if (commaPos == -1) return input.Substring(startPos);
        return input.Substring(startPos, commaPos - startPos);
    }
}