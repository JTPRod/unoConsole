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
        /// Allows other classes to see the number of cards in the AI's hand
        /// </summary>
        /// <returns></returns>
        public int getHandSize()
        {
            return hand.GetHandSize();
        }

        /// <summary>
        /// The Computer/AI takes its turn
        /// </summary>
        /// <param name="topCard">The top card currently on the discard pile</param>
        public void Play(Card topCard)
        {
            if (hand.GetHandSize() == 0)
            {
                return;
            }

            List<Card> cards = hand.GetHand();

            Card cardToPlay = null;

            foreach (Card card in cards)
            {
                if (GameManager.ValidateCard(card))
                {
                    cardToPlay = card;
                }
            }

            //If playable card was found, play card
            if (cardToPlay != null)
            {
                hand.RemoveCard(cardToPlay);
                GameManager.PlayCard(cardToPlay);
                UI.DisplayComputerPlayCard(cardToPlay);

                //Select color if card was wild card
                if (cardToPlay.getType() == "Wild" || cardToPlay.getType() == "wild")
                {
                    string color = SelectColor();

                    cardToPlay.setColor(color);
                }

                if (hand.GetHandSize() == 1)
                {
                    UI.Uno();
                }
                else if (hand.GetHandSize() == 0)
                {
                    UI.DeclareWinner(2);
                    GameManager.gameState = GameState.GAMEOVER;
                }
            }
            else
            {
                bool noPlayableCard = true;
                //Draw cards until a card can be played

                while (noPlayableCard)
                {
                    Card c = Deck.Draw();
                    UI.DisplayComputerDrawCard();

                    if (GameManager.ValidateCard(c))
                    {
                        noPlayableCard = false;
                        UI.DisplayComputerPlayCard(c);

                        if (hand.GetHandSize() == 1)
                        {
                            UI.Uno();
                        }
                        else if (hand.GetHandSize() == 0)
                        {
                            UI.DeclareWinner(2);
                            GameManager.gameState = GameState.GAMEOVER;
                        }
                    }
                    else
                    {
                        hand.AddCard(c);
                    }
                }

            }
        }
        /// <summary>
        /// The Computer/AI/Opponent draws a card
        /// </summary>
        public void DrawCard()
        {
            hand.AddCard(Deck.Draw());
            UI.DisplayComputerDrawCard();
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

            if (randomNumber == 4)
            {
                color = "Red";
            }
            else if (randomNumber == 3)
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

            UI.DisplayColorSelected(color);

            return color;
        }

        /// <summary>
        /// Resets all cards in the AI's hand and empties hand
        /// </summary>
        public void Reset()
        {
            List<Card> cards = hand.GetHand();


            //reset all cards in AI/Computer's hand, and remove them from hand
            while (cards.Count() > 0)
            {
                if (cards.Count() <= 0) break;
                Card card = cards[0];
                card.setInPlay(false);
                if (card.getType() == "Wild" || card.getType() == "wild")
                {
                    card.setColor("null");
                }
                cards.RemoveAt(0);
            }
        }
    }
}
