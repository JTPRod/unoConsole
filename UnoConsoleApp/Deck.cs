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
        private static Card[] allCards = [new Card("Red", "1"), new Card("Red", "2"), new Card("Red", "3"), new Card("Red", "4"), new Card("Red", "5"), new Card("Red", "6"), new Card("Red", "7"), new Card("Red", "8"), new Card("Red", "9"), new Card("Red", "0"), new Card("Red", "Skip"),
                                          new Card("Yellow", "1"), new Card("Yellow", "2"), new Card("Yellow", "3"), new Card("Yellow", "4"), new Card("Yellow", "5"), new Card("Yellow", "6"), new Card("Yellow", "7"), new Card("Yellow", "8"), new Card("Yellow", "9"), new Card("Yellow", "0"), new Card("Red", "Skip"),
                                          new Card("Green", "1"), new Card("Green", "2"), new Card("Green", "3"), new Card("Green", "4"), new Card("Green", "5"), new Card("Green", "6"), new Card("Green", "7"), new Card("Green", "8"), new Card("Green", "9"), new Card("Green", "0"), new Card("Red", "Skip"),
                                          new Card("Blue", "1"), new Card("Blue", "2"), new Card("Blue", "3"), new Card("Blue", "4"), new Card("Blue", "5"), new Card("Blue", "6"), new Card("Blue", "7"), new Card("Blue", "8"), new Card("Blue", "9"), new Card("Blue", "0"), new Card("Red", "Skip"),
                                          new Card("Red", "1"), new Card("Red", "2"), new Card("Red", "3"), new Card("Red", "4"), new Card("Red", "5"), new Card("Red", "6"), new Card("Red", "7"), new Card("Red", "8"), new Card("Red", "9"), new Card("Red", "Skip"),
                                          new Card("Yellow", "1"), new Card("Yellow", "2"), new Card("Yellow", "3"), new Card("Yellow", "4"), new Card("Yellow", "5"), new Card("Yellow", "6"), new Card("Yellow", "7"), new Card("Yellow", "8"), new Card("Yellow", "9"), new Card("Yellow", "Skip"),
                                          new Card("Green", "1"), new Card("Green", "2"), new Card("Green", "3"), new Card("Green", "4"), new Card("Green", "5"), new Card("Green", "6"), new Card("Green", "7"), new Card("Green", "8"), new Card("Green", "9"), new Card("Green", "Skip"),
                                          new Card("Blue", "1"), new Card("Blue", "2"), new Card("Blue", "3"), new Card("Blue", "4"), new Card("Blue", "5"), new Card("Blue", "6"), new Card("Blue", "7"), new Card("Blue", "8"), new Card("Blue", "9"), new Card("Blue", "Skip"),
                                          new Card("NULL", "Wild"), new Card("NULL", "Wild"), new Card("NULL", "Wild"), new Card("NULL", "Wild")];

        private static List<Card> deck = new List<Card>();

        /// <summary>
        /// Returns a random Uno Card from the deck
        /// </summary>
        /// <returns>A random Uno Card</returns>
        public static Card Draw()
        {
            if(deck.Count() == 0)
            {
                Deck.Shuffle();
            }

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
            Console.WriteLine("\nShuffling Deck!\n");
        
            deck.Clear();
        
            foreach (Card card in allCards)
            { 
                if(!card.getInPlay())
                {
                    if(card.getType() == "Wild" || card.getType() == "wild")
                    {
                        card.setColor("NULL");
                    }

                    deck.Add(card);
                }
            }
        }
        }
        }
