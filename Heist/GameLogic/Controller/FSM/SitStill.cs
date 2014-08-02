using GameLogic.Model;
using GameLogic.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller.FSM
{
    class SitStill : Behavior<TestEntity>
    {
        public override int GetInputFromEnvironment(TestEntity e, State world)
        {
            int input = 0;
            Random rand = new Random();
            if (rand.NextDouble() < .05)
            {
                input = 1;
            }

            return input;
        }

        public override void React(TestEntity e, State world)
        {
        }
    }
}
