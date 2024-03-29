﻿using Heist;
using Heist.Display;
using Heist.Utils;
using GameLogic;
using GameLogic.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Model;
using Heist.Screens.Abstract;
using InputListener;

namespace Heist.Screens.Concrete
{
    class InGameScreen : Screen, EventListener
    {
        Level lvl;

        public InGameScreen(int widthScreen, int heightScreen, IScreenMaster master)
            : base(widthScreen, heightScreen, master)
        {
            LevelLoader load = LevelLoader.GetCurrentLoader();

            lvl = load.CreateLevel(this);
        }

        public override void Update(GameTime gameTime)
        {
            lvl.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            lvl.Draw(gameTime, batch);
        }

        public void OnEvent(Event e)
        {
            switch(e.Type)
            {
                case EventType.End: 
                    ChangeScreen<MainMenuScreen>();
                    break;
            }
        }
    }
}