using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic
{
    class LevelLoader
    {
        private int id;

        public LevelLoader(int id_)
        {
            id = id_;
        }

        public int getId()
        {
            return id;
        }
    }
}
