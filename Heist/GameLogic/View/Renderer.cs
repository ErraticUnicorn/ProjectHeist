using InputListener;
using GameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Model.Abstract;

namespace GameLogic.View
{
    class Renderer : EventListener
    {
        int xPan, yPan;
        ViewDB db;
        Camera c;

        public Renderer(ViewDB db_, Camera c_)
        {
            db = db_;
            c = c_;
            xPan = yPan = 0;
        }

        public void UpdateAnimation(GameTime gameTime, IEnumerable<Entity> entities)
        {
            foreach (Entity e in entities)
            {
                AnimatedTexture2D anim = db.GetAnimation(e.texName);
                if (anim != null)
                {
                    anim.UpdateTime(gameTime, e);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, State state)
        {
            int delta = 10;
            c.Pan(xPan * delta, yPan * delta);

            IEnumerable<Entity> entities = state.GetAllEntities();

            batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            foreach (Entity e in entities)
            {
                Point pos = new Point((int)e.x, (int)e.y);
                AnimatedTexture2D anim = db.GetAnimation(e.texName);

                Texture2D tex;
                Vector2 size;
                Rectangle source;
                if (anim == null)
                {
                    tex = db.Get(e.texName);
                    size = new Vector2(tex.Width, tex.Height);
                    source = new Rectangle(0, 0, tex.Width, tex.Height);
                }
                else
                {
                    tex = anim.GetSheet();
                    size = new Vector2(anim.GetWidth(), anim.GetHeight());
                    source = anim.GetWindow(e.index);
                }

                batch.Draw(tex, c.GetRenderPosition(pos, size), source, Color.White, 0.0f,
                    Vector2.Zero, 1.0f, SpriteEffects.None, (float)(e.x + e.y + .0001f) / 1200);
            }

            batch.End();

        }

        public void OnEvent(Event e)
        {
            switch (e.Type)
            {
                case EventType.CameraUp:
                    yPan = 1;
                    break;
                case EventType.CameraRight:
                    xPan = -1;
                    break;
                case EventType.CameraDown:
                    yPan = -1;
                    break;
                case EventType.CameraLeft:
                    xPan = 1;
                    break;
                case EventType.CameraUpEnd:
                    yPan = 0;
                    break;
                case EventType.CameraRightEnd:
                    xPan = 0;
                    break;
                case EventType.CameraDownEnd:
                    yPan = 0;
                    break;
                case EventType.CameraLeftEnd:
                    xPan = 0;
                    break;
            }
        }

    }
}
