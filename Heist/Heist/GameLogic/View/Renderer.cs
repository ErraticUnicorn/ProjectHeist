using Heist.GameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.View
{
    class Renderer
    {
        Texture2D tex;

        public Renderer(Texture2D tex_)
        {
            tex = tex_;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, State state)
        {
            batch.Begin();
            batch.Draw(tex, new Rectangle(state.test.X, state.test.Y, tex.Width, tex.Height), Color.White);
            batch.End();
        }
    }
}
