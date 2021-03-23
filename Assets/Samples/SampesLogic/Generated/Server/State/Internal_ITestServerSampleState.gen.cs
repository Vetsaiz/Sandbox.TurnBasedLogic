using System;
using SampesLogic.Logic.StateData.ServerElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestServerSampleState :ITestServerSampleState, IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "ITestServerSampleState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
        }

        #region Internal

        public String _TestServerString;
        public Int32 _TestServerInt;

        #endregion

        #region Source

        String ITestServerSampleState.TestServerString
        {
            get => _TestServerString;
        }
        Int32 ITestServerSampleState.TestServerInt
        {
            get => _TestServerInt;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestServerString;
            result += _TestServerInt;
            return result;
        }

        #endregion

    }
}
