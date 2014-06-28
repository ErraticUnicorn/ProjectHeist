using Heist.GameLogic.Controller;
using Heist.GameLogic.Input;
using Heist.GameLogic.Model;
using Heist.GameLogic.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic
{
    class Level
    {
        private State state;
        private Renderer rend;
        private Operator op;

        private EventDispatcher disp;

        public Level(ViewDB db)
        {
            state = new State(new Point(100, 100));
            rend = new Renderer(db);
            op = new Operator();

            disp = new EventDispatcher();

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
