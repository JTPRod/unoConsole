namespace UnoConsoleApp
{
    internal class UI
    {
        public static void DisplayTurn(int turn)
        {
            if(turn == 1){
                Console.WriteLine("\nIt is YOUR turn\n");
            } else {
                Console.WriteLine("\nIt is THE COMPUTER'S turn\n");
            }  
        }

        public static void DisplayCurrentState(int opponentHandSize, int drawNumber, bool skip, Card topCard, Hand playerHand) //skip stating number of cards in opponent hand
        {
            Console.WriteLine("\nCOMPUTER hand size: " + opponentHandSize + "\n");
        }


        public static void DisplayComputerPlayCard(Card card)
        {

            Console.WriteLine("\nCOMPUTER played " + card.getColor() + " : " + card.getType() + "\n");
        }

        public static void DisplayComputerDrawCard()
        {
            Console.WriteLine("COMPUTER drew a card");
        }


        public static Card PromptPlayerTurn(Card topCard, Hand playerHand)
        {
            bool validInput = false;
            Card playerCard = null;
            while(!validInput)
            {
                Console.WriteLine("\nTop Card in Play: " + topCard.getColor() + " : " + topCard.getType() + "\n");
                Console.WriteLine("\nPlease Select A Card To Play: \n");
                Console.WriteLine("\n[0] - Draw");
                for (int i = 0; i < playerHand.GetHandSize(); i++)
                {
                    Card card = playerHand.GetHand()[i];
                    Console.WriteLine("[" + (i + 1) + "] - " + card.getColor() + " : " + card.getType());
                }
           
                string userInput = Console.ReadLine();

                if (userInput == null)
                {
                    Console.WriteLine("\nMust input value!\n");
                }

                int inputIndex = -457;

                if(!int.TryParse(userInput, out inputIndex))
                {
                    Console.WriteLine("\nInput must be a number!\n");
                }

                else if (inputIndex == 0)
                {
                    Console.WriteLine("\nYou draw cards until you have a card you can play!\n");
                    GameManager.PlayerDrawUntilCanPlay();
                    return null;
                }

                else if(inputIndex < 0 || inputIndex > playerHand.GetHandSize())
                {
                    Console.WriteLine("\nThat is not a valid input!");
                }

                else
                {
                    playerCard = playerHand.GetHand()[inputIndex - 1];

                    if(!GameManager.ValidateCard(playerCard))
                    {
                        Console.WriteLine("\nYou can't play that card!");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
            }
            return playerCard;
        }

        public static string PromptPlayAgain()
        {
            bool validInput = false;
            while (!validInput){
                Console.WriteLine("\nWould you like to play again? (Y/N)");
            string response = Console.ReadLine();
            if (response == "Y" || response == "y"){
                validInput = true;
                return "Y";
            } else{
                validInput = true;
                return "N";
                }
            }
            return "N";
        }

        public static string PromptSelectColor()
        {
            Console.WriteLine("\nPlease pick a color to change to (R/Y/G/B)");
            string colorChosen = Console.ReadLine();
            switch (colorChosen)
            {
                case "R":
                    return "Red";
                case "Y":
                    return "Yellow";
                case "G":
                    return "Green";
                case "B":
                    return "Blue";
                case "r":
                    return "Red";
                case "y":
                    return "Yellow";
                case "g":
                    return "Green";
                case "b":
                    return "Blue";
                default:
                    return null;
            }
        }

        public static string DisplayColorSelected(String color)
        {
            Console.WriteLine(color + "was chosen!");
            return color;
        }

        public static void Uno()
        {
            Console.WriteLine("UNO!");
        }

        public static void DeclareWinner(int winner)
        {
            if(winner == 1){
                Console.WriteLine("YOU WIN!");
            }else{
                Console.WriteLine("YOU LOSE!");
            }
        }

        public static void DisplayGameReset()
        {
            Console.WriteLine("GAME RESET");
        }

        private static void InvalidCardSelection(Card card, int notSureAnymore)
        {
            Console.WriteLine("Sorry, that is in invalid card. Please select a valid card");
        }
    }
}
