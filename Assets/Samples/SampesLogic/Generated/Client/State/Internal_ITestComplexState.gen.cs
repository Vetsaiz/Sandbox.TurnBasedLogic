using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using UniRx;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestComplexState : ITestComplexStateClient, ITestComplexState 
    {
        private ChangeStorage _storage;
        private string DataId = "testComplexState";
        private TestAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, TestAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_TestString = _TestString;
            Interface_TestInt = new ReactiveProperty<Int32>(_TestInt);
            _SubSet?.InitData(DataId, storage);
            Interface_SubSet = new ReactiveProperty<ITestSubStateClient>(_SubSet);
            Interface_TestData = new ReactiveProperty<SimpleTestData>(_TestData);
        }
        public void PreSave()
        {
            _SubSet?.PreSave();
        }

        #region Queries

        public SimpleTestData GetData()
        {
            return _accessor.GetData();
        }
        public SimpleTestData GetStrData(System.String testStr)
        {
            return _accessor.GetStrData(testStr);
        }
        public Int32 TestIntStatic => _accessor.TestInt;

        #endregion

        #region Interface

        private String Interface_TestString;
        String ITestComplexStateClient.TestString => Interface_TestString;
        private ReactiveProperty<Int32> Interface_TestInt;
        IReadOnlyReactiveProperty<Int32> ITestComplexStateClient.TestInt => Interface_TestInt;
        private ReactiveProperty<ITestSubStateClient> Interface_SubSet;
        IReadOnlyReactiveProperty<ITestSubStateClient> ITestComplexStateClient.SubSet => Interface_SubSet;
        private ReactiveProperty<SimpleTestData> Interface_TestData;
        IReadOnlyReactiveProperty<SimpleTestData> ITestComplexStateClient.TestData => Interface_TestData;

        #endregion

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
                _storage?.AddChange(this, DataId + $".testInt.{value.ToString()}", () => Interface_TestInt.Value = value);
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
                _storage?.AddChange(this, DataId + $".subSet.{castValue?.ToString()}", () => Interface_SubSet.Value = castValue);
            }
        }
        SimpleTestData ITestComplexState.TestData
        {
            get => _TestData;
            set
            {
                _TestData = value;
                _storage?.AddChange(this, DataId + $".testData.{value?.ToString()}", () => Interface_TestData.Value = value);
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
