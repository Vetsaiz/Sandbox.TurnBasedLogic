using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IShopState : IShopStateClient, IShopState 
    {
        private ChangeStorage _storage;
        private string DataId = "shopState";
        private ShopAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, ShopAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LD_Groups?.Init($"{DataId}.good_groups", storage, _Groups);
            LD_Offers?.Init($"{DataId}.offers", storage, _Offers);
            LD_Transactions?.Init($"{DataId}.transactions", storage, _Transactions);
        }
        public void PreSave()
        {
            foreach (var temp in LD_Groups.Source)
            {
                temp.Value.PreSave();
            }
            _Groups = LD_Groups.Source;
            foreach (var temp in LD_Offers.Source)
            {
                temp.Value.PreSave();
            }
            _Offers = LD_Offers.Source;
            _Transactions = LD_Transactions.Source;
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

        #region Interface

        IReadOnlyReactiveDictionary<Int32, IGoodGroupItemClient> IShopStateClient.Groups => LD_Groups.Interface;
        public IReadOnlyReactiveProperty<IGoodGroupItemClient> GetGroupsProperty(Int32 key)
        {
            return LD_Groups.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, IGoodSlotItemClient> IShopStateClient.Offers => LD_Offers.Interface;
        public IReadOnlyReactiveProperty<IGoodSlotItemClient> GetOffersProperty(Int32 key)
        {
            return LD_Offers.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<String, PaymentProgress> IShopStateClient.Transactions => LD_Transactions.Interface;
        public IReadOnlyReactiveProperty<PaymentProgress?> GetTransactionsProperty(String key)
        {
            return LD_Transactions.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("good_groups")]
        public Dictionary<string, Internal_IGoodGroupItem> _Groups = new Dictionary<string, Internal_IGoodGroupItem>();
        private InternalLogicDictionary<Int32, Internal_IGoodGroupItem, IGoodGroupItem, IGoodGroupItemClient> LD_Groups = new InternalLogicDictionary<Int32, Internal_IGoodGroupItem, IGoodGroupItem, IGoodGroupItemClient>();
        [JsonName("offers")]
        public Dictionary<string, Internal_IGoodSlotItem> _Offers = new Dictionary<string, Internal_IGoodSlotItem>();
        private InternalLogicDictionary<Int32, Internal_IGoodSlotItem, IGoodSlotItem, IGoodSlotItemClient> LD_Offers = new InternalLogicDictionary<Int32, Internal_IGoodSlotItem, IGoodSlotItem, IGoodSlotItemClient>();
        [JsonName("transactions")]
        public Dictionary<string, PaymentProgress> _Transactions = new Dictionary<string, PaymentProgress>();
        private StructLogicDictionary<String, PaymentProgress> LD_Transactions = new StructLogicDictionary<String, PaymentProgress>();

        #endregion

        #region Source

        ILogicDictionary<Int32, IGoodGroupItem> IShopState.Groups
        {
            get => LD_Groups;
        }
        ILogicDictionary<Int32, IGoodSlotItem> IShopState.Offers
        {
            get => LD_Offers;
        }
        ILogicDictionary<String, PaymentProgress> IShopState.Transactions
        {
            get => LD_Transactions;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_Groups.ToString();
            result += LD_Offers.ToString();
            result += LD_Transactions.ToString();
            return result;
        }

        #endregion

    }
}
