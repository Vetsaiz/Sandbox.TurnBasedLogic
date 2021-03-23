using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Server.Static
{
    internal class Internal_ITestStructuresStatic : ITestStructuresStatic 
    {
        public void PostSerialize()
        {
            _Elements?.PostSerialize();
            _DictElements?.PostSerialize();
            _ArrayElements?.PostSerialize();
        }

        #region Interface

        public ITestElementsStatic Elements => _Elements;

        public ITestDictStatic DictElements => _DictElements;

        public ITestArrayStatic ArrayElements => _ArrayElements;


        #endregion

        #region Internal

        [JsonName("elements")]
        public Internal_ITestElementsStatic _Elements;
        [JsonName("dictElements")]
        public Internal_ITestDictStatic _DictElements;
        [JsonName("arrayElements")]
        public Internal_ITestArrayStatic _ArrayElements;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
