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
        private static Deck Deck = new Deck();

        private static Hand playerHand = new Hand();

        private static AI opponent = new AI();

        public static GameState gameState = GameState.SETUP;

        private static int drawTwo = 0;

        private static bool skip = false;

        private static int turn = 0;   //Player turn will be 1, Computer turn will be 2, no one's turn will be 0

        private static Card topCard = null;







        /// <summary>
        /// Maintains Game Loop
        /// </summary>
        public static void Main()
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
                        string playerResponse = UI.PromptPlayAgain();

                        if (playerResponse == "N" || playerResponse == "n")
                        {
                            keepPlaying = false;
                        }
                        else if (playerResponse == "Y" || playerResponse == "y")
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
        private static void PlayGame()
        {
            if (turn == 1)
            {
                UI.DisplayCurrentState(opponent.getHandSize(), drawTwo, skip, topCard, playerHand);
                UI.DisplayTurn(turn);
                PlayerTurn();
                turn = 2;
            }
            else
            {
                UI.DisplayCurrentState(opponent.getHandSize(), drawTwo, skip, topCard, playerHand);
                UI.DisplayTurn(turn);
                ComputerTurn();
                turn = 1;
            }
        }

        /// <summary>
        /// Sets up the very stard of the game
        /// </summary>
        private static void StartGame()
        {
            Deck.Shuffle(); //shuffle Deck
            topCard = Deck.Draw();

            //opponent and player draw hand of seven cards
            for (int i = 0; i < 7; i++)
            {
                opponent.DrawCard();
                playerHand.AddCard(Deck.Draw());
            }

            UI.DisplayGameReset();

            turn = 1;
            gameState = GameState.PLAY;
        }

        /// <summary>
        /// Resets state of the game after game ends
        /// </summary>
        private static void ResetGame()
        {
            List<Card> cards = playerHand.GetHand();


            //reset all cards in players hand, and remove them from hand
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

            opponent.Reset();   //reset all cards in the AI/Compuer/Opponent's hand

            Deck.Shuffle();
        }

        /// <summary>
        /// Executes player turn
        /// </summary>
        private static void PlayerTurn()
        {
            //Player turn skipped if under the effects of a "Skip" Card
            if (skip)
            {
                Console.WriteLine("Player turn skipped!");
                skip = false;
                return;
            }

            //Player draws cards and turn ends if under the effects of a "Draw Two" Card
            if (drawTwo > 0)
            {
                for (int i = 0; drawTwo > 0; drawTwo--)
                {
                    playerHand.AddCard(Deck.Draw());
                }
                return;
            }

            //Get player input
            Card card = UI.PromptPlayerTurn(topCard, playerHand);

            //Return if a card was not played
            if (card == null)
            {
                return;
            }

            playerHand.RemoveCard(card);
            PlayCard(card);


            //Select color if card was wild card
            if (card.getType() == "Wild" || card.getType() == "wild")
            {
                string color = UI.PromptSelectColor();

                card.setColor(color);
            }

            //Check for Uno or GameWon
            if (playerHand.GetHandSize() == 1)
            {
                UI.Uno();
            }
            else if (playerHand.GetHandSize() == 0)
            {
                UI.DeclareWinner(1);
                gameState = GameState.GAMEOVER;
            }
        }


        /// <summary>
        /// Executes Computer Turn
        /// </summary>
        private static void ComputerTurn()
        {
            //Opponent turn skipped if under the effects of a "Skip" Card
            if (skip)
            {
                Console.WriteLine("Opponent turn skipped!");
                skip = false;
                return;
            }

            //opponent draws cards and turn ends if under the effects of a "Draw Two" Card
            if (drawTwo > 0)
            {
                for (int i = 0; drawTwo > 0; drawTwo--)
                {
                    opponent.DrawCard();
                }
                return;
            }

            opponent.Play(topCard);
        }

        /// <summary>
        /// Ensures that a card can be played without breaking the rules.
        /// </summary>
        /// <param name="card">Card being validated</param>
        /// <returns>Whether card is valid</returns>
        public static bool ValidateCard(Card card)
        {
            //if(topCard.getType() == "DrawTwo" && !(card.getType() == "DrawTwo"))
            //{
            //    return false;
            //}

            if (card.getType() == "Wild" || card.getType() == "wild")
            {
                return true;
            }

            if (card.getType() == topCard.getType())
            {
                return true;
            }

            if (card.getColor() == topCard.getColor())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds card to top of discard pile
        /// </summary>
        /// <param name="card">Card being played</param>
        public static void PlayCard(Card card)
        {

            topCard.setInPlay(false);
            topCard = card;

            if (topCard.getType() == "Skip" || topCard.getType() == "skip")
            {
                skip = true;
            }

            if (topCard.getType() == "DrawTwo")
            {
                drawTwo += 2;
            }
        }

        /// <summary>
        /// The player draws cards until they can play a card
        /// </summary>
        public static void PlayerDrawUntilCanPlay()
        {
            bool noPlayableCard = true;
            //Draw cards until a card can be played
            while (noPlayableCard)
            {
                Card c = Deck.Draw();

                Console.WriteLine("You drew: " + c.getColor() + " " + c.getType());

                if (GameManager.ValidateCard(c))
                {
                    noPlayableCard = false;

                    if (c == null)
                    {
                        Console.WriteLine("TEST");
                    }
                    Console.WriteLine("You can play this! You played " + c.getColor() + " " + c.getType());

                    //Select color if card was wild card
                    if (c.getType() == "Wild" || c.getType() == "wild")
                    {
                        string color = UI.PromptSelectColor();

                        c.setColor(color);
                    }

                    GameManager.PlayCard(c);
                    break;

                    if (playerHand.GetHandSize() == 1)
                    {
                        UI.Uno();
                    }
                    else if (playerHand.GetHandSize() == 0)
                    {
                        UI.DeclareWinner(2);
                        GameManager.gameState = GameState.GAMEOVER;
                    }
                }
                else
                {
                    Console.WriteLine("You cannot play this card. You added this card to your hand.");
                    playerHand.AddCard(c);
                }
            }
        }
    }
}