
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

        private void ResolveCollision(Dynamic e1, Dynamic e2)
        {
            Console.WriteLine("Collision: " + e1.id + " and " + e2.id);
        }

        private void DynamicCollisions(IEnumerable<Dynamic> entities)
        {
            List<Dynamic> other = new List<Dynamic>();
            foreach(Dynamic e1 in entities)
            {
                foreach (Dynamic e2 in other)
                {
                    if (e1.GetHitBox().Intersects(e2.GetHitBox()))
                    {
                        ResolveCollision(e1, e2);
                    }
                }

                other.Add(e1);
            }
        }

        public void Process(IEnumerable<Dynamic> entities)
        {
            //DynamicCollisions(entities);

            foreach (Dynamic e in entities)
            {
                WayPoint w = e.GetNextPoint();
                if (w != null)
                {
                    e.x = (e.x * (1 - w.speed) + w.targetX * w.speed);
                    e.y = (e.y * (1 - w.speed) + w.targetY * w.speed);

                    if (Math.Abs(e.x - w.targetX) < EPSILON && Math.Abs(e.y - w.targetY) < EPSILON)
                    {
                        e.RemoveNextPoint();
                    }
                }
            }
        }

    }
}
