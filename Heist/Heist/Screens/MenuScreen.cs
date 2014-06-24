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
    abstract class MenuScreen : Screen
    {
        protected Image title;
        protected List<Button> buttons;

        public MenuScreen(int widthScreen, int heightScreen, IScreenMaster master)
            : base(widthScreen, heightScreen, master)
        {
            buttons = new List<Button>();
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
            foreach(Button button in buttons)
            {
                UpdateButton(button);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            title.Draw(batch);
            foreach(Button button in buttons) 
            {
                button.Draw(batch);
            }
            batch.End();
        }
    }
}
