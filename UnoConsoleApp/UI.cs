using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    internal class UI
    {
        public void DisplayTurn(int turn)
        {
            if(int == 1){
                Console.WriteLine("It is YOUR turn")
                PromptPlayerTurn();
            } else {
                Console.WriteLine("It is THE COMPUTER'S turn")
            } throw new NotImplementedException();
        }

        public void DisplayCurrentState(int opponentHandSize, int drawNumber, bool skip, Card topCard, Hand playerHand) //skip stating number of cards in opponent hand
        {
            if(topCard.type == "Skip"){
                skip = true
            } else {
                skip = false
            }

            Console.WriteLine(topcard);
            Console.WriteLine(playerHand)

            throw new NotImplementedException();
        }


        public void DisplayComputerPlayCard(Card card)
        {
            Console.WriteLine(card)
            throw new NotImplementedException();
        }

        public void DisplayComputerDrawCard()
        {
            Console.WriteLine("COMPUTER drew a card")
            throw new NotImplementedException();
        }


        public string PromptPlayerTurn(Card card, Hand playerHand)
        {
            Console.WriteLine(playerHand)
            Console.WriteLine("Please pick a card to play, or draw a card")
            throw new NotImplementedException();
        }

        public string PromptPlayAgain() //make sure to return 'True' or 'False'
        {
            Console.WriteLine("Would you like to play again? (Y/N)")
            throw new NotImplementedException();
        }

        public string PromptSelectColor()
        {
            Console.WriteLine("Please pick a color to change to (R/Y/G/B)")
            throw new NotImplementedException();
        }

        public string DisplayColorSelected()      //Another thing marked wrong on the UML
        {
            throw new NotImplementedException();
        }

        public void Uno()
        {
            throw new NotImplementedException();
        }

        public void DeclareWinner(int winner)
        {
            if(winner == 1){
                Console.WriteLine("YOU WIN!")
            }else{
                Console.WriteLine("YOU LOSE!")
            }
            throw new NotImplementedException();
        }

        public void DisplayGameReset()
        {
            Console.WriteLine("GAME RESET")
            throw new NotImplementedException();
        }

        private void InvalidCardSelection(Card card, int notSureAnymore)
        {
            Console.WriteLine("Sorry, that is in invalid card. Please select a valid card")
            throw new NotImplementedException();
        }
    }
}
