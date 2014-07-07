
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
{
    class Physics
    {

        public void Process(IEnumerable<Dynamic> entities)
        {
            foreach (Dynamic e in entities)
            {
                double accel = e.accel;
                e.x = (e.x * (1 - accel) + e.targetX * accel);
                e.y = (e.y * (1 - accel) + e.targetY * accel);
            }
        }
    }
}
