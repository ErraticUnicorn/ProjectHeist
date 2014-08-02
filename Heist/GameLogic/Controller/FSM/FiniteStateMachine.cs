using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller.FSM
{
    class FiniteStateMachine
    {
        int numStates;
        int[] mapping;

        public FiniteStateMachine(int[] mapping_, int numStates_)
        {
            numStates = numStates_;
            mapping = mapping_;
        }

        public int GetNextState(int currentState, int input)
        {
            return mapping[input * numStates + currentState];
        }
    }
}
