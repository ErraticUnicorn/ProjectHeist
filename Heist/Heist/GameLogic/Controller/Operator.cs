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
        Physics p;

        public Operator()
        {
            human = new InputPlayer(0);
            p = new Physics();
        }

        public void Update(GameTime gameTime, State state)
        {
            List<Dynamic> ent = state.GetAllDynamicEntities();
            human.Process(ent);
            p.Process(ent);
        }

        public void OnEvent(Event e)
        {
            human.OnEvent(e);
        }
    }
}
