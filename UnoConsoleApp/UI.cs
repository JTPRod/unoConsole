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
            throw new NotImplementedException();
        }

        public void DisplayCurrentState(int opponentHandSize, int drawNumber, bool skip, Card topCard, Hand playerHand)
        {
            throw new NotImplementedException();
        }


        public void DisplayComputerPlayCard(Card card)
        {
            throw new NotImplementedException();
        }

        public void DisplayComputerDrawCard(Card card)
        {
            throw new NotImplementedException();
        }


        public string PromptPlayerTurn(Card card, Hand playerHand)
        {
            throw new NotImplementedException();
        }

        public string PromptPlayAgain()
        {
            throw new NotImplementedException();
        }

        public string PromptSelectColor()
        {
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
            throw new NotImplementedException();
        }

        public void DisplayGameReset()
        {
            throw new NotImplementedException();
        }

        private void InvalidCardSelection(Card card, int notSureAnymore)
        {
            throw new NotImplementedException();
        }
    }
}
