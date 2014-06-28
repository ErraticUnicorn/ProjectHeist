using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Input
{
    interface EventListener
    {
        void OnEvent(Event e);
    }
}
