using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestServerElementsState : ITestServerElementsStateClient, ITestServerElementsState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testServerElementsState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_ServerElement = new ReactiveProperty<String>(_ServerElement);
            Interface_ServerElement1 = new ReactiveProperty<Int32>(_ServerElement1);
            Interface_ServerElement2 = new ReactiveProperty<Int64>(_ServerElement2);
            Interface_ServerElement3 = new ReactiveProperty<Single>(_ServerElement3);
            Interface_ServerElement4 = new ReactiveProperty<Double>(_ServerElement4);
            Interface_ServerElement5 = new ReactiveProperty<Boolean>(_ServerElement5);
            Interface_ServerElement6 = new ReactiveProperty<SimpleTestData>(_ServerElement6);
            Interface_ServerElement7 = new ReactiveProperty<TestEnum>(_ServerElement7);
        }
        public void PreSave()
        {
        }

        #region Interface

        private ReactiveProperty<String> Interface_ServerElement;
        IReadOnlyReactiveProperty<String> ITestServerElementsStateClient.ServerElement => Interface_ServerElement;
        private ReactiveProperty<Int32> Interface_ServerElement1;
        IReadOnlyReactiveProperty<Int32> ITestServerElementsStateClient.ServerElement1 => Interface_ServerElement1;
        private ReactiveProperty<Int64> Interface_ServerElement2;
        IReadOnlyReactiveProperty<Int64> ITestServerElementsStateClient.ServerElement2 => Interface_ServerElement2;
        private ReactiveProperty<Single> Interface_ServerElement3;
        IReadOnlyReactiveProperty<Single> ITestServerElementsStateClient.ServerElement3 => Interface_ServerElement3;
        private ReactiveProperty<Double> Interface_ServerElement4;
        IReadOnlyReactiveProperty<Double> ITestServerElementsStateClient.ServerElement4 => Interface_ServerElement4;
        private ReactiveProperty<Boolean> Interface_ServerElement5;
        IReadOnlyReactiveProperty<Boolean> ITestServerElementsStateClient.ServerElement5 => Interface_ServerElement5;
        private ReactiveProperty<SimpleTestData> Interface_ServerElement6;
        IReadOnlyReactiveProperty<SimpleTestData> ITestServerElementsStateClient.ServerElement6 => Interface_ServerElement6;
        private ReactiveProperty<TestEnum> Interface_ServerElement7;
        IReadOnlyReactiveProperty<TestEnum> ITestServerElementsStateClient.ServerElement7 => Interface_ServerElement7;

        #endregion

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
            set => _storage.AddServerChange();
        }
        public void SetServerElement(String value)
        {
            _ServerElement = value;
            Interface_ServerElement.Value = value;
        }
        Int32 ITestServerElementsState.ServerElement1
        {
            get => _ServerElement1;
            set => _storage.AddServerChange();
        }
        public void SetServerElement1(Int32 value)
        {
            _ServerElement1 = value;
            Interface_ServerElement1.Value = value;
        }
        Int64 ITestServerElementsState.ServerElement2
        {
            get => _ServerElement2;
            set => _storage.AddServerChange();
        }
        public void SetServerElement2(Int64 value)
        {
            _ServerElement2 = value;
            Interface_ServerElement2.Value = value;
        }
        Single ITestServerElementsState.ServerElement3
        {
            get => _ServerElement3;
            set => _storage.AddServerChange();
        }
        public void SetServerElement3(Single value)
        {
            _ServerElement3 = value;
            Interface_ServerElement3.Value = value;
        }
        Double ITestServerElementsState.ServerElement4
        {
            get => _ServerElement4;
            set => _storage.AddServerChange();
        }
        public void SetServerElement4(Double value)
        {
            _ServerElement4 = value;
            Interface_ServerElement4.Value = value;
        }
        Boolean ITestServerElementsState.ServerElement5
        {
            get => _ServerElement5;
            set => _storage.AddServerChange();
        }
        public void SetServerElement5(Boolean value)
        {
            _ServerElement5 = value;
            Interface_ServerElement5.Value = value;
        }
        SimpleTestData ITestServerElementsState.ServerElement6
        {
            get => _ServerElement6;
            set => _storage.AddServerChange();
        }
        public void SetServerElement6(SimpleTestData value)
        {
            _ServerElement6 = value;
            Interface_ServerElement6.Value = value;
        }
        TestEnum ITestServerElementsState.ServerElement7
        {
            get => _ServerElement7;
            set => _storage.AddServerChange();
        }
        public void SetServerElement7(TestEnum value)
        {
            _ServerElement7 = value;
            Interface_ServerElement7.Value = value;
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
