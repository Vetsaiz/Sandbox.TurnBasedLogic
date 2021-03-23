using System;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestSubState : ITestSubStateClient, ITestSubState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testSubState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_TestFloat = _TestFloat;
            Interface_TestDouble = new ReactiveProperty<Int64>(_TestDouble);
            Interface_TestData = _TestData;
            Interface_Commands = new ReactiveProperty<String[]>(_Commands);
        }
        public void PreSave()
        {
        }

        #region Interface

        private Single Interface_TestFloat;
        Single ITestSubStateClient.TestFloat => Interface_TestFloat;
        private ReactiveProperty<Int64> Interface_TestDouble;
        IReadOnlyReactiveProperty<Int64> ITestSubStateClient.TestDouble => Interface_TestDouble;
        private SimpleTestData Interface_TestData;
        SimpleTestData ITestSubStateClient.TestData => Interface_TestData;
        private ReactiveProperty<String[]> Interface_Commands;
        IReadOnlyReactiveProperty<String[]> ITestSubStateClient.Commands => Interface_Commands;

        #endregion

        #region Internal

        [JsonName("testFloat")]
        public Single _TestFloat;
        [JsonName("testDouble")]
        public Int64 _TestDouble;
        [JsonName("testData")]
        public SimpleTestData _TestData;
        [JsonName("commands")]
        public String[] _Commands;

        #endregion

        #region Source

        Single ITestSubState.TestFloat
        {
            get => _TestFloat;
        }
        Int64 ITestSubState.TestDouble
        {
            get => _TestDouble;
            set
            {
                _TestDouble = value;
                _storage?.AddChange(this, DataId + $".testDouble.{value.ToString()}", () => Interface_TestDouble.Value = value);
            }
        }
        SimpleTestData ITestSubState.TestData
        {
            get => _TestData;
        }
        String[] ITestSubState.Commands
        {
            get => _Commands;
            set
            {
                _Commands = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".commands.{id}",  () => Interface_Commands.Value = value);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestFloat;
            result += _TestDouble;
            result += _TestData?.ToString();
            result += _Commands != null ? string.Join("", _Commands.Select(x=>x)) : "";
            return result;
        }

        #endregion

    }
}
