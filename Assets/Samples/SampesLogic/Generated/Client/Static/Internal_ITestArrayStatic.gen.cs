using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Client.Static
{
    internal class Internal_ITestArrayStatic : ITestArrayStatic 
    {
        public void PostSerialize()
        {
            if (_ArrayElements3 != null)
            {
                foreach (var temp in _ArrayElements3)
                {
                    temp.PostSerialize();
                }
            }
        }

        #region Interface

        public String[] ArrayElements => _ArrayElements;

        public Int32[] ArrayElements1 => _ArrayElements1;

        public SimpleTestData[] ArrayElements2 => _ArrayElements2;

        public ITestElementStatic[] ArrayElements3 => _ArrayElements3;


        #endregion

        #region Internal

        [JsonName("arrayElements")]
        public String[] _ArrayElements;
        [JsonName("arrayElements1")]
        public Int32[] _ArrayElements1;
        [JsonName("arrayElements2")]
        public SimpleTestData[] _ArrayElements2;
        [JsonName("arrayElements3")]
        public Internal_ITestElementStatic[] _ArrayElements3;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
