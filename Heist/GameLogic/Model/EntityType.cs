using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GameLogic.Model
{
    [DataContract]
    public abstract class EntityType<T> where T : Entity
    {
        public abstract T NewEntity();
    }
}
