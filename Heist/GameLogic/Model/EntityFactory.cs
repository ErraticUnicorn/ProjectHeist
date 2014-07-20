using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GameLogic.Model
{
    [DataContract]
    public abstract class EntityFactory<T> where T : Entity
    {
        public abstract T NewEntity();
    }
}
