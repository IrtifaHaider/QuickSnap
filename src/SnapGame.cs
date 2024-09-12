using System;
using SwinGameSDK;
using CardGames.GameLogic;

namespace CardGames
{
    public class SnapGame
    {
		private static void DrawGame(Snap myGame)
		{
			SwinGame.ClearScreen(Color.White);

			// Draw the top card
			Card top = myGame.TopCard;
			if (top != null)
			{
				SwinGame.DrawText ("Top Card is " + top.ToString (), Color.RoyalBlue, 0, 20);
				SwinGame.DrawText ("Player 1 score: " + myGame.Score(0), Color.RoyalBlue, 0, 30);
				SwinGame.DrawText ("Player 2 score: " + myGame.Score(1), Color.RoyalBlue, 0, 40);
				SwinGame.DrawCell (SwinGame.BitmapNamed ("Cards"), top.CardIndex, 350, 50);
			}
			else
			{
				SwinGame.DrawText ("No card played yet...", Color.RoyalBlue, 0, 20);
			}

			// Draw the back of the cards... to represent the deck
			SwinGame.DrawCell (SwinGame.BitmapNamed ("Cards"), 52, 160, 50);

			//Draw onto the screen
			SwinGame.RefreshScreen(60);
		}
		private static void HandleUserInput(Snap myGame)
		{
			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
			{
				myGame.Start ();
			}
		}
        public static void LoadResources()
        {
            Bitmap cards;
            cards = SwinGame.LoadBitmapNamed ("Cards", "Cards.png");
            SwinGame.BitmapSetCellDetails (cards, 82, 110, 13, 5, 53);  // set the cells in the bitmap to match the cards
			SwinGame.LoadFontNamed ("GameFont", " ChunkFive-Regular.otf", 12);    
        }

		/// <summary>
		
		/// </summary>
	/// <param name="myGame">The game object to update in response to events.</param>
		/// <summary>
		/// <param name="myGame">The game object to update in response to events.</param>
		/// </summary>
		/// <param name="myGame">The details of the game -- mostly top card and scores.</param>

		/// Updates the game -- it should flip the cards itself once started!
		/// </summary>
		/// <param name="myGame">The game to be updated...</param>
		private static void UpdateGame(Snap myGame)
		{
			myGame.Update(); // just ask the game to do this...
		}

        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("Snap!", 860, 500);

			//Load the card images and set their cell details
            LoadResources();
            
			// Create the game!
			Snap myGame = new Snap ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				HandleUserInput (myGame);
				//DrawGame (myGame);
				UpdateGame (myGame);
            }
        }
    }
}