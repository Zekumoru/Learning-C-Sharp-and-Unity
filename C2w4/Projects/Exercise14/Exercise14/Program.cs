using System;
using System.Collections.Generic;
using ConsoleCards;

internal class Program
{
    static void Main()
    {
        #region Problem 1

        // declare and create deck and hand variables
        Deck deck = new Deck();
        List<Card> hand = new List<Card>();

        // shuffle the deck
        deck.Shuffle();

        #endregion

        #region Problem 2

        // deal 5 cards
        for (int i = 0; i < 5; i++)
        {
            hand.Add(deck.TakeTopCard());
        }

        // flip all the cards
        foreach (Card card in hand)
        {
            card.FlipOver();
        }

        // print all the cards in hand
        foreach (Card card in hand)
        {
            card.Print();
        }

        #endregion
    }
}