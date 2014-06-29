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
        public Operator()
        {
            human = new InputPlayer(0);
        }

        public void Update(GameTime gameTime, State state)
        {
            List<Dynamic> ent = state.GetAllDynamicEntities();
            human.Process(ent);
            foreach(Dynamic e in ent)
            {
                double accel = .025;
                e.x = (e.x * (1 - accel) + e.targetX * accel);
                e.y = (e.y * (1 - accel) + e.targetY * accel);
            }
        }

        public void OnEvent(Event e)
        {
            human.OnEvent(e);
        }
    }
}
