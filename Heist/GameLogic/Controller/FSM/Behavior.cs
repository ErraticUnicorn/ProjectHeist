using GameLogic.Model;
using GameLogic.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller.FSM
{
    abstract class Behavior<T> where T : Control
    {
        public abstract int GetInputFromEnvironment(T e, State world);

        public abstract void React(T e, State world);
    }
}
