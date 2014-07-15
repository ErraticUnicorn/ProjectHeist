using Heist.Display;
using Heist.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    class PreGameScreen : Screen
    {
        TextButton cont;

        public PreGameScreen(int widthScreen, int heightScreen, IScreenMaster master)
            : base(widthScreen, heightScreen, master)
        {
            LevelLoader lvl = LevelLoader.GetCurrentLoader();

            Texture2D up = Load<Texture2D>("Image/buttonUp");
            Texture2D down = Load<Texture2D>("Image/buttonDown");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;
            int centerY = heightScreen / 2 - up.Height / 2;

            cont = new TextButton(centerX, centerY, up, down, font, "Continue to InGame (Level " + lvl.GetId() + ")");

            cont.select += delegate() { ChangeScreen<InGameScreen>(); };
        }

        public override void Update(GameTime gameTime)
        {
            if (cont.Collide(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    cont.SetPressed(true);
                }
                else
                {
                    cont.SetPressed(false);
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            cont.Draw(batch);
            batch.End();
        }
    }
}