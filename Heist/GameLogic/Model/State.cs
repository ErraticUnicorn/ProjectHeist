using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    class State
    {
        private TestEntityType test;

        private List<Control> player;
        private List<Control> com;

        public State(StaticData sdb)
        {
            player = new List<Control>();
            com = new List<Control>();

            test = sdb.GetTestEntityType("test");

            TestEntity e = test.NewEntity();
            e.id = 0;
            player.Add(e);

            e = test.NewEntity();
            e.id = 1;
            com.Add(e);

            e = test.NewEntity();
            e.id = 2;
            player.Add(e);
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
