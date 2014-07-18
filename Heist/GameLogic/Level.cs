using GameLogic.Controller;
using InputListener;
using GameLogic.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class Level
    {
        private State state;
        private Renderer rend;
        private Operator op;

        private EventDispatcher disp;

        public Level(EventListener sysCall, StaticData sdb, ViewDB vdb)
        {
            state = new State(sdb);
            rend = new Renderer(vdb);
            op = new Operator();

            disp = new EventDispatcher();

            disp.MapInput(InputType.MouseLeft_Up, EventType.Select);
            disp.MapInput(InputType.MouseRight_Up, EventType.Action);

            disp.MapInput(InputType.RightShift_Down, EventType.Waypoint);
            disp.MapInput(InputType.RightShift_Up, EventType.WaypointOff);
            disp.MapInput(InputType.LeftShift_Down, EventType.Waypoint);
            disp.MapInput(InputType.LeftShift_Up, EventType.WaypointOff);

            disp.MapInput(InputType.Escape_Up, EventType.End);

            disp.AddListener(rend, EventType.View);
            disp.AddListener(op, EventType.Game);
            disp.AddListener(sysCall, EventType.System);
        }

        public void Update(GameTime gameTime)
        {
            disp.Process();
            op.Update(gameTime, state);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            rend.Draw(gameTime, batch, state);
        }
    }
}
