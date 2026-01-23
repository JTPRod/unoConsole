using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    enum GameState
    {
        SETUP,
        PLAY,
        GAMEOVER
    }


    internal class GameManager
    {
        private Deck deck = new Deck();

        private Hand playerHand = new Hand();

        private AI opponent = new AI();

        private GameState gameState = GameState.SETUP;

        private int drawTwo = 0;

        private bool skip = false;

        private int turn = 0;   //Player turn will be 1, Computer turn will be 2, no one's turn will be 0

        private Card topCard = null;







        /// <summary>
        /// Maintains Game Loop
        /// </summary>
        public void Main()
        {
            bool keepPlaying = true;
            do
            {
                switch (gameState)
                {
                    case GameState.SETUP:
                        StartGame(); 
                        break;

                    case GameState.PLAY:
                        PlayGame(); 
                        break;

                    case GameState.GAMEOVER:
                        string playerResponse = new UI().PromptPlayAgain();

                        if (playerResponse == "False" || playerResponse == "false")
                        {
                            keepPlaying = false;
                        }
                        else if(playerResponse == "True" || playerResponse == "true")
                        {
                            ResetGame();
                            gameState = GameState.SETUP;
                        }
                        break;
                    default:
                        break;
                }

            } while (keepPlaying);
        }

        /// <summary>
        /// Executes the player or opponent turn
        /// </summary>
        private void PlayGame()
        {
            if (turn == 1)
            {
                new UI().DisplayCurrentState(0, drawTwo, skip, topCard, playerHand);
                new UI().DisplayTurn(turn);
                PlayerTurn();
                turn = 2;
            }
            else
            {
                new UI().DisplayCurrentState(0, drawTwo, skip, topCard, playerHand);
                new UI().DisplayTurn(turn);
                ComputerTurn();
                turn = 1;
            }
        }

        /// <summary>
        /// Sets up the very stard of the game
        /// </summary>
        private void StartGame()
        { 
            deck.Shuffle(); //shuffle deck
            
            //opponent and player draw hand of seven cards
            for(int i = 0; i < 7; i++)
            {
                opponent.DrawCard();
                playerHand.AddCard(deck.Draw());
            }

            UI ui = new UI();
            ui.DisplayGameReset();
            ui.DisplayCurrentState(0, drawTwo, skip, topCard, playerHand);

            turn = 1;
        }

        /// <summary>
        /// Resets state of the game after game ends
        /// </summary>
        private void ResetGame()
        {
            List<Card> cards = playerHand.GetHand();
           

            //reset all cards in players hand, and remove them from hand
            for(int i = 0; i < cards.Count(); i++)
            {
                if (cards.Count() <= 0) break;
                Card card = cards[0];
                card.setInPlay(false);
                if (card.getType() == "Wild" || card.getType() == "wild")
                {
                    card.setColor("null Wild");
                }
                cards.RemoveAt(0);
            }

            //Would do the same as with the player with the AI/Computer/Opponent, but due to a UML issue, this is not possible


            deck.Shuffle();
        }


        private void PlayerTurn()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Executes Computer Turn
        /// </summary>
        private void ComputerTurn()
        {
            //opponent draws cards and turn ends if under the effects of a "Draw Two" Card
            if(drawTwo > 0)
            {
                for(int i = 0; drawTwo > 0; drawTwo--)
                {
                    opponent.DrawCard();
                }
                return;
            }

            string cardText = opponent.Play(topCard);

            if(cardText == null || cardText.Length == 0 || cardText == "")
            {
                return;
            }

            if(cardText == "No cards")
            {
                //new UI().DeclareWinner(2);
                gameState = GameState.GAMEOVER;
            }

            Card playedCard = new Card();
            playedCard.setColor(cardText);

            PlayCard(playedCard);
        }

        /// <summary>
        /// Ensures that a card can be played without breaking the rules.
        /// </summary>
        /// <param name="card">Card being validated</param>
        /// <returns>Whether card is valid</returns>
        public bool ValidateCard(Card card)
        {
            //if(topCard.getType() == "DrawTwo" && !(card.getType() == "DrawTwo"))
            //{
            //    return false;
            //}

            if (card.getType() == "Wild" || card.getType() == "wild")
            {
                return true;
            }

            if(card.getType() == topCard.getType())
            {
                return true;
            }

            if(card.getColor() == topCard.getColor())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds card to top of discard pile
        /// </summary>
        /// <param name="card">Card being played</param>
        public void PlayCard(Card card)
        {
            topCard.setInPlay(false);
            topCard = card;

            if (topCard.getType() == "Skip" || topCard.getType() == "skip")
            {
                skip = true;
            }

            if(topCard.getType() == "DrawTwo")
            {
                drawTwo += 2;
            }

            if(topCard.getType() == "Wild" || topCard.getType() == "wild")
            {
                UI ui = new UI();
                string color = ui.PromptSelectColor();
                StringBuilder sb = new StringBuilder();
                sb.Append(color);
                sb.Append(' ');
                sb.Append(topCard.GetType());
                string colorInput = sb.ToString();
                card.setColor(colorInput);
            }
        }
    }
}
