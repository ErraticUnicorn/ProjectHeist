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
    delegate void SelectionCallback(int sel);

    class Renderer : EventListener
    {
        Point newSel;

        int xPan, yPan;
        ViewDB db;
        Camera c;
        SelectionCallback onSelect;

        public Renderer(ViewDB db_, Viewport view, SelectionCallback onSelect_)
        {
            newSel = new Point(-1, -1);

            db = db_;
            c = new Camera(0, 0, view);
            xPan = yPan = 0;

            onSelect = onSelect_;
        }

        private Rectangle GetRenderBox(Entity e, int width, int height)
        {
            Point p = c.WorldToScreen(new Point((int)e.x, (int)e.y));
            return new Rectangle(p.X - width / 2, p.Y - height, width, height);
        }

        private void ChangeSelection(IEnumerable<Entity> entities)
        {
            int sel = -1;
            foreach (Entity e in entities)
            {
                int width = 0;
                int height = 0;
                
                AnimatedTexture2D anim = db.GetAnimation(e.texName);
                if (anim == null)
                {
                    Texture2D tex = db.Get(e.texName);
                    width = tex.Width;
                    height = tex.Height;
                }
                else
                {
                    Rectangle rect = anim.GetWindow(e.index);
                    width = rect.Width;
                    height = rect.Height;
                }

                Rectangle r = GetRenderBox(e, width, height);
                if (r.Contains(newSel))
                {
                    sel = e.id;
                }
            }

            onSelect(sel);
        }

        public void Update(GameTime gameTime, State state)
        {
            IEnumerable<Entity> entities = state.GetAllEntities();

            if (newSel != new Point(-1, -1))
            {
                ChangeSelection(entities);
                newSel = new Point(-1, -1);
            }

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

            batch.Begin();
            Texture2D bg = db.Get("bg");
            batch.Draw(bg, new Rectangle(0, 0, bg.Width, bg.Height), Color.White);
            foreach (Entity e in entities)
            {
                AnimatedTexture2D anim = db.GetAnimation(e.texName);
                if (anim == null)
                {
                    Texture2D tex = db.Get(e.texName);
                    batch.Draw(tex, GetRenderBox(e, tex.Width, tex.Height), Color.White);
                }
                else
                {
                    Texture2D tex = anim.GetSheet();
                    Rectangle p = GetRenderBox(e, anim.GetWidth(), anim.GetHeight());
                    batch.Draw(tex, new Vector2(p.X, p.Y), anim.GetWindow(e.index), Color.White, 0.0f, 
                        Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                }
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
