using Heist.GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Controller
{
    class Physics
    {

        public void Process(List<Dynamic> entities)
        {
            foreach (Dynamic e in entities)
            {
                double accel = .025;
                e.x = (e.x * (1 - accel) + e.targetX * accel);
                e.y = (e.y * (1 - accel) + e.targetY * accel);
            }
        }
    }
}
