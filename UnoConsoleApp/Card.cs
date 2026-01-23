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


        public string getColor()
        {
            return color;
        }

        public string getType()
        {
            return type;
        }

        public bool getInPlay()
        { 
            return inPlay; 
        }

        /// <summary>
        /// Sets card color and type
        /// </summary>
        /// <param name="color">Color and Type formated in string "[color] [type]"</param>
        public void setColor(string color)
        {
            string[] colorType = color.Split(' ');

            color = colorType[0];
            type = colorType[1];
        }

        public void setInPlay(bool isInPlay)
        {
            inPlay = isInPlay;
        }
    }
}
