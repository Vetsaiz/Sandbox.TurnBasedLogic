using System;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ClientElements;
using SampesLogic.Logic.StaticData;
using UniRx;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestClientState : ITestClientStateClient, ITestClientState 
    {
        private ChangeStorage _storage;
        private string DataId = "testClientState";
        private TestClientAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, TestClientAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _TestElements?.InitData(DataId, storage);
            Interface_TestElements = new ReactiveProperty<ITestElementsStateClient>(_TestElements);
            _TestDict?.InitData(DataId, storage);
            Interface_TestDict = new ReactiveProperty<ITestDictStateClient>(_TestDict);
            _TestList?.InitData(DataId, storage);
            Interface_TestList = new ReactiveProperty<ITestListStateClient>(_TestList);
            _TestArray?.InitData(DataId, storage);
            Interface_TestArray = new ReactiveProperty<ITestArrayStateClient>(_TestArray);
        }
        public void PreSave()
        {
            _TestElements?.PreSave();
            _TestDict?.PreSave();
            _TestList?.PreSave();
            _TestArray?.PreSave();
        }

        #region Queries

        public String GetElement()
        {
            return _accessor.GetElement();
        }
        public Int32 GetElement1()
        {
            return _accessor.GetElement1();
        }
        public Int64 GetElement2()
        {
            return _accessor.GetElement2();
        }
        public Single GetElement3()
        {
            return _accessor.GetElement3();
        }
        public Double GetElement4()
        {
            return _accessor.GetElement4();
        }
        public Boolean GetElement5()
        {
            return _accessor.GetElement5();
        }
        public SimpleTestData GetElement6()
        {
            return _accessor.GetElement6();
        }
        public ComplexTestData GetElement7()
        {
            return _accessor.GetElement7();
        }
        public ITestElementStatic GetElement8()
        {
            return _accessor.GetElement8();
        }
        public IReadOnlyDictionary<String, String> GetDictElements()
        {
            return _accessor.GetDictElements();
        }
        public IReadOnlyDictionary<String, Int32> GetDictElements1()
        {
            return _accessor.GetDictElements1();
        }
        public IReadOnlyDictionary<Int32, String> GetDictElements2()
        {
            return _accessor.GetDictElements2();
        }
        public IReadOnlyDictionary<Int32, ITestElementStatic> GetDictElements3()
        {
            return _accessor.GetDictElements3();
        }
        public IReadOnlyDictionary<Int32, SimpleTestData> GetDictElements4()
        {
            return _accessor.GetDictElements4();
        }
        public String[] GetArrayElements()
        {
            return _accessor.GetArrayElements();
        }
        public Int32[] GetArrayElements1()
        {
            return _accessor.GetArrayElements1();
        }
        public SimpleTestData[] GetArrayElements2()
        {
            return _accessor.GetArrayElements2();
        }
        public ITestElementStatic[] GetArrayElements3()
        {
            return _accessor.GetArrayElements3();
        }
        public ITestElementsStateClient TestElementsStatic => _accessor.TestElements as ITestElementsStateClient;
        public String ElementStatic => _accessor.Element;
        public Int32 Element1Static => _accessor.Element1;
        public Int64 Element2Static => _accessor.Element2;
        public Single Element3Static => _accessor.Element3;
        public Double Element4Static => _accessor.Element4;
        public Boolean Element5Static => _accessor.Element5;
        public SimpleTestData Element6Static => _accessor.Element6;
        public ComplexTestData Element7Static => _accessor.Element7;
        public ITestElementStatic Element8Static => _accessor.Element8;
        public IReadOnlyDictionary<String, String> DictElementsStatic => _accessor.DictElements;
        public IReadOnlyDictionary<String, Int32> DictElements1Static => _accessor.DictElements1;
        public IReadOnlyDictionary<Int32, String> DictElements2Static => _accessor.DictElements2;
        public IReadOnlyDictionary<Int32, ITestElementStatic> DictElements3Static => _accessor.DictElements3;
        public IReadOnlyDictionary<Int32, SimpleTestData> DictElements4Static => _accessor.DictElements4;
        public String[] ArrayElementsStatic => _accessor.ArrayElements;
        public Int32[] ArrayElements1Static => _accessor.ArrayElements1;
        public SimpleTestData[] ArrayElements2Static => _accessor.ArrayElements2;
        public ITestElementStatic[] ArrayElements3Static => _accessor.ArrayElements3;

        #endregion

        #region Interface

        private ReactiveProperty<ITestElementsStateClient> Interface_TestElements;
        IReadOnlyReactiveProperty<ITestElementsStateClient> ITestClientStateClient.TestElements => Interface_TestElements;
        private ReactiveProperty<ITestDictStateClient> Interface_TestDict;
        IReadOnlyReactiveProperty<ITestDictStateClient> ITestClientStateClient.TestDict => Interface_TestDict;
        private ReactiveProperty<ITestListStateClient> Interface_TestList;
        IReadOnlyReactiveProperty<ITestListStateClient> ITestClientStateClient.TestList => Interface_TestList;
        private ReactiveProperty<ITestArrayStateClient> Interface_TestArray;
        IReadOnlyReactiveProperty<ITestArrayStateClient> ITestClientStateClient.TestArray => Interface_TestArray;

        #endregion

        #region Internal

        [JsonName("testElements")]
        public Internal_ITestElementsState _TestElements;
        [JsonName("testDict")]
        public Internal_ITestDictState _TestDict;
        [JsonName("testList")]
        public Internal_ITestListState _TestList;
        [JsonName("testArray")]
        public Internal_ITestArrayState _TestArray;

        #endregion

        #region Source

        ITestElementsState ITestClientState.TestElements
        {
            get => _TestElements;
            set
            {
                var castValue = (Internal_ITestElementsState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestElements = castValue;
                _storage?.AddChange(this, DataId + $".testElements.{castValue?.ToString()}", () => Interface_TestElements.Value = castValue);
            }
        }
        ITestDictState ITestClientState.TestDict
        {
            get => _TestDict;
            set
            {
                var castValue = (Internal_ITestDictState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestDict = castValue;
                _storage?.AddChange(this, DataId + $".testDict.{castValue?.ToString()}", () => Interface_TestDict.Value = castValue);
            }
        }
        ITestListState ITestClientState.TestList
        {
            get => _TestList;
            set
            {
                var castValue = (Internal_ITestListState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestList = castValue;
                _storage?.AddChange(this, DataId + $".testList.{castValue?.ToString()}", () => Interface_TestList.Value = castValue);
            }
        }
        ITestArrayState ITestClientState.TestArray
        {
            get => _TestArray;
            set
            {
                var castValue = (Internal_ITestArrayState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestArray = castValue;
                _storage?.AddChange(this, DataId + $".testArray.{castValue?.ToString()}", () => Interface_TestArray.Value = castValue);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestElements?.ToString();
            result += _TestDict?.ToString();
            result += _TestList?.ToString();
            result += _TestArray?.ToString();
            return result;
        }

        #endregion

    }
}
