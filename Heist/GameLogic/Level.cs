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
    public class EventType
    {
        public const int None = 0;
        public const int Zoom = 1;
        public const int Pan = 2;
        public const int Action = 4;
        public const int Pause = 8;
        public const int Select = 16;
        public const int Waypoint = 32;
        public const int WaypointOff = 64;
        public const int End = 128;
        public const int CameraUp = 256;
        public const int CameraRight = 512;
        public const int CameraDown = 1024;
        public const int CameraLeft = 2048;
        public const int CameraUpEnd = 4096;
        public const int CameraRightEnd = 8192;
        public const int CameraDownEnd = 16384;
        public const int CameraLeftEnd = 32768;

        public const int View = Select | Zoom | Pan | CameraUp | CameraRight | CameraDown | CameraLeft | CameraUpEnd | CameraRightEnd | CameraDownEnd | CameraLeftEnd;
        public const int Game = Action | Pause | Waypoint | WaypointOff;
        public const int System = End;
    }

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
