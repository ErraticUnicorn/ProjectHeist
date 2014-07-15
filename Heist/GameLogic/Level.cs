﻿using GameLogic.Controller;
using InputListener;
using GameLogic.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class Level
    {
        private State state;
        private Renderer rend;
        private Operator op;

        private EventDispatcher disp;

        public Level(StaticData sdb, ViewDB vdb)
        {
            state = new State(sdb);
            rend = new Renderer(vdb);
            op = new Operator();

            disp = new EventDispatcher();

            disp.MapInput(InputType.MouseLeft_Up, EventType.Select);
            disp.MapInput(InputType.MouseRight_Up, EventType.Action);

            disp.AddListener(rend, EventType.View);
            disp.AddListener(op, EventType.Game);
        }

        public void Update(GameTime gameTime)
        {
            disp.Process();
            op.Update(gameTime, state);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            rend.Draw(gameTime, batch, state);
        }
    }
}
