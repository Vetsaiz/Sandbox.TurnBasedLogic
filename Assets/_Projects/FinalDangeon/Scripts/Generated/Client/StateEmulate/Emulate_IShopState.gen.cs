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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IShopState : IShopStateEmulate, IShopState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private ShopAccessor _accessor;
        public void InitData(IShopStateClient client, ShopAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LD_Groups.Init(client.Groups, storage);
            LD_Offers.Init(client.Offers, storage);
            LD_Transactions.Init(client.Transactions, storage);
        }


        #region Queries

        public IGoodSlotItemClient GetSlot(System.Int32 groupId, System.Int32 slotId)
        {
            return _accessor.GetSlot(groupId, slotId) as IGoodSlotItemClient;
        }
        public IPrice GetRefreshPrice(System.Int32 groupId)
        {
            return _accessor.GetRefreshPrice(groupId);
        }
        public IShopStatic StaticStatic => _accessor.Static;

        #endregion

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, IGoodGroupItemEmulate> IShopStateEmulate.Groups => LD_Groups;
        IEmulateClientDictionary<Int32, IGoodSlotItemEmulate> IShopStateEmulate.Offers => LD_Offers;
        IEmulateClientDictionary<String, PaymentProgress> IShopStateEmulate.Transactions => LD_Transactions;

        #endregion

        #region Internal

        ILogicDictionary<Int32, IGoodGroupItem> IShopState.Groups => LD_Groups;
        ILogicDictionary<Int32, IGoodSlotItem> IShopState.Offers => LD_Offers;
        ILogicDictionary<String, PaymentProgress> IShopState.Transactions => LD_Transactions;

        #endregion

        #region Source

        public InternalEmulateDictionary<Int32,Emulate_IGoodGroupItem, IGoodGroupItem, IGoodGroupItemEmulate> LD_Groups { get; } = new InternalEmulateDictionary<Int32,Emulate_IGoodGroupItem, IGoodGroupItem, IGoodGroupItemEmulate>();
        public InternalEmulateDictionary<Int32,Emulate_IGoodSlotItem, IGoodSlotItem, IGoodSlotItemEmulate> LD_Offers { get; } = new InternalEmulateDictionary<Int32,Emulate_IGoodSlotItem, IGoodSlotItem, IGoodSlotItemEmulate>();
        public ValueEmulateDictionary<String, PaymentProgress> LD_Transactions { get; } = new ValueEmulateDictionary<String, PaymentProgress>();

        #endregion

    }
}
