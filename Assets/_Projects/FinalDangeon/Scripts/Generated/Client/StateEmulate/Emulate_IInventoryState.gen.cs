using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;

using MetaLogic.Logic.Static;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
using MetaLogic.Data;
using MetaLogic.Logic.State;
using VetsEngine.MetaLogic.Contracts;

namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IInventoryState : IInventoryStateEmulate, IInventoryState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private InventoryAccessor _accessor;
        public void InitData(IInventoryStateClient client, InventoryAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LD_Items.Init(client.Items, storage);
            LD_Gacha.Init(client.Gacha, storage);
        }


        #region Queries

        public Int64 GetNextUpdate()
        {
            return _accessor.GetNextUpdate();
        }
        public IInventoryStatic StaticStatic => _accessor.Static;

        #endregion

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, Int32> IInventoryStateEmulate.Items => LD_Items;
        IEmulateClientDictionary<Int32, Int64> IInventoryStateEmulate.Gacha => LD_Gacha;

        #endregion

        #region Internal

        ILogicDictionary<Int32, Int32> IInventoryState.Items => LD_Items;
        ILogicDictionary<Int32, Int64> IInventoryState.Gacha => LD_Gacha;

        #endregion

        #region Source

        public ValueEmulateDictionary<Int32, Int32> LD_Items { get; } = new ValueEmulateDictionary<Int32, Int32>();
        public ValueEmulateDictionary<Int32, Int64> LD_Gacha { get; } = new ValueEmulateDictionary<Int32, Int64>();

        #endregion

    }
}
