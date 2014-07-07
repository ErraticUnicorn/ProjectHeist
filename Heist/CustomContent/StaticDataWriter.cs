using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Microsoft.Xna.Framework.Content;
using System.Runtime.Serialization.Json;
using GameLogic.Model;

namespace CustomContent
{
    [ContentTypeWriter]
    class StaticDataWriter : ContentTypeWriter<StaticData>
    {
        protected override void Write(ContentWriter output, StaticData value)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(StaticData));
            s.WriteObject(output.BaseStream, value);
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(StaticData).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "Heist.Utils.StaticDataReader, Heist," +
               " Version=1.0.0.0, Culture=neutral";
        }
    }
}
