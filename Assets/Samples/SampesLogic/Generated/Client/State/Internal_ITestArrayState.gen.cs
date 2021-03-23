using System;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestArrayState : ITestArrayStateClient, ITestArrayState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testArrayState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_ArrayElement = new ReactiveProperty<String[]>(_ArrayElement);
            Interface_ArrayElement1 = new ReactiveProperty<Int32[]>(_ArrayElement1);
            Interface_ArrayElement2 = new ReactiveProperty<Int64[]>(_ArrayElement2);
            Interface_ArrayElement3 = new ReactiveProperty<Single[]>(_ArrayElement3);
            Interface_ArrayElement4 = new ReactiveProperty<Double[]>(_ArrayElement4);
            Interface_ArrayElement5 = new ReactiveProperty<Boolean[]>(_ArrayElement5);
            Interface_ArrayElement6 = new ReactiveProperty<SimpleTestData[]>(_ArrayElement6);
            Interface_ArrayElement7 = new ReactiveProperty<TestEnum[]>(_ArrayElement7);
            if (_ArrayElement8 != null)
            {
                foreach (var temp in _ArrayElement8)
                {
                    temp.InitData($"{DataId}.arrayElement8", storage);
                }
            }
            Interface_ArrayElement8 = _ArrayElement8;
        }
        public void PreSave()
        {
        }

        #region Interface

        private ReactiveProperty<String[]> Interface_ArrayElement;
        IReadOnlyReactiveProperty<String[]> ITestArrayStateClient.ArrayElement => Interface_ArrayElement;
        private ReactiveProperty<Int32[]> Interface_ArrayElement1;
        IReadOnlyReactiveProperty<Int32[]> ITestArrayStateClient.ArrayElement1 => Interface_ArrayElement1;
        private ReactiveProperty<Int64[]> Interface_ArrayElement2;
        IReadOnlyReactiveProperty<Int64[]> ITestArrayStateClient.ArrayElement2 => Interface_ArrayElement2;
        private ReactiveProperty<Single[]> Interface_ArrayElement3;
        IReadOnlyReactiveProperty<Single[]> ITestArrayStateClient.ArrayElement3 => Interface_ArrayElement3;
        private ReactiveProperty<Double[]> Interface_ArrayElement4;
        IReadOnlyReactiveProperty<Double[]> ITestArrayStateClient.ArrayElement4 => Interface_ArrayElement4;
        private ReactiveProperty<Boolean[]> Interface_ArrayElement5;
        IReadOnlyReactiveProperty<Boolean[]> ITestArrayStateClient.ArrayElement5 => Interface_ArrayElement5;
        private ReactiveProperty<SimpleTestData[]> Interface_ArrayElement6;
        IReadOnlyReactiveProperty<SimpleTestData[]> ITestArrayStateClient.ArrayElement6 => Interface_ArrayElement6;
        private ReactiveProperty<TestEnum[]> Interface_ArrayElement7;
        IReadOnlyReactiveProperty<TestEnum[]> ITestArrayStateClient.ArrayElement7 => Interface_ArrayElement7;
        private ITestSampleStateClient[] Interface_ArrayElement8;
        ITestSampleStateClient[] ITestArrayStateClient.ArrayElement8 => Interface_ArrayElement8;

        #endregion

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
                _storage?.AddChange(this, DataId + $".arrayElement.{id}",  () => Interface_ArrayElement.Value = value);
            }
        }
        Int32[] ITestArrayState.ArrayElement1
        {
            get => _ArrayElement1;
            set
            {
                _ArrayElement1 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement1.{id}",  () => Interface_ArrayElement1.Value = value);
            }
        }
        Int64[] ITestArrayState.ArrayElement2
        {
            get => _ArrayElement2;
            set
            {
                _ArrayElement2 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement2.{id}",  () => Interface_ArrayElement2.Value = value);
            }
        }
        Single[] ITestArrayState.ArrayElement3
        {
            get => _ArrayElement3;
            set
            {
                _ArrayElement3 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement3.{id}",  () => Interface_ArrayElement3.Value = value);
            }
        }
        Double[] ITestArrayState.ArrayElement4
        {
            get => _ArrayElement4;
            set
            {
                _ArrayElement4 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement4.{id}",  () => Interface_ArrayElement4.Value = value);
            }
        }
        Boolean[] ITestArrayState.ArrayElement5
        {
            get => _ArrayElement5;
            set
            {
                _ArrayElement5 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement5.{id}",  () => Interface_ArrayElement5.Value = value);
            }
        }
        SimpleTestData[] ITestArrayState.ArrayElement6
        {
            get => _ArrayElement6;
            set
            {
                _ArrayElement6 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement6.{id}",  () => Interface_ArrayElement6.Value = value);
            }
        }
        TestEnum[] ITestArrayState.ArrayElement7
        {
            get => _ArrayElement7;
            set
            {
                _ArrayElement7 = value;
                var id = value != null ? string.Join("", value.Select(x => x.ToString())) : null; 
                _storage?.AddChange(this, DataId + $".arrayElement7.{id}",  () => Interface_ArrayElement7.Value = value);
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
