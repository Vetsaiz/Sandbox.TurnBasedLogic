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
    internal class Emulate_IGoodGroupSlotItem : IGoodGroupSlotItemEmulate, IGoodGroupSlotItem 
    , IInitStateData<IGoodGroupSlotItemClient>, IInitStateData<IGoodGroupSlotItem>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IGoodGroupSlotItemClient client, ChangeStorage storage)
        {
            _storage = storage;
            _Value = client.Value.Select(x =>
            {
                var internalElement = new Emulate_IGoodSlotItem();
                internalElement.InitData(x, storage);
                return internalElement;
            }
            ).ToArray();
        }

        public void InitData(IGoodGroupSlotItem data, ChangeStorage storage)
        {
            _storage = storage;
            _Value = data.Value.Select(x =>
            {
                var internalElement = new Emulate_IGoodSlotItem();
                internalElement.InitData(x, storage);
                return internalElement;
            }
            ).ToArray();
        }

        #region Common


        #endregion

        #region Interface

        IGoodSlotItemEmulate[] IGoodGroupSlotItemEmulate.Value => _Value;

        #endregion

        #region Internal

        IGoodSlotItem[] IGoodGroupSlotItem.Value
        {
            get => _Value;
        }

        #endregion

        #region Source

        Emulate_IGoodSlotItem[] _Value;

        #endregion

    }
}
