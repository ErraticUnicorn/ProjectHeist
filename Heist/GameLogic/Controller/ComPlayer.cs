
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
{
    class ComPlayer : Player
    {
        public int state;

        public ComPlayer(int id) : base(id)
        {
        }

        public override void Process(IEnumerable<Control> entities)
        {
            foreach (Control e in entities)
            {
                Random rand = new Random();
                if(rand.NextDouble() < .05)
                {
                    e.wayPoints.Enqueue(new WayPoint(rand.NextDouble() * 800, rand.NextDouble() * 480, e.accel));
                }
            }
        }
    }
}
