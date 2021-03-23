using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestComplexState : ITestComplexState 
    {
        private ChangeStorage _storage;
        private string DataId = "testComplexState";
        private TestAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, TestAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _SubSet?.InitData(DataId, storage);
        }
        public void PreSave()
        {
            _SubSet?.PreSave();
        }

        #region Internal

        [JsonName("testString")]
        public String _TestString;
        [JsonName("testInt")]
        public Int32 _TestInt;
        [JsonName("subSet")]
        public Internal_ITestSubState _SubSet;
        [JsonName("testData")]
        public SimpleTestData _TestData;

        #endregion

        #region Source

        String ITestComplexState.TestString
        {
            get => _TestString;
        }
        Int32 ITestComplexState.TestInt
        {
            get => _TestInt;
            set
            {
                _TestInt = value;
                _storage?.AddChange(this, DataId + $".testInt.{value.ToString()}", null);
            }
        }
        ITestSubState ITestComplexState.SubSet
        {
            get => _SubSet;
            set
            {
                var castValue = (Internal_ITestSubState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _SubSet = castValue;
                _storage?.AddChange(this, DataId + $".subSet.{castValue?.ToString()}", null);
            }
        }
        SimpleTestData ITestComplexState.TestData
        {
            get => _TestData;
            set
            {
                _TestData = value;
                _storage?.AddChange(this, DataId + $".testData.{value?.ToString()}", null);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestString;
            result += _TestInt;
            result += _SubSet?.ToString();
            result += _TestData?.ToString();
            return result;
        }

        #endregion

    }
}
