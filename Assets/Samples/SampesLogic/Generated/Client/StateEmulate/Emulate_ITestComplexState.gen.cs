using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using UniRx;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestComplexState : ITestComplexStateEmulate, ITestComplexState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private TestAccessor _accessor;
        public void InitData(ITestComplexStateClient client, TestAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            TestString = client.TestString;
            client.TestInt.Subscribe(x => _TestInt = x).AddTo(_disposables);
            client.SubSet.Subscribe(x =>
            {
                _SubSet = new Emulate_ITestSubState();
                if (x != null)
                {
                    _SubSet.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            client.TestData.Subscribe(x => _TestData = x).AddTo(_disposables);
        }


        #region Queries

        public SimpleTestData GetData()
        {
            return _accessor.GetData();
        }
        public SimpleTestData GetStrData(System.String testStr)
        {
            return _accessor.GetStrData(testStr);
        }
        public Int32 TestIntStatic => _accessor.TestInt;

        #endregion

        #region Common

        public String TestString { get; private set; }
        private Int32 _TestInt;
        public Int32  TestInt
        {
            get => _TestInt;
               set
            {
                 var backValue = _TestInt;
                _storage.AddBackAction(() => _TestInt = backValue);
                _TestInt = value;
            }
        }
        private SimpleTestData _TestData;
        public SimpleTestData  TestData
        {
            get => _TestData;
               set
            {
                 var backValue = _TestData;
                _storage.AddBackAction(() => _TestData = backValue);
                _TestData = value;
            }
        }

        #endregion

        #region Interface

        ITestSubStateEmulate ITestComplexStateEmulate.SubSet => _SubSet;

        #endregion

        #region Internal

        ITestSubState ITestComplexState.SubSet
        {
            get => _SubSet;
            set => _SubSet = value as Emulate_ITestSubState;
        }

        #endregion

        #region Source

        Emulate_ITestSubState _SubSet;

        #endregion

    }
}
