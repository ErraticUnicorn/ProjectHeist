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
    class TestScreenTwo : Screen
    {
        private Button tex;

        public TestScreenTwo(int widthScreen, int heightScreen, IScreenMaster c)
            : base(widthScreen, heightScreen, c)
        {
            tex = new TextButton(100, 100, Load<Texture2D>("Image/red"), Load<Texture2D>("Image/blue"), Load<SpriteFont>("Font/text"), "Hate");
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
            ChangeScreen<TestScreen>();
        }
    }
}
