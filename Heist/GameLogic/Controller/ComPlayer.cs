
using GameLogic.Controller.FSM;
using GameLogic.Model;
using GameLogic.Model.Abstract;
using GameLogic.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
{
    class ComPlayer : Player
    {
        FiniteStateMachine test;

        public ComPlayer(int id) : base(id)
        {
            int[] t = new int[]{0, 1, 1, 0};

            test = new FiniteStateMachine(t, 2);
        }

        public override void Process(IEnumerable<Control> entities, State world)
        {
            foreach (Control e in entities)
            {
                Behavior<TestEntity> b = BehaviorFactory.GetTestBehavior(e.state);
                b.React((TestEntity)e, world);

                int input = b.GetInputFromEnvironment((TestEntity)e, world);
                e.state = test.GetNextState(e.state, input);
            }
        }
    }
}
