using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Client.Static
{
    internal class Internal_ITestDictStatic : ITestDictStatic 
    {
        public void PostSerialize()
        {
            ROD_DictElements2 = _DictElements2 != null ? _DictElements2.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_DictElements3 = _DictElements3 != null ? _DictElements3.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ITestElementStatic;
            }
            ) : null;
            ROD_DictElements7 = _DictElements7 != null ? _DictElements7.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y => 
            {
                var array = new ITestElementStatic[y.Value.Values.Length];
                for (var i = 0; i < y.Value.Values.Length; i++)
                {
                     y.Value.Values[i].PostSerialize();
                     array[i] = y.Value.Values[i];
                }
                return array;
            }
            ) : null;
        }

        #region Interface

        public IReadOnlyDictionary<String, String> DictElements => _DictElements;

        public IReadOnlyDictionary<String, Int32> DictElements1 => _DictElements1;

        public  IReadOnlyDictionary<Int32, String> DictElements2 => ROD_DictElements2;

        public  IReadOnlyDictionary<Int32, ITestElementStatic> DictElements3 => ROD_DictElements3;

        public  IReadOnlyDictionary<Int32, SimpleTestData> DictElements4 => ROD_DictElements4;

        public IReadOnlyDictionary<Int32, ITestElementStatic[]> DictElements7 => ROD_DictElements7;


        #endregion

        #region Internal

        [JsonName("dictElements")]
        public Dictionary<String, String> _DictElements;
        [JsonName("dictElements1")]
        public Dictionary<String, Int32> _DictElements1;
        [JsonName("dictElements2")]
        public Dictionary<String, String> _DictElements2;
        private Dictionary<Int32, String> ROD_DictElements2;
        [JsonName("dictElements3")]
        public Dictionary<String, Internal_ITestElementStatic> _DictElements3;
        private Dictionary<Int32, ITestElementStatic> ROD_DictElements3;
        [JsonName("dictElements4")]
        public Dictionary<String, SimpleTestData> _DictElements4;
        private Dictionary<Int32, SimpleTestData> ROD_DictElements4;
        [JsonName("dictElements7")]
        public Dictionary<String, DictElements7_Array> _DictElements7;
        private Dictionary<Int32, ITestElementStatic[]> ROD_DictElements7;

        #endregion
        #region AdittionalClasses

        internal class DictElements7_Array
        {
            [JsonName("values")]
             public Internal_ITestElementStatic[] Values;
        }

        #endregion

    }
}
