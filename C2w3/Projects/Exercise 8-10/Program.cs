
internal class Program
{
    static void Main()
    {
        Exercise10();
    }

    static void Exercise8()
    {
        int num;

        // Problem 1: print all even number from 0 to num
        num = GetUserIntInput();
        for (int i = 0; i < num + 1; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine();

        // Problem 2: print row
        num = GetUserIntInput();
        for (int i = 0; i < num; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }

    static void Exercise9()
    {
        // Problem 1
        int row = GetUserIntInput();
        int col = GetUserIntInput();

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Problem 2
        int num = GetUserIntInput();
        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Exercise10()
    {
        int input;
        do
        {
            Console.WriteLine("**************");
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Start Game");
            Console.WriteLine("2 - Load Game");
            Console.WriteLine("3 - Options");
            Console.WriteLine("4 - Quit");
            Console.WriteLine("**************");
            input = GetUserIntInput();
            switch(input)
            {
                case 1:
                    Console.WriteLine("Starting game...");
                    break;
                case 2:
                    Console.WriteLine("Loading game...");
                    break;
                case 3:
                    Console.WriteLine("Opening options...");
                    break;
                case 4:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid input! Try again...");
                    break;
            }
            Console.WriteLine();
        } while (input != 4);
    }

    static int GetUserIntInput()
    {
        Console.Write("Enter an int: ");
        string? input = Console.ReadLine();
        if (input == null) return 0;
        return int.Parse(input);
    }
}