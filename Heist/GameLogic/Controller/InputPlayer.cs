using InputListener;

using GameLogic.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
{
    class InputPlayer : Player
    {
        int sel;

        Point newSel;
        Point p;

        public InputPlayer(int id)
            : base(id)
        {
            sel = -1;

            newSel = new Point(-1, -1);
            p = new Point(-1, -1);
        }

        public override void Process(IEnumerable<Control> entities)
        {
            if (newSel != new Point(-1, -1))
            {
                bool change = false;
                foreach (Dynamic e in entities)
                {
                    e.texName = "red";

                    if (newSel.X - e.x < 64 && newSel.Y - e.y < 64 && newSel.X - e.x > 0 && newSel.Y - e.y > 0)
                    {
                        sel = e.id;
                        e.texName = "blue";
                        change = true;
                    }
                }
                
                if(!change)
                {
                    sel = -1;
                }

                newSel = new Point(-1, -1);
            }

            if (p != new Point(-1, -1))
            {
                foreach (Dynamic e in entities)
                {
                    if (e.id == sel)
                    {
                        e.wayPoints.Enqueue(new WayPoint(p.X, p.Y, e.accel));
                        break;
                    }
                }

                p = new Point(-1, -1);
            }
        }

        public void OnEvent(Event e)
        {
            switch (e.Type)
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
