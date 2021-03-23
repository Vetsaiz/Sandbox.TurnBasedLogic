using System;
using System.Collections.Generic;
using System.Linq;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestArrayState : ITestArrayStateEmulate, ITestArrayState 
    , IInitStateData<ITestArrayStateClient>, IInitStateData<ITestArrayState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestArrayStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.ArrayElement.Subscribe(x => _ArrayElement = x).AddTo(_disposables);
            client.ArrayElement1.Subscribe(x => _ArrayElement1 = x).AddTo(_disposables);
            client.ArrayElement2.Subscribe(x => _ArrayElement2 = x).AddTo(_disposables);
            client.ArrayElement3.Subscribe(x => _ArrayElement3 = x).AddTo(_disposables);
            client.ArrayElement4.Subscribe(x => _ArrayElement4 = x).AddTo(_disposables);
            client.ArrayElement5.Subscribe(x => _ArrayElement5 = x).AddTo(_disposables);
            client.ArrayElement6.Subscribe(x => _ArrayElement6 = x).AddTo(_disposables);
            client.ArrayElement7.Subscribe(x => _ArrayElement7 = x).AddTo(_disposables);
            _ArrayElement8 = client.ArrayElement8.Select(x =>
            {
                var internalElement = new Emulate_ITestSampleState();
                internalElement.InitData(x, storage);
                return internalElement;
            }
            ).ToArray();
        }

        public void InitData(ITestArrayState data, ChangeStorage storage)
        {
            ArrayElement = data.ArrayElement;
            ArrayElement1 = data.ArrayElement1;
            ArrayElement2 = data.ArrayElement2;
            ArrayElement3 = data.ArrayElement3;
            ArrayElement4 = data.ArrayElement4;
            ArrayElement5 = data.ArrayElement5;
            ArrayElement6 = data.ArrayElement6;
            ArrayElement7 = data.ArrayElement7;
            _ArrayElement8 = data.ArrayElement8.Select(x =>
            {
                var internalElement = new Emulate_ITestSampleState();
                internalElement.InitData(x, storage);
                return internalElement;
            }
            ).ToArray();
        }

        #region Common

        private String[] _ArrayElement;
        public String[]  ArrayElement
        {
            get => _ArrayElement;
               set
            {
                 var backValue = _ArrayElement;
                _storage.AddBackAction(() => _ArrayElement = backValue);
                _ArrayElement = value;
            }
        }
        private Int32[] _ArrayElement1;
        public Int32[]  ArrayElement1
        {
            get => _ArrayElement1;
               set
            {
                 var backValue = _ArrayElement1;
                _storage.AddBackAction(() => _ArrayElement1 = backValue);
                _ArrayElement1 = value;
            }
        }
        private Int64[] _ArrayElement2;
        public Int64[]  ArrayElement2
        {
            get => _ArrayElement2;
               set
            {
                 var backValue = _ArrayElement2;
                _storage.AddBackAction(() => _ArrayElement2 = backValue);
                _ArrayElement2 = value;
            }
        }
        private Single[] _ArrayElement3;
        public Single[]  ArrayElement3
        {
            get => _ArrayElement3;
               set
            {
                 var backValue = _ArrayElement3;
                _storage.AddBackAction(() => _ArrayElement3 = backValue);
                _ArrayElement3 = value;
            }
        }
        private Double[] _ArrayElement4;
        public Double[]  ArrayElement4
        {
            get => _ArrayElement4;
               set
            {
                 var backValue = _ArrayElement4;
                _storage.AddBackAction(() => _ArrayElement4 = backValue);
                _ArrayElement4 = value;
            }
        }
        private Boolean[] _ArrayElement5;
        public Boolean[]  ArrayElement5
        {
            get => _ArrayElement5;
               set
            {
                 var backValue = _ArrayElement5;
                _storage.AddBackAction(() => _ArrayElement5 = backValue);
                _ArrayElement5 = value;
            }
        }
        private SimpleTestData[] _ArrayElement6;
        public SimpleTestData[]  ArrayElement6
        {
            get => _ArrayElement6;
               set
            {
                 var backValue = _ArrayElement6;
                _storage.AddBackAction(() => _ArrayElement6 = backValue);
                _ArrayElement6 = value;
            }
        }
        private TestEnum[] _ArrayElement7;
        public TestEnum[]  ArrayElement7
        {
            get => _ArrayElement7;
               set
            {
                 var backValue = _ArrayElement7;
                _storage.AddBackAction(() => _ArrayElement7 = backValue);
                _ArrayElement7 = value;
            }
        }

        #endregion

        #region Interface

        ITestSampleStateEmulate[] ITestArrayStateEmulate.ArrayElement8 => _ArrayElement8;

        #endregion

        #region Internal

        ITestSampleState[] ITestArrayState.ArrayElement8
        {
            get => _ArrayElement8;
        }

        #endregion

        #region Source

        Emulate_ITestSampleState[] _ArrayElement8;

        #endregion

    }
}
