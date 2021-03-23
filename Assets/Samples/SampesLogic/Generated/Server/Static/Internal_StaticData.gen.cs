using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.StaticData;
using SampesLogic.Shared;

namespace SampesLogic.Server.Static
{
    internal class Internal_StaticData : IStaticData
    {
        [JsonName(" testStatic")] 
        public Internal_ITestStatic _TestStatic;
        public ITestStatic TestStatic => _TestStatic;
        [JsonName(" testStructuresStatic")] 
        public Internal_ITestStructuresStatic _TestStructuresStatic;
        public ITestStructuresStatic TestStructuresStatic => _TestStructuresStatic;

        public Internal_StaticData()
        {
            _TestStatic = new Internal_ITestStatic();
            _TestStructuresStatic = new Internal_ITestStructuresStatic();
        }
        public void PostSerialize()
        {
            _TestStatic.PostSerialize(); 
            _TestStructuresStatic.PostSerialize(); 
        }
    }
}
