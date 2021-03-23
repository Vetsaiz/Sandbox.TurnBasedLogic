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
    internal class Internal_ITestDictState : ITestDictState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "testDictState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            LD_DictElement?.Init($"{DataId}.dictElement", storage, _DictElement);
            LD_DictElement1?.Init($"{DataId}.dictElement1", storage, _DictElement1);
            LD_DictElement2?.Init($"{DataId}.dictElement2", storage, _DictElement2);
            LD_DictElement3?.Init($"{DataId}.dictElement3", storage, _DictElement3);
            LD_DictElement4?.Init($"{DataId}.dictElement4", storage, _DictElement4);
            LD_DictElement5?.Init($"{DataId}.dictElement5", storage, _DictElement5);
            LD_DictElement8?.Init($"{DataId}.dictElement8", storage, _DictElement8);
            LD_DictElement9?.Init($"{DataId}.dictElement9", storage, _DictElement9);
            LD_DictElement10?.Init($"{DataId}.dictElement10", storage, _DictElement10);
            LD_DictElement11?.Init($"{DataId}.dictElement11", storage, _DictElement11);
            LD_DictElement12?.Init($"{DataId}.dictElement12", storage, _DictElement12);
            LD_DictElement14?.Init($"{DataId}.dictElement14", storage, _DictElement14);
            LD_DictElement13?.Init($"{DataId}.dictElement13", storage, _DictElement13);
        }
        public void PreSave()
        {
            _DictElement = LD_DictElement.Source;
            _DictElement1 = LD_DictElement1.Source;
            _DictElement2 = LD_DictElement2.Source;
            _DictElement3 = LD_DictElement3.Source;
            _DictElement4 = LD_DictElement4.Source;
            _DictElement5 = LD_DictElement5.Source;
            foreach (var temp in LD_DictElement8.Source)
            {
                temp.Value.PreSave();
            }
            _DictElement8 = LD_DictElement8.Source;
            _DictElement9 = LD_DictElement9.Source;
            foreach (var temp in LD_DictElement10.Source)
            {
                temp.Value.PreSave();
            }
            _DictElement10 = LD_DictElement10.Source;
            _DictElement11 = LD_DictElement11.Source;
            _DictElement12 = LD_DictElement12.Source;
            _DictElement14 = LD_DictElement14.Source;
            _DictElement13 = LD_DictElement13.Source;
        }

        #region Internal

        [JsonName("dictElement")]
        public Dictionary<string, String> _DictElement = new Dictionary<string, String>();
        private ReferenceLogicDictionary<String, String> LD_DictElement = new ReferenceLogicDictionary<String, String>();
        [JsonName("dictElement1")]
        public Dictionary<string, Int32> _DictElement1 = new Dictionary<string, Int32>();
        private StructLogicDictionary<String, Int32> LD_DictElement1 = new StructLogicDictionary<String, Int32>();
        [JsonName("dictElement2")]
        public Dictionary<string, Int64> _DictElement2 = new Dictionary<string, Int64>();
        private StructLogicDictionary<String, Int64> LD_DictElement2 = new StructLogicDictionary<String, Int64>();
        [JsonName("dictElement3")]
        public Dictionary<string, Single> _DictElement3 = new Dictionary<string, Single>();
        private StructLogicDictionary<String, Single> LD_DictElement3 = new StructLogicDictionary<String, Single>();
        [JsonName("dictElement4")]
        public Dictionary<string, Double> _DictElement4 = new Dictionary<string, Double>();
        private StructLogicDictionary<String, Double> LD_DictElement4 = new StructLogicDictionary<String, Double>();
        [JsonName("dictElement5")]
        public Dictionary<string, Boolean> _DictElement5 = new Dictionary<string, Boolean>();
        private StructLogicDictionary<String, Boolean> LD_DictElement5 = new StructLogicDictionary<String, Boolean>();
        [JsonName("dictElement8")]
        public Dictionary<string, Internal_ITestSampleState> _DictElement8 = new Dictionary<string, Internal_ITestSampleState>();
        private InternalLogicDictionary<String, Internal_ITestSampleState, ITestSampleState, ITestSampleState> LD_DictElement8 = new InternalLogicDictionary<String, Internal_ITestSampleState, ITestSampleState, ITestSampleState>();
        [JsonName("dictElement9")]
        public Dictionary<string, String> _DictElement9 = new Dictionary<string, String>();
        private ReferenceLogicDictionary<Int32, String> LD_DictElement9 = new ReferenceLogicDictionary<Int32, String>();
        [JsonName("dictElement10")]
        public Dictionary<string, Internal_ITestSampleState> _DictElement10 = new Dictionary<string, Internal_ITestSampleState>();
        private InternalLogicDictionary<Int32, Internal_ITestSampleState, ITestSampleState, ITestSampleState> LD_DictElement10 = new InternalLogicDictionary<Int32, Internal_ITestSampleState, ITestSampleState, ITestSampleState>();
        [JsonName("dictElement11")]
        public Dictionary<string, Int32[]> _DictElement11 = new Dictionary<string, Int32[]>();
        private ReferenceLogicDictionary<String, Int32[]> LD_DictElement11 = new ReferenceLogicDictionary<String, Int32[]>();
        [JsonName("dictElement12")]
        public Dictionary<string, Int32> _DictElement12 = new Dictionary<string, Int32>();
        private StructLogicDictionary<TestEnum, Int32> LD_DictElement12 = new StructLogicDictionary<TestEnum, Int32>();
        [JsonName("dictElement14")]
        public Dictionary<string, Int32[]> _DictElement14 = new Dictionary<string, Int32[]>();
        private InternalValueListDictionary<String, Int32> LD_DictElement14 = new InternalValueListDictionary<String, Int32>();
        [JsonName("dictElement13")]
        public Dictionary<string, Internal_ITestSampleState[]> _DictElement13 = new Dictionary<string, Internal_ITestSampleState[]>();
        private InternalInternalListDictionary<String, Internal_ITestSampleState,ITestSampleState, ITestSampleState> LD_DictElement13 = new InternalInternalListDictionary<String, Internal_ITestSampleState,ITestSampleState, ITestSampleState>();

        #endregion

        #region Source

        ILogicDictionary<String, String> ITestDictState.DictElement
        {
            get => LD_DictElement;
        }
        ILogicDictionary<String, Int32> ITestDictState.DictElement1
        {
            get => LD_DictElement1;
        }
        ILogicDictionary<String, Int64> ITestDictState.DictElement2
        {
            get => LD_DictElement2;
        }
        ILogicDictionary<String, Single> ITestDictState.DictElement3
        {
            get => LD_DictElement3;
        }
        ILogicDictionary<String, Double> ITestDictState.DictElement4
        {
            get => LD_DictElement4;
        }
        ILogicDictionary<String, Boolean> ITestDictState.DictElement5
        {
            get => LD_DictElement5;
        }
        ILogicDictionary<String, ITestSampleState> ITestDictState.DictElement8
        {
            get => LD_DictElement8;
        }
        ILogicDictionary<Int32, String> ITestDictState.DictElement9
        {
            get => LD_DictElement9;
        }
        ILogicDictionary<Int32, ITestSampleState> ITestDictState.DictElement10
        {
            get => LD_DictElement10;
        }
        ILogicDictionary<String, Int32[]> ITestDictState.DictElement11
        {
            get => LD_DictElement11;
        }
        ILogicDictionary<TestEnum, Int32> ITestDictState.DictElement12
        {
            get => LD_DictElement12;
        }
        ILogicDictionary<String, ILogicList<Int32>> ITestDictState.DictElement14
        {
            get => LD_DictElement14;
        }
        ILogicDictionary<String, ILogicList<ITestSampleState>> ITestDictState.DictElement13
        {
            get => LD_DictElement13;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_DictElement.ToString();
            result += LD_DictElement1.ToString();
            result += LD_DictElement2.ToString();
            result += LD_DictElement3.ToString();
            result += LD_DictElement4.ToString();
            result += LD_DictElement5.ToString();
            result += LD_DictElement8.ToString();
            result += LD_DictElement9.ToString();
            result += LD_DictElement10.ToString();
            result += LD_DictElement11.ToString();
            result += LD_DictElement12.ToString();
            result += LD_DictElement14.ToString();
            result += LD_DictElement13.ToString();
            return result;
        }

        #endregion

    }
}
