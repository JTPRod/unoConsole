using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    enum GameState
    {
        SETUP
    }


    internal class GameManager
    {
        private Deck deck = new Deck();

        private Hand playerHand = new Hand();

        private AI opponent = new AI();

        private GameState gameState = GameState.SETUP;

        private int drawTwo = 0;

        private bool skip = false;

        private int turn = 0;

        private Card topCard = null;








        public void Main()
        {
            throw new NotImplementedException();
        }


        private void PlayGame()
        {
            throw new NotImplementedException();
        }


        private void StartGame()
        { 
            throw new NotImplementedException(); 
        }


        private void ResetGame()
        {
            throw new NotImplementedException();
        }


        private void PlayerTurn()
        {
            throw new NotImplementedException();
        }


        private void ComputerTurn()
        {
            throw new NotImplementedException();
        }


        public bool ValidateCard(Card card)
        {
            throw new NotImplementedException();
        }

        public void PlayCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
