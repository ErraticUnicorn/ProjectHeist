
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
                if(rand.NextDouble() < .05 && e is Dynamic)
                {
                    ((Dynamic)e).AppendWayPoint(new WayPoint(rand.NextDouble() * 466.476, rand.NextDouble() * 466.476, ((Dynamic)e).maxSpeed));
                }
            }
        }
    }
}
