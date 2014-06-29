using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Model
{
    class TestEntity : Dynamic
    {
        public TestEntity(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {
        }
    }
}
