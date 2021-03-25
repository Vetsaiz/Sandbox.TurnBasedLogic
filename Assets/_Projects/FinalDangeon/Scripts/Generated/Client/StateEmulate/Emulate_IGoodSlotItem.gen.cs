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
    internal class Emulate_IGoodSlotItem : IGoodSlotItemEmulate, IGoodSlotItem 
    , IInitStateData<IGoodSlotItemClient>, IInitStateData<IGoodSlotItem>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IGoodSlotItemClient client, ChangeStorage storage)
        {
            _storage = storage;
            GoodId = client.GoodId;
            client.IsBuy.Subscribe(x => _IsBuy = x).AddTo(_disposables);
            client.WaitTime.Subscribe(x => _WaitTime = x).AddTo(_disposables);
        }

        public void InitData(IGoodSlotItem data, ChangeStorage storage)
        {
            _storage = storage;
            GoodId = data.GoodId;
            IsBuy = data.IsBuy;
            WaitTime = data.WaitTime;
        }

        #region Common

        public Int32 GoodId { get; private set; }
        private Boolean _IsBuy;
        public Boolean  IsBuy
        {
            get => _IsBuy;
               set
            {
                 var backValue = _IsBuy;
                _storage.AddBackAction(() => _IsBuy = backValue);
                _IsBuy = value;
            }
        }
        private Int64 _WaitTime;
        public Int64  WaitTime
        {
            get => _WaitTime;
               set
            {
                 var backValue = _WaitTime;
                _storage.AddBackAction(() => _WaitTime = backValue);
                _WaitTime = value;
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
