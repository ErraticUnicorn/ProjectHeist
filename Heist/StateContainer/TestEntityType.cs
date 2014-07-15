using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StateContainer
{
    [DataContract]
    public class TestEntityType : EntityType<TestEntity>
    {
        [DataMember]
        private String name;
        [DataMember]
        private String texName;
        [DataMember]
        private double accel;

        public TestEntityType(String name_, String texName_, decimal accel_)
        {
            name = name_;
            texName = texName_;
            accel = (double)accel_;
        }

        public TestEntityType(String name_, String texName_, double accel_)
        {
            name = name_;
            texName = texName_;
            accel = accel_;
        }

        public override TestEntity NewEntity()
        {
            return new TestEntity(texName, 0, 0, 0, accel);
        }
    }
}
