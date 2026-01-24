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
        private Card[] allCards = new Card[98];

        private List<Card> deck = new List<Card>();

        /// <summary>
        /// Generates a random Uno Card and gives it to whoever drew a card
        /// </summary>
        /// <returns>A randomly generated Uno Card</returns>
        public Card Draw()
        {
            //instantiate Random
            Random rnd = new Random();

            //Generate random card color
            int colorInt = rnd.Next(1, 4);

            StringBuilder sb = new StringBuilder();

            if (colorInt == 4)
            {
                sb.Append("Red ");
            }
            else if (colorInt == 3)
            {
                sb.Append("Blue ");
            }
            else if (colorInt == 2)
            {
                sb.Append("Green ");
            }
            else
            {
                sb.Append("Yellow ");
            }

            //Generate random card type
            int typeInt = rnd.Next(1, 13);

            if(typeInt == 1)
            {
                sb.Append("1");
            }
            else if(typeInt  == 2)
            {
                sb.Append("2");
            }
            else if(typeInt == 3)
            {
                sb.Append("3");
            }
            else if(typeInt == 4)
            {
                sb.Append("4");
            }
            else if (typeInt == 5)
            {
                sb.Append("5");
            }
            else if (typeInt == 6)
            {
                sb.Append("6");
            }
            else if(typeInt == 7)
            {
                sb.Append("7");
            }
            else if(typeInt == 8)
            {
                sb.Append("8");
            }
            else if(typeInt == 9)
            {
                sb.Append("9");
            }
            else if(typeInt == 10)
            {
                sb.Append("0");
            }
            else if(typeInt == 11)
            {
                sb.Append("Skip");
            }
            else if(typeInt == 12)
            {
                sb.Append("DrawTwo");
            }
            else
            {
                sb.Clear();
                sb.Append("null Wild");
            }

            //Configure and return Card
            string cardInfo = sb.ToString();

            Card card = new Card();
            card.setColor(cardInfo);
            return card;
        }

        /// <summary>
        /// This method shows the user that the deck is being shuffled
        /// </summary>
        public void Shuffle()
        {
            Console.WriteLine("Shuffling Deck!");
        }

    }
}
