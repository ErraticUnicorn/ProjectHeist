using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputListener
{
    [FlagsAttribute]
    public enum EventType
    {
        None = 0,
        Zoom = 1,
        Pan = 2,
        Action = 4,
        Pause = 8,
        Select = 16,
        Waypoint = 32,
        WaypointOff = 64,
        End = 128,
        CameraUp = 256,
        CameraRight = 512,
        CameraDown = 1024,
        CameraLeft = 2048,
        CameraUpEnd = 4096,
        CameraRightEnd = 8192,
        CameraDownEnd = 16384,
        CameraLeftEnd = 32768,

        View = Select | Zoom | Pan | CameraUp | CameraRight | CameraDown | CameraLeft | CameraUpEnd | CameraRightEnd | CameraDownEnd | CameraLeftEnd,
        Game = Action | Pause | Waypoint | WaypointOff,
        System = End
    }

    public class Event
    {
        public EventType Type { get; private set; }
        public Point Location { get; private set; }
        public int Scroll { get; private set; }

        public Event(EventType type_, Point location_, int scroll_)
        {
            Type = type_;
            Location = location_;
            Scroll = scroll_;
        }

    }
}
