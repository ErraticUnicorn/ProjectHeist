using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Input
{
    class InputInterpreter
    {
        public InputInterpreter()
        {
        }

        public Event Process()
        {
            Event res = null;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                res = new Event(EventType.Action, new Point(0, 0));
            }
            else if (Mouse.GetState().MiddleButton == ButtonState.Pressed)
            {
                res = new Event(EventType.Pan, new Point(0, 0));
            }
            else if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                res = new Event(EventType.Pause, new Point(0, 0));
            }
            else if (Mouse.GetState().ScrollWheelValue == 1)
            {
                res = new Event(EventType.Zoom, new Point(0, 0));
            }
            return res;
        }
    }
}
