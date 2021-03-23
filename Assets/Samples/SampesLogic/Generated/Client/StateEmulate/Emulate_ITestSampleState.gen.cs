using System;
using System.Collections.Generic;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestSampleState : ITestSampleStateEmulate, ITestSampleState 
    , IInitStateData<ITestSampleStateClient>, IInitStateData<ITestSampleState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestSampleStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            TestString = client.TestString;
            TestInt = client.TestInt;
        }

        public void InitData(ITestSampleState data, ChangeStorage storage)
        {
            TestString = data.TestString;
            TestInt = data.TestInt;
        }

        #region Common

        public String TestString { get; private set; }
        public Int32 TestInt { get; private set; }

        #endregion

        #region Interface


        #endregion

        #region Internal


        #endregion

        #region Source


        #endregion

    }
}
