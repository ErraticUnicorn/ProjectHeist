﻿using Heist.Display;
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
    class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen(int widthScreen, int heightScreen, IScreenMaster master, object[] data) : base(widthScreen, heightScreen, master)
        {
            Texture2D up = Load<Texture2D>("Image/red");
            Texture2D down = Load<Texture2D>("Image/blue");
            SpriteFont font = Load<SpriteFont>("Font/text");

            int centerX = widthScreen / 2 - up.Width / 2;
            int buttonStartY = heightScreen / 3;
            int buttonSpacing = 10;

            title = new Image(centerX, 10, up);
            Button newGame = new TextButton(centerX, buttonStartY, up, down, font, "New Game");
            Button loadGame = new TextButton(centerX, buttonStartY + up.Height + buttonSpacing, up, down, font, "Load Game");
            Button options = new TextButton(centerX, buttonStartY + 2 * (up.Height + buttonSpacing), up, down, font, "Options");

            newGame.select += delegate() { ChangeScreen<StoryScreen>(new object[] {new LevelLoader(1)}); };
            loadGame.select += delegate() { ChangeScreen<LoadGameScreen>(); };
            options.select += delegate() { ChangeScreen<OptionScreen>(); };

            buttons.Add(newGame);
            buttons.Add(loadGame);
            buttons.Add(options);
        }
    }
}
