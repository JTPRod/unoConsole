namespace UnoConsoleApp
{
    internal class UI
    {
        public static void DisplayTurn(int turn)
        {
            if(turn == 1){
                Console.WriteLine("It is YOUR turn");
            } else {
                Console.WriteLine("It is THE COMPUTER'S turn");
            }  
        }

        public static void DisplayCurrentState(int opponentHandSize, int drawNumber, bool skip, Card topCard, Hand playerHand) //skip stating number of cards in opponent hand
        {
            Console.WriteLine(topCard);
            Console.WriteLine(playerHand);
        }


        public static void DisplayComputerPlayCard(Card card)
        {
            Console.WriteLine("COMPUTER played " + card);
        }

        public static void DisplayComputerDrawCard()
        {
            Console.WriteLine("COMPUTER drew a card");
        }


        public static Card PromptPlayerTurn(Card card, Hand playerHand)
        {
            bool validInput = false;
            Card playerCard = null;
            while(!validInput)
            {

                // display top card, and all cards in player hand (with number options), and -1 to draw
                Console.WriteLine("Please Select A Card To Play: ");
                string userInput = Console.ReadLine();

                if (userInput == null)
                {
                    Console.WriteLine("Must input value!");
                    continue;
                }

                int inputIndex = -457;

                if(!int.TryParse(userInput, out inputIndex))
                {
                    Console.WriteLine("Input must be a number!");
                    continue;
                }

                else if (inputIndex == -1)
                {
                    Console.WriteLine("You draw cards until you have a card you can play!");
                    GameManager.PlayerDrawUntilCanPlay();
                    return null;
                }

                else if(inputIndex < 0 || inputIndex > playerHand.GetHandSize())
                {
                    Console.WriteLine("That is not a valid input!");
                    continue;
                }

                else
                {
                    playerCard = playerHand.GetHand()[inputIndex];

                    if(!GameManager.ValidateCard(playerCard))
                    {
                        Console.WriteLine("You can't play that card!");
                        continue;
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
                Console.WriteLine("Would you like to play again? (Y/N)");
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
            Console.WriteLine("Please pick a color to change to (R/Y/G/B)");
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

        public static string DisplayColorSelected(String color)      //Another thing marked wrong on the UML
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
