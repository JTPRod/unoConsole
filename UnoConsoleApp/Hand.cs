using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnoConsoleApp;

namespace UnoConsoleApp
{
    internal class Hand
    {
        private List<Card> hand;


        public List<Card> GetHand()
        {
            return hand;
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public void RemoveCard(Card card)
        {
            hand.Remove(card);
        }

        public int GetHandSize()
        {
            return hand.Count;
        }
    }
}
