using System;
using Exercise4;

internal class Program
{
    static void Main(string[] args)
    {
        Kid kid1 = new ArtisticKid();
        Kid kid2 = new DisobedientKid();
        Kid kid3 = new FriendlyKid();

        kid1.PrintMessage();
        kid2.PrintMessage();
        kid3.PrintMessage();
    }
}