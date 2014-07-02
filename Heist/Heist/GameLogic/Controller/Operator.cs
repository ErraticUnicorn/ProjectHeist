using Heist.GameLogic.Input;
using Heist.GameLogic.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Controller
{
    class Operator : EventListener
    {
        InputPlayer human;
        ComPlayer com;

        Physics p;

        public Operator()
        {
            human = new InputPlayer(0);
            com = new ComPlayer(1);

            p = new Physics();
        }

        public void Update(GameTime gameTime, State state)
        {
            human.Process(state.GetEntitiesFor(0));
            com.Process(state.GetEntitiesFor(1));
            p.Process(state.GetDynamicEntities());
        }

        public void OnEvent(Event e)
        {
            human.OnEvent(e);
        }
    }
}
