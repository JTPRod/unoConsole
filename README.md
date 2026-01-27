# Uno Console App

## Installation 
- NOTE: Requires funtional C# environment to run.
<br>
1.) Download Zip File from Github (Click Green "Code" button, then click "Download From Zip")
  <br>
  <img width="318" height="277" alt="image" src="https://github.com/user-attachments/assets/e26393ba-619f-4ef3-842e-6471e848372f" />
  <br><br>
2.) Navigate to zip file in file explore. Right click on zip file and select "Extract All". (Optionally select a location to extract to). Then click "Extract"
<br>
<img width="210" height="103" alt="image" src="https://github.com/user-attachments/assets/4933c6c5-e8c9-4058-982e-1672570d9851" />
<br>
<img width="152" height="67" alt="image" src="https://github.com/user-attachments/assets/1c6c1b9e-6e51-4820-9aa1-2e8962ee3e47" />
<br><br>
3.) Navigate to "unoConsole-main" -> unoConsole-main". Single click and then right click on the SLN, hover over "Open With" and select either Visual Studio or Visual Studio Code.
  NOTE: it is important to open this file in an environment that can run C#!
<br>
<img width="283" height="122" alt="image" src="https://github.com/user-attachments/assets/677fe210-e7be-47ce-9217-9c274c0a28fa" />
<br>
<img width="488" height="187" alt="image" src="https://github.com/user-attachments/assets/f12860c6-546a-482a-b5ad-e45365003aa6" />
<br><br>

## Setup
1.) Build Solution to ensure that solution is error free.
<br><br>


## Usage
To Execute Program -- Click the "Play" button or run the file 
<br><br>
To Win -- Be the first player to run out of cards!
<br><br>
To Play A Card -- On your turn, the cards in your hand will be displayed as a numbered list. To play a card, type the number next to the card you want to play into the terminal and hit enter. If 
the card is legal (can be played in accordance with the rules of the game), the card will be played. Otherwise you will be prompted again to select a different card.
<br><br>
To Draw A Card -- On your turn, type "-1" into the terminal and hit enter. You will then draw cards until you obtain a card that you can play. That card will then be played, and your turn will end. 
<br><br>
To Set The Color Of A Wild Card -- When you play a "Wild Card", you will then be prompted to select a color. Please enter "R", "Y", "G", or "B" (case insensitive). R = Red, Y = Yellow, G = Green, B = Blue.
The Wild Card you played will now be the color you selected while it is the top card in play.
<br><br>
To Play Again -- When the game ends, you will be prompted with the question "Would you like to play again? (Y/N)". To play again, type "Y" or "y" and hit enter. The game will restart. To exit program, 
type "N", or "n" and hit enter. The game can be played again at any time by restarting the program.
<br><br><br>
### RULES:
<br>
-- Both the player and computer will start with seven cards in their hand. One card will be selected for use as the top card in play.
<br>
-- On your turn, you may play up to one card.
<br>
-- A card may only be played if:
<br>
1.) It shares a color with the top card in play.
<br>
2.) It shares a number or type (0-9, or Skip) with the top card in play.
<br>
3.) It is a "Wild Card"
<br>
--If you do not have any cards that meet the requirements, you must draw cards from the deck until you have a card you can play.
<br>
-- If at the start of your turn a skip card was the most recent card played by another player, your turn will be skipped and you will not be able to play or draw any card(s)
