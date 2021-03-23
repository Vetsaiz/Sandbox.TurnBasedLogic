using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ServerElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestServerElementsState : ITestServerElementsStateEmulate, ITestServerElementsState 
    , IInitStateData<ITestServerElementsStateClient>, IInitStateData<ITestServerElementsState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestServerElementsStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.ServerElement.Subscribe(x => _ServerElement = x).AddTo(_disposables);
            client.ServerElement1.Subscribe(x => _ServerElement1 = x).AddTo(_disposables);
            client.ServerElement2.Subscribe(x => _ServerElement2 = x).AddTo(_disposables);
            client.ServerElement3.Subscribe(x => _ServerElement3 = x).AddTo(_disposables);
            client.ServerElement4.Subscribe(x => _ServerElement4 = x).AddTo(_disposables);
            client.ServerElement5.Subscribe(x => _ServerElement5 = x).AddTo(_disposables);
            client.ServerElement6.Subscribe(x => _ServerElement6 = x).AddTo(_disposables);
            client.ServerElement7.Subscribe(x => _ServerElement7 = x).AddTo(_disposables);
        }

        public void InitData(ITestServerElementsState data, ChangeStorage storage)
        {
            ServerElement = data.ServerElement;
            ServerElement1 = data.ServerElement1;
            ServerElement2 = data.ServerElement2;
            ServerElement3 = data.ServerElement3;
            ServerElement4 = data.ServerElement4;
            ServerElement5 = data.ServerElement5;
            ServerElement6 = data.ServerElement6;
            ServerElement7 = data.ServerElement7;
        }

        #region Common

        private String _ServerElement;
        public String  ServerElement
        {
            get => _ServerElement;
               set
            {
                 var backValue = _ServerElement;
                _storage.AddBackAction(() => _ServerElement = backValue);
                _ServerElement = value;
            }
        }
        private Int32 _ServerElement1;
        public Int32  ServerElement1
        {
            get => _ServerElement1;
               set
            {
                 var backValue = _ServerElement1;
                _storage.AddBackAction(() => _ServerElement1 = backValue);
                _ServerElement1 = value;
            }
        }
        private Int64 _ServerElement2;
        public Int64  ServerElement2
        {
            get => _ServerElement2;
               set
            {
                 var backValue = _ServerElement2;
                _storage.AddBackAction(() => _ServerElement2 = backValue);
                _ServerElement2 = value;
            }
        }
        private Single _ServerElement3;
        public Single  ServerElement3
        {
            get => _ServerElement3;
               set
            {
                 var backValue = _ServerElement3;
                _storage.AddBackAction(() => _ServerElement3 = backValue);
                _ServerElement3 = value;
            }
        }
        private Double _ServerElement4;
        public Double  ServerElement4
        {
            get => _ServerElement4;
               set
            {
                 var backValue = _ServerElement4;
                _storage.AddBackAction(() => _ServerElement4 = backValue);
                _ServerElement4 = value;
            }
        }
        private Boolean _ServerElement5;
        public Boolean  ServerElement5
        {
            get => _ServerElement5;
               set
            {
                 var backValue = _ServerElement5;
                _storage.AddBackAction(() => _ServerElement5 = backValue);
                _ServerElement5 = value;
            }
        }
        private SimpleTestData _ServerElement6;
        public SimpleTestData  ServerElement6
        {
            get => _ServerElement6;
               set
            {
                 var backValue = _ServerElement6;
                _storage.AddBackAction(() => _ServerElement6 = backValue);
                _ServerElement6 = value;
            }
        }
        private TestEnum _ServerElement7;
        public TestEnum  ServerElement7
        {
            get => _ServerElement7;
               set
            {
                 var backValue = _ServerElement7;
                _storage.AddBackAction(() => _ServerElement7 = backValue);
                _ServerElement7 = value;
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
