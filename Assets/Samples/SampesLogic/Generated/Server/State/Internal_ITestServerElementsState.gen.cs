using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestServerElementsState : ITestServerElementsState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testServerElementsState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
        }
        public void PreSave()
        {
        }

        #region Internal

        [JsonIgnore]
        [JsonName("serverElement")]
        public String _ServerElement;
        [JsonIgnore]
        [JsonName("serverElement1")]
        public Int32 _ServerElement1;
        [JsonIgnore]
        [JsonName("serverElement2")]
        public Int64 _ServerElement2;
        [JsonIgnore]
        [JsonName("serverElement3")]
        public Single _ServerElement3;
        [JsonIgnore]
        [JsonName("serverElement4")]
        public Double _ServerElement4;
        [JsonIgnore]
        [JsonName("serverElement5")]
        public Boolean _ServerElement5;
        [JsonIgnore]
        [JsonName("serverElement6")]
        public SimpleTestData _ServerElement6;
        [JsonIgnore]
        [JsonName("serverElement7")]
        public TestEnum _ServerElement7;

        #endregion

        #region Source

        String ITestServerElementsState.ServerElement
        {
            get => _ServerElement;
            set => _ServerElement = value;
        }
        Int32 ITestServerElementsState.ServerElement1
        {
            get => _ServerElement1;
            set => _ServerElement1 = value;
        }
        Int64 ITestServerElementsState.ServerElement2
        {
            get => _ServerElement2;
            set => _ServerElement2 = value;
        }
        Single ITestServerElementsState.ServerElement3
        {
            get => _ServerElement3;
            set => _ServerElement3 = value;
        }
        Double ITestServerElementsState.ServerElement4
        {
            get => _ServerElement4;
            set => _ServerElement4 = value;
        }
        Boolean ITestServerElementsState.ServerElement5
        {
            get => _ServerElement5;
            set => _ServerElement5 = value;
        }
        SimpleTestData ITestServerElementsState.ServerElement6
        {
            get => _ServerElement6;
            set => _ServerElement6 = value;
        }
        TestEnum ITestServerElementsState.ServerElement7
        {
            get => _ServerElement7;
            set => _ServerElement7 = value;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _ServerElement;
            result += _ServerElement1;
            result += _ServerElement2;
            result += _ServerElement3;
            result += _ServerElement4;
            result += _ServerElement5;
            result += _ServerElement6?.ToString();
            result += _ServerElement7;
            return result;
        }

        #endregion

    }
}
