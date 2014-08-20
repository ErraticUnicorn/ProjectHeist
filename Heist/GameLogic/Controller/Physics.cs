
using GameLogic.Model;
using GameLogic.Model.Abstract;
using Microsoft.Xna.Framework;
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

        public void Process(IEnumerable<Dynamic> entities, GameTime gameTime)
        {
            //DynamicCollisions(entities);

            foreach (Dynamic e in entities)
            {
                WayPoint w = e.GetNextPoint();
                if (w != null)
                {
                    double distSquared = (w.targetX - e.x) * (w.targetX - e.x) + (w.targetY - e.y) * (w.targetY - e.y);

                    if(e.xDir == 0 && e.yDir == 0)
                    {
                        double dist = Math.Sqrt((w.targetX - e.x) * (w.targetX - e.x) + (w.targetY - e.y) * (w.targetY - e.y));
                        e.xDir = (w.targetX - e.x) / dist;
                        e.yDir = (w.targetY - e.y) / dist;
                    }

                    if (distSquared * e.accel < e.speed)
                    {
                        e.speed = e.speed * (1 - e.accel);
                    }
                    else
                    {
                        e.speed = e.speed * (1 - e.accel) + w.speed * e.accel;
                    }

                    e.x += e.speed * e.xDir * gameTime.ElapsedGameTime.TotalSeconds;
                    e.y += e.speed * e.yDir * gameTime.ElapsedGameTime.TotalSeconds;

                    if (distSquared < EPSILON * EPSILON)
                    {
                        e.RemoveNextPoint();
                    }
                }
            }
        }

    }
}
