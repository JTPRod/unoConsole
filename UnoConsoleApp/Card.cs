using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    internal class Card
    {
        private string color = "";

        private string type = "";

        private bool inPlay = false;

        public Card(string color, string type)
        {
            this.color = color;
            this.type = type;
        }

        /// <summary>
        /// Allows other classes to see this card's color
        /// </summary>
        /// <returns>This card's color</returns>
        public string getColor()
        {
            return color;
        }

        /// <summary>
        /// Allows other classes to see this card's type
        /// </summary>
        /// <returns>This card's type</returns>
        public string getType()
        {
            return type;
        }

        /// <summary>
        /// Allows other classes to see if this card is in play
        /// </summary>
        /// <returns>If this card is in play</returns>
        public bool getInPlay()
        { 
            return inPlay; 
        }

        /// <summary>
        /// Sets card color
        /// </summary>
        /// <param name="color">Color of the card</param>
        public void setColor(string color)
        {
            this.color = color;
        }

        /// <summary>
        /// Allows other classes to tell this card if it is in play
        /// </summary>
        /// <param name="isInPlay">Whether this card is in play</param>
        public void setInPlay(bool isInPlay)
        {
            inPlay = isInPlay;
        }
    }
}