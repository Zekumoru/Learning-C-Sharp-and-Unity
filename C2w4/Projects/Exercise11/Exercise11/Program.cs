using System;
using ConsoleCards;

namespace Exercise11
{
    /// <summary>
    /// Exercise 11
    /// </summary>
    class Program
    {
        /// <summary>
        /// Exercise 11
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            #region Problem 1

            // declare and create a new deck
            Deck deck = new Deck();

            // declare and create an array that will hold 5 cards
            Card[] cards = new Card[5];

            // shuffle the deck
            deck.Shuffle();

            #endregion

            #region Problem 2

            // take card then add it to cards array
            cards[0] = deck.TakeTopCard();

            // flip the element 0's card
            cards[0].FlipOver();

            // print the element 0's card
            cards[0].Print();

            #endregion

            #region Problem 3

            // take another card then add to cards array
            cards[1] = deck.TakeTopCard();

            // flip the card
            cards[1].FlipOver();

            // print cards
            foreach (Card card in cards)
            {
                if (card == null)
                {
                    break;
                }
                else
                {
                    card.Print();
                }
            }

            #endregion
        }
    }
}
