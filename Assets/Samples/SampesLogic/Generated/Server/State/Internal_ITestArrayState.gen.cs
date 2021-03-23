using System;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestArrayState : ITestArrayState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testArrayState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            if (_ArrayElement8 != null)
            {
                foreach (var temp in _ArrayElement8)
                {
                    temp.InitData($"{DataId}.arrayElement8", storage);
                }
            }
        }
        public void PreSave()
        {
        }

        #region Internal

        [JsonName("arrayElement")]
        public String[] _ArrayElement;
        [JsonName("arrayElement1")]
        public Int32[] _ArrayElement1;
        [JsonName("arrayElement2")]
        public Int64[] _ArrayElement2;
        [JsonName("arrayElement3")]
        public Single[] _ArrayElement3;
        [JsonName("arrayElement4")]
        public Double[] _ArrayElement4;
        [JsonName("arrayElement5")]
        public Boolean[] _ArrayElement5;
        [JsonName("arrayElement6")]
        public SimpleTestData[] _ArrayElement6;
        [JsonName("arrayElement7")]
        public TestEnum[] _ArrayElement7;
        [JsonName("arrayElement8")]
        public Internal_ITestSampleState[] _ArrayElement8;

        #endregion

        #region Source

        String[] ITestArrayState.ArrayElement
        {
            get => _ArrayElement;
            set
            {
                _ArrayElement = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement.{id}",  null);
            }
        }
        Int32[] ITestArrayState.ArrayElement1
        {
            get => _ArrayElement1;
            set
            {
                _ArrayElement1 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement1.{id}",  null);
            }
        }
        Int64[] ITestArrayState.ArrayElement2
        {
            get => _ArrayElement2;
            set
            {
                _ArrayElement2 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement2.{id}",  null);
            }
        }
        Single[] ITestArrayState.ArrayElement3
        {
            get => _ArrayElement3;
            set
            {
                _ArrayElement3 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement3.{id}",  null);
            }
        }
        Double[] ITestArrayState.ArrayElement4
        {
            get => _ArrayElement4;
            set
            {
                _ArrayElement4 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement4.{id}",  null);
            }
        }
        Boolean[] ITestArrayState.ArrayElement5
        {
            get => _ArrayElement5;
            set
            {
                _ArrayElement5 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement5.{id}",  null);
            }
        }
        SimpleTestData[] ITestArrayState.ArrayElement6
        {
            get => _ArrayElement6;
            set
            {
                _ArrayElement6 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement6.{id}",  null);
            }
        }
        TestEnum[] ITestArrayState.ArrayElement7
        {
            get => _ArrayElement7;
            set
            {
                _ArrayElement7 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement7.{id}",  null);
            }
        }
        ITestSampleState[] ITestArrayState.ArrayElement8
        {
            get => _ArrayElement8;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _ArrayElement != null ? string.Join("", _ArrayElement.Select(x=>x)) : "";
            result += _ArrayElement1 != null ? string.Join("", _ArrayElement1.Select(x=>x)) : "";
            result += _ArrayElement2 != null ? string.Join("", _ArrayElement2.Select(x=>x)) : "";
            result += _ArrayElement3 != null ? string.Join("", _ArrayElement3.Select(x=>x)) : "";
            result += _ArrayElement4 != null ? string.Join("", _ArrayElement4.Select(x=>x)) : "";
            result += _ArrayElement5 != null ? string.Join("", _ArrayElement5.Select(x=>x)) : "";
            result += _ArrayElement6 != null ? string.Join("", _ArrayElement6.Select(x=>x?.ToString())) : "";
            result += _ArrayElement7 != null ? string.Join("", _ArrayElement7.Select(x=>x)) : "";
            result += _ArrayElement8 != null ? string.Join("", _ArrayElement8.Select(x=>x?.ToString())) : "";
            return result;
        }

        #endregion

    }
}
