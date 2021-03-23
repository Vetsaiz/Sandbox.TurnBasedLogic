using System;
using System.Linq;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestServerArrayState : ITestServerArrayStateClient, ITestServerArrayState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testServerArrayState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_ArrayServerElement = new ReactiveProperty<String[]>(_ArrayServerElement);
            Interface_ArrayServerElement1 = new ReactiveProperty<Int32[]>(_ArrayServerElement1);
            Interface_ArrayServerElement2 = new ReactiveProperty<Int64[]>(_ArrayServerElement2);
            Interface_ArrayServerElement3 = new ReactiveProperty<Single[]>(_ArrayServerElement3);
            Interface_ArrayServerElement4 = new ReactiveProperty<Double[]>(_ArrayServerElement4);
            Interface_ArrayServerElement5 = new ReactiveProperty<Boolean[]>(_ArrayServerElement5);
            Interface_ArrayServerElement6 = new ReactiveProperty<SimpleTestData[]>(_ArrayServerElement6);
            Interface_ArrayServerElement7 = new ReactiveProperty<TestEnum[]>(_ArrayServerElement7);
        }
        public void PreSave()
        {
        }

        #region Interface

        private ReactiveProperty<String[]> Interface_ArrayServerElement;
        IReadOnlyReactiveProperty<String[]> ITestServerArrayStateClient.ArrayServerElement => Interface_ArrayServerElement;
        private ReactiveProperty<Int32[]> Interface_ArrayServerElement1;
        IReadOnlyReactiveProperty<Int32[]> ITestServerArrayStateClient.ArrayServerElement1 => Interface_ArrayServerElement1;
        private ReactiveProperty<Int64[]> Interface_ArrayServerElement2;
        IReadOnlyReactiveProperty<Int64[]> ITestServerArrayStateClient.ArrayServerElement2 => Interface_ArrayServerElement2;
        private ReactiveProperty<Single[]> Interface_ArrayServerElement3;
        IReadOnlyReactiveProperty<Single[]> ITestServerArrayStateClient.ArrayServerElement3 => Interface_ArrayServerElement3;
        private ReactiveProperty<Double[]> Interface_ArrayServerElement4;
        IReadOnlyReactiveProperty<Double[]> ITestServerArrayStateClient.ArrayServerElement4 => Interface_ArrayServerElement4;
        private ReactiveProperty<Boolean[]> Interface_ArrayServerElement5;
        IReadOnlyReactiveProperty<Boolean[]> ITestServerArrayStateClient.ArrayServerElement5 => Interface_ArrayServerElement5;
        private ReactiveProperty<SimpleTestData[]> Interface_ArrayServerElement6;
        IReadOnlyReactiveProperty<SimpleTestData[]> ITestServerArrayStateClient.ArrayServerElement6 => Interface_ArrayServerElement6;
        private ReactiveProperty<TestEnum[]> Interface_ArrayServerElement7;
        IReadOnlyReactiveProperty<TestEnum[]> ITestServerArrayStateClient.ArrayServerElement7 => Interface_ArrayServerElement7;

        #endregion

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
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement(String[] value)
        {
            _ArrayServerElement = value;
            Interface_ArrayServerElement.Value = value;
        }
        Int32[] ITestServerArrayState.ArrayServerElement1
        {
            get => _ArrayServerElement1;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement1(Int32[] value)
        {
            _ArrayServerElement1 = value;
            Interface_ArrayServerElement1.Value = value;
        }
        Int64[] ITestServerArrayState.ArrayServerElement2
        {
            get => _ArrayServerElement2;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement2(Int64[] value)
        {
            _ArrayServerElement2 = value;
            Interface_ArrayServerElement2.Value = value;
        }
        Single[] ITestServerArrayState.ArrayServerElement3
        {
            get => _ArrayServerElement3;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement3(Single[] value)
        {
            _ArrayServerElement3 = value;
            Interface_ArrayServerElement3.Value = value;
        }
        Double[] ITestServerArrayState.ArrayServerElement4
        {
            get => _ArrayServerElement4;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement4(Double[] value)
        {
            _ArrayServerElement4 = value;
            Interface_ArrayServerElement4.Value = value;
        }
        Boolean[] ITestServerArrayState.ArrayServerElement5
        {
            get => _ArrayServerElement5;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement5(Boolean[] value)
        {
            _ArrayServerElement5 = value;
            Interface_ArrayServerElement5.Value = value;
        }
        SimpleTestData[] ITestServerArrayState.ArrayServerElement6
        {
            get => _ArrayServerElement6;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement6(SimpleTestData[] value)
        {
            _ArrayServerElement6 = value;
            Interface_ArrayServerElement6.Value = value;
        }
        TestEnum[] ITestServerArrayState.ArrayServerElement7
        {
            get => _ArrayServerElement7;
            set => _storage.AddServerChange();
        }
        public void SetArrayServerElement7(TestEnum[] value)
        {
            _ArrayServerElement7 = value;
            Interface_ArrayServerElement7.Value = value;
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
