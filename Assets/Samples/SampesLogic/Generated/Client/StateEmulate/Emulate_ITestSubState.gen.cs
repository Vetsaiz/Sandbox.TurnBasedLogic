using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StateData;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestSubState : ITestSubStateEmulate, ITestSubState 
    , IInitStateData<ITestSubStateClient>, IInitStateData<ITestSubState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestSubStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            TestFloat = client.TestFloat;
            client.TestDouble.Subscribe(x => _TestDouble = x).AddTo(_disposables);
            TestData = client.TestData;
            client.Commands.Subscribe(x => _Commands = x).AddTo(_disposables);
        }

        public void InitData(ITestSubState data, ChangeStorage storage)
        {
            TestFloat = data.TestFloat;
            TestDouble = data.TestDouble;
            TestData = data.TestData;
            Commands = data.Commands;
        }

        #region Common

        public Single TestFloat { get; private set; }
        private Int64 _TestDouble;
        public Int64  TestDouble
        {
            get => _TestDouble;
               set
            {
                 var backValue = _TestDouble;
                _storage.AddBackAction(() => _TestDouble = backValue);
                _TestDouble = value;
            }
        }
        public SimpleTestData TestData { get; private set; }
        private String[] _Commands;
        public String[]  Commands
        {
            get => _Commands;
               set
            {
                 var backValue = _Commands;
                _storage.AddBackAction(() => _Commands = backValue);
                _Commands = value;
            }
        }

        #endregion

        #region Interface


        #endregion

        #region Internal


        #endregion

        #region Source


        #endregion

    }
}
