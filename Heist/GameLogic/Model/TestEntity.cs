﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    public class TestEntity : Dynamic
    {
        public TestEntity(string texName, int id, double x, double y, double accel)
            : base(texName, id, x, y, accel)
        {
        }

        public override Rectangle GetHitBox()
        {
            return new Rectangle((int)x, (int)y, 64, 64);
        }
    }
}
