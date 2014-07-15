using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace GameLogic.Model
{
    [DataContract]
    public class StaticData
    {
        [DataMember]
        public Dictionary<String, TestEntityType> test;

        public StaticData(Dictionary<String, TestEntityType> test_)
        {
            test = test_;
        }

        public TestEntityType GetTestEntityType(String name)
        {
            return test[name];
        }

    }
}
