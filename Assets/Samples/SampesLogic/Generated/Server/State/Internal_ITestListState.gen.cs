using System;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core.Collections.Logic;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestListState : ITestListState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testListState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            LL_ListElement?.Init($"{DataId}.listElement", storage, _ListElement);
            LL_ListElement1?.Init($"{DataId}.listElement1", storage, _ListElement1);
            LL_ListElement2?.Init($"{DataId}.listElement2", storage, _ListElement2);
            LL_ListElement3?.Init($"{DataId}.listElement3", storage, _ListElement3);
            LL_ListElement4?.Init($"{DataId}.listElement4", storage, _ListElement4);
            LL_ListElement5?.Init($"{DataId}.listElement5", storage, _ListElement5);
            LL_ListElement6?.Init($"{DataId}.listElement6", storage, _ListElement6);
            LL_ListElement7?.Init($"{DataId}.listElement7", storage, _ListElement7);
            LL_ListElement8?.Init($"{DataId}.listElement8", storage, _ListElement8);
        }
        public void PreSave()
        {
            foreach (var temp in LL_ListElement)
            {
            }
            foreach (var temp in LL_ListElement1)
            {
            }
            foreach (var temp in LL_ListElement2)
            {
            }
            foreach (var temp in LL_ListElement3)
            {
            }
            foreach (var temp in LL_ListElement4)
            {
            }
            foreach (var temp in LL_ListElement5)
            {
            }
            foreach (var temp in LL_ListElement6)
            {
            }
            foreach (var temp in LL_ListElement7)
            {
            }
            foreach (var temp in LL_ListElement8)
            {
                (temp as Internal_ITestSampleState).PreSave();
            }
        }

        #region Internal

        [JsonName("listElement")]
        public List<String> _ListElement = new List<String>();
        private ValueLogicList<String> LL_ListElement = new ValueLogicList<String>();
        [JsonName("listElement1")]
        public List<Int32> _ListElement1 = new List<Int32>();
        private ValueLogicList<Int32> LL_ListElement1 = new ValueLogicList<Int32>();
        [JsonName("listElement2")]
        public List<Int64> _ListElement2 = new List<Int64>();
        private ValueLogicList<Int64> LL_ListElement2 = new ValueLogicList<Int64>();
        [JsonName("listElement3")]
        public List<Single> _ListElement3 = new List<Single>();
        private ValueLogicList<Single> LL_ListElement3 = new ValueLogicList<Single>();
        [JsonName("listElement4")]
        public List<Double> _ListElement4 = new List<Double>();
        private ValueLogicList<Double> LL_ListElement4 = new ValueLogicList<Double>();
        [JsonName("listElement5")]
        public List<Boolean> _ListElement5 = new List<Boolean>();
        private ValueLogicList<Boolean> LL_ListElement5 = new ValueLogicList<Boolean>();
        [JsonName("listElement6")]
        public List<SimpleTestData> _ListElement6 = new List<SimpleTestData>();
        private ValueLogicList<SimpleTestData> LL_ListElement6 = new ValueLogicList<SimpleTestData>();
        [JsonName("listElement7")]
        public List<TestEnum> _ListElement7 = new List<TestEnum>();
        private ValueLogicList<TestEnum> LL_ListElement7 = new ValueLogicList<TestEnum>();
        [JsonName("listElement8")]
        public List<Internal_ITestSampleState> _ListElement8 = new List<Internal_ITestSampleState>();
        private InternalLogicList<Internal_ITestSampleState, ITestSampleState, ITestSampleState> LL_ListElement8 = new InternalLogicList<Internal_ITestSampleState, ITestSampleState, ITestSampleState>();

        #endregion

        #region Source

        ILogicList<String> ITestListState.ListElement
        {
            get => LL_ListElement;
        }
        ILogicList<Int32> ITestListState.ListElement1
        {
            get => LL_ListElement1;
        }
        ILogicList<Int64> ITestListState.ListElement2
        {
            get => LL_ListElement2;
        }
        ILogicList<Single> ITestListState.ListElement3
        {
            get => LL_ListElement3;
        }
        ILogicList<Double> ITestListState.ListElement4
        {
            get => LL_ListElement4;
        }
        ILogicList<Boolean> ITestListState.ListElement5
        {
            get => LL_ListElement5;
        }
        ILogicList<SimpleTestData> ITestListState.ListElement6
        {
            get => LL_ListElement6;
        }
        ILogicList<TestEnum> ITestListState.ListElement7
        {
            get => LL_ListElement7;
        }
        ILogicList<ITestSampleState> ITestListState.ListElement8
        {
            get => LL_ListElement8;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LL_ListElement.ToString();
            result += LL_ListElement1.ToString();
            result += LL_ListElement2.ToString();
            result += LL_ListElement3.ToString();
            result += LL_ListElement4.ToString();
            result += LL_ListElement5.ToString();
            result += LL_ListElement6.ToString();
            result += LL_ListElement7.ToString();
            result += LL_ListElement8.ToString();
            return result;
        }

        #endregion

    }
}
