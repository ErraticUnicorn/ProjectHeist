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
    class TestScreen : Screen
    {
        private Button tex;

        public TestScreen(int widthScreen, int heightScreen, Texture2D up, Texture2D down)
            : base(widthScreen, heightScreen)
        {
            tex = new Button(100, 100, up, down);
            tex.select += Select;

        }
        public override void Update(GameTime gameTime)
        {
            if (tex.Collide(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    tex.SetPressed(true);
                }
                else
                {
                    tex.SetPressed(false);
                }
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            tex.Draw(batch);
            batch.End();
        }
        private void Select()
        {
            Console.WriteLine("Love");
        }
    }
}
