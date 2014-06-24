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
    class PauseScreen : MenuScreen
    {
        public PauseScreen(int widthScreen, int heightScreen, IScreenMaster master, object[] data)
            : base(widthScreen, heightScreen, master)
        {
            Texture2D up = Load<Texture2D>("Image/red");
            Texture2D down = Load<Texture2D>("Image/blue");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;
            int buttonStartY = heightScreen / 3;
            int buttonSpacing = 10;

            title = new Image(centerX, 10, up);
            Button cont = new TextButton(centerX, buttonStartY, up, down, font, "Win");
            Button restart = new TextButton(centerX, buttonStartY + up.Height + buttonSpacing, up, down, font, "Restart");
            Button exit = new TextButton(centerX, buttonStartY + 2 * (up.Height + buttonSpacing), up, down, font, "Exit");

            cont.select += delegate() { ChangeScreen<StoryScreen>(); };
            restart.select += delegate() { ChangeScreen<PreGameScreen>(); };
            exit.select += delegate() { ChangeScreen<MainMenuScreen>(); };

            buttons.Add(cont);
            buttons.Add(restart);
            buttons.Add(exit);
        }
    }
}
