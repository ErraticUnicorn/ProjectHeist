using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic
{
    class LevelLoader
    {
        private int id;

        private static LevelLoader current;
        
        private LevelLoader()
        {
        }

        private LevelLoader(int id_)
        {
            id = id_;
        }

        public static bool Load(int id)
        {
            current = new LevelLoader(id);

            return true;
        }

        public static LevelLoader GetCurrentLoader()
        {
            if (current == null)
            {
                throw new InvalidOperationException("LevelLoader instance cannot be accessed before Load(id) is called.");
            }

            return current;
        }
        
        public int GetId()
        {
            return id;
        }
    }
}
