using InputListener;
using GameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.View
{
    class Renderer : EventListener
    {
        int xPan, yPan;
        ViewDB db;
        Camera c;

        public Renderer(ViewDB db_)
        {
            db = db_;
            c = new Camera(0, 0, new Viewport(0, 0, 640, 400));
            xPan = yPan = 0;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, State state)
        {
            int delta = 10;
            c.Pan(xPan * delta, yPan * delta);

            Matrix m = c.GetTransform();
            IEnumerable<Entity> entities = state.GetAllEntities();

            batch.Begin(0, null, null, null, null, null, m);
            foreach (Entity e in entities)
            {
                Texture2D tex = db.Get(e.texName);
                batch.Draw(tex, new Rectangle((int)e.x, (int)e.y, tex.Width, tex.Height), Color.White);
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

        public Point ScreenToWorld(Point screen)
        {
            return c.ScreenToWorld(screen);
        }
    }
}
