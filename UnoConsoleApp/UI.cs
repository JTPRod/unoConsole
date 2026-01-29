namespace UnoConsoleApp
{
    internal class UI
    {
        public static void DisplayTurn(int turn)
        {
            if(turn == 1){
                Console.WriteLine("================================================\n");
                Console.WriteLine("It is YOUR turn");
            } else {
                Console.WriteLine("================================================\n");
                Console.WriteLine("It is THE COMPUTER'S turn");
            }  
        }

        public static void DisplayCurrentState(int opponentHandSize, int drawNumber, bool skip, Card topCard, Hand playerHand) //skip stating number of cards in opponent hand
        {
            Console.WriteLine("\nCOMPUTER hand size: " + opponentHandSize + "\n");
        }


        public static void DisplayComputerPlayCard(Card card)
        {

            Console.Write("\nCOMPUTER played ");
            if (card.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
            if (card.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
            if (card.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            if (card.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
            if (card.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(card.getColor() + " : " + card.getType());
            Console.ForegroundColor = ConsoleColor.White;
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
                //Console.WriteLine("\nTop Card in Play -> " + topCard.getColor() + " : " + topCard.getType() + "\n");
                Console.Write("\nTop Card in Play -> ");
                if(topCard.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
                if (topCard.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
                if (topCard.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                if (topCard.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
                if (topCard.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(topCard.getColor() + " : " + topCard.getType() + "\n");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Your Hand:");
                Console.WriteLine("[0] - (Draw Cards)");
                for (int i = 0; i < playerHand.GetHandSize(); i++)
                {
                    Card card = playerHand.GetHand()[i];
                    Console.Write("[" + (i + 1) + "] - ");
                    if (card.getColor() == "Green") Console.ForegroundColor = ConsoleColor.Green;
                    if (card.getColor() == "Red") Console.ForegroundColor = ConsoleColor.Red;
                    if (card.getColor() == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                    if (card.getColor() == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
                    if (card.getColor() == "NULL") Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(card.getColor() + " : " + card.getType());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\nPlease Select A Card To Play: \n");
           
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
                    Console.WriteLine("\nYou draw cards until you have a card you can play!");
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
                Console.WriteLine("\n================================================");
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
            Console.Write("\nPlease pick a color to change to (");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Y");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("G");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("B");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(")");
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
            if (color == "Green") Console.ForegroundColor = ConsoleColor.Green;
            if (color == "Red") Console.ForegroundColor = ConsoleColor.Red;
            if (color == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            if (color == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(color);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" was chosen!");
            return color;
        }

        public static void Uno()
        {
            Console.WriteLine("\nUNO!");
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
            Console.WriteLine("\nGAME RESET");
        }

        private static void InvalidCardSelection(Card card, int notSureAnymore)
        {
            Console.WriteLine("Sorry, that is in invalid card. Please select a valid card");
        }
    }
}
