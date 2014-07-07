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
        Select = 8,

        View = Zoom | Pan,
        Game = Action | Pause | Select
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
