using Heist.GameLogic.Controller;
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

        public Level(Texture2D tex)
        {
            state = new State(new Point(100, 100));
            rend = new Renderer(tex);
            op = new Operator();
        }

        public void Update(GameTime gameTime)
        {
            op.Update(gameTime, state);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            rend.Draw(gameTime, batch, state);
        }

    }
}
