using System;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;

namespace MetaTests.Client.Core
{

    public class TestSerializator : ISerializator
    {
        public string Serialize(object obj)
        {
            return JsonWriter.Serialize(obj);
        }

        public T Deserialize<T>(string serialize) where T : class
        {
            return JsonReader.Deserialize<T>(serialize);
        }

        public object Deserialize(string data, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
