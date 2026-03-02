using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoConsoleApp
{
    internal class TestingFunctions
    {

        /// <summary>
        /// Tests if the GameManager's ValidateCard function is working correctly.
        /// Testing equires the "TopCard" variable in GameManager to be made public.
        /// </summary>
      //public static void TestCardValidation(string topCardColor, string topCardType, string otherColor, string otherType)
      //{
      //    Card top = new Card(topCardColor, topCardType);
      //    Card failingCard = new Card(otherColor, otherType);
      //    Card passingColor = new Card(topCardColor, otherType);
      //    Card passingType = new Card(otherColor, topCardType);
      //    Card passingWild = new Card("NULL", "Wild");
      //
      //    Console.WriteLine("Testing Card Validation Function");
      //
      //    GameManager.topCard = top;
      //
      //    if(GameManager.ValidateCard(failingCard))
      //    {
      //        Console.WriteLine("Fail: Incorrectly validated a failing card.");
      //    } else
      //    {
      //        Console.WriteLine("Pass: Correctly invalidated a failing card.");
      //    }
      //
      //    if(GameManager.ValidateCard(passingColor))
      //    {
      //        Console.WriteLine("Pass: Correctly validated card with matching color.");
      //    } else
      //    {
      //        Console.WriteLine("Fail: Failed to validate card with matching color.");
      //    }
      //
      //    if(GameManager.ValidateCard(passingType))
      //    {
      //        Console.WriteLine("Pass: Correctly validated card with matching type.");
      //    } else
      //    {
      //        Console.WriteLine("Fail: Failed to validate card with matching type.");
      //    }
      //
      //    if(GameManager.ValidateCard(passingWild))
      //    {
      //        Console.WriteLine("Pass: Correctly validated Wild Card");
      //    }else
      //    {
      //        Console.WriteLine("Fail: Failed to validate Wild Card");
      //    }
      //}




        /// <summary>
        /// Tests if the GameManager's PlayCard function is working correctly.
        /// Testing equires the "TopCard" and "skip" variables in GameManager 
        /// to be made public.
        /// </summary>
       //public static void TestPlayCard(string colorOne, string colorTwo, string typeOne, string typeTwo)
       //{
       //    Console.WriteLine("Testing Play Card Function:");
       //
       //    Card top = new Card(colorOne, typeOne);
       //    Card testSameColorCard = new Card(colorOne, typeTwo);
       //    Card testSameTypeCard = new Card(colorTwo, typeTwo);
       //    Card testSkipCard = new Card(colorTwo, "Skip");
       //
       //    GameManager.topCard = top;
       //
       //    Console.WriteLine("Testing Card of same color...");
       //    GameManager.PlayCard(testSameColorCard);
       //
       //    if (GameManager.topCard.getColor() == colorOne && GameManager.topCard.getType() == typeTwo && !GameManager.skip)
       //    {
       //        Console.WriteLine("Pass: Correctly played card.");
       //    } else if (GameManager.topCard.getColor() == colorOne && GameManager.topCard.getType() == typeTwo && GameManager.skip)
       //    {
       //        Console.WriteLine("Fail: Correctly replaced topCard, but incorrectly identified a 'Skip' Card.");
       //    } else if((GameManager.topCard.getColor() != colorOne || GameManager.topCard.getType() != typeTwo) && !GameManager.skip)
       //    {
       //        Console.WriteLine("Fail: Failed to replace topCard.");
       //    } else
       //    {
       //        Console.WriteLine("Fail: Failed to replace topCard and incorrectly identified a 'Skip' Card.");
       //    }
       //
       //
       //    Console.WriteLine("Testing Card of same type...");
       //    GameManager.PlayCard(testSameTypeCard);
       //
       //    if (GameManager.topCard.getColor() == colorTwo && GameManager.topCard.getType() == typeTwo && !GameManager.skip)
       //    {
       //        Console.WriteLine("Pass: Correctly played card.");
       //    }
       //    else if (GameManager.topCard.getColor() == colorTwo && GameManager.topCard.getType() == typeTwo && GameManager.skip)
       //    {
       //        Console.WriteLine("Fail: Correctly replaced topCard, but incorrectly identified a 'Skip' Card.");
       //    }
       //    else if ((GameManager.topCard.getColor() != colorTwo || GameManager.topCard.getType() != typeTwo) && !GameManager.skip)
       //    {
       //        Console.WriteLine("Fail: Failed to replace topCard.");
       //    }
       //    else
       //    {
       //        Console.WriteLine("Fail: Failed to replace topCard and incorrectly identified a 'Skip' Card.");
       //    }
       //
       //
       //    Console.WriteLine("Testing Skip Card...");
       //    GameManager.PlayCard(testSkipCard);
       //
       //    if (GameManager.topCard.getColor() == colorTwo && GameManager.topCard.getType() == "Skip" && GameManager.skip)
       //    {
       //        Console.WriteLine("Pass: Correctly played card and correctly identified a 'Skip' Card.");
       //    }
       //    else if (GameManager.topCard.getColor() == colorTwo && GameManager.topCard.getType() == "Skip" && !GameManager.skip)
       //    {
       //        Console.WriteLine("Fail: Correctly replaced topCard, but failed to identify a 'Skip' Card.");
       //    }
       //    else if ((GameManager.topCard.getColor() != colorTwo || GameManager.topCard.getType() != "Skip") && GameManager.skip)
       //    {
       //        Console.WriteLine("Fail: Correctly identified a 'Skip' Card, but failed to replace topCard.");
       //    }
       //    else
       //    {
       //        Console.WriteLine("Fail: Failed to replace topCard and failed to identify a 'Skip' Card.");
       //    }
       //
       //}



        /// <summary>
        /// Tests if the AI is properly selecting a color when asked to.
        /// </summary>
        //public static void TestAISelectRandomColor()
        //{
        //    AI ai = new AI();
        //
        //    string selectedColor = ai.SelectColor();
        //
        //    if(selectedColor == "Red" || selectedColor == "Yellow" || selectedColor == "Green" || selectedColor == "Blue")
        //    {
        //        Console.WriteLine("Pass: The computer correctly selected a valid color. The color was: " + selectedColor);
        //    } else
        //    {
        //        Console.WriteLine("Fail: The computer did not select a valid color. The computer selected: " + selectedColor);
        //    }
        //}

    }
}
