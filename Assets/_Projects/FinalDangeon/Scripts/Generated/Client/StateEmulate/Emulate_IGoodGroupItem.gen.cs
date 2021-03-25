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
    internal class Emulate_IGoodGroupItem : IGoodGroupItemEmulate, IGoodGroupItem 
    , IInitStateData<IGoodGroupItemClient>, IInitStateData<IGoodGroupItem>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IGoodGroupItemClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.CurrentSlots.Subscribe(x =>
            {
                _CurrentSlots = new Emulate_IGoodGroupSlotItem();
                if (x != null)
                {
                    _CurrentSlots.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            client.RefreshNumber.Subscribe(x => _RefreshNumber = x).AddTo(_disposables);
            client.FinishTime.Subscribe(x => _FinishTime = x).AddTo(_disposables);
        }

        public void InitData(IGoodGroupItem data, ChangeStorage storage)
        {
            _storage = storage;
            _CurrentSlots = new Emulate_IGoodGroupSlotItem();
            _CurrentSlots.InitData(data.CurrentSlots, storage);
            RefreshNumber = data.RefreshNumber;
            FinishTime = data.FinishTime;
        }

        #region Common

        private Int32 _RefreshNumber;
        public Int32  RefreshNumber
        {
            get => _RefreshNumber;
               set
            {
                 var backValue = _RefreshNumber;
                _storage.AddBackAction(() => _RefreshNumber = backValue);
                _RefreshNumber = value;
            }
        }
        private Int64 _FinishTime;
        public Int64  FinishTime
        {
            get => _FinishTime;
               set
            {
                 var backValue = _FinishTime;
                _storage.AddBackAction(() => _FinishTime = backValue);
                _FinishTime = value;
            }
        }

        #endregion

        #region Interface

        IGoodGroupSlotItemEmulate IGoodGroupItemEmulate.CurrentSlots => _CurrentSlots;

        #endregion

        #region Internal

        IGoodGroupSlotItem IGoodGroupItem.CurrentSlots
        {
            get => _CurrentSlots;
            set => _CurrentSlots = value as Emulate_IGoodGroupSlotItem;
        }

        #endregion

        #region Source

        Emulate_IGoodGroupSlotItem _CurrentSlots;

        #endregion

    }
}
