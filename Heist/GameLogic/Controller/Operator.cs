using InputListener;

using GameLogic.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
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
            human.Process(state.GetEntitiesFor(0), state);
            com.Process(state.GetEntitiesFor(1), state);
            p.Process(state.GetDynamicEntities());
        }

        public void OnEvent(Event e)
        {
            human.OnEvent(e);
        }

        public void OnSelect(int id)
        {
            human.OnSelect(id);
        }
    }
}
