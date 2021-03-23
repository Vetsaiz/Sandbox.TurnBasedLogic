using System;
using System.Collections.Generic;
using SampesLogic.Logic.StateData.ServerElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core.Collections.Logic;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestServerDictState :ITestServerDictState, IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "ITestServerDictState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            LD_DictServerElement?.Init(DataId, storage, _DictServerElement);
            LD_DictServerElement1?.Init(DataId, storage, _DictServerElement1);
            LD_DictServerElement2?.Init(DataId, storage, _DictServerElement2);
            LD_DictServerElement3?.Init(DataId, storage, _DictServerElement3);
            LD_DictServerElement4?.Init(DataId, storage, _DictServerElement4);
            LD_DictServerElement5?.Init(DataId, storage, _DictServerElement5);
            LD_DictServerElement9?.Init(DataId, storage, _DictServerElement9);
            LD_DictServerElement11?.Init(DataId, storage, _DictServerElement11);
        }

        #region Internal

        private ValueLogicDictionary<String, String> LD_DictServerElement;
        public Dictionary<string, String> _DictServerElement = new Dictionary<string, String>();
        private ValueLogicDictionary<String, Int32> LD_DictServerElement1;
        public Dictionary<string, Int32> _DictServerElement1 = new Dictionary<string, Int32>();
        private ValueLogicDictionary<String, Int64> LD_DictServerElement2;
        public Dictionary<string, Int64> _DictServerElement2 = new Dictionary<string, Int64>();
        private ValueLogicDictionary<String, Single> LD_DictServerElement3;
        public Dictionary<string, Single> _DictServerElement3 = new Dictionary<string, Single>();
        private ValueLogicDictionary<String, Double> LD_DictServerElement4;
        public Dictionary<string, Double> _DictServerElement4 = new Dictionary<string, Double>();
        private ValueLogicDictionary<String, Boolean> LD_DictServerElement5;
        public Dictionary<string, Boolean> _DictServerElement5 = new Dictionary<string, Boolean>();
        private ValueLogicDictionary<Int32, String> LD_DictServerElement9;
        public Dictionary<string, String> _DictServerElement9 = new Dictionary<string, String>();
        private ValueLogicDictionary<String, Int32[]> LD_DictServerElement11;
        public Dictionary<string, Int32[]> _DictServerElement11 = new Dictionary<string, Int32[]>();

        #endregion

        #region Source

        ILogicDictionary<String, String> ITestServerDictState.DictServerElement
        {
            get => LD_DictServerElement;
        }
        ILogicDictionary<String, Int32> ITestServerDictState.DictServerElement1
        {
            get => LD_DictServerElement1;
        }
        ILogicDictionary<String, Int64> ITestServerDictState.DictServerElement2
        {
            get => LD_DictServerElement2;
        }
        ILogicDictionary<String, Single> ITestServerDictState.DictServerElement3
        {
            get => LD_DictServerElement3;
        }
        ILogicDictionary<String, Double> ITestServerDictState.DictServerElement4
        {
            get => LD_DictServerElement4;
        }
        ILogicDictionary<String, Boolean> ITestServerDictState.DictServerElement5
        {
            get => LD_DictServerElement5;
        }
        ILogicDictionary<Int32, String> ITestServerDictState.DictServerElement9
        {
            get => LD_DictServerElement9;
        }
        ILogicDictionary<String, Int32[]> ITestServerDictState.DictServerElement11
        {
            get => LD_DictServerElement11;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_DictServerElement.ToString();
            result += LD_DictServerElement1.ToString();
            result += LD_DictServerElement2.ToString();
            result += LD_DictServerElement3.ToString();
            result += LD_DictServerElement4.ToString();
            result += LD_DictServerElement5.ToString();
            result += LD_DictServerElement9.ToString();
            result += LD_DictServerElement11.ToString();
            return result;
        }

        #endregion

    }
}
