using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace GameLogic.Model.Static
{
    [DataContract]
    public class StaticData
    {
        [DataMember]
        public Dictionary<String, TestEntityFactory> test;

        public StaticData(Dictionary<String, TestEntityFactory> test_)
        {
            test = test_;
        }

        public TestEntityFactory GetTestEntityType(String name)
        {
            return test[name];
        }

    }
}
