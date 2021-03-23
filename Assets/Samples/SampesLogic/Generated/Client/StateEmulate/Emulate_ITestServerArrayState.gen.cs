using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestServerArrayState : ITestServerArrayStateEmulate, ITestServerArrayState 
    , IInitStateData<ITestServerArrayStateClient>, IInitStateData<ITestServerArrayState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestServerArrayStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.ArrayServerElement.Subscribe(x => _ArrayServerElement = x).AddTo(_disposables);
            client.ArrayServerElement1.Subscribe(x => _ArrayServerElement1 = x).AddTo(_disposables);
            client.ArrayServerElement2.Subscribe(x => _ArrayServerElement2 = x).AddTo(_disposables);
            client.ArrayServerElement3.Subscribe(x => _ArrayServerElement3 = x).AddTo(_disposables);
            client.ArrayServerElement4.Subscribe(x => _ArrayServerElement4 = x).AddTo(_disposables);
            client.ArrayServerElement5.Subscribe(x => _ArrayServerElement5 = x).AddTo(_disposables);
            client.ArrayServerElement6.Subscribe(x => _ArrayServerElement6 = x).AddTo(_disposables);
            client.ArrayServerElement7.Subscribe(x => _ArrayServerElement7 = x).AddTo(_disposables);
        }

        public void InitData(ITestServerArrayState data, ChangeStorage storage)
        {
            ArrayServerElement = data.ArrayServerElement;
            ArrayServerElement1 = data.ArrayServerElement1;
            ArrayServerElement2 = data.ArrayServerElement2;
            ArrayServerElement3 = data.ArrayServerElement3;
            ArrayServerElement4 = data.ArrayServerElement4;
            ArrayServerElement5 = data.ArrayServerElement5;
            ArrayServerElement6 = data.ArrayServerElement6;
            ArrayServerElement7 = data.ArrayServerElement7;
        }

        #region Common

        private String[] _ArrayServerElement;
        public String[]  ArrayServerElement
        {
            get => _ArrayServerElement;
               set
            {
                 var backValue = _ArrayServerElement;
                _storage.AddBackAction(() => _ArrayServerElement = backValue);
                _ArrayServerElement = value;
            }
        }
        private Int32[] _ArrayServerElement1;
        public Int32[]  ArrayServerElement1
        {
            get => _ArrayServerElement1;
               set
            {
                 var backValue = _ArrayServerElement1;
                _storage.AddBackAction(() => _ArrayServerElement1 = backValue);
                _ArrayServerElement1 = value;
            }
        }
        private Int64[] _ArrayServerElement2;
        public Int64[]  ArrayServerElement2
        {
            get => _ArrayServerElement2;
               set
            {
                 var backValue = _ArrayServerElement2;
                _storage.AddBackAction(() => _ArrayServerElement2 = backValue);
                _ArrayServerElement2 = value;
            }
        }
        private Single[] _ArrayServerElement3;
        public Single[]  ArrayServerElement3
        {
            get => _ArrayServerElement3;
               set
            {
                 var backValue = _ArrayServerElement3;
                _storage.AddBackAction(() => _ArrayServerElement3 = backValue);
                _ArrayServerElement3 = value;
            }
        }
        private Double[] _ArrayServerElement4;
        public Double[]  ArrayServerElement4
        {
            get => _ArrayServerElement4;
               set
            {
                 var backValue = _ArrayServerElement4;
                _storage.AddBackAction(() => _ArrayServerElement4 = backValue);
                _ArrayServerElement4 = value;
            }
        }
        private Boolean[] _ArrayServerElement5;
        public Boolean[]  ArrayServerElement5
        {
            get => _ArrayServerElement5;
               set
            {
                 var backValue = _ArrayServerElement5;
                _storage.AddBackAction(() => _ArrayServerElement5 = backValue);
                _ArrayServerElement5 = value;
            }
        }
        private SimpleTestData[] _ArrayServerElement6;
        public SimpleTestData[]  ArrayServerElement6
        {
            get => _ArrayServerElement6;
               set
            {
                 var backValue = _ArrayServerElement6;
                _storage.AddBackAction(() => _ArrayServerElement6 = backValue);
                _ArrayServerElement6 = value;
            }
        }
        private TestEnum[] _ArrayServerElement7;
        public TestEnum[]  ArrayServerElement7
        {
            get => _ArrayServerElement7;
               set
            {
                 var backValue = _ArrayServerElement7;
                _storage.AddBackAction(() => _ArrayServerElement7 = backValue);
                _ArrayServerElement7 = value;
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
