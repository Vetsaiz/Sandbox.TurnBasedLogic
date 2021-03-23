using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core.Collections.Logic;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestServerListState :ITestServerListState, IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "ITestServerListState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            LL_ListServerElement?.Init(DataId, storage, _ListServerElement);
            LL_ListServerElement1?.Init(DataId, storage, _ListServerElement1);
            LL_ListServerElement2?.Init(DataId, storage, _ListServerElement2);
            LL_ListServerElement3?.Init(DataId, storage, _ListServerElement3);
            LL_ListServerElement4?.Init(DataId, storage, _ListServerElement4);
            LL_ListServerElement5?.Init(DataId, storage, _ListServerElement5);
            LL_ListServerElement6?.Init(DataId, storage, _ListServerElement6);
            LL_ListServerElement7?.Init(DataId, storage, _ListServerElement7);
        }

        #region Internal

        private ValueLogicList<String> LL_ListServerElement = new ValueLogicList<String>();
        public List<String> _ListServerElement = new List<String>();
        private ValueLogicList<Int32> LL_ListServerElement1 = new ValueLogicList<Int32>();
        public List<Int32> _ListServerElement1 = new List<Int32>();
        private ValueLogicList<Int64> LL_ListServerElement2 = new ValueLogicList<Int64>();
        public List<Int64> _ListServerElement2 = new List<Int64>();
        private ValueLogicList<Single> LL_ListServerElement3 = new ValueLogicList<Single>();
        public List<Single> _ListServerElement3 = new List<Single>();
        private ValueLogicList<Double> LL_ListServerElement4 = new ValueLogicList<Double>();
        public List<Double> _ListServerElement4 = new List<Double>();
        private ValueLogicList<Boolean> LL_ListServerElement5 = new ValueLogicList<Boolean>();
        public List<Boolean> _ListServerElement5 = new List<Boolean>();
        private ValueLogicList<SimpleTestData> LL_ListServerElement6 = new ValueLogicList<SimpleTestData>();
        public List<SimpleTestData> _ListServerElement6 = new List<SimpleTestData>();
        private ValueLogicList<TestEnum> LL_ListServerElement7 = new ValueLogicList<TestEnum>();
        public List<TestEnum> _ListServerElement7 = new List<TestEnum>();

        #endregion

        #region Source

        ILogicList<String> ITestServerListState.ListServerElement
        {
            get => LL_ListServerElement;
        }
        ILogicList<Int32> ITestServerListState.ListServerElement1
        {
            get => LL_ListServerElement1;
        }
        ILogicList<Int64> ITestServerListState.ListServerElement2
        {
            get => LL_ListServerElement2;
        }
        ILogicList<Single> ITestServerListState.ListServerElement3
        {
            get => LL_ListServerElement3;
        }
        ILogicList<Double> ITestServerListState.ListServerElement4
        {
            get => LL_ListServerElement4;
        }
        ILogicList<Boolean> ITestServerListState.ListServerElement5
        {
            get => LL_ListServerElement5;
        }
        ILogicList<SimpleTestData> ITestServerListState.ListServerElement6
        {
            get => LL_ListServerElement6;
        }
        ILogicList<TestEnum> ITestServerListState.ListServerElement7
        {
            get => LL_ListServerElement7;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LL_ListServerElement.ToString();
            result += LL_ListServerElement1.ToString();
            result += LL_ListServerElement2.ToString();
            result += LL_ListServerElement3.ToString();
            result += LL_ListServerElement4.ToString();
            result += LL_ListServerElement5.ToString();
            result += LL_ListServerElement6.ToString();
            result += LL_ListServerElement7.ToString();
            return result;
        }

        #endregion

    }
}
