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
    class OptionScreen : MenuScreen
    {
        public OptionScreen(int widthScreen, int heightScreen, IScreenMaster master, object[] data)
            : base(widthScreen, heightScreen, master)
        {
            Texture2D up = Load<Texture2D>("Image/red");
            Texture2D down = Load<Texture2D>("Image/blue");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;

            title = new Image(centerX, 10, up);
            Button back = new TextButton(centerX, heightScreen - up.Height - 10, up, down, font, "Back");

            back.select += delegate() { ChangeScreen<MainMenuScreen>(); };

            buttons.Add(back);
        }

    }
}
