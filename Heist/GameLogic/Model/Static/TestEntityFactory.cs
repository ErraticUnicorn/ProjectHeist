﻿using GameLogic.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GameLogic.Model.Static
{
    [DataContract]
    public class TestEntityFactory : EntityFactory<TestEntity>
    {
        [DataMember]
        private String name;
        [DataMember]
        private String texName;
        [DataMember]
        private double maxSpeed;
        [DataMember]
        private double accel;

        public TestEntityFactory(String name_, String texName_, decimal maxSpeed_, decimal accel_)
        {
            name = name_;
            texName = texName_;
            maxSpeed = (double)maxSpeed_;
            accel = (double)accel_;
        }

        public TestEntityFactory(String name_, String texName_, double maxSpeed_, double accel_)
        {
            name = name_;
            texName = texName_;
            maxSpeed = maxSpeed_;
            accel = accel_;
        }

        public override TestEntity NewEntity()
        {
            return new TestEntity(texName, 0, 0, 0, maxSpeed, accel);
        }
    }
}
