using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameLogic.Model.Abstract;
using InputListener;

namespace GameLogic.View
{
    public delegate void SelectionCallback(int sel);

    class UI : EventListener
    {
        ViewDB db;
        Camera c;

        Point newSel;
        SelectionCallback onSelect;

        public UI(ViewDB db_, Camera c_, SelectionCallback onSelect_)
        {
            db = db_;
            c = c_;

            newSel = new Point(-1, -1);

            onSelect = onSelect_;
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

                Vector2 p = c.GetRenderPosition(new Point((int)e.x, (int)e.y), new Vector2(width, height));
                Rectangle r = new Rectangle((int)p.X, (int)p.Y, width, height);

                if (r.Contains(newSel))
                {
                    sel = e.id;
                }
            }

            onSelect(sel);
        }

        public void Update(GameTime gameTime, IEnumerable<Entity> entities)
        {
            if (newSel != new Point(-1, -1))
            {
                ChangeSelection(entities);
                newSel = new Point(-1, -1);
            }

        }

        public void OnEvent(Event e)
        {
            switch (e.Type)
            {
                case EventType.Select:
                    newSel = e.Location;
                    break;
            }
        }

    }
}
