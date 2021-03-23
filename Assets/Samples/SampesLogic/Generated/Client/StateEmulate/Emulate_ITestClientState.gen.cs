using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ClientElements;
using SampesLogic.Logic.StaticData;
using UniRx;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestClientState : ITestClientStateEmulate, ITestClientState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private TestClientAccessor _accessor;
        public void InitData(ITestClientStateClient client, TestClientAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            client.TestElements.Subscribe(x =>
            {
                _TestElements = new Emulate_ITestElementsState();
                if (x != null)
                {
                    _TestElements.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            client.TestDict.Subscribe(x =>
            {
                _TestDict = new Emulate_ITestDictState();
                if (x != null)
                {
                    _TestDict.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            client.TestList.Subscribe(x =>
            {
                _TestList = new Emulate_ITestListState();
                if (x != null)
                {
                    _TestList.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            client.TestArray.Subscribe(x =>
            {
                _TestArray = new Emulate_ITestArrayState();
                if (x != null)
                {
                    _TestArray.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
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

        ITestElementsStateClient TestElements => _accessor.TestElements as ITestElementsStateClient;
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

        #region Common


        #endregion

        #region Interface

        ITestElementsStateEmulate ITestClientStateEmulate.TestElements => _TestElements;
        ITestDictStateEmulate ITestClientStateEmulate.TestDict => _TestDict;
        ITestListStateEmulate ITestClientStateEmulate.TestList => _TestList;
        ITestArrayStateEmulate ITestClientStateEmulate.TestArray => _TestArray;

        #endregion

        #region Internal

        ITestElementsState ITestClientState.TestElements
        {
            get => _TestElements;
            set => _TestElements = value as Emulate_ITestElementsState;
        }
        ITestDictState ITestClientState.TestDict
        {
            get => _TestDict;
            set => _TestDict = value as Emulate_ITestDictState;
        }
        ITestListState ITestClientState.TestList
        {
            get => _TestList;
            set => _TestList = value as Emulate_ITestListState;
        }
        ITestArrayState ITestClientState.TestArray
        {
            get => _TestArray;
            set => _TestArray = value as Emulate_ITestArrayState;
        }

        #endregion

        #region Source

        Emulate_ITestElementsState _TestElements;
        Emulate_ITestDictState _TestDict;
        Emulate_ITestListState _TestList;
        Emulate_ITestArrayState _TestArray;

        #endregion

    }
}
