using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;

using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IBuffBattleData : IBuffBattleDataEmulate, IBuffBattleData 
    , IInitStateData<IBuffBattleDataClient>, IInitStateData<IBuffBattleData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IBuffBattleDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.CountStack.Subscribe(x => _CountStack = x).AddTo(_disposables);
            client.NeededRemove.Subscribe(x => _NeededRemove = x).AddTo(_disposables);
            OwnerId = client.OwnerId;
        }

        public void InitData(IBuffBattleData data, ChangeStorage storage)
        {
            _storage = storage;
            CountStack = data.CountStack;
            NeededRemove = data.NeededRemove;
            OwnerId = data.OwnerId;
        }

        #region Common

        private Int32 _CountStack;
        public Int32  CountStack
        {
            get => _CountStack;
               set
            {
                 var backValue = _CountStack;
                _storage.AddBackAction(() => _CountStack = backValue);
                _CountStack = value;
            }
        }
        private Boolean _NeededRemove;
        public Boolean  NeededRemove
        {
            get => _NeededRemove;
               set
            {
                 var backValue = _NeededRemove;
                _storage.AddBackAction(() => _NeededRemove = backValue);
                _NeededRemove = value;
            }
        }
        public Int32 OwnerId { get; private set; }

        #endregion

        #region Interface


        #endregion

        #region Internal


        #endregion

        #region Source


        #endregion

    }
}
