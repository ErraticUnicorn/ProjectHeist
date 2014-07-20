using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    public abstract class Entity
    {
        public string texName;
        public int id;
        public double x, y;
        public int collideX, collideY;

        public Entity(string texName_, int id_, double x_, double y_)
        {
            texName = texName_;
            id = id_;
            x = x_;
            y = y_;
            collideX = -1;
            collideY = -1;
        }

        public abstract Rectangle GetHitBox();
    }
}
