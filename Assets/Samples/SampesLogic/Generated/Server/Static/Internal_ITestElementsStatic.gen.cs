using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Server.Static
{
    internal class Internal_ITestElementsStatic : ITestElementsStatic 
    {
        public void PostSerialize()
        {
            _Element8?.PostSerialize();
        }

        #region Interface

        public String Element => _Element;

        public Int32 Element1 => _Element1;

        public Int64 Element2 => _Element2;

        public Single Element3 => _Element3;

        public Double Element4 => _Element4;

        public Boolean Element5 => _Element5;

        public SimpleTestData Element6 => _Element6;

        public ComplexTestData Element7 => _Element7;

        public ITestElementStatic Element8 => _Element8;


        #endregion

        #region Internal

        [JsonName("element")]
        public String _Element;
        [JsonName("element1")]
        public Int32 _Element1;
        [JsonName("element2")]
        public Int64 _Element2;
        [JsonName("element3")]
        public Single _Element3;
        [JsonName("element4")]
        public Double _Element4;
        [JsonName("element5")]
        public Boolean _Element5;
        [JsonName("element6")]
        public SimpleTestData _Element6;
        [JsonName("element7")]
        public ComplexTestData _Element7;
        [JsonName("element8")]
        public Internal_ITestElementStatic _Element8;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
