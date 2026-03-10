using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static bool isAttack; //Indicates if player wants to play UnoAttack or Traditional Uno







        /// <summary>
        /// Maintains Game Loop
        /// </summary>
        public static void Main()
        {
            bool keepPlaying = true;
            bool validGamemode = false;
            do
            {
                while (validGamemode == false){
                    string gamemode = UI.promptGamemode();
                    if (gamemode == "Classic")
                    {
                        // play classic
                        isAttack = false;
                        validGamemode = true;
                    } else if (gamemode == "Attack")
                    {
                        // play attack
                        isAttack = true;
                        validGamemode = true;
                    } else
                    {
                        validGamemode = false;
                    }
                }

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

                            validGamemode = false;
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
            //Handle any case where TopCard may be wild card with color "NULL" at start of turn (such as if it was the first TopCard of the game)
            if (topCard.getColor() == "NULL")
            {
                string color = opponent.SelectColor();
                topCard.setColor(color);
            }

            if (turn == 1)
            {
                UI.DisplayCurrentState(opponent.getHandSize(), drawTwo, skip, topCard, playerHand);
                Console.WriteLine("================================================\n");

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

                Console.Write("\n(Hit Enter to Continue)");
                string pause = Console.ReadLine();
            }
        }

        /// <summary>
        /// Sets up the very stard of the game
        /// </summary>
        private static void StartGame()
        {
            skip = false;
            drawTwo = 0;

            Deck.Shuffle(); //shuffle Deck
            topCard = Deck.Draw();

            //opponent and player draw hand of seven cards
            for (int i = 0; i < 7; i++)
            {
                opponent.DrawCard();
                playerHand.AddCard(Deck.Draw());
            }

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
                if (card.getType() == "Wild" || card.getType() == "wild" || card.getType() == "Wild +4" || card.getType() == "Wild x2")
                {
                    card.setColor("null");
                }
                cards.RemoveAt(0);
            }

            opponent.Reset();   //reset all cards in the AI/Compuer/Opponent's hand

            UI.DisplayGameReset();
        }

        /// <summary>
        /// Executes player turn
        /// </summary>
        private static void PlayerTurn()
        {
            //Player turn skipped if under the effects of a "Skip" Card
            if (skip)
            {
                Console.WriteLine("\nSkip Card in play! Player turn skipped!");
                skip = false;

                Console.Write("\n(Hit Enter to Continue)");
                string pause = Console.ReadLine();
                return;
            }

            //Player draws cards and turn ends if under the effects of a "Draw Two" Card
            if (drawTwo > 0 && !isAttack)
            {
                if (drawTwo == 2) Console.WriteLine("\nDraw Two Card in play! Player must draw two cards and skip their turn!");
                if (drawTwo == 4) Console.WriteLine("\nWild Draw Four Card in play! Opponent must draw four cards and skip their turn!");


                for (int i = 0; drawTwo > 0; drawTwo--)
                {
                    Card c = Deck.Draw();
                    Console.Write("\nYou drew a ");
                    if (c.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
                    if (c.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
                    if (c.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                    if (c.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
                    if (c.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(c.getColor() + " : " + c.getType());
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(" and added it to your hand.");
                    playerHand.AddCard(c);

                    Console.Write("\n(Hit Enter to Continue)");
                    string pause = Console.ReadLine();
                }
                return;
            }

            //Player hits "attack" button and turn ends if under the effects of a "Draw Two" Card in Uno Attack
            if (drawTwo > 0 && isAttack)
            {
                Console.WriteLine("\nx2 Card in play! Player must hit attack button twice and skip their turn!");

                for (int i = 0; drawTwo > 0; drawTwo--)
                {                   
                    PlayerAttack();
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

            Console.Write("\nYou played ");
            if (card.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
            if (card.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
            if (card.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            if (card.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
            if (card.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(card.getColor() + " : " + card.getType() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            playerHand.RemoveCard(card);
            PlayCard(card);


            //Select color if card was wild card
            if (card.getType() == "Wild" || card.getType() == "wild" || card.getType() == "Wild +4" || card.getType() == "Wild x2")
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
                Console.WriteLine("\nSkip Card in play! Opponent turn skipped!");
                skip = false;
                return;
            }

            //opponent draws cards and turn ends if under the effects of a "Draw Two" Card
            if (drawTwo > 0 && !isAttack)
            {
                if(drawTwo == 2) Console.WriteLine("\nDraw Two Card in play! Opponent must draw two cards and skip their turn!");
                if(drawTwo == 4) Console.WriteLine("\nWild Draw Four Card in play! Opponent must draw four cards and skip their turn!");

                for (int i = 0; drawTwo > 0; drawTwo--)
                {
                    opponent.DrawCard();
                }
                return;
            }


            //opponent draws cards and turn ends if under the effects of a "Draw Two" Card
            if (drawTwo > 0 && isAttack)
            {
                Console.WriteLine("\nx2 Card in play! Opponent must hit attack button twice and skip their turn!");

                for (int i = 0; drawTwo > 0; drawTwo--)
                {
                    opponent.Attack();
                }
                return;
            }

            opponent.Play(topCard);

            //Console.Write("\n(Hit Enter to Continue)");
            //string pause = Console.ReadLine();
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

            if (card.getType() == "Wild" || card.getType() == "wild" || card.getType() == "Wild +4" || card.getType() == "Wild x2")
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

            if (topCard.getType() == "DrawTwo" || topCard.getType() == "x2" || topCard.getType() == "Wild x2")
            {
                drawTwo += 2;
            }

            if (topCard.getType() == "Wild +4")
            {
                drawTwo += 4;
            }           
        }

        /// <summary>
        /// The player draws cards until they can play a card
        /// </summary>
        public static void PlayerDrawUntilCanPlay()
        {
            bool noPlayableCard = true;
            //Draw cards until a card can be played (if not using "Uno Attack" rules.
            while (noPlayableCard && !isAttack)
            {
                Card c = Deck.Draw();

                Console.Write("\nYou drew: ");
                if (c.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
                if (c.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
                if (c.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                if (c.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
                if (c.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(c.getColor() + " " + c.getType());
                Console.ForegroundColor = ConsoleColor.White;

                if (GameManager.ValidateCard(c))
                {
                    noPlayableCard = false;

                    if (c == null)
                    {
                        Console.WriteLine("TEST");
                    }
                    Console.Write("You can play this! \n\nYou played ");
                    if (c.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
                    if (c.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
                    if (c.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                    if (c.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
                    if (c.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(c.getColor() + " " + c.getType());
                    Console.ForegroundColor = ConsoleColor.White;

                    //Select color if card was wild card
                    if (c.getType() == "Wild" || c.getType() == "wild" || c.getType() == "Wild x2" || c.getType() == "Wild +4")
                    {
                        string color = UI.PromptSelectColor();

                        c.setColor(color);
                    }

                    GameManager.PlayCard(c);

                    if (playerHand.GetHandSize() == 1)
                    {
                        UI.Uno();
                    }
                    else if (playerHand.GetHandSize() == 0)
                    {
                        UI.DeclareWinner(2);
                        GameManager.gameState = GameState.GAMEOVER;
                    }

                    Console.Write("\n(Hit Enter to Continue)");
                    string pause = Console.ReadLine();

                    break;
                }
                else
                {
                    Console.WriteLine("You cannot play this card. You added this card to your hand.");
                    playerHand.AddCard(c);

                    Console.Write("\n(Hit Enter to Continue)");
                    string pause = Console.ReadLine();
                }
            }
        }


        /// <summary>
        /// The player hits the "Attack" button, and has a chance to recieve a random number of cards, which they will add to their hand.
        /// </summary>
        public static void PlayerAttack()
        {   
            Console.WriteLine("\nYou hit the attack button!");
            List<Card> cardsDrawn = Deck.PressAttackButton();

            if (cardsDrawn.Count > 0) Console.WriteLine("\nYou received " + cardsDrawn.Count + " cards, and added them to your hand!");
            if (cardsDrawn.Count == 0) Console.WriteLine("\nNo cards came out!");

            foreach (Card c in cardsDrawn)
            {
                playerHand.AddCard(c);
            }

            Console.Write("\n(Hit Enter to Continue)");
            string pause = Console.ReadLine();
            
        }
    }
}