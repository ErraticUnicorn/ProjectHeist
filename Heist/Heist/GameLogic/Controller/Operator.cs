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
        int time;

        public Operator()
        {
            time = 0;
        }

        public void Update(GameTime gameTime, State state)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            if (time > 1000)
            {
                time = 0;
                Random rand = new Random();
                state.test = new Point(rand.Next(100, 200), rand.Next(100, 200));
            }
        }

        public void OnEvent(Event e)
        {

        }
    }
}
