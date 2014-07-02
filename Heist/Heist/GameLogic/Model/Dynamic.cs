using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Model
{
    abstract class Dynamic : Entity
    {
        public double accel, targetX, targetY;

        public Dynamic(string texName, int id, double x, double y, double accel_, double targetX_, double targetY_)
            : base(texName, id, x, y)
        {
            accel = accel_;
            targetX = targetX_;
            targetY = targetY_;
        }

        public Dynamic(string texName, int id, double x, double y, double accel_)
            : base(texName, id, x, y)
        {
            accel = accel_;
            targetX = x;
            targetY = y;
        }

        public Dynamic(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {
            accel = 0;
            targetX = x;
            targetY = y;
        }
    }
}
