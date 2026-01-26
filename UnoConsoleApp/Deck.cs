using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    internal class Deck
    {
        private static Card[] allCards = [new Card("Red", "1"), new Card("Red", "2")];

        private static List<Card> deck = new List<Card>();

        /// <summary>
 /// Returns a random Uno Card from the deck
 /// </summary>
 /// <returns>A random Uno Card</returns>
 public static Card Draw()
 {
     //instantiate Random
     Random rnd = new Random();

     int random_index = rnd.Next(0, deck.Count());

     Card card = deck[random_index];

     card.setInPlay(true);

     deck.RemoveAt(random_index);

     return card;
 }

 /// <summary>
 /// This adds the cards that are not in play back into the deck
 /// </summary>
 public static void Shuffle()
 {
     //Console.WriteLine("Shuffling Deck!");

     deck.Clear();

     foreach (Card card in allCards)
     { 
         if(!card.getInPlay())
         {
             deck.Add(card);
         }
     }
 }
    }
}
