using Heist.Display;
using Heist.GameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    class InGameScreen : Screen
    {
        Level lvl;

        TextButton win;
        TextButton pause;

        public InGameScreen(int widthScreen, int heightScreen, IScreenMaster master)
            : base(widthScreen, heightScreen, master)
        {
            LevelLoader load = LevelLoader.GetCurrentLoader();
            lvl = load.CreateLevel(Load<Texture2D>("Image/red"));

            Texture2D up = Load<Texture2D>("Image/red");
            Texture2D down = Load<Texture2D>("Image/blue");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;
            int centerY = heightScreen / 2 - up.Height / 2;
            int spacing = 50;

            win = new TextButton(centerX, centerY - spacing, up, down, font, "Next Level");
            pause = new TextButton(centerX, centerY + spacing, up, down, font, "Exit");

            win.select += delegate() { LevelLoader.Load(load.GetId() + 1); ChangeScreen<StoryScreen>(); };
            pause.select += delegate() { ChangeScreen<MainMenuScreen>(); };
        }

        public override void Update(GameTime gameTime)
        {
            if (win.Collide(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    win.SetPressed(true);
                }
                else
                {
                    win.SetPressed(false);
                }
            }
            if (pause.Collide(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    pause.SetPressed(true);
                }
                else
                {
                    pause.SetPressed(false);
                }
            }

            lvl.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();
            win.Draw(batch);
            pause.Draw(batch);
            batch.End();

            lvl.Draw(gameTime, batch);
        }
    }
}