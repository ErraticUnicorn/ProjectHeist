using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateContainer
{
    public abstract class Entity
    {
        public string texName;
        public int id;
        public double x, y;

        public Entity(string texName_, int id_, double x_, double y_)
        {
            texName = texName_;
            id = id_;
            x = x_;
            y = y_;
        }

    }
}
