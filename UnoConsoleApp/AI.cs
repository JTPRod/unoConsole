using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    internal class AI
    {
        private Hand hand = new Hand();

        /// <summary>
        /// The Computer/AI takes its turn
        /// </summary>
        /// <param name="topCard">The top card currently on the discard pile</param>
        /// <returns>A string with the type and color of the current card</returns>
        public string Play(Card topCard)
        {
            if(hand.GetHandSize() == 0)
            {
                return "No cards";
            }

            List<Card> cards = hand.GetHand();
            foreach(Card card in cards)
            {              
                if (card.getType() == "Wild" || card.getType() == "wild")
                {
                    new UI().DisplayComputerPlayCard(card);
                    string color = SelectColor();
                    card.setInPlay(false);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(card.getColor());
                    sb.Append(' ');
                    sb.Append(card.getType());
                    string cardText = sb.ToString();

                    hand.RemoveCard(card);
                    if (hand.GetHandSize() == 1)
                    {
                        new UI().Uno();
                    }
                    else if (hand.GetHandSize() == 0)
                    {
                        new UI().DeclareWinner(2);
                    }
                    else
                    {
                        Console.WriteLine("Opponent now has " + hand.GetHandSize() + " cards remaining in their hand");
                    }

                    return cardText;    //Due to UML Error, card cannot be played GameManager directly, and instead its properties must be passed as a string
                }

                if (card.getType() == topCard.getType())
                {
                    new UI().DisplayComputerPlayCard(card);
                    card.setInPlay(false);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(card.getColor());
                    sb.Append(' ');
                    sb.Append(card.getType());
                    string cardText = sb.ToString();

                    hand.RemoveCard(card);
                    if (hand.GetHandSize() == 1)
                    {
                        new UI().Uno();
                    }
                    else if (hand.GetHandSize() == 0)
                    {
                        new UI().DeclareWinner(2);
                    }
                    else
                    {
                        Console.WriteLine("Opponent now has " + hand.GetHandSize() + " cards remaining in their hand");
                    }

                    return cardText;    //Due to UML Error, card cannot be played GameManager directly, and instead its properties must be passed as a string
                }

                if (card.getColor() == topCard.getColor())
                {
                    new UI().DisplayComputerPlayCard(card);
                    card.setInPlay(false);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(card.getColor());
                    sb.Append(' ');
                    sb.Append(card.getType());
                    string cardText = sb.ToString();

                    hand.RemoveCard(card);
                    if (hand.GetHandSize() == 1)
                    {
                        new UI().Uno();
                    }
                    else if (hand.GetHandSize() == 0)
                    {
                        new UI().DeclareWinner(2);
                    }
                    else
                    {
                        Console.WriteLine("Opponent now has " + hand.GetHandSize() + " cards remaining in their hand");
                    }

                    return cardText;    //Due to UML Error, card cannot be played GameManager directly, and instead its properties must be passed as a string
                }
            }


            //Draw cards until a card can be played
            while(true)
            {
                Card c = new Deck().Draw();
                new UI().DisplayComputerDrawCard();

                if (c.getColor() == topCard.getColor() || c.getType() == topCard.getType() || c.getType() == "Wild" || c.getType() == "wild")
                {
                    StringBuilder sb = new StringBuilder();
                    c.setInPlay(false);
                    sb.Append(c.getColor());
                    sb.Append(' ');
                    sb.Append(c.getType());
                    string cardText = sb.ToString();

                    if (hand.GetHandSize() == 1)
                    {
                        new UI().Uno();
                    }
                    else if (hand.GetHandSize() == 0)
                    {
                        new UI().DeclareWinner(2);
                    }
                    else
                    {
                        Console.WriteLine("Opponent now has " + hand.GetHandSize() + " cards remaining in their hand");
                    }

                    return cardText;    //Due to UML Error, card cannot be played GameManager directly, and instead its properties must be passed as a string
                }
                else
                {
                    hand.AddCard(c);
                }
            }

        }

        /// <summary>
        /// The Computer/AI/Opponent draws a card
        /// </summary>
        public void DrawCard()
        {
            hand.AddCard(new Deck().Draw());
            new UI().DisplayComputerDrawCard();
        }


        /// <summary>
        /// Selects a random Card Color
        /// </summary>
        /// <returns>Card Color that was selected</returns>
        public string SelectColor()
        {
            Random r = new Random();

            int randomNumber = r.Next(1, 4);

            string color = "";

            if(randomNumber == 4)
            {
                color = "Red";
            }
            else if(randomNumber == 3)
            {
                color = "Blue";
            }
            else if (randomNumber == 2)
            {
                color = "Green";
            }
            else
            {
                color = "Yellow";
            }

            //new UI().DisplayColorSelected();  //Unfortunately, due to a UML Error, the color cannot be passed to the UI to display. It will be displayed through here instead.
            Console.WriteLine("The Opponent Selected Card Color: " + color);

            return color;
        }
    }
}
