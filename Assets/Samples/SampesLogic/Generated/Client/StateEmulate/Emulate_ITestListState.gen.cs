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
    internal class Emulate_ITestListState : ITestListStateEmulate, ITestListState 
    , IInitStateData<ITestListStateClient>, IInitStateData<ITestListState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestListStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            LL_ListElement.Init(client.ListElement, storage);
            LL_ListElement1.Init(client.ListElement1, storage);
            LL_ListElement2.Init(client.ListElement2, storage);
            LL_ListElement3.Init(client.ListElement3, storage);
            LL_ListElement4.Init(client.ListElement4, storage);
            LL_ListElement5.Init(client.ListElement5, storage);
            LL_ListElement6.Init(client.ListElement6, storage);
            LL_ListElement7.Init(client.ListElement7, storage);
            LL_ListElement8.Init(client.ListElement8, storage);
        }

        public void InitData(ITestListState data, ChangeStorage storage)
        {
            LL_ListElement.Init(data.ListElement, storage);
            LL_ListElement1.Init(data.ListElement1, storage);
            LL_ListElement2.Init(data.ListElement2, storage);
            LL_ListElement3.Init(data.ListElement3, storage);
            LL_ListElement4.Init(data.ListElement4, storage);
            LL_ListElement5.Init(data.ListElement5, storage);
            LL_ListElement6.Init(data.ListElement6, storage);
            LL_ListElement7.Init(data.ListElement7, storage);
            LL_ListElement8.Init(data.ListElement8, storage);
        }

        #region Common


        #endregion

        #region Interface

        IList<String> ITestListStateEmulate.ListElement => LL_ListElement.Interface;
        IList<Int32> ITestListStateEmulate.ListElement1 => LL_ListElement1.Interface;
        IList<Int64> ITestListStateEmulate.ListElement2 => LL_ListElement2.Interface;
        IList<Single> ITestListStateEmulate.ListElement3 => LL_ListElement3.Interface;
        IList<Double> ITestListStateEmulate.ListElement4 => LL_ListElement4.Interface;
        IList<Boolean> ITestListStateEmulate.ListElement5 => LL_ListElement5.Interface;
        IList<SimpleTestData> ITestListStateEmulate.ListElement6 => LL_ListElement6.Interface;
        IList<TestEnum> ITestListStateEmulate.ListElement7 => LL_ListElement7.Interface;
        IList<ITestSampleStateEmulate> ITestListStateEmulate.ListElement8 => LL_ListElement8.Interface;

        #endregion

        #region Internal

        ILogicList<String> ITestListState.ListElement => LL_ListElement;
        ILogicList<Int32> ITestListState.ListElement1 => LL_ListElement1;
        ILogicList<Int64> ITestListState.ListElement2 => LL_ListElement2;
        ILogicList<Single> ITestListState.ListElement3 => LL_ListElement3;
        ILogicList<Double> ITestListState.ListElement4 => LL_ListElement4;
        ILogicList<Boolean> ITestListState.ListElement5 => LL_ListElement5;
        ILogicList<SimpleTestData> ITestListState.ListElement6 => LL_ListElement6;
        ILogicList<TestEnum> ITestListState.ListElement7 => LL_ListElement7;
        ILogicList<ITestSampleState> ITestListState.ListElement8 => LL_ListElement8;

        #endregion

        #region Source

        public ValueEmulateList<String> LL_ListElement { get; } = new ValueEmulateList<String>();
        public ValueEmulateList<Int32> LL_ListElement1 { get; } = new ValueEmulateList<Int32>();
        public ValueEmulateList<Int64> LL_ListElement2 { get; } = new ValueEmulateList<Int64>();
        public ValueEmulateList<Single> LL_ListElement3 { get; } = new ValueEmulateList<Single>();
        public ValueEmulateList<Double> LL_ListElement4 { get; } = new ValueEmulateList<Double>();
        public ValueEmulateList<Boolean> LL_ListElement5 { get; } = new ValueEmulateList<Boolean>();
        public ValueEmulateList<SimpleTestData> LL_ListElement6 { get; } = new ValueEmulateList<SimpleTestData>();
        public ValueEmulateList<TestEnum> LL_ListElement7 { get; } = new ValueEmulateList<TestEnum>();
        public InternalEmulateList<Emulate_ITestSampleState, ITestSampleState, ITestSampleStateEmulate> LL_ListElement8 { get; } = new InternalEmulateList<Emulate_ITestSampleState, ITestSampleState, ITestSampleStateEmulate>();

        #endregion

    }
}
