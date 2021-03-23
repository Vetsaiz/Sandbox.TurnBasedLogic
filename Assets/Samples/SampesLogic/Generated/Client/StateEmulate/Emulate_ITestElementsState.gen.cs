using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using UniRx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestElementsState : ITestElementsStateEmulate, ITestElementsState 
    , IInitStateData<ITestElementsStateClient>, IInitStateData<ITestElementsState>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(ITestElementsStateClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.Element.Subscribe(x => _Element = x).AddTo(_disposables);
            client.Element1.Subscribe(x => _Element1 = x).AddTo(_disposables);
            client.Element2.Subscribe(x => _Element2 = x).AddTo(_disposables);
            client.Element3.Subscribe(x => _Element3 = x).AddTo(_disposables);
            client.Element4.Subscribe(x => _Element4 = x).AddTo(_disposables);
            client.Element5.Subscribe(x => _Element5 = x).AddTo(_disposables);
            client.Element6.Subscribe(x => _Element6 = x).AddTo(_disposables);
            client.Element7.Subscribe(x => _Element7 = x).AddTo(_disposables);
            client.Element8.Subscribe(x =>
            {
                _Element8 = new Emulate_ITestSampleState();
                if (x != null)
                {
                    _Element8.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
        }

        public void InitData(ITestElementsState data, ChangeStorage storage)
        {
            Element = data.Element;
            Element1 = data.Element1;
            Element2 = data.Element2;
            Element3 = data.Element3;
            Element4 = data.Element4;
            Element5 = data.Element5;
            Element6 = data.Element6;
            Element7 = data.Element7;
            _Element8 = new Emulate_ITestSampleState();
            _Element8.InitData(data.Element8, storage);
        }

        #region Common

        private String _Element;
        public String  Element
        {
            get => _Element;
               set
            {
                 var backValue = _Element;
                _storage.AddBackAction(() => _Element = backValue);
                _Element = value;
            }
        }
        private Int32 _Element1;
        public Int32  Element1
        {
            get => _Element1;
               set
            {
                 var backValue = _Element1;
                _storage.AddBackAction(() => _Element1 = backValue);
                _Element1 = value;
            }
        }
        private Int64 _Element2;
        public Int64  Element2
        {
            get => _Element2;
               set
            {
                 var backValue = _Element2;
                _storage.AddBackAction(() => _Element2 = backValue);
                _Element2 = value;
            }
        }
        private Single _Element3;
        public Single  Element3
        {
            get => _Element3;
               set
            {
                 var backValue = _Element3;
                _storage.AddBackAction(() => _Element3 = backValue);
                _Element3 = value;
            }
        }
        private Double _Element4;
        public Double  Element4
        {
            get => _Element4;
               set
            {
                 var backValue = _Element4;
                _storage.AddBackAction(() => _Element4 = backValue);
                _Element4 = value;
            }
        }
        private Boolean _Element5;
        public Boolean  Element5
        {
            get => _Element5;
               set
            {
                 var backValue = _Element5;
                _storage.AddBackAction(() => _Element5 = backValue);
                _Element5 = value;
            }
        }
        private SimpleTestData _Element6;
        public SimpleTestData  Element6
        {
            get => _Element6;
               set
            {
                 var backValue = _Element6;
                _storage.AddBackAction(() => _Element6 = backValue);
                _Element6 = value;
            }
        }
        private TestEnum _Element7;
        public TestEnum  Element7
        {
            get => _Element7;
               set
            {
                 var backValue = _Element7;
                _storage.AddBackAction(() => _Element7 = backValue);
                _Element7 = value;
            }
        }

        #endregion

        #region Interface

        ITestSampleStateEmulate ITestElementsStateEmulate.Element8 => _Element8;

        #endregion

        #region Internal

        ITestSampleState ITestElementsState.Element8
        {
            get => _Element8;
            set => _Element8 = value as Emulate_ITestSampleState;
        }

        #endregion

        #region Source

        Emulate_ITestSampleState _Element8;

        #endregion

    }
}
