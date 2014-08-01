
using GameLogic.Model;
using GameLogic.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Controller
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
