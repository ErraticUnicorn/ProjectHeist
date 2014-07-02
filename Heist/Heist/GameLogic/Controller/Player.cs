using Heist.GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Controller
{
    abstract class Player
    {
        public int id { get; private set; }

        public Player(int id_)
        {
            id = id_;
        }

        public abstract void Process(IEnumerable<Control> entities);
    }
}
