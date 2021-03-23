using System;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestSubState : ITestSubState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testSubState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
        }
        public void PreSave()
        {
        }

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
                _storage?.AddChange(this, DataId + $".testDouble.{value.ToString()}", null);
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
                _storage?.AddChange(this, DataId + $".commands.{id}",  null);
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
