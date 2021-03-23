using System;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestServerArrayState : ITestServerArrayState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testServerArrayState";
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
        [JsonName("arrayServerElement")]
        public String[] _ArrayServerElement;
        [JsonIgnore]
        [JsonName("arrayServerElement1")]
        public Int32[] _ArrayServerElement1;
        [JsonIgnore]
        [JsonName("arrayServerElement2")]
        public Int64[] _ArrayServerElement2;
        [JsonIgnore]
        [JsonName("arrayServerElement3")]
        public Single[] _ArrayServerElement3;
        [JsonIgnore]
        [JsonName("arrayServerElement4")]
        public Double[] _ArrayServerElement4;
        [JsonIgnore]
        [JsonName("arrayServerElement5")]
        public Boolean[] _ArrayServerElement5;
        [JsonIgnore]
        [JsonName("arrayServerElement6")]
        public SimpleTestData[] _ArrayServerElement6;
        [JsonIgnore]
        [JsonName("arrayServerElement7")]
        public TestEnum[] _ArrayServerElement7;

        #endregion

        #region Source

        String[] ITestServerArrayState.ArrayServerElement
        {
            get => _ArrayServerElement;
            set => _ArrayServerElement = value;
        }
        Int32[] ITestServerArrayState.ArrayServerElement1
        {
            get => _ArrayServerElement1;
            set => _ArrayServerElement1 = value;
        }
        Int64[] ITestServerArrayState.ArrayServerElement2
        {
            get => _ArrayServerElement2;
            set => _ArrayServerElement2 = value;
        }
        Single[] ITestServerArrayState.ArrayServerElement3
        {
            get => _ArrayServerElement3;
            set => _ArrayServerElement3 = value;
        }
        Double[] ITestServerArrayState.ArrayServerElement4
        {
            get => _ArrayServerElement4;
            set => _ArrayServerElement4 = value;
        }
        Boolean[] ITestServerArrayState.ArrayServerElement5
        {
            get => _ArrayServerElement5;
            set => _ArrayServerElement5 = value;
        }
        SimpleTestData[] ITestServerArrayState.ArrayServerElement6
        {
            get => _ArrayServerElement6;
            set => _ArrayServerElement6 = value;
        }
        TestEnum[] ITestServerArrayState.ArrayServerElement7
        {
            get => _ArrayServerElement7;
            set => _ArrayServerElement7 = value;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _ArrayServerElement != null ? string.Join("", _ArrayServerElement.Select(x=>x)) : "";
            result += _ArrayServerElement1 != null ? string.Join("", _ArrayServerElement1.Select(x=>x)) : "";
            result += _ArrayServerElement2 != null ? string.Join("", _ArrayServerElement2.Select(x=>x)) : "";
            result += _ArrayServerElement3 != null ? string.Join("", _ArrayServerElement3.Select(x=>x)) : "";
            result += _ArrayServerElement4 != null ? string.Join("", _ArrayServerElement4.Select(x=>x)) : "";
            result += _ArrayServerElement5 != null ? string.Join("", _ArrayServerElement5.Select(x=>x)) : "";
            result += _ArrayServerElement6 != null ? string.Join("", _ArrayServerElement6.Select(x=>x?.ToString())) : "";
            result += _ArrayServerElement7 != null ? string.Join("", _ArrayServerElement7.Select(x=>x)) : "";
            return result;
        }

        #endregion

    }
}
