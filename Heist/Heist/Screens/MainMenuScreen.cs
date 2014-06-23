using Heist.Display;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    class MainMenuScreen : Screen
    {
        private Image title;
        private TextButton newGame, loadGame, options;

        public MainMenuScreen(int widthScreen, int heightScreen, IScreenMaster master) : base(widthScreen, heightScreen, master)
        {
            Texture2D up = Load<Texture2D>("Image/red");
            Texture2D down = Load<Texture2D>("Image/blue");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;
            int buttonStartY = heightScreen / 3;
            int buttonSpacing = 10;

            title = new Image(centerX, 10, up);
            newGame = new TextButton(centerX, buttonStartY, up, down, font, "New Game");
            loadGame = new TextButton(centerX, buttonStartY + up.Height + buttonSpacing, up, down, font, "Load Game");
            options = new TextButton(centerX, buttonStartY + 2 * (up.Height + buttonSpacing), up, down, font, "Options");
        }

        private void UpdateButton(Button button)
        {
            if (button.Collide(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    button.SetPressed(true);
                }
                else
                {
                    button.SetPressed(false);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateButton(newGame);
            UpdateButton(loadGame);
            UpdateButton(options); 
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            title.Draw(batch);
            newGame.Draw(batch);
            loadGame.Draw(batch);
            options.Draw(batch);
            batch.End();
        }
    }
}
