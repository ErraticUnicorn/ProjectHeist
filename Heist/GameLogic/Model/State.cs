using GameLogic.Model.Abstract;
using GameLogic.Model.Concrete;
using GameLogic.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    class State
    {
        private int maxId;
        private StaticData db;

        private List<Control> player;
        private List<Control> com;

        public State(StaticData sdb)
        {
            player = new List<Control>();
            com = new List<Control>();
            maxId = 0;

            db = sdb;

            AddEntity<TestEntity>(0, "test", 368, 208);
            AddEntity<TestEntity>(1, "test", 300, 100);

            AddEntity<TestEntity>(0, "test", 0, 0);
            AddEntity<TestEntity>(0, "test", 570, 0);
            AddEntity<TestEntity>(0, "test", 0, 570);
            AddEntity<TestEntity>(0, "test", 570, 570);
        }

        public int AddEntity<T>(int controller, String type, double x, double y)
        {
            TestEntity e = db.GetTestEntityType(type).NewEntity();
            e.id = maxId;
            maxId++;

            e.x = x;
            e.y = y;

            if (controller == 0)
            {
                player.Add(e);
            }
            else
            {
                com.Add(e);
            }

            return e.id;
        }

        public void RemoveEntity(int controller, int id)
        {
            if (controller == 0)
            {
                player.RemoveAt(id);
            }
            else
            {
                com.RemoveAt(id);
            }
        }

        public IEnumerable<Entity> GetAllEntities()
        {
            return player.Union<Control>(com);
        }

        public IEnumerable<Dynamic> GetDynamicEntities()
        {
            List<Dynamic> res = new List<Dynamic>();
            var all = GetAllEntities();
            foreach(Entity e in all) {
                if (e is Dynamic)
                {
                    res.Add((Dynamic) e);
                }
            }
            
            return res;
        }

        public IEnumerable<Control> GetEntitiesFor(int controller)
        {
            return (controller == 0) ? player : com;
        }
    }
}
