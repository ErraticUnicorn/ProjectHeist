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
        private List<Control> player;
        private List<Control> com;

        public State()
        {
            player = new List<Control>();
            com = new List<Control>();

            player.Add(new TestEntity("red", 0, 100, 100, .005));
            com.Add(new TestEntity("red", 1, 200, 100, .005));
            player.Add(new TestEntity("red", 2, 100, 200, .005));
        }

        public IEnumerable<Entity> GetAllEntities()
        {
            return player.Union<Control>(com);
        }

        public IEnumerable<Dynamic> GetDynamicEntities()
        {
            return player.Union<Dynamic>(com);
        }

        public IEnumerable<Control> GetEntitiesFor(int controller)
        {
            return (controller == 0) ? player : com;
        }
    }
}
