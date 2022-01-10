using System;
using ConsoleCards;
using System.Collections.Generic;

namespace Exercise12
{
    /// <summary>
    /// Exercise 12
    /// </summary>
    class Program
    {
        /// <summary>
        /// Exercise 12
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // create deck and hand
            Deck deck = new Deck();
            List<Card> hand = new List<Card>();

            deck.Shuffle();

            // add card, flip over, and print
            hand.Add(deck.TakeTopCard());
            hand[0].FlipOver();
            hand[0].Print();
            Console.WriteLine();

            // add another card, flip over, and print both cards
            hand.Add(deck.TakeTopCard());
            hand[1].FlipOver();
            foreach (Card card in hand)
            {
                card.Print();
            }
        }
    }
}
