using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputListener
{
    public class Event
    {
        public int Type { get; private set; }
        public Point Location { get; private set; }
        public int Scroll { get; private set; }

        public Event(int type_, Point location_, int scroll_)
        {
            Type = type_;
            Location = location_;
            Scroll = scroll_;
        }

    }
}
