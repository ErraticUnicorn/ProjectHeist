using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model.Abstract
{
    public abstract class Control : Entity
    {
        public int state;

        public Control(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {

        }
    }
}
