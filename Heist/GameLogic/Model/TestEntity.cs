using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    public class TestEntity : Control
    {
        public TestEntity(string texName, int id, double x, double y, double accel)
            : base(texName, id, x, y, accel)
        {
        }
    }
}
