
using GameLogic.Model;
using GameLogic.Model.Abstract;
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

        public override void Process(IEnumerable<Control> entities)
        {
            foreach (Control e in entities)
            {
                int input = 0;
                Random rand = new Random();
                        if (rand.NextDouble() < .05)
                        {
                            input = 1;
                        }

                e.state = test.GetNextState(e.state, input);
                Console.WriteLine(e.state);

                switch(e.state)
                {
                    case (0):
                        break;
                    case (1):
                        if (e is Dynamic)
                        {
                            ((Dynamic)e).AppendWayPoint(new WayPoint(rand.NextDouble() * 466.476, rand.NextDouble() * 466.476, ((Dynamic)e).maxSpeed));
                        }
                        break;
                }
            }
        }
    }
}
