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
    public class Level : EventListener
    {
        private State state;
        private Renderer rend;
        private Operator op;

        private EventDispatcher disp;

        public Level(EventListener sysCall, StaticData sdb, ViewDB vdb)
        {
            state = new State(sdb);
            op = new Operator();
            rend = new Renderer(vdb, op.OnSelect);

            disp = new EventDispatcher();

            disp.MapInput(InputType.MouseLeft_Up, EventType.Select);
            disp.MapInput(InputType.MouseRight_Up, EventType.Action);

            disp.MapInput(InputType.RightShift_Down, EventType.Waypoint);
            disp.MapInput(InputType.RightShift_Up, EventType.WaypointOff);
            disp.MapInput(InputType.LeftShift_Down, EventType.Waypoint);
            disp.MapInput(InputType.LeftShift_Up, EventType.WaypointOff);

            disp.MapInput(InputType.Up_Down, EventType.CameraUp);
            disp.MapInput(InputType.Right_Down, EventType.CameraRight);
            disp.MapInput(InputType.Down_Down, EventType.CameraDown);
            disp.MapInput(InputType.Left_Down, EventType.CameraLeft);
            disp.MapInput(InputType.Up_Up, EventType.CameraUpEnd);
            disp.MapInput(InputType.Right_Up, EventType.CameraRightEnd);
            disp.MapInput(InputType.Down_Up, EventType.CameraDownEnd);
            disp.MapInput(InputType.Left_Up, EventType.CameraLeftEnd);

            disp.MapInput(InputType.Escape_Up, EventType.End);

            disp.AddListener(rend, EventType.View);
            disp.AddListener(this, EventType.Game);
            disp.AddListener(sysCall, EventType.System);

        }

        public void Update(GameTime gameTime)
        {
            disp.Process();
            rend.Update(gameTime, state);
            op.Update(gameTime, state);
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            rend.Draw(gameTime, batch, state);
        }

        public void OnEvent(Event e)
        {
            Event newE = new Event(e.Type, rend.ScreenToWorld(e.Location), e.Scroll);
            op.OnEvent(newE);
        }
    }
}
