using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model.Abstract
{
    public abstract class Entity
    {
        public string texName;
        public int index;
        public double time;

        public int id;
        public double x, y;
        public int collideX, collideY;

        public Entity()
        {
            texName = "null";
            id = -1;
            x = -1;
            y = -1;
            collideX = -1;
            collideY = -1;
        }

        public abstract Rectangle GetHitBox();
    }
}
