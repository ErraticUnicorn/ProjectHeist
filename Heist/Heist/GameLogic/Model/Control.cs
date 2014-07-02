using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Model
{
    abstract class Control : Dynamic
    {
        public int controller, state;

        public Control(string texName, int id, double x, double y, double accel)
            : base(texName, id, x, y, accel)
        {

        }
    }
}
