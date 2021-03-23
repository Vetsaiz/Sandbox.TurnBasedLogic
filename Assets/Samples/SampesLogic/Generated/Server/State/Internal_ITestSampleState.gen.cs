using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestSampleState : ITestSampleState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testSampleState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
        }
        public void PreSave()
        {
        }

        #region Internal

        [JsonName("testString")]
        public String _TestString;
        [JsonName("testInt")]
        public Int32 _TestInt;

        #endregion

        #region Source

        String ITestSampleState.TestString
        {
            get => _TestString;
        }
        Int32 ITestSampleState.TestInt
        {
            get => _TestInt;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestString;
            result += _TestInt;
            return result;
        }

        #endregion

    }
}
