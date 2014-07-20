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
    delegate void SelectionCallback(int sel);

    class Renderer : EventListener
    {
        Point newSel;

        int xPan, yPan;
        ViewDB db;
        Camera c;
        SelectionCallback onSelect;

        public Renderer(ViewDB db_, SelectionCallback onSelect_)
        {
            newSel = new Point(-1, -1);

            db = db_;
            c = new Camera(0, 0, new Viewport(0, 0, 800, 480));
            xPan = yPan = 0;

            onSelect = onSelect_;
        }

        private void ChangeSelection(IEnumerable<Entity> entities)
        {
            int sel = -1;
            foreach (Entity e in entities)
            {
                Texture2D tex = db.Get(e.texName);
                Point p = c.WorldToScreen(new Point((int)e.x, (int)e.y));
                if (newSel.X - p.X < tex.Height && newSel.Y - p.Y < tex.Width && newSel.X - p.X > 0 && newSel.Y - p.Y > 0)
                {
                    sel = e.id;
                }
            }

            onSelect(sel);
        }

        public void Update(GameTime gameTime, State state)
        {
            if (newSel != new Point(-1, -1))
            {
                IEnumerable<Entity> entities = state.GetAllEntities();
                ChangeSelection(entities);
                newSel = new Point(-1, -1);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, State state)
        {

            int delta = 10;
            c.Pan(xPan * delta, yPan * delta);

            IEnumerable<Entity> entities = state.GetAllEntities();

            batch.Begin();
            Texture2D bg = db.Get("bg");
            batch.Draw(bg, new Rectangle(0, 0, bg.Width, bg.Height), Color.White);
            foreach (Entity e in entities)
            {
                Texture2D tex = db.Get(e.texName);
                Point p = c.WorldToScreen(new Point((int)e.x, (int)e.y));
                batch.Draw(tex, new Rectangle(p.X, p.Y, tex.Width, tex.Height), Color.White);
            }
            batch.End();

        }

        public void OnEvent(Event e)
        {
            switch (e.Type)
            {
                case EventType.Select:
                    newSel = e.Location;
                    break;
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
