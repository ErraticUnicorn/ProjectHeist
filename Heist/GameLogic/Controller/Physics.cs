
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
                if (e.wayPoints.Count > 0)
                {
                    WayPoint w = e.wayPoints.Peek();

                    e.x = (e.x * (1 - w.accel) + w.targetX * w.accel);
                    e.y = (e.y * (1 - w.accel) + w.targetY * w.accel);

                    if (Math.Abs(e.x - w.targetX) < EPSILON || Math.Abs(e.y - w.targetY) < EPSILON)
                    {
                        e.wayPoints.Dequeue();
                    }
                }

            }
        }
    }
}
