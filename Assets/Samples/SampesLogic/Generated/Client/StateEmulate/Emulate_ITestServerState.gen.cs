using System;
using System.Collections.Generic;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ServerElements;
using UniRx;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_ITestServerState : ITestServerStateEmulate, ITestServerState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private TestServerAccessor _accessor;
        public void InitData(ITestServerStateClient client, TestServerAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            client.TestServerElements.Subscribe(x =>
            {
                _TestServerElements = new Emulate_ITestServerElementsState();
                if (x != null)
                {
                    _TestServerElements.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            client.TestServerArray.Subscribe(x =>
            {
                _TestServerArray = new Emulate_ITestServerArrayState();
                if (x != null)
                {
                    _TestServerArray.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
        }


        #region Queries


        #endregion

        #region Common


        #endregion

        #region Interface

        ITestServerElementsStateEmulate ITestServerStateEmulate.TestServerElements => _TestServerElements;
        ITestServerArrayStateEmulate ITestServerStateEmulate.TestServerArray => _TestServerArray;

        #endregion

        #region Internal

        ITestServerElementsState ITestServerState.TestServerElements
        {
            get => _TestServerElements;
            set => _TestServerElements = value as Emulate_ITestServerElementsState;
        }
        ITestServerArrayState ITestServerState.TestServerArray
        {
            get => _TestServerArray;
            set => _TestServerArray = value as Emulate_ITestServerArrayState;
        }

        #endregion

        #region Source

        Emulate_ITestServerElementsState _TestServerElements;
        Emulate_ITestServerArrayState _TestServerArray;

        #endregion

    }
}
