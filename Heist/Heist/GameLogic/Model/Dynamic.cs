using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Model
{
    abstract class Dynamic : Entity
    {
        public double targetX, targetY;

        public Dynamic(string texName, int id, double x, double y, double targetX_, double targetY_)
            : base(texName, id, x, y)
        {
            targetX = targetX_;
            targetY = targetY_;
        }

        public Dynamic(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {
            targetX = x;
            targetY = y;
        }
    }
}
