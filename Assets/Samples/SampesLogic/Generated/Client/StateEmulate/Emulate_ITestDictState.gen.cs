using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core.Collections.Emulate;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestDictState : ITestDictStateEmulate, ITestDictState 
    , IInitStateData<ITestDictStateClient>, IInitStateData<ITestDictState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestDictStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            LD_DictElement.Init(client.DictElement, storage);
            LD_DictElement1.Init(client.DictElement1, storage);
            LD_DictElement2.Init(client.DictElement2, storage);
            LD_DictElement3.Init(client.DictElement3, storage);
            LD_DictElement4.Init(client.DictElement4, storage);
            LD_DictElement5.Init(client.DictElement5, storage);
            LD_DictElement8.Init(client.DictElement8, storage);
            LD_DictElement9.Init(client.DictElement9, storage);
            LD_DictElement10.Init(client.DictElement10, storage);
            LD_DictElement11.Init(client.DictElement11, storage);
        }

        public void InitData(ITestDictState data, ChangeStorage storage)
        {
            LD_DictElement.Init(data.DictElement, storage);
            LD_DictElement1.Init(data.DictElement1, storage);
            LD_DictElement2.Init(data.DictElement2, storage);
            LD_DictElement3.Init(data.DictElement3, storage);
            LD_DictElement4.Init(data.DictElement4, storage);
            LD_DictElement5.Init(data.DictElement5, storage);
            LD_DictElement8.Init(data.DictElement8, storage);
            LD_DictElement9.Init(data.DictElement9, storage);
            LD_DictElement10.Init(data.DictElement10, storage);
            LD_DictElement11.Init(data.DictElement11, storage);
        }

        #region Common


        #endregion

        #region Interface

        IDictionary<String, String> ITestDictStateEmulate.DictElement => LD_DictElement.Interface;
        IDictionary<String, Int32> ITestDictStateEmulate.DictElement1 => LD_DictElement1.Interface;
        IDictionary<String, Int64> ITestDictStateEmulate.DictElement2 => LD_DictElement2.Interface;
        IDictionary<String, Single> ITestDictStateEmulate.DictElement3 => LD_DictElement3.Interface;
        IDictionary<String, Double> ITestDictStateEmulate.DictElement4 => LD_DictElement4.Interface;
        IDictionary<String, Boolean> ITestDictStateEmulate.DictElement5 => LD_DictElement5.Interface;
        IDictionary<String, ITestSampleStateEmulate> ITestDictStateEmulate.DictElement8 => LD_DictElement8.Interface;
        IDictionary<Int32, String> ITestDictStateEmulate.DictElement9 => LD_DictElement9.Interface;
        IDictionary<Int32, ITestSampleStateEmulate> ITestDictStateEmulate.DictElement10 => LD_DictElement10.Interface;
        IDictionary<String, Int32[]> ITestDictStateEmulate.DictElement11 => LD_DictElement11.Interface;

        #endregion

        #region Internal

        ILogicDictionary<String, String> ITestDictState.DictElement => LD_DictElement;
        ILogicDictionary<String, Int32> ITestDictState.DictElement1 => LD_DictElement1;
        ILogicDictionary<String, Int64> ITestDictState.DictElement2 => LD_DictElement2;
        ILogicDictionary<String, Single> ITestDictState.DictElement3 => LD_DictElement3;
        ILogicDictionary<String, Double> ITestDictState.DictElement4 => LD_DictElement4;
        ILogicDictionary<String, Boolean> ITestDictState.DictElement5 => LD_DictElement5;
        ILogicDictionary<String, ITestSampleState> ITestDictState.DictElement8 => LD_DictElement8;
        ILogicDictionary<Int32, String> ITestDictState.DictElement9 => LD_DictElement9;
        ILogicDictionary<Int32, ITestSampleState> ITestDictState.DictElement10 => LD_DictElement10;
        ILogicDictionary<String, Int32[]> ITestDictState.DictElement11 => LD_DictElement11;

        public ILogicDictionary<TestEnum, int> DictElement12 { get; }
        public ILogicDictionary<string, ILogicList<int>> DictElement14 { get; }
        public ILogicDictionary<string, ILogicList<ITestSampleState>> DictElement13 { get; }
        #endregion

        #region Source

        public ValueEmulateDictionary<String, String> LD_DictElement { get; } = new ValueEmulateDictionary<String, String>();
        public ValueEmulateDictionary<String, Int32> LD_DictElement1 { get; } = new ValueEmulateDictionary<String, Int32>();
        public ValueEmulateDictionary<String, Int64> LD_DictElement2 { get; } = new ValueEmulateDictionary<String, Int64>();
        public ValueEmulateDictionary<String, Single> LD_DictElement3 { get; } = new ValueEmulateDictionary<String, Single>();
        public ValueEmulateDictionary<String, Double> LD_DictElement4 { get; } = new ValueEmulateDictionary<String, Double>();
        public ValueEmulateDictionary<String, Boolean> LD_DictElement5 { get; } = new ValueEmulateDictionary<String, Boolean>();
        public InternalEmulateDictionary<String,Emulate_ITestSampleState, ITestSampleState, ITestSampleStateEmulate> LD_DictElement8 { get; } = new InternalEmulateDictionary<String,Emulate_ITestSampleState, ITestSampleState, ITestSampleStateEmulate>();
        public ValueEmulateDictionary<Int32, String> LD_DictElement9 { get; } = new ValueEmulateDictionary<Int32, String>();
        public InternalEmulateDictionary<Int32,Emulate_ITestSampleState, ITestSampleState, ITestSampleStateEmulate> LD_DictElement10 { get; } = new InternalEmulateDictionary<Int32,Emulate_ITestSampleState, ITestSampleState, ITestSampleStateEmulate>();
        public ValueEmulateDictionary<String, Int32[]> LD_DictElement11 { get; } = new ValueEmulateDictionary<String, Int32[]>();

        #endregion

    }
}
