using Heist.GameLogic.Input;
using Heist.GameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.View
{
    class Renderer : EventListener
    {
        ViewDB db;

        public Renderer(ViewDB db_)
        {
            db = db_;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, State state)
        {
            List<Entity> entities = state.GetAllEntities();

            batch.Begin();
            foreach (Entity e in entities)
            {
                Texture2D tex = db.Get(e.texName);
                batch.Draw(tex, new Rectangle((int)e.x, (int)e.y, tex.Width, tex.Height), Color.White);
            }
            batch.End();

        }

        public void OnEvent(Event e)
        {

        }
    }
}
