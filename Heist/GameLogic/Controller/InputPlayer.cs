﻿using InputListener;

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
        int oldSel;

        bool waypoint;
        Point p;

        public InputPlayer(int id)
            : base(id)
        {
            sel = -1;
            oldSel = -1;

            p = new Point(-1, -1);
            waypoint = false;
        }

        private void applyAction(IEnumerable<Control> entities)
        {
            foreach (Control e in entities)
            {
                if (e.id == sel && e is Dynamic)
                {
                    Dynamic d = (Dynamic)e;
                    WayPoint w = new WayPoint(p.X, p.Y, d.maxSpeed);

                    if (waypoint)
                    {
                        d.AppendWayPoint(w);
                    }
                    else
                    {
                        d.SetWayPoint(w);
                    }
                    break;
                }
            }

        }

        public override void Process(IEnumerable<Control> entities)
        {
            if (sel != oldSel)
            {
                foreach (Entity e in entities)
                {
                    if (e.id == sel)
                    {
                        e.texName = "blue";
                    }
                    else if (e.id == oldSel)
                    {
                        e.texName = "red";
                    }
                }
                oldSel = sel;
            }

            if (p != new Point(-1, -1))
            {
                applyAction(entities);
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
                case EventType.Waypoint:
                    waypoint = true;
                    break;
                case EventType.WaypointOff:
                    waypoint = false;
                    break;
            }
        }

        public void OnSelect(int id)
        {
            oldSel = sel;
            sel = id;
        }
    }
}
