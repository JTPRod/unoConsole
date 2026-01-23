using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    internal class Hand
    {
        private List<Card> hand = new List<Card>();

        /// <summary>
        /// Lets other classes see the list of cards that is in this "Hand"
        /// </summary>
        /// <returns>the list of cards in this hand</returns>
        public List<Card> GetHand()
        {
            return hand;
        }

        /// <summary>
        /// Adds a card to the hand
        /// </summary>
        /// <param name="card">Card being added</param>
        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        /// <summary>
        /// Removes a card from the hand
        /// </summary>
        /// <param name="card">Card that is being removed</param>
        public void RemoveCard(Card card)
        {
            hand.Remove(card);
        }

        /// <summary>
        /// Allows other classes to see the number of cards in this hand
        /// </summary>
        /// <returns>Number of cards in this hand</returns>
        public int GetHandSize()
        {
            return hand.Count;
        }
    }
}
