using GameLogic.Model;
using GameLogic.Model.Abstract;
using InputListener;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.View
{
    class GUI
    {
        ViewDB db;
        Camera c;

        Renderer r;
        UI ui;

        public GUI(ViewDB db_, Viewport v, SelectionCallback onSelect, EventDispatcher disp)
        {
            db = db_;
            c = new Camera(0, 0, v);

            r = new Renderer(db, c);
            ui = new UI(db, c, onSelect);

            disp.AddListener(r, EventType.View);
            disp.AddListener(ui, EventType.UI);
        }

        public void Update(GameTime gameTime, State state)
        {
            IEnumerable<Entity> entities = state.GetAllEntities();

            r.UpdateAnimation(gameTime, entities);
            ui.Update(gameTime, entities);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch, State state)
        {
            r.Draw(gameTime, batch, state);
        }

        public Point ScreenToWorld(Point point)
        {
            return c.ScreenToWorld(point);
        }
    }
}
