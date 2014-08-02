using GameLogic.Controller.FSM;
using GameLogic.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller.FSM
{
    static class BehaviorFactory
    {
        public static Behavior<TestEntity> GetTestBehavior(int number)
        {
            switch (number)
            {
                case (0):
                    return new SitStill();
                case (1):
                    return new RandomWalk();
            }

            return null;
        }
    }
}