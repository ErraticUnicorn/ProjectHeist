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
    class OptionScreen : Screen
    {
        private Image title;
        private TextButton back;

        public OptionScreen(int widthScreen, int heightScreen, IScreenMaster master, object[] data)
            : base(widthScreen, heightScreen, master, data)
        {
            Texture2D up = Load<Texture2D>("Image/red");
            Texture2D down = Load<Texture2D>("Image/blue");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;

            title = new Image(centerX, 10, up);
            back = new TextButton(centerX, heightScreen - up.Height - 10, up, down, font, "Back");

            back.select += delegate() { ChangeScreen<MainMenuScreen>(); };
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
            UpdateButton(back);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            title.Draw(batch);
            back.Draw(batch);
            batch.End();
        }
    }
}
