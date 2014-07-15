using Microsoft.Xna.Framework.Content;
using GameLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Heist.Utils
{
    class StaticDataReader : ContentTypeReader<StaticData>
    {
        protected override StaticData Read(ContentReader input, StaticData existingInstance)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(StaticData));
            return (StaticData) s.ReadObject(input.BaseStream);
        }
    }
}
