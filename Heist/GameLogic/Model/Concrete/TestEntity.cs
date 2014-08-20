using GameLogic.Model.Abstract;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model.Concrete
{
    public class TestEntity : Dynamic
    {
        public TestEntity(string texName, int id, double x, double y, double maxSpeed, double accel)
            : base()
        {
            this.texName = texName;
            this.id = id;
            this.x = x;
            this.y = y;
            this.maxSpeed = maxSpeed;
            this.accel = accel;
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle((int)x, (int)y, 32, 64);
        }
    }
}
