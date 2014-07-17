
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
{
    class Physics
    {
        private const double EPSILON = 1;

        public void Process(IEnumerable<Dynamic> entities)
        {
            foreach (Dynamic e in entities)
            {
                WayPoint w = e.GetNextPoint();
                if (w != null)
                {
                    e.x = (e.x * (1 - w.speed) + w.targetX * w.speed);
                    e.y = (e.y * (1 - w.speed) + w.targetY * w.speed);

                    if (Math.Abs(e.x - w.targetX) < EPSILON || Math.Abs(e.y - w.targetY) < EPSILON)
                    {
                        e.RemoveNextPoint();
                    }
                }
            }
        }
    }
}
