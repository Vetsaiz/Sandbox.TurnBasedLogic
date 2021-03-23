using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestElementsState : ITestElementsState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testElementsState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _Element8?.InitData(DataId, storage);
        }
        public void PreSave()
        {
            _Element8?.PreSave();
        }

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
        public TestEnum _Element7;
        [JsonName("element8")]
        public Internal_ITestSampleState _Element8;

        #endregion

        #region Source

        String ITestElementsState.Element
        {
            get => _Element;
            set
            {
                _Element = value;
                _storage?.AddChange(this, DataId + $".element.{value}", null);
            }
        }
        Int32 ITestElementsState.Element1
        {
            get => _Element1;
            set
            {
                _Element1 = value;
                _storage?.AddChange(this, DataId + $".element1.{value.ToString()}", null);
            }
        }
        Int64 ITestElementsState.Element2
        {
            get => _Element2;
            set
            {
                _Element2 = value;
                _storage?.AddChange(this, DataId + $".element2.{value.ToString()}", null);
            }
        }
        Single ITestElementsState.Element3
        {
            get => _Element3;
            set
            {
                _Element3 = value;
                _storage?.AddChange(this, DataId + $".element3.{value.ToString()}", null);
            }
        }
        Double ITestElementsState.Element4
        {
            get => _Element4;
            set
            {
                _Element4 = value;
                _storage?.AddChange(this, DataId + $".element4.{value.ToString()}", null);
            }
        }
        Boolean ITestElementsState.Element5
        {
            get => _Element5;
            set
            {
                _Element5 = value;
                _storage?.AddChange(this, DataId + $".element5.{value.ToString()}", null);
            }
        }
        SimpleTestData ITestElementsState.Element6
        {
            get => _Element6;
            set
            {
                _Element6 = value;
                _storage?.AddChange(this, DataId + $".element6.{value?.ToString()}", null);
            }
        }
        TestEnum ITestElementsState.Element7
        {
            get => _Element7;
            set
            {
                _Element7 = value;
                _storage?.AddChange(this, DataId + $".element7.{value.ToString()}", null);
            }
        }
        ITestSampleState ITestElementsState.Element8
        {
            get => _Element8;
            set
            {
                var castValue = (Internal_ITestSampleState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _Element8 = castValue;
                _storage?.AddChange(this, DataId + $".element8.{castValue?.ToString()}", null);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Element;
            result += _Element1;
            result += _Element2;
            result += _Element3;
            result += _Element4;
            result += _Element5;
            result += _Element6?.ToString();
            result += _Element7;
            result += _Element8?.ToString();
            return result;
        }

        #endregion

    }
}
