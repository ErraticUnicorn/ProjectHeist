using Heist.GameLogic.Input;
using Heist.GameLogic.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Controller
{
    class Operator : EventListener
    {
        int sel;

        Point newSel;
        Point p;

        public Operator()
        {
            sel = -1;
            newSel = new Point(-1, -1);
            p = new Point(-1, -1);
        }

        public void Update(GameTime gameTime, State state)
        {
            if(newSel != new Point(-1, -1))
            {
                foreach (Entity e in state.GetAllEntities())
                {
                    if (newSel.X - e.x < 64 && newSel.Y - e.y < 64 && newSel.X - e.x > 0 && newSel.Y - e.y > 0)
                    {
                        if (sel != -1)
                        {
                            state.GetEntityById(sel).texName = "red";
                        }
                        sel = e.id;
                        e.texName = "blue";
                        p = new Point((int) e.x, (int) e.y);
                        break;
                    }
                }
                newSel = new Point(-1, -1);
            }

            if (sel != -1)
            {
                Entity player = state.GetEntityById(sel);
                double accel = .025;
                player.x = (player.x * (1 - accel) + p.X * accel);
                player.y = (player.y * (1 - accel) + p.Y * accel);
            }
        }

        public void OnEvent(Event e)
        {
            switch(e.Type)
            {
                case EventType.Action:
                    p = e.Location;
                    break;
                case EventType.Select:
                    newSel = e.Location;
                    break;
            }
        }
    }
}
