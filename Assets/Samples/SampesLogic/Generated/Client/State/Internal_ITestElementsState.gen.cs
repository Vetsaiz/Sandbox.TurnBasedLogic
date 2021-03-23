using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestElementsState : ITestElementsStateClient, ITestElementsState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testElementsState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_Element = new ReactiveProperty<String>(_Element);
            Interface_Element1 = new ReactiveProperty<Int32>(_Element1);
            Interface_Element2 = new ReactiveProperty<Int64>(_Element2);
            Interface_Element3 = new ReactiveProperty<Single>(_Element3);
            Interface_Element4 = new ReactiveProperty<Double>(_Element4);
            Interface_Element5 = new ReactiveProperty<Boolean>(_Element5);
            Interface_Element6 = new ReactiveProperty<SimpleTestData>(_Element6);
            Interface_Element7 = new ReactiveProperty<TestEnum>(_Element7);
            _Element8?.InitData(DataId, storage);
            Interface_Element8 = new ReactiveProperty<ITestSampleStateClient>(_Element8);
        }
        public void PreSave()
        {
            _Element8?.PreSave();
        }

        #region Interface

        private ReactiveProperty<String> Interface_Element;
        IReadOnlyReactiveProperty<String> ITestElementsStateClient.Element => Interface_Element;
        private ReactiveProperty<Int32> Interface_Element1;
        IReadOnlyReactiveProperty<Int32> ITestElementsStateClient.Element1 => Interface_Element1;
        private ReactiveProperty<Int64> Interface_Element2;
        IReadOnlyReactiveProperty<Int64> ITestElementsStateClient.Element2 => Interface_Element2;
        private ReactiveProperty<Single> Interface_Element3;
        IReadOnlyReactiveProperty<Single> ITestElementsStateClient.Element3 => Interface_Element3;
        private ReactiveProperty<Double> Interface_Element4;
        IReadOnlyReactiveProperty<Double> ITestElementsStateClient.Element4 => Interface_Element4;
        private ReactiveProperty<Boolean> Interface_Element5;
        IReadOnlyReactiveProperty<Boolean> ITestElementsStateClient.Element5 => Interface_Element5;
        private ReactiveProperty<SimpleTestData> Interface_Element6;
        IReadOnlyReactiveProperty<SimpleTestData> ITestElementsStateClient.Element6 => Interface_Element6;
        private ReactiveProperty<TestEnum> Interface_Element7;
        IReadOnlyReactiveProperty<TestEnum> ITestElementsStateClient.Element7 => Interface_Element7;
        private ReactiveProperty<ITestSampleStateClient> Interface_Element8;
        IReadOnlyReactiveProperty<ITestSampleStateClient> ITestElementsStateClient.Element8 => Interface_Element8;

        #endregion

        #region Internal

        [JsonName("element")]
        public String _Element;
        [JsonName("element1")]
        public Int32 _Element1;
        [JsonName("element2")]
        public Int64 _Element2;
        [JsonName("element3")]
        public Single _Element3;
        [JsonName("element4")]
        public Double _Element4;
        [JsonName("element5")]
        public Boolean _Element5;
        [JsonName("element6")]
        public SimpleTestData _Element6;
        [JsonName("element7")]
        public TestEnum _Element7;
        [JsonName("element8")]
        public Internal_ITestSampleState _Element8;

        #endregion

        #region Source

        String ITestElementsState.Element
        {
            get => _Element;
            set
            {
                _Element = value;
                _storage?.AddChange(this, DataId + $".element.{value}", () => Interface_Element.Value = value);
            }
        }
        Int32 ITestElementsState.Element1
        {
            get => _Element1;
            set
            {
                _Element1 = value;
                _storage?.AddChange(this, DataId + $".element1.{value.ToString()}", () => Interface_Element1.Value = value);
            }
        }
        Int64 ITestElementsState.Element2
        {
            get => _Element2;
            set
            {
                _Element2 = value;
                _storage?.AddChange(this, DataId + $".element2.{value.ToString()}", () => Interface_Element2.Value = value);
            }
        }
        Single ITestElementsState.Element3
        {
            get => _Element3;
            set
            {
                _Element3 = value;
                _storage?.AddChange(this, DataId + $".element3.{value.ToString()}", () => Interface_Element3.Value = value);
            }
        }
        Double ITestElementsState.Element4
        {
            get => _Element4;
            set
            {
                _Element4 = value;
                _storage?.AddChange(this, DataId + $".element4.{value.ToString()}", () => Interface_Element4.Value = value);
            }
        }
        Boolean ITestElementsState.Element5
        {
            get => _Element5;
            set
            {
                _Element5 = value;
                _storage?.AddChange(this, DataId + $".element5.{value.ToString()}", () => Interface_Element5.Value = value);
            }
        }
        SimpleTestData ITestElementsState.Element6
        {
            get => _Element6;
            set
            {
                _Element6 = value;
                _storage?.AddChange(this, DataId + $".element6.{value?.ToString()}", () => Interface_Element6.Value = value);
            }
        }
        TestEnum ITestElementsState.Element7
        {
            get => _Element7;
            set
            {
                _Element7 = value;
                _storage?.AddChange(this, DataId + $".element7.{value.ToString()}", () => Interface_Element7.Value = value);
            }
        }
        ITestSampleState ITestElementsState.Element8
        {
            get => _Element8;
            set
            {
                var castValue = (Internal_ITestSampleState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _Element8 = castValue;
                _storage?.AddChange(this, DataId + $".element8.{castValue?.ToString()}", () => Interface_Element8.Value = castValue);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Element;
            result += _Element1;
            result += _Element2;
            result += _Element3;
            result += _Element4;
            result += _Element5;
            result += _Element6?.ToString();
            result += _Element7;
            result += _Element8?.ToString();
            return result;
        }

        #endregion

    }
}
