using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Model
{
    abstract class Dynamic : Entity
    {
        public double dx, dy;

        public Dynamic(string texName, int id, double x, double y, double dx_, double dy_)
            : base(texName, id, x, y)
        {
            dx = dx_;
            dy = dy_;
        }

        public Dynamic(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {
        }
    }
}
