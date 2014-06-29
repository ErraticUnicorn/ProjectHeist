using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Model
{
    class State
    {
        private List<Entity> list;

        public State()
        {
            list = new List<Entity>();

            list.Add(new TestEntity("red", 0, 100, 100));
            list.Add(new TestEntity("red", 1, 200, 100));
            list.Add(new TestEntity("red", 2, 100, 200));
        }

        public List<Entity> GetAllEntities()
        {
            return list;
        }

        public Entity GetEntityById(int id)
        {
            return list[id];
        }
    }
}
